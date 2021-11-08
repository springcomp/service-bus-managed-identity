using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DetectOSCredentialManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.WriteLine("Hello Beauty!");
                Program.SetCredentials("FOO", "friday", "fr!d@y0", PersistanceType.LocalComputer);
                var userpass = Program.GetCredential("FOO");
                Console.WriteLine($"User: {userpass.Username} Password: {userpass.Password}");
                Program.RemoveCredentials("FOO");
                Debug.Assert(Program.GetCredential("FOO") == null);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Console.WriteLine("Hello Cutie!");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Console.WriteLine("Too Costly!");
            }
        }
    }
}
