using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System.Xml;
using Aras.IOM;
using System;
using Core = Microsoft.Office.Core;
using Common.Properties;



//This add-in is for a SALT excel file.
//It will do the following.
//  1. verify the range for CBP names is in the excel file.  If not end and tell user.
//  2. Get all names of x4_CBP ItemTypes in a List
//  3. Get current row of CPB names in a List
//  4. Update the row of CBP Names.
//  3. Get all the Parameters of the associate document and populate options for each CBP Name.
//      Don't know how to do that yet.
namespace OfficeConnectorExtensionCommon
{

    public partial class OfficeConnectorExtensionAddinRibbon
    {

        private void WorkflowAddinRibbon_load(object sender, RibbonUIEventArgs e)
        {
           
        }

        private void NextState_TextChanged(object sender, RibbonControlEventArgs e)
        {
            PromoteButton.Enabled = !String.IsNullOrEmpty(((RibbonComboBox)sender).Label);
        }
    }

}
