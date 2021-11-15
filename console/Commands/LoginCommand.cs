using Azure.Core;
using Azure.Identity;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace console.Commands
{
    internal sealed class LoginCommand : AsyncCommand<LoginCommand.Settings>
    {
        public sealed class Settings : CommandSettings
        {
            [CommandOption("-c|--application-client-id")]
            [Description("Application ID of user-assigned identity. Required for service principal auth.")]
            public string ClientId { get; set; }

            [CommandOption("-t|--tenant-id")]
            [Description("The Azure Active Directory tenant ID to use for OAuth device interactive login.")]
            public string TenantId { get; set; }

            public override ValidationResult Validate()
            {
                return String.IsNullOrWhiteSpace(ClientId) || String.IsNullOrWhiteSpace(TenantId)
                    ? ValidationResult.Error("Missing required --application-client-id or --tenant-id argument.")
                    : ValidationResult.Success();
            }
        }

        public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
        {
            AnsiConsole.MarkupLine($"[cyan]Authenticating against Azure Service Bus...[/]");

            var tenantId = settings.TenantId;
            var clientId = settings.ClientId;
            var clientSecret = Environment.GetEnvironmentVariable("AZSERVICEBUS_SPA_CLIENT_SECRET");

            // retrieve access token

            if (clientSecret == null)
            {
                AnsiConsole.MarkupLine($"[red]Missing required `AZSERVICEBUS_SPA_CLIENT_SECRET`.[/]");
                Environment.Exit(1);
            }

            AnsiConsole.MarkupLine($"[gray]{clientId}[/]");
            AnsiConsole.MarkupLine($"[gray]{clientSecret.Substring(0, Math.Min(4, clientSecret.Length))}***REDACTED***[/]");

            var credentials = (TokenCredential)new ClientSecretCredential(
                tenantId,
                clientId,
                clientSecret
                );

            var requestContext = new TokenRequestContext(new[] { Constants.AZURE_SERVICE_BUS_AUDIENCE, });
            var token = await credentials.GetTokenAsync(requestContext, CancellationToken.None);

            // persist in credentials store
            // credentials store is limited to 512 bytes

            var credentialStore = Utilities.GetCredentialStore();

            bool succeeded = true;
            var counter = 0;

            foreach (var fragment in token.Token.Split(512)) {

                // TODO: split in the provider

                if (!credentialStore.SetCredentials($"{Constants.AZURE_SERVICE_BUS_AUDIENCE}_{counter:000}", clientId, fragment))
                {
                    succeeded = false;
                    break;
                }

                counter++;
            }

            if (!succeeded)
            {
                AnsiConsole.MarkupLine($"[red]Unable to persist access token to operation system’s credential store.[/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"[white]Azure Service Bus access token saved in operating system’s credential store.[/]");
                AnsiConsole.MarkupLine($"[cyan]Azure Service Bus authentication successful.[/]");
            }

            return 0;
        }
    }

    public static class StringExtensions
    {
        public static IEnumerable<string> Split(this string str, int maxLength)
        {
            int index = 0;
            while (true)
            {
                if (index + maxLength >= str.Length)
                {
                    yield return str.Substring(index);
                    yield break;
                }
                yield return str.Substring(index, maxLength);
                index += maxLength;
            }
        }
    }
}