
using System.Text;
using System.Windows.Forms;
using EnvDTE;
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
            //MessageBox.Show("Test");
            //Project[] projects = base.Application.DTE.ActiveSolutionProjects as Project[];
            //StringBuilder builder = new StringBuilder();
            //foreach (SelectedItem item in base.Application.SelectedItems)
            //{
            //    builder.AppendLine(item.GetType() + ":" + item.Name);
            //}
            //MessageBox.Show(builder.ToString());
            UIHierarchy solutionExplorer = base.Application.DTE.Windows.Item(Constants.vsext_wk_SProjectWindow).Object as UIHierarchy;
            SelectedItems items = base.Application.SelectedItems;
            if (null == items || items.Count == 0)
            {
                return;
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                UIHierarchyItems uiItems = solutionExplorer.UIHierarchyItems;
                showNodes(uiItems.Item(1), builder, 0);
                MessageBox.Show(builder.ToString());
                //StringBuilder builder = new StringBuilder();
                //foreach (SelectedItem item in items)
                //{
                //    SelectedItems children = item.Collection;
                //    solutionExplorer.UIHierarchyItems
                //}
                //MessageBox.Show(builder.ToString());
            }
        }

        private void showNodes(UIHierarchyItem item, StringBuilder builder, int leftSpace)
        {
            if (null != item)
            {
                builder.Append(' ', leftSpace);
                builder.AppendLine(item.Name);
                if (item.UIHierarchyItems.Count == 0)
                {
                    return;
                }
                else
                {
                    for (int i = 1; i <= item.UIHierarchyItems.Count; ++i)
                    {
                        showNodes(item.UIHierarchyItems.Item(i), builder, leftSpace + 1);
                    }
                }
            }
        }
    }
}
