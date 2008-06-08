
using System;
using EnvDTE80;
using MyAddin.Commands.SortCommands;
namespace MyAddin.Commands
{
    public class CommandFactory
    {
        public static AbstractCommand CreateCommand(string name, DTE2 application)
        {
            switch (name)
            {
                case "DateSortCommand":
                    return new DateSortCommand(application);
                case "ExtensionSortCommand":
                    return new ExtensionSortCommand(application);
                default:
                    throw new ArgumentException(String.Format("No command has been found with the following name : '{0}'", name));
            }
        }
    }
}
