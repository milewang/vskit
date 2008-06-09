
using System.Collections.Generic;
using System.Reflection;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using MyAddin.Commands;
namespace MyAddin
{
    class MenuManager
    {
        private DTE2 application;
        private Dictionary<string, AbstractCommand> commands = new Dictionary<string, AbstractCommand>();
        private List<CommandBarEvents> menuItemHandlerList = new List<CommandBarEvents>();

        public MenuManager(DTE2 application)
        {
            this.application = application;
        }


        public CommandBarPopup CreatePopupMenu(string commandBarName, string menuName)
        {
            CommandBar commandBar = GetCommandBar(commandBarName);
            int position = commandBar.Controls.Count + 1;
            CommandBarPopup menu = commandBar.Controls.Add(MsoControlType.msoControlPopup, Missing.Value, Missing.Value, position, true) as CommandBarPopup;
            menu.Caption = menuName;
            menu.TooltipText = "";
            return menu;

        }
        public CommandBarPopup CreatePopupMenu(CommandBarPopup popupMenu, string subPopupMenuName, int position)
        {
            CommandBarPopup menu = (CommandBarPopup)popupMenu.Controls.Add(MsoControlType.msoControlPopup, 1, "", position, true);
            menu.Caption = subPopupMenuName;
            menu.TooltipText = "";
            return menu;
        }

        public void AddCommandMenu(CommandBarPopup popupMenu, AbstractCommand command, int position)
        {

            CommandBarControl menuItem = popupMenu.Controls.Add(MsoControlType.msoControlButton, 1, "", position, true);
            menuItem.Tag = command.Name.ToString();
            menuItem.Caption = command.Caption;
            menuItem.TooltipText = command.Tooltips;

            CommandBarEvents events = application.DTE.Events.get_CommandBarEvents(menuItem) as CommandBarEvents;
            events.Click += new _dispCommandBarControlEvents_ClickEventHandler(events_Click);
            menuItemHandlerList.Add(events);

            if (!commands.ContainsKey(command.Caption))
            {
                commands.Add(command.Caption, command);
            }


        }

        void events_Click(object commandBarControl, ref bool Handled, ref bool CancelDefault)
        {
            CommandBarControl control = commandBarControl as CommandBarControl;
            if (commands.ContainsKey(control.Caption))
            {
                commands[control.Caption].act();
            }
        }


        private CommandBar GetCommandBar(string name)
        {
            CommandBars bars = application.DTE.CommandBars as CommandBars;
            return bars[name] as CommandBar;
        }
    }
}
