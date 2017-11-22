using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools.Ribbon;
using OfficeConnectorExtensionCommon;

namespace WordAddIn1
{
    public partial class ThisAddIn
    {
        private Utilities u = new Utilities();
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            //Add these events to trigger when a file is opened/closed and what to do with the 3 buttons in the Ribbon
            Globals.ThisAddIn.Application.DocumentOpen += new Word.ApplicationEvents4_DocumentOpenEventHandler(Application_Open);
            Globals.ThisAddIn.Application.DocumentBeforeClose += new Word.ApplicationEvents4_DocumentBeforeCloseEventHandler(Application_Close);
            Globals.Ribbons.WorkflowAddinRibbon.CompleteTaskButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(Complete_Task);
            Globals.Ribbons.WorkflowAddinRibbon.RefreshButton.Click += new RibbonControlEventHandler(RefreshButton_Click);
            Globals.Ribbons.WorkflowAddinRibbon.PromoteButton.Click += new RibbonControlEventHandler(Promote_Click);
            
        }

        private void Promote_Click(object sender, RibbonControlEventArgs e)
        {

            u.Complete_Promote(Globals.ThisAddIn.Application.ActiveDocument.CustomDocumentProperties, Globals.Ribbons.WorkflowAddinRibbon);
            u.Refresh_ribbon(Globals.ThisAddIn.Application.ActiveDocument.CustomDocumentProperties, Globals.Ribbons.WorkflowAddinRibbon);
       
        }

        private void RefreshButton_Click(object sender, RibbonControlEventArgs e)
        {
            //refresh the workflow/activity/lifecycle/state like the file was just opened.
            u.Refresh_ribbon(Globals.ThisAddIn.Application.ActiveDocument.CustomDocumentProperties, Globals.Ribbons.WorkflowAddinRibbon);
        }

        private void Application_Close(Word.Document Doc, ref bool Cancel)
        {
            u.Application_close(Doc.FullName, Globals.Ribbons.WorkflowAddinRibbon);
        }

        private void Application_Open(Word.Document Doc)
        {
            u.Refresh_ribbon(Doc.CustomDocumentProperties, Globals.Ribbons.WorkflowAddinRibbon);

        }
        private void Complete_Task(object sender, RibbonControlEventArgs e)
        {
            u.Complete_Activity(Globals.ThisAddIn.Application.ActiveDocument.CustomDocumentProperties, Globals.Ribbons.WorkflowAddinRibbon);
            u.Refresh_ribbon(Globals.ThisAddIn.Application.ActiveDocument.CustomDocumentProperties, Globals.Ribbons.WorkflowAddinRibbon);

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
            return new Microsoft.Office.Tools.Ribbon.IRibbonExtension[] { new OfficeConnectorExtensionCommon.OfficeConnectorExtensionAddinRibbon(Globals.Factory.GetRibbonFactory()) };

        }

    }
    partial class ThisRibbonCollection : Microsoft.Office.Tools.Ribbon.RibbonReadOnlyCollection

    {

        internal OfficeConnectorExtensionCommon.OfficeConnectorExtensionAddinRibbon WorkflowAddinRibbon

        {

            get { return this.GetRibbon<OfficeConnectorExtensionCommon.OfficeConnectorExtensionAddinRibbon>(); }

        }

    }
}
