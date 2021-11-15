using System;
using console;
using console.Commands;
using Spectre.Console.Cli;

namespace AppWithPlugin
{
	class Program
	{
		static int Main(string[] args)
		{
			var app = new CommandApp<LoginCommand>();
			app.Configure(config => {
				config.AddCommand<LoginCommand>("login");
			});
			return app.Run(args);
		}
	}
}
