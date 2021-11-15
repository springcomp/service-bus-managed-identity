using Credentials.Interop;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace console
{
    partial class Utilities
    {
        public static ICredentialStore? GetCredentialStore()
        {
            var assembly = LoadAssembly();

            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(ICredentialStore).IsAssignableFrom(type))
                {
                    var activated = (ICredentialStore)(object)Activator.CreateInstance(type);
                    return activated;
                }
            }

            return null;
        }
        public static Assembly LoadAssembly()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return AssemblyLoader.LoadAssembly("credentials-win64.dll");

            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                throw new NotSupportedException();

            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                throw new NotSupportedException();

            throw new NotSupportedException();
        }
    }
}