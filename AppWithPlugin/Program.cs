using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using console;
using Credentials.Interop;

namespace AppWithPlugin
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 1 && args[0] == "/d")
                {
                    Console.WriteLine("Waiting for any key...");
                    Console.ReadLine();
                }

                string[] pluginPaths = new string[]
                {
                    @"credentials-win64\bin\Debug\netstandard2.1\credentials-win64.dll"
                };

                IEnumerable<Credentials.Interop.ICredentialStore> commands = pluginPaths.SelectMany(pluginPath =>
                {
                    Assembly pluginAssembly = LoadPlugin(pluginPath);
                    return CreateCommands(pluginAssembly);
                }).ToList();

                if (args.Length == 0)
                {
                    Console.WriteLine("Commands: ");
                    foreach (ICredentialStore command in commands)
                    {
                        Console.WriteLine(command.GetType().FullName);
                    }
                }
                else
                {
                    foreach (string commandName in args)
                    {
                        Console.WriteLine($"-- {commandName} --");

                        ICredentialStore command = commands.FirstOrDefault();
                        if (command == null)
                        {
                            Console.WriteLine("No such command is known.");
                            return;
                        }

                        command.RemoveCredentials("http://password");

                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static Assembly LoadPlugin(string relativePath)
        {
            // Navigate up to the solution root
            string root = Path.GetFullPath(Path.Combine(
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(
                            Path.GetDirectoryName(
                                Path.GetDirectoryName(typeof(Program).Assembly.Location)))))));

            string pluginLocation = Path.GetFullPath(Path.Combine(root, relativePath.Replace('\\', Path.DirectorySeparatorChar)));
            Console.WriteLine($"Loading commands from: {pluginLocation}");

            return AssemblyLoader.LoadAssembly(pluginLocation);
            
            var loadContext = new AssemblyLoader(pluginLocation);
            return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
        }

        static IEnumerable<ICredentialStore> CreateCommands(Assembly assembly)
        {
            int count = 0;

            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(ICredentialStore).IsAssignableFrom(type))
                {
                    ICredentialStore result = Activator.CreateInstance(type) as ICredentialStore;
                    if (result != null)
                    {
                        count++;
                        yield return result;
                    }
                }
            }

            if (count == 0)
            {
                string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
                throw new ApplicationException(
                    $"Can't find any type which implements ICommand in {assembly} from {assembly.Location}.\n" +
                    $"Available types: {availableTypes}");
            }
        }
    }
}
