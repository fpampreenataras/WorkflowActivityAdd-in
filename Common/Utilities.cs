using System;
using Aras.IOM;
using Core = Microsoft.Office.Core;
using Microsoft.Office.Tools.Ribbon;
using Settings = Common.Properties.Settings;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.IO;

namespace WorkflowAddinCommon
{
    public class Utilities
    {
        Innovator inn;
        public void Refresh_ribbon(Core.DocumentProperties properties, WorkflowAddinRibbon MyRibbon)
        {
            if ((inn = Connect_to_Aras(MyRibbon)) != null)
            {
                List<Core.DocumentProperty> propertylist = properties.Cast<Core.DocumentProperty>().ToList();
                bool PrimaryLinkItemIdexist = propertylist.Where(x => x.Name == Settings.Default.arasPrimaryLinkItemId).Any();
                if (PrimaryLinkItemIdexist)
                {
                    UpdateWorkFlowRibbonName(properties[Settings.Default.arasPrimaryLinkItemId].Value, MyRibbon.WorkflowNameRibbonLabel);
                    UpdateActivityRibbonName(properties[Settings.Default.arasPrimaryLinkItemId].Value, MyRibbon.ActivityRibbonLabel, MyRibbon.CompleteTaskButton);
                }
                bool DocumentIdexist = propertylist.Where(x => x.Name == Settings.Default.ArasDocumentId).Any();
                if (DocumentIdexist)
                {
                    UpdateLifeCycleRibbonName(properties[Settings.Default.ArasDocumentId].Value, MyRibbon.LifeCycleRibbonLabel);
                    UpdateStateRibbonName(properties[Settings.Default.ArasDocumentId].Value, MyRibbon.StateNameRibbonLabel);
                    UpdateNextStateComboBox(properties[Settings.Default.ArasDocumentId].Value, MyRibbon);
                }
                MyRibbon.PromoteButton.Enabled = !String.IsNullOrEmpty(MyRibbon.NextStateComboBox.Text);

                //MyRibbon.CompleteTaskButton.Enabled = !MyRibbon.WorkflowNameRibbonLabel.Label.Contains("Not Assigned");
            }
        }

        private void UpdateStateRibbonName(string id, RibbonLabel stateLabel)
        {
            Item Document = inn.applyAML(AddtoItem(Settings.Default.getStateName, "config_id", id));
            if (Document.node != null)
            {
                string StateName = Document.getProperty("state");
                stateLabel.Label = StateName;
            }
        }


        private void UpdateLifeCycleRibbonName(string id, RibbonLabel lifeCycleLabel)
        {
           

            Item Document = inn.applyAML(AddtoItem(Settings.Default.getStateName,"config_id",id));
            if (Document.node != null)
            {
                string StateID = Document.getProperty("current_state");

                Item LifeCycleName = inn.applyAML(Settings.Default.getLifeCycleName.Replace("<id>", "<id>" + StateID));
                if (LifeCycleName != null)
                {
                    lifeCycleLabel.Label = LifeCycleName.getProperty("description");
                }
                else
                {
                    lifeCycleLabel.Label = "Error retriving Life Cycle name.";
                }
            }
        }

        public void Application_close(string filename, WorkflowAddinRibbon MyRibbon)
        {
            if (filename.Contains("mso_viablecopy"))  // hack to get around office connector opening and closing document when doing a Save to Aras
            {
                MyRibbon.WorkflowNameRibbonLabel.Label = "";
                MyRibbon.ActivityRibbonLabel.Label = "";
                MyRibbon.CompleteTaskButton.Enabled = false;
                MyRibbon.PromoteButton.Enabled = false;
            }
        }

        private void UpdateWorkFlowRibbonName(string source_id, RibbonLabel WorkflowNameRibbonLabel)
        {
            //update workflow ribbon label);
            Item Workflow = inn.applyAML(AddtoItem(Settings.Default.getWorkFlowAML, "source_id", source_id));
            if (Workflow.node != null)
            {
                string Workflowprocessid = Workflow.getProperty("related_id");
                Item WorkFlowProcess = inn.applyAML(AddtoItem(Settings.Default.getWorkFlowProcessAML, "id", Workflowprocessid));
                string WorkflowName = inn.applyAML(AddtoItem(Settings.Default.getWorkflowMapNameAML, "id", WorkFlowProcess.getProperty("copied_from_string"))).getProperty("name");
                WorkflowNameRibbonLabel.Label = WorkflowName;
            }
            else
            {
              
                WorkflowNameRibbonLabel.Label = "Not Assigned";
            }
        }

