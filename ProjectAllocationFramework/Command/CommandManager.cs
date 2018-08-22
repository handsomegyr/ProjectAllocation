using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using ProjectAllocationFramework.Statues;

namespace ProjectAllocationFramework.Command
{
    public class EmptyCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            return true;
        }
    }

    public class CommandManager
    {
        static Dictionary<Type, CommandBase> commandlist = new Dictionary<Type, CommandBase>();
        static CommandBase emptyCommand = new EmptyCommand();

        static CommandManager()
        {
            //LoadCommandFromFile(Assembly.GetExecutingAssembly());
        }

        private static void LoadCommandFromFile(Assembly asm)
        {
            Type[] types = asm.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Type t = types[i];
                if (t.IsSubclassOf(typeof(CommandBase)))
                {
                    CommandBase newCommand = Activator.CreateInstance(t) as CommandBase;
                    if (newCommand != null)
                        RegisteCommand(newCommand);
                }
            }
        }


        public static CommandBase GetCommand(Type t)
        {
            //if (commandlist.ContainsKey(Family))
            //    return commandlist[Family];
            //else
            //{
            //    LoadCommandFromFile(Family.Assembly);
            //    return GetCommand(Family);
            //}

            CommandBase newCommand = Activator.CreateInstance(t) as CommandBase;
            return newCommand;

        }

        private static void RegisteCommand(CommandBase command)
        {
            Type key = command.GetType();
            if (!commandlist.ContainsKey(key))
                commandlist.Add(key, command);
        }
    }

}
