using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace console.Commands
{
	internal sealed class LoginCommand : Command<LoginCommand.Settings>
	{
		public sealed class Settings : CommandSettings
		{
			[CommandOption("-c|--application-client-id")]
			[Description("Application ID of user-assigned identity. Required for service principal auth.")]
			public string ClientId { get; set; }

			[CommandOption("-t|--tenant-id")]
			[Description("The Azure Active Directory tenant ID to use for OAuth device interactive login.")]
			public string TenantId { get; set; }
		}

		public override int Execute(CommandContext context, Settings settings)
		{
			AnsiConsole.MarkupLine($"Login: {settings.ClientId}, {settings.TenantId}");
			return 0;
		}
	}
}