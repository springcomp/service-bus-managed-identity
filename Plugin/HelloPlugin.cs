using System;
using Credentials.Interop;

namespace HelloPlugin
{
    public class HelloCommand : ICredentialStore
    {
        public bool RemoveCredentials(string target)
        {
            Console.WriteLine("Hello !!!");
            return true;
        }

        public bool SetCredentials(string target, string username, string password)
        {
            Console.WriteLine("Hello !!!");
            return true;
        }
    }
}
