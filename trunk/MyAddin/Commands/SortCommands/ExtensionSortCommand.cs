using System;
using EnvDTE80;

namespace MyAddin.Commands.SortCommands
{
    public class ExtensionSortCommand : AbstractCommand
    {
        public ExtensionSortCommand(DTE2 application)
            : base(application, "Sort By Extension", "Sort Items By Extensions")
        {

        }
        public override void act()
        {
            Console.WriteLine("extension sort");
        }
    }
}
