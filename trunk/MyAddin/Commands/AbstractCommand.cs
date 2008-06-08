
using EnvDTE80;
namespace MyAddin.Commands
{
    public abstract class AbstractCommand
    {
        private DTE2 application;
        private string caption;
        private string tooltips;

        public AbstractCommand(DTE2 application, string caption, string tooltips)
        {
            this.application = application;
            this.caption = caption;
            this.tooltips = tooltips;
        }
        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        /// <value>The application.</value>
        public DTE2 Application
        {
            get { return application; }
        }

        ///// <summary>
        ///// Gets the id.
        ///// </summary>
        ///// <value>The id.</value>
        //public System.Guid Id
        //{
        //    get
        //    {
        //        return id;
        //    }
        //}

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return this.GetType().Name; }
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public string Caption
        {
            get
            {
                return caption;
            }
            set
            {
                caption = value;
            }
        }

        /// <summary>
        /// Gets or sets the tooltip text.
        /// </summary>
        /// <value>The tooltip text.</value>
        public string Tooltips
        {
            get
            {
                return tooltips;
            }
            set
            {
                tooltips = value;
            }
        }
        public abstract void act();
    }
}