        private void UpdateActivityRibbonName(string source_id, RibbonLabel ActivityRibbonLabel, RibbonButton CompleteTaskButton)
        {
            Item Workflow = inn.applyAML(AddtoItem(Settings.Default.getWorkFlowAML, "source_id", source_id));
            if (Workflow.node != null)
            {
                string Workflowprocessid = Workflow.getProperty("related_id");
                Item WorkFlowProcess = inn.applyAML(AddtoItem(Settings.Default.getWorkFlowProcessAML, "id", Workflowprocessid));
                string WorkflowName = inn.applyAML(AddtoItem(Settings.Default.getWorkflowMapNameAML, "id", WorkFlowProcess.getProperty("copied_from_string"))).getProperty("name");

                Item WorkFlowProcessActivities = inn.applyAML(AddtoItem(Settings.Default.getActivitiesAML,"source_id", Workflowprocessid));
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
                        Item myactivities = inn.applyAML(Settings.Default.getMyTasks);
                        for (int j = 0; j < myactivities.getItemCount(); j++)
                        {
                            Item myInBasketItem = myactivities.getItemByIndex(j);
                            string containerid = myInBasketItem.getProperty("container");
                            if (containerid == Workflowprocessid)
                            {
                                CompleteTaskButton.Enabled = true;
                            }
                        }
                        return;
                    }
                }
                //if code gets here and didn't break out then end of workflow
                ActivityRibbonLabel.Label = inn.getItemById("Activity", endactivity).getPropertyAttribute("config_id", "keyed_name");
                CompleteTaskButton.Enabled = false;
            }
            else
            {
                ActivityRibbonLabel.Label = "";
                CompleteTaskButton.Enabled = false;
            }
        }
        private void UpdateNextStateComboBox(string source_id, WorkflowAddinRibbon MyRibbon)
        {

            Item Document = inn.applyAML(AddtoItem(Settings.Default.getStateName, "config_id", source_id));
            if (Document.node != null)
            {
                string stateId = Document.getProperty("current_state");
                Item CurrentUserIds = inn.applyAML(Settings.Default.getCurrentUserIDs);
                List<string> idslist = new List<string>();
                for (int i = 0; i < CurrentUserIds.getItemCount(); i++)
                {
                    Item id = CurrentUserIds.getItemByIndex(i);
                    idslist.Add(id.getAttribute("id"));
                }
                Item NextStates = inn.applyAML(AddtoItem(Settings.Default.getNextStates, "from_state", stateId));
                MyRibbon.NextStateComboBox.Items.Clear();
                MyRibbon.NextStateComboBox.Text = "";
                MyRibbon.PromoteButton.Enabled = !MyRibbon.PromoteButton.Enabled;
                for (int i = 0; i < NextStates.getItemCount(); i++)
                {
                    Item nextstate = NextStates.getItemByIndex(i);
                    string role = nextstate.getProperty("role");
                    if (idslist.Contains(role))
                    {
                        RibbonDropDownItem rddi = MyRibbon.Factory.CreateRibbonDropDownItem();
                        rddi.Label = nextstate.getPropertyAttribute("to_state","keyed_name");
                        MyRibbon.NextStateComboBox.Items.Add(rddi);
                    }
                }
            }

        }

        public void Complete_Activity(Core.DocumentProperties properties, WorkflowAddinRibbon MyRibbon)
        {
            List<Core.DocumentProperty> propertylist = properties.Cast<Core.DocumentProperty>().ToList();
            bool PrimaryLinkItemIdexist = propertylist.Where(x => x.Name == Settings.Default.arasPrimaryLinkItemId).Any();
            if (PrimaryLinkItemIdexist)
            {
                if ((inn = Connect_to_Aras(MyRibbon)) != null)
                {
                    ActivityForm AF = new ActivityForm()
                    {
                        inn = inn,
                        primarylinkedid = properties[Settings.Default.arasPrimaryLinkItemId].Value
                    };

                    AF.ShowDialog();
                    Updatelabels(properties, MyRibbon);

                    MyRibbon.CompleteTaskButton.Enabled = !String.IsNullOrEmpty(MyRibbon.WorkflowNameRibbonLabel.Label);
                }
            }
        }

        public void Complete_Promote(Core.DocumentProperties properties, WorkflowAddinRibbon MyRibbon)
        {
            //execute the AML to promote
            if ((inn = Connect_to_Aras(MyRibbon)) != null)
            {

                Item result = inn.applyAML(AddtoItem (Settings.Default.promoteAML.Replace("document.id=", "document.id='" + properties[Settings.Default.ArasDocumentId].Value + "'\">"),  "state" , MyRibbon.NextStateComboBox.Text));
                XmlReader readerresult = XmlReader.Create(new StringReader(result.ToString()));
                if (readerresult.ReadToDescendant("faultcode"))
                {
                    readerresult.Read();
                    string error = readerresult.Value;
                    if (error.Contains("IsLocked"))
                    {
                        System.Windows.Forms.MessageBox.Show("Document needs to be locked before promoting");
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(error);
                    }
                }
                //Updatelabels(properties, MyRibbon);
            }

        }

        public Innovator Connect_to_Aras(WorkflowAddinRibbon MyRibbon)
        {

            string url = "";
            string db = "";
            string windowauth = "";
            string user = "";
            string path = Environment.GetEnvironmentVariable("Appdata") + "\\OfficeConnector\\config.xml";
            if (System.IO.File.Exists(path))
            {
                XmlReader config = XmlReader.Create(path);
                config.ReadToDescendant("innovator");
                config.MoveToAttribute("innovatorServerName");
                url = config.Value;
                config.MoveToAttribute("innovatorDatabaseName");
                db = config.Value;
                config.MoveToAttribute("innovatorUserName");
                user = config.Value;
                config.MoveToAttribute("isWindowsAuthenticated");
                windowauth = config.Value;
                if (windowauth == "True")
                {
                    WinAuthHttpServerConnection winnconn = IomFactory.CreateWinAuthHttpServerConnection(url, db);
                    Item login_result = winnconn.Login();
                    if (login_result.isError())
                    {
                        System.Windows.Forms.MessageBox.Show("Login failed.  Check configfile for login information ", "Login Failed");
                        return null;
                    }
                    return IomFactory.CreateInnovator(winnconn);
                }
                else  //Office connector set up but windowauth not set up so use login information from tab.
                {

                    Common.LoginForm loginform = new LoginForm();
                    loginform.URLTextBox.Text = url;
                    loginform.DBsComboBox.Text = db;
                    loginform.LoginTextBox.Text = user;
                    loginform.ShowDialog();
                    return loginform.Inn;
                }
            }
            else  //Office Connector not set up so use the add-in tab information
            {
                Common.LoginForm loginform = new LoginForm();
                loginform.ShowDialog();
                return loginform.Inn;
            }
        }

    
        public void Updatelabels(Core.DocumentProperties properties, WorkflowAddinRibbon MyRibbon)
        {

            UpdateLifeCycleRibbonName(properties[Settings.Default.ArasDocumentId].Value, MyRibbon.LifeCycleRibbonLabel);
            UpdateStateRibbonName(properties[Settings.Default.ArasDocumentId].Value, MyRibbon.StateNameRibbonLabel);
            UpdateNextStateComboBox(properties[Settings.Default.ArasDocumentId].Value, MyRibbon);
            UpdateWorkFlowRibbonName(properties[Settings.Default.arasPrimaryLinkItemId].Value, MyRibbon.WorkflowNameRibbonLabel);
            UpdateActivityRibbonName(properties[Settings.Default.arasPrimaryLinkItemId].Value, MyRibbon.ActivityRibbonLabel, MyRibbon.CompleteTaskButton);
        }

        public string AddtoItem(string AMLstring, string propertyname, string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(AMLstring);
            XmlNode itemelem = doc.FirstChild.FirstChild;
            XmlElement elem = doc.CreateElement(propertyname);
            elem.InnerText = value;
            itemelem.AppendChild(elem);
            return doc.OuterXml;
        }
     
    }
}
