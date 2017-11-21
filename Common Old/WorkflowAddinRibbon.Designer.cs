namespace SharedRibonLibrary
{
    partial class WorkflowAddinRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public WorkflowAddinRibbon(Microsoft.Office.Tools.Ribbon.RibbonFactory factory)
            : base(factory)
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.tab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // WorkflowAddinRibbon
            // 
            this.Name = "WorkflowAddinRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook, Microsoft.PowerPoint.Presentation, Microsoft.Project.Pr" +
    "oject, Microsoft.Visio.Drawing, Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.WorkflowAddinRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
    }

    //partial class ThisRibbonCollection
    //{
    //    internal WorkflowAddinRibbon WorkflowAddinRibbon
    //    {
    //        get { return this.GetRibbon<WorkflowAddinRibbon>(); }
    //    }
    //}
}
