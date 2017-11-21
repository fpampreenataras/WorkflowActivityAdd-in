using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aras.IOM;
using System.Xml;
using Forms = System.Windows.Forms;
using Core = Microsoft.Office.Core;
using MyExcel = Microsoft.Office.Interop.Excel;
using MyWord = Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools.Ribbon;
using SharedRibonLibrary.Properties;

namespace SharedRibonLibrary
{
    public class Utilities
    {
        Innovator inn;

        public Innovator Connect_to_Aras
        {
            get
            {
                string url = "";
                string db = "";
                string windowauth = "";
                //string user = "";
                XmlDocument config = new XmlDocument();
                string path = Environment.GetEnvironmentVariable("Appdata") + "\\OfficeConnector\\config.xml";
                if (System.IO.File.Exists(path))
                {
                    config.Load(path);
                    url = config.ChildNodes[0].FirstChild.Attributes[0].Value;
                    db = config.ChildNodes[0].FirstChild.Attributes[1].Value;
                    windowauth = config.ChildNodes[0].FirstChild.Attributes[3].Value;
                    if (windowauth == "True")
                    {
                        WinAuthHttpServerConnection winnconn = IomFactory.CreateWinAuthHttpServerConnection(url, db);
                        Item login_result = winnconn.Login();
                        if (login_result.isError())
                        {
                            Forms.MessageBox.Show("Login failed.  Check configfile for login information ", "Login Failed");
                            return null;
                        }
                        return IomFactory.CreateInnovator(winnconn);
                    }
                    else  //Office connector set up but windowauth not set up so prompt user for login.
                    {
                        //prompt with OC login
                        // still needs work
                        //OfficeConnector.Dialogs.DialogFactory dialogfactory = new ArasOC.Dialogs.DialogFactory();
                        //dialogfactory.GetLoginDialog();

                        //Dictionary<string, string> logindict = new Dictionary<string, string>();

                        //OfficeConnector.Dialogs.LoginDialog loginDialog = new ArasOC.Dialogs.LoginDialog(logindict, new ArasOC.OfficeApps.OfficeApp(),ArasOC.Configurations.IConfigurationStorage()) ;
                        //loginDialog.ShowDialog();
                        ////ArasOC.OfficeApps.OfficeApp loginofficeapp;
                        ////ArasOC.Configurations.IConfigurationStorage iconfig = new 

                        //////OfficeConnector.Dialogs.LoginDialog OCLoginDialog = new ArasOC.Dialogs.LoginDialog(logindict, loginofficeapp,);
                        //////OCLoginDialog.ShowDialog();
                        //////url = OCLoginDialog.Url;
                        ////HttpServerConnection conn = IomFactory.CreateHttpServerConnection(OCLoginDialog.Url, OCLoginDialog.DB, OCLoginDialog.UserName, OCLoginDialog.Password);
                        ////return IomFactory.CreateInnovator(conn);
                        System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                        Forms.MessageBox.Show("'" + ((System.Reflection.AssemblyProductAttribute)assembly.GetCustomAttributes(false)[7]).Product + "' only works with Windows Authentication active", "Login Failed");
                        return null;
                    }
                }
                else  //Office Connector not set up so prompt for Aras Login
                {

                    //HttpServerConnection conn = IomFactory.CreateHttpServerConnection(url, db, user, password);
                    //Item login_result = conn.Login();
                    //if (login_result.isError())
                    //{
                    //    //prompt with OC login
                    //    OfficeConnector.Dialogs.LoginDialog OCLoginDialog = new ArasOC.Dialogs.LoginDialog();
                    //    OCLoginDialog.ShowDialog();
                    //    url = OCLoginDialog.Url;

                    //}

                    Forms.MessageBox.Show("Login failed.  This Add-in only works with Windows Authentication active and Office Connector enabled", "Login Failed");
                    //return IomFactory.CreateInnovator(conn);
                    return null;
                }
            }

        }


        public void Application_open(Core.DocumentProperties properties, RibbonButton CompleteTaskButton, RibbonLabel WorkflowNameRibbonLabel, RibbonLabel ActivityRibbonLabel)
        {
            if ((inn = Connect_to_Aras) != null)
            {
                
                //update workflow ribbon label
                UpdateWorkFlowRibbonName(properties[Settings.Default.arasPrimaryLinkItemId].Value,  WorkflowNameRibbonLabel);

                //update activity ribbon label
                UpdateActivityRibbonName(properties[Settings.Default.arasPrimaryLinkItemId].Value, ActivityRibbonLabel,CompleteTaskButton);

                CompleteTaskButton.Enabled = !String.IsNullOrEmpty(WorkflowNameRibbonLabel.Label);
            }
        }

