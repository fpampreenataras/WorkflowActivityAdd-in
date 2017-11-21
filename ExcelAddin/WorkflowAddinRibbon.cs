using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Excel;
using AU = ArasUtilities;



//This add-in is for a SALT excel file.
//It will do the following.
//  1. verify the range for CBP names is in the excel file.  If not end and tell user.
//  2. Get all names of x4_CBP ItemTypes in a List
//  3. Get current row of CPB names in a List
//  4. Update the row of CBP Names.
//  3. Get all the Parameters of the associate document and populate options for each CBP Name.
//      Don't know how to do that yet.
namespace WorkflowExelAddin
{

    public partial class WorkflowAddinRibbon
    {
      
        private void WorkflowAddinRibbon_load(object sender, RibbonUIEventArgs e)
        {
            //login to innovator somehow.  Using windows authentication for now
         

           //add the event to catch loading a new file form Aras so that we can get the files workflow and activity names
           
            Globals.WorkflowAddin.Application.WorkbookOpen += new AppEvents_WorkbookOpenEventHandler(Application_WorkbookOpen);
            Globals.WorkflowAddin.Application.WorkbookBeforeClose += new AppEvents_WorkbookBeforeCloseEventHandler(Application_WorkbookClose);
            CompleteTaskButton.Enabled = false;
            
        }


        //populate workflow and activity
        void Application_WorkbookOpen(Workbook Wb)
        {
            (new AU.Utilities()).Application_open(Wb.CustomDocumentProperties, CompleteTaskButton, WorkflowNameRibbonLabel, ActivityRibbonLabel);

        }

        private void Application_WorkbookClose(Workbook Wb, ref bool Cancel)
        {
            if (!Wb.FullName.Contains("mso_viablecopy"))  // hack to get around office connector opening and closing document when doing a Save to Aras
            {
                WorkflowNameRibbonLabel.Label = "";
                ActivityRibbonLabel.Label = "";
            }
        }
        private void Complete_Activity_click(object sender, RibbonControlEventArgs e)
        {

            (new AU.Utilities()).Complete_Activity(Globals.WorkflowAddin.Application.ActiveWorkbook.CustomDocumentProperties, CompleteTaskButton, WorkflowNameRibbonLabel, ActivityRibbonLabel);

        }

    

    
    }

}
