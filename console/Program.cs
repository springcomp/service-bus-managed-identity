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
            var credentialStore = Utilities.GetCredentialStore();
            credentialStore.SetCredentials("https://target.com", "maxime", "password");
            Environment.Exit(43);
        }
    }
}
