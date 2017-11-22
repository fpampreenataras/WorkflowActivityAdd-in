namespace OfficeConnectorExtensionCommon
{
    partial class OfficeConnectorExtensionAddinRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public OfficeConnectorExtensionAddinRibbon(Microsoft.Office.Tools.Ribbon.RibbonFactory factory)
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
            this.WorkflowTab = this.Factory.CreateRibbonTab();
            this.ActivityGroup = this.Factory.CreateRibbonGroup();
            this.box3 = this.Factory.CreateRibbonBox();
            this.CompleteTaskButton = this.Factory.CreateRibbonButton();
            this.box5 = this.Factory.CreateRibbonBox();
            this.PromoteButton = this.Factory.CreateRibbonButton();
            this.NextStateComboBox = this.Factory.CreateRibbonComboBox();
            this.box4 = this.Factory.CreateRibbonBox();
            this.RefreshButton = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.LifeCycleGroup = this.Factory.CreateRibbonGroup();
            this.box1 = this.Factory.CreateRibbonBox();
            this.LifeCycleLabel = this.Factory.CreateRibbonLabel();
            this.LifeCycleRibbonLabel = this.Factory.CreateRibbonLabel();
            this.label5 = this.Factory.CreateRibbonLabel();
            this.box2 = this.Factory.CreateRibbonBox();
            this.StateLabel = this.Factory.CreateRibbonLabel();
            this.StateNameRibbonLabel = this.Factory.CreateRibbonLabel();
            this.WorkflowStatusGroup = this.Factory.CreateRibbonGroup();
            this.WorkflowNameBox = this.Factory.CreateRibbonBox();
            this.WorkflowLbl = this.Factory.CreateRibbonLabel();
            this.WorkflowNameRibbonLabel = this.Factory.CreateRibbonLabel();
            this.Space1 = this.Factory.CreateRibbonLabel();
            this.ActivityBox = this.Factory.CreateRibbonBox();
            this.ActivityLbl = this.Factory.CreateRibbonLabel();
            this.ActivityRibbonLabel = this.Factory.CreateRibbonLabel();
            this.WorkflowTab.SuspendLayout();
            this.ActivityGroup.SuspendLayout();
            this.box3.SuspendLayout();
            this.box5.SuspendLayout();
            this.box4.SuspendLayout();
            this.LifeCycleGroup.SuspendLayout();
            this.box1.SuspendLayout();
            this.box2.SuspendLayout();
            this.WorkflowStatusGroup.SuspendLayout();
            this.WorkflowNameBox.SuspendLayout();
            this.ActivityBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorkflowTab
            // 
            this.WorkflowTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.WorkflowTab.Groups.Add(this.ActivityGroup);
            this.WorkflowTab.Groups.Add(this.LifeCycleGroup);
            this.WorkflowTab.Groups.Add(this.WorkflowStatusGroup);
            this.WorkflowTab.Label = "Office Connector Extension";
            this.WorkflowTab.Name = "WorkflowTab";
            // 
            // ActivityGroup
            // 
            this.ActivityGroup.Items.Add(this.box3);
            this.ActivityGroup.Items.Add(this.box5);
            this.ActivityGroup.Items.Add(this.box4);
            this.ActivityGroup.Items.Add(this.separator1);
            this.ActivityGroup.Label = "Activity actions";
            this.ActivityGroup.Name = "ActivityGroup";
            // 
            // box3
            // 
            this.box3.Items.Add(this.CompleteTaskButton);
            this.box3.Name = "box3";
            // 
            // CompleteTaskButton
            // 
            this.CompleteTaskButton.Enabled = false;
            this.CompleteTaskButton.Label = "Complete Activity";
            this.CompleteTaskButton.Name = "CompleteTaskButton";
            this.CompleteTaskButton.OfficeImageId = "AcceptInvitation";
            this.CompleteTaskButton.ShowImage = true;
            // 
            // box5
            // 
            this.box5.Items.Add(this.PromoteButton);
            this.box5.Items.Add(this.NextStateComboBox);
            this.box5.Name = "box5";
            // 
            // PromoteButton
            // 
            this.PromoteButton.Enabled = false;
            this.PromoteButton.Label = "Promote";
            this.PromoteButton.Name = "PromoteButton";
            this.PromoteButton.OfficeImageId = "AcceptInvitation";
            this.PromoteButton.ShowImage = true;
            // 
            // NextStateComboBox
            // 
            this.NextStateComboBox.Label = "Next State";
            this.NextStateComboBox.Name = "NextStateComboBox";
            this.NextStateComboBox.SizeString = "1234567890";
            this.NextStateComboBox.Text = null;
            this.NextStateComboBox.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.NextState_TextChanged);
            // 
            // box4
            // 
            this.box4.Items.Add(this.RefreshButton);
            this.box4.Name = "box4";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Label = "Update From Aras";
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.OfficeImageId = "RecurrenceEdit";
            this.RefreshButton.ShowImage = true;
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // LifeCycleGroup
            // 
            this.LifeCycleGroup.Items.Add(this.box1);
            this.LifeCycleGroup.Items.Add(this.label5);
            this.LifeCycleGroup.Items.Add(this.box2);
            this.LifeCycleGroup.Label = "Life Cycle Staus";
            this.LifeCycleGroup.Name = "LifeCycleGroup";
            // 
            // box1
            // 
            this.box1.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.box1.Items.Add(this.LifeCycleLabel);
            this.box1.Items.Add(this.LifeCycleRibbonLabel);
            this.box1.Name = "box1";
            // 
            // LifeCycleLabel
            // 
            this.LifeCycleLabel.Label = "Life Cycle";
            this.LifeCycleLabel.Name = "LifeCycleLabel";
            // 
            // LifeCycleRibbonLabel
            // 
            this.LifeCycleRibbonLabel.Label = " ";
            this.LifeCycleRibbonLabel.Name = "LifeCycleRibbonLabel";
            // 
            // label5
            // 
            this.label5.Label = "          ";
            this.label5.Name = "label5";
            // 
            // box2
            // 
            this.box2.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.box2.Items.Add(this.StateLabel);
            this.box2.Items.Add(this.StateNameRibbonLabel);
            this.box2.Name = "box2";
            // 
            // StateLabel
            // 
            this.StateLabel.Label = "State";
            this.StateLabel.Name = "StateLabel";
            // 
            // StateNameRibbonLabel
            // 
            this.StateNameRibbonLabel.Label = " ";
            this.StateNameRibbonLabel.Name = "StateNameRibbonLabel";
            // 
            // WorkflowStatusGroup
            // 
            this.WorkflowStatusGroup.Items.Add(this.WorkflowNameBox);
            this.WorkflowStatusGroup.Items.Add(this.Space1);
            this.WorkflowStatusGroup.Items.Add(this.ActivityBox);
            this.WorkflowStatusGroup.Label = "Workflow Status";
            this.WorkflowStatusGroup.Name = "WorkflowStatusGroup";
            // 
            // WorkflowNameBox
            // 
            this.WorkflowNameBox.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.WorkflowNameBox.Items.Add(this.WorkflowLbl);
            this.WorkflowNameBox.Items.Add(this.WorkflowNameRibbonLabel);
            this.WorkflowNameBox.Name = "WorkflowNameBox";
            // 
            // WorkflowLbl
            // 
            this.WorkflowLbl.Label = "Workflow";
            this.WorkflowLbl.Name = "WorkflowLbl";
            // 
            // WorkflowNameRibbonLabel
            // 
            this.WorkflowNameRibbonLabel.Label = "Not Assigned";
            this.WorkflowNameRibbonLabel.Name = "WorkflowNameRibbonLabel";
            // 
            // Space1
            // 
            this.Space1.Label = "          ";
            this.Space1.Name = "Space1";
            // 
            // ActivityBox
            // 
            this.ActivityBox.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.ActivityBox.Items.Add(this.ActivityLbl);
            this.ActivityBox.Items.Add(this.ActivityRibbonLabel);
            this.ActivityBox.Name = "ActivityBox";
            // 
            // ActivityLbl
            // 
            this.ActivityLbl.Label = "Activity";
            this.ActivityLbl.Name = "ActivityLbl";
            // 
            // ActivityRibbonLabel
            // 
            this.ActivityRibbonLabel.Label = " ";
            this.ActivityRibbonLabel.Name = "ActivityRibbonLabel";
            // 
            // WorkflowAddinRibbon
            // 
            this.Name = "WorkflowAddinRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook, Microsoft.PowerPoint.Presentation, Microsoft.Word.Docum" +
    "ent";
            this.Tabs.Add(this.WorkflowTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.WorkflowAddinRibbon_load);
            this.WorkflowTab.ResumeLayout(false);
            this.WorkflowTab.PerformLayout();
            this.ActivityGroup.ResumeLayout(false);
            this.ActivityGroup.PerformLayout();
            this.box3.ResumeLayout(false);
            this.box3.PerformLayout();
            this.box5.ResumeLayout(false);
            this.box5.PerformLayout();
            this.box4.ResumeLayout(false);
            this.box4.PerformLayout();
            this.LifeCycleGroup.ResumeLayout(false);
            this.LifeCycleGroup.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();
            this.box2.ResumeLayout(false);
            this.box2.PerformLayout();
            this.WorkflowStatusGroup.ResumeLayout(false);
            this.WorkflowStatusGroup.PerformLayout();
            this.WorkflowNameBox.ResumeLayout(false);
            this.WorkflowNameBox.PerformLayout();
            this.ActivityBox.ResumeLayout(false);
            this.ActivityBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Office.Tools.Ribbon.RibbonTab WorkflowTab;
        public Microsoft.Office.Tools.Ribbon.RibbonGroup ActivityGroup;
        public Microsoft.Office.Tools.Ribbon.RibbonButton CompleteTaskButton;
        public Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        public Microsoft.Office.Tools.Ribbon.RibbonLabel WorkflowLbl;
        public Microsoft.Office.Tools.Ribbon.RibbonLabel ActivityLbl;
        public Microsoft.Office.Tools.Ribbon.RibbonLabel WorkflowNameRibbonLabel;
        public Microsoft.Office.Tools.Ribbon.RibbonLabel ActivityRibbonLabel;
        public Microsoft.Office.Tools.Ribbon.RibbonGroup WorkflowStatusGroup;
        public Microsoft.Office.Tools.Ribbon.RibbonBox WorkflowNameBox;
        public Microsoft.Office.Tools.Ribbon.RibbonBox ActivityBox;
        public Microsoft.Office.Tools.Ribbon.RibbonButton RefreshButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel Space1;
        public Microsoft.Office.Tools.Ribbon.RibbonButton PromoteButton;
        public Microsoft.Office.Tools.Ribbon.RibbonGroup LifeCycleGroup;
        public Microsoft.Office.Tools.Ribbon.RibbonBox box1;
        public Microsoft.Office.Tools.Ribbon.RibbonLabel LifeCycleLabel;
        public Microsoft.Office.Tools.Ribbon.RibbonLabel LifeCycleRibbonLabel;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label5;
        public Microsoft.Office.Tools.Ribbon.RibbonBox box2;
        public Microsoft.Office.Tools.Ribbon.RibbonLabel StateLabel;
        public Microsoft.Office.Tools.Ribbon.RibbonLabel StateNameRibbonLabel;
        public Microsoft.Office.Tools.Ribbon.RibbonComboBox NextStateComboBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box3;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box5;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box4;
    }

    //partial class ThisRibbonCollection
    //{
    //    internal WorkflowAddinRibbon Ribbon1
    //    {
    //        get { return this.GetRibbon<WorkflowAddinRibbon>(); }
    //    }
    //}
}
