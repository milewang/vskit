
using System;
using EnvDTE80;
namespace MyAddin.Commands.SortCommands
{
    public class DateSortCommand : AbstractCommand
    {
        public DateSortCommand(DTE2 application)
            : base(application, "Sort By Date", "Sort Items By Date")
        {

        }
        public override void act()
        {
            Console.WriteLine("date sort");
        }
    }
}
