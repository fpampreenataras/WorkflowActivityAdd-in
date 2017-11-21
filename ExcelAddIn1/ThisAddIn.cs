using Excel = Microsoft.Office.Interop.Excel;
using WorkflowAddinCommon;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;

namespace ExcelAddIn1
{
    public partial class ThisAddIn
    {
        private Utilities u = new Utilities();
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Globals.ThisAddIn.Application.WorkbookOpen += new AppEvents_WorkbookOpenEventHandler(Application_WorkbookOpen);
            Globals.ThisAddIn.Application.WorkbookBeforeClose += new AppEvents_WorkbookBeforeCloseEventHandler(Application_WorkbookClose);
            Globals.Ribbons.WorkflowAddinRibbon.CompleteTaskButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(Complete_Task);
            Globals.Ribbons.WorkflowAddinRibbon.RefreshButton.Click += new RibbonControlEventHandler(RefreshButton_Click);
            Globals.Ribbons.WorkflowAddinRibbon.PromoteButton.Click += new RibbonControlEventHandler(Promote_Click);
        }
        private void Promote_Click(object sender, RibbonControlEventArgs e)
        {

            u.Complete_Promote(Globals.ThisAddIn.Application.ActiveWorkbook.CustomDocumentProperties, Globals.Ribbons.WorkflowAddinRibbon);
            u.Refresh_ribbon(Globals.ThisAddIn.Application.ActiveWorkbook.CustomDocumentProperties, Globals.Ribbons.WorkflowAddinRibbon);
          
        }

        private void RefreshButton_Click(object sender, RibbonControlEventArgs e)
        {
           //refresh the workflow and activity like you just opened the file.
            u.Refresh_ribbon(Globals.ThisAddIn.Application.ActiveWorkbook.CustomDocumentProperties, Globals.Ribbons.WorkflowAddinRibbon);
        }

        private void Application_WorkbookClose(Excel.Workbook Wb, ref bool Cancel)
        {
            u.Application_close(Wb.FullName, Globals.Ribbons.WorkflowAddinRibbon);
        }

        private void Application_WorkbookOpen(Excel.Workbook Wb)
        {
          
            u.Refresh_ribbon(Globals.ThisAddIn.Application.ActiveWorkbook.CustomDocumentProperties, Globals.Ribbons.WorkflowAddinRibbon);
        }

        private void Complete_Task(object sender, RibbonControlEventArgs e)
        {
            u.Complete_Activity(Globals.ThisAddIn.Application.ActiveWorkbook.CustomDocumentProperties, Globals.Ribbons.WorkflowAddinRibbon);
            u.Refresh_ribbon(Globals.ThisAddIn.Application.ActiveWorkbook.CustomDocumentProperties, Globals.Ribbons.WorkflowAddinRibbon);
        }


        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion


        protected override Microsoft.Office.Tools.Ribbon.IRibbonExtension[] CreateRibbonObjects()

        {
            return new Microsoft.Office.Tools.Ribbon.IRibbonExtension[] { new WorkflowAddinCommon.WorkflowAddinRibbon(Globals.Factory.GetRibbonFactory()) };

        }


    }
    partial class ThisRibbonCollection : Microsoft.Office.Tools.Ribbon.RibbonReadOnlyCollection

    {

        internal WorkflowAddinCommon.WorkflowAddinRibbon WorkflowAddinRibbon

        {

            get { return this.GetRibbon<WorkflowAddinCommon.WorkflowAddinRibbon>(); }

        }

    }
}
