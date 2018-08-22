using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ProjectAllocationFramework
{
    public class ApplicationDispatcher
    {
        public static void  Dispatch(string assemblyName, string[] parameters){

            try
            {
                if (assemblyName.EndsWith(".exe"))
                {
                    ExeDispatch(assemblyName, parameters);
                }else{
                    if (assemblyName.EndsWith(".dll"))
                    {
                        DllDispatch(assemblyName, parameters);
                    }
                }
              
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        
        }

        private static void DllDispatch(string assemblyName, string[] parameters)
        {
            IEntry instance = GetInstance(assemblyName, parameters);
            if (instance != null)
            {
            }
        }

        public static IEntry GetInstance(string assemblyName, string[] parameters)
        {
            if (File.Exists(assemblyName))
            {
                Assembly assembly = Assembly.LoadFrom(assemblyName);
                System.Type[] types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.GetInterface("IEntry") != null)
                    {
                        IEntry instance = Activator.CreateInstance(type) as IEntry;
                        return instance;
                    }
                }

            }
            return null;
        }


        private static void ExeDispatch(string assemblyName, string[] parameters)
        {
            string arguments = string.Empty;
            foreach (var item in parameters)
	        {
                arguments = arguments + " " + item;
	        }
            Process p = new Process();
            p.StartInfo.FileName = assemblyName;
            p.StartInfo.Arguments = arguments;
            p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            p.Start();
            p.WaitForExit();
        }
    }
}
