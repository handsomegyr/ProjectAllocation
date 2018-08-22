using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Resources;

namespace ProjectAllocationResource
{
    /// <summary>
    /// Helper class to load resources strings.
    /// </summary>
    public static class ResourceLoader
    {
        /// <summary>
        /// Load a resource string.
        /// </summary>
        /// <param name="baseName">The base name of the resource.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <returns>The string from the resource.</returns>
        public static string LoadString(string resourceName)
        {
            object value = LoadObject(resourceName);
            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                return value.ToString();
            }
        }
        
        public static object LoadObject(string resourceName)
        {
            return LoadObject(resourceName, Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// Load a resource object.
        /// </summary>
        /// <param name="baseName">The base name of the resource.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <param name="asm">The assembly to load the resource from.</param>
        /// <returns>The string from the resource.</returns>
        public static object LoadObject(string resourceName, Assembly asm)
        {
            if (string.IsNullOrEmpty(resourceName)) throw new ArgumentNullException("resourceName");
            if (asm == null) asm = Assembly.GetCallingAssembly();

            object value = null;
            if (null == value && null != asm) value = SearchForResource(asm, resourceName);
            if (null == value) value = SearchForResource(Assembly.GetExecutingAssembly(), resourceName);
         
            return value;
        }

        private static object SearchForResource(Assembly asm, string resourceName)
        {
            string[] resources = asm.GetManifestResourceNames();

            foreach (string resource in resources)
            {
                // Remove additional .resource token
                const string token = ".resources";
                string resourceToUse = resource;
                if (resource.EndsWith(token))
                {
                    resourceToUse = resource.Replace(token, string.Empty);
                }

                object result = LoadAssemblyResource(asm, resourceToUse, resourceName);

                if (result != null)
                {
                    return result;
                }
                
            }

            return null;
        }

        private static object LoadAssemblyResource(Assembly asm, string baseName, string resourceName)
        {
            try
            {
                ResourceManager rm = new ResourceManager(baseName, asm);
                return rm.GetObject(resourceName);
            }
            catch (MissingManifestResourceException)
            {
            }
            return null;
        }
    }
}
