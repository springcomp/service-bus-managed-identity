using Azure.Core;
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Spectre.Console;

if (args.Length == 0)
{
	Console.WriteLine("Please, specify a topic name.");
	Environment.Exit(42);
}

var topicName = args[0];

// See https://aka.ms/new-console-template for more information

var configuration = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.AddUserSecrets<Program>()
			.Build()
			;

var clientId = configuration.GetValue<string>("service-principals:sample-app:client-id");
var tenantId = configuration.GetValue<string>("service-principals:sample-app:tenant-id");
var clientSecret = configuration.GetValue<string>("service-principals:sample-app:client-secret");
var serviceBusNamespace = configuration.GetValue<string>("service-bus-namespaces:sample:qualified-name");

AnsiConsole.MarkupLine($"[gray]{clientId}[/]");
AnsiConsole.MarkupLine($"[gray]{clientSecret.Substring(0, 4)}***REDACTED***[/]");

var credentials = (TokenCredential) new ClientSecretCredential(
	tenantId,
	clientId,
	clientSecret
	);

var context = new TokenRequestContext(new []{ "https://servicebus.azure.net/.default",});
var token = await credentials.GetTokenAsync(context, CancellationToken.None);

Console.WriteLine(token);
credentials = new SecretStoreCredential(token);

var client = new ServiceBusClient(serviceBusNamespace, credentials);
var sender = client.CreateSender(topicName);
try
{
	AnsiConsole.Markup($"[cyan]Sending message to [underline]{topicName}[/]... [/]");

	await sender.SendMessageAsync(
		new ServiceBusMessage("Hello, world!"),
		CancellationToken.None
		);

	AnsiConsole.MarkupLine("[green]Done.[/]");
}
catch (ServiceBusException e)
{
	AnsiConsole.MarkupLine("");
	AnsiConsole.MarkupLine($"[underline red]{e.Message}[/]");
}
catch (TaskCanceledException e)
{
	AnsiConsole.MarkupLine("");
	AnsiConsole.WriteException(e);
}
catch (Exception e)
{
	AnsiConsole.MarkupLine("");
	AnsiConsole.WriteException(e);
}

public sealed class SecretStoreCredential : TokenCredential
{
	private readonly AccessToken token_;
	public SecretStoreCredential(AccessToken token)
	{
		token_ = token;
	}

	public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
	{
		return token_;
	}

	public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
	{
		return new ValueTask<AccessToken>(Task.FromResult(token_));
	}
}