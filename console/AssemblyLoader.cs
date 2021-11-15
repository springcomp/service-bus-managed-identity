using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace console
{
    public class AssemblyLoader : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver resolver_;

        public static Assembly LoadAssembly(string name)
        {
            var directory = Path.GetDirectoryName(typeof(AssemblyLoader).Assembly.Location);
            if (directory == null) throw new NotSupportedException();

            var path = Path.Combine(directory, name);

            path = @"C:\Projects\springcomp\plugins\credentials-win64\bin\Debug\netstandard2.1\credentials-win64.dll";
            path = @"C:\Projects\springcomp\plugins\AppWithPlugin\bin\Debug\netcoreapp3.1\credentials-win64.dll";

            var loadContext = new AssemblyLoader(path);
            return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(path)));
        }

        public AssemblyLoader(string pluginPath)
        {
            resolver_ = new AssemblyDependencyResolver(pluginPath);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            string assemblyPath = resolver_.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath != null)
            {
                return LoadFromAssemblyPath(assemblyPath);
            }

            return null;
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            string libraryPath = resolver_.ResolveUnmanagedDllToPath(unmanagedDllName);
            if (libraryPath != null)
            {
                return LoadUnmanagedDllFromPath(libraryPath);
            }

            return IntPtr.Zero;
        }
    }
}
