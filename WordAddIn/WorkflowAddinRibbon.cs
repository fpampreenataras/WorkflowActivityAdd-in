using Microsoft.Office.Tools.Ribbon;
using Core = Microsoft.Office.Core;
using Aras.IOM;
using AU = ArasUtilities;
//using MyWord = Microsoft.Office.Interop.Word;
using Settings = WorkflowWordAddIn.Properties.Settings;
using System;
using Microsoft.Office.Interop.Word;

namespace WordAddIn
{
    public partial class WorkflowAddinRibbon
    {
        private void WorkflowAddinRibbon_Load(object sender, RibbonUIEventArgs e)
        {
           
            //add the event to catch loading a new file form Aras so that we can get the files workflow and activity names
            Globals.WorkflowAddin.Application.DocumentOpen += new ApplicationEvents4_DocumentOpenEventHandler(Application_DocumentOpen);
            Globals.WorkflowAddin.Application.DocumentBeforeClose += new ApplicationEvents4_DocumentBeforeCloseEventHandler(Application_DocumentBeforeClose);
            CompleteTaskButton.Enabled = false;
        }
        
        private void Application_DocumentOpen(Document Doc)
        {
            (new AU.Utilities()).Application_open(Doc.CustomDocumentProperties, CompleteTaskButton, WorkflowNameRibbonLabel, ActivityRibbonLabel);
        }

        private void Application_DocumentBeforeClose(Document Doc, ref bool Cancel)
        {
            if (!Doc.FullName.Contains("mso_viablecopy"))  // hack to get around office connector opening and closing document when doing a Save to Aras
            {
                WorkflowNameRibbonLabel.Label = "";
                ActivityRibbonLabel.Label = "";
            }
        }

        private void Complete_Activity_click(object sender, RibbonControlEventArgs e)
        {

            (new AU.Utilities()).Complete_Activity(Globals.WorkflowAddin.Application.ActiveDocument.CustomDocumentProperties, CompleteTaskButton, WorkflowNameRibbonLabel, ActivityRibbonLabel);
        
        }
    }
}
