using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using EnvDTE;
using EnvDTE80;
using Extensibility;
using Microsoft.VisualStudio.CommandBars;
using MyAddin.Commands;

namespace MyAddin
{
    /// <summary>The object for implementing an Add-in.</summary>
    /// <seealso class='IDTExtensibility2' />
    public class Connect : IDTExtensibility2, IDTCommandTarget
    {
        private DTE2 applicationObject;
        private AddIn addInInstance;
        private MenuManager menuManager = null;
        private ResourceManager rm = new ResourceManager("MyAddin.CommandBar", Assembly.GetExecutingAssembly());
        private Dictionary<string, AbstractCommand> commands = new Dictionary<string, AbstractCommand>();
        /// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
        public Connect()
        {
        }

        /// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
        /// <param term='application'>Root object of the host application.</param>
        /// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
        /// <param term='addInInst'>Object representing this Add-in.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            this.applicationObject = application as DTE2;
            this.addInInstance = addInInst as AddIn;
            this.menuManager = new MenuManager(this.applicationObject);

            this.commands.Add("DateSortCommand", CommandFactory.CreateCommand("DateSortCommand", this.applicationObject));
            this.commands.Add("ExtensionSortCommand", CommandFactory.CreateCommand("ExtensionSortCommand", this.applicationObject));

            string caption = rm.GetString("SortMenuCaption");
            CommandBarPopup popup = menuManager.CreatePopupMenu("Solution", caption);
            menuManager.AddCommandMenu(popup, commands["DateSortCommand"], 1);
            menuManager.AddCommandMenu(popup, commands["ExtensionSortCommand"], 2);

            popup = menuManager.CreatePopupMenu("Project", caption);
            menuManager.AddCommandMenu(popup, commands["DateSortCommand"], 1);
            menuManager.AddCommandMenu(popup, commands["ExtensionSortCommand"], 2);

            popup = menuManager.CreatePopupMenu("Folder", caption);
            menuManager.AddCommandMenu(popup, commands["DateSortCommand"], 1);
            menuManager.AddCommandMenu(popup, commands["ExtensionSortCommand"], 2);


        }


        /// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
        /// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
        {
        }

        /// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />		
        public void OnAddInsUpdate(ref Array custom)
        {
        }

        /// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnStartupComplete(ref Array custom)
        {
        }

        /// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnBeginShutdown(ref Array custom)
        {
        }

        /// <summary>Implements the QueryStatus method of the IDTCommandTarget interface. This is called when the command's availability is updated</summary>
        /// <param term='commandName'>The name of the command to determine state for.</param>
        /// <param term='neededText'>Text that is needed for the command.</param>
        /// <param term='status'>The state of the command in the user interface.</param>
        /// <param term='commandText'>Text requested by the neededText parameter.</param>
        /// <seealso class='Exec' />
        public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
        {
            if (neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
            {
                if (commandName == "MyAddin.Connect.MyAddin")
                {
                    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    return;
                }
            }
        }

        /// <summary>Implements the Exec method of the IDTCommandTarget interface. This is called when the command is invoked.</summary>
        /// <param term='commandName'>The name of the command to execute.</param>
        /// <param term='executeOption'>Describes how the command should be run.</param>
        /// <param term='varIn'>Parameters passed from the caller to the command handler.</param>
        /// <param term='varOut'>Parameters passed from the command handler to the caller.</param>
        /// <param term='handled'>Informs the caller if the command was handled or not.</param>
        /// <seealso class='Exec' />
        public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
        {
            handled = false;
            if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
            {
                if (commandName == "MyAddin.Connect.MyAddin")
                {
                    handled = true;
                    return;
                }
            }
        }
    }
}