        private void UpdateWorkFlowRibbonName(string source_id, RibbonLabel WorkflowNameRibbonLabel)
        {
            //update workflow ribbon label
            Item Workflow = inn.applyAML(Settings.Default.getWorkFlowAML.Replace("<source_id>", "<source_id>" + source_id));
            if (Workflow.node != null)
            {
                string Workflowprocessid = Workflow.getProperty("related_id");
                Item WorkFlowProcess = inn.applyAML(Settings.Default.getWorkFlowProcessAML.Replace("<id></id>", "<id>" + Workflowprocessid + "</id>"));
                string WorkflowName = inn.applyAML(Settings.Default.getWorkflowMapNameAML.Replace("<id></id>", "<id>" + WorkFlowProcess.getProperty("copied_from_string") + "</id>")).getProperty("name");
                WorkflowNameRibbonLabel.Label = WorkflowName;
            }
        }

        private void UpdateActivityRibbonName(string source_id, RibbonLabel ActivityRibbonLabel, RibbonButton CompleteTaskButton)
        {
            Item Workflow = inn.applyAML(Settings.Default.getWorkFlowAML.Replace("<source_id>", "<source_id>" + source_id));
            if (Workflow.node != null)
            {
                string Workflowprocessid = Workflow.getProperty("related_id");
                Item WorkFlowProcess = inn.applyAML(Settings.Default.getWorkFlowProcessAML.Replace("<id></id>", "<id>" + Workflowprocessid + "</id>"));
                string WorkflowName = inn.applyAML(Settings.Default.getWorkflowMapNameAML.Replace("<id></id>", "<id>" + WorkFlowProcess.getProperty("copied_from_string") + "</id>")).getProperty("name");

                Item WorkFlowProcessActivities = inn.applyAML(Settings.Default.getActivitiesAML.Replace("<source_id>", "<source_id>" + Workflowprocessid));
                string endactivity = "";
                for (int i = 0; i < WorkFlowProcessActivities.getItemCount(); i++)
                {
                    Item WorkFlowProcessActivity = WorkFlowProcessActivities.getItemByIndex(i);
                    Item Activity = WorkFlowProcessActivity.getPropertyItem("related_id");
                    string currentstate = Activity.getPropertyAttribute("current_state", "keyed_name");
                    endactivity = Activity.getProperty("is_end") == "1" && string.IsNullOrEmpty(endactivity) ? Activity.getID() : endactivity;
                    if (currentstate == "Active")
                    {
                        string currentactivity = Activity.getPropertyAttribute("config_id", "keyed_name");
                        ActivityRibbonLabel.Label = currentactivity;
                        CompleteTaskButton.Enabled = true;
                        return;
                    }
                }
                //if code gets here and didn't break out then end of workflow
                ActivityRibbonLabel.Label = inn.getItemById("Activity", endactivity).getPropertyAttribute("config_id", "keyed_name");
                CompleteTaskButton.Enabled = false;
            }
        }

        public void Complete_Activity(Core.DocumentProperties properties, RibbonButton CompleteTaskButton, RibbonLabel WorkflowNameRibbonLabel, RibbonLabel ActivityRibbonLabel)
        {

            if ((inn = Connect_to_Aras) != null)
            {
                ActivityForm AF = new ActivityForm()
                {
                    //docid = properties[Settings.Default.ArasDocumentIDCPName].Value,
                    inn = inn,
                    primarylinkedid = properties[Settings.Default.arasPrimaryLinkItemId].Value
                };

                AF.ShowDialog();

                //update workflow ribbon label
                UpdateWorkFlowRibbonName(properties[Settings.Default.arasPrimaryLinkItemId].Value, WorkflowNameRibbonLabel);

                //update activity ribbon label
                UpdateActivityRibbonName(properties[Settings.Default.arasPrimaryLinkItemId].Value, ActivityRibbonLabel, CompleteTaskButton);

                CompleteTaskButton.Enabled = !String.IsNullOrEmpty(WorkflowNameRibbonLabel.Label);
            }
        }
    }
}
