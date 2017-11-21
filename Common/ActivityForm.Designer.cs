namespace WorkflowAddinCommon
{
    partial class ActivityForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WorkflowActivityInfoPanel = new System.Windows.Forms.Panel();
            this.ActivityNameLabel = new System.Windows.Forms.Label();
            this.WorkflowNameLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WorkFlowActivityLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SaveChangesBtn = new System.Windows.Forms.Button();
            this.CompleteBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Comments = new System.Windows.Forms.TextBox();
            this.DelegatetoDropDown = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.VoteComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TaskPanel = new System.Windows.Forms.Panel();
            this.TaskDataGridView = new System.Windows.Forms.DataGridView();
            this.Sequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Required = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Complete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.WorkflowActivityInfoPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TaskPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkflowActivityInfoPanel
            // 
            this.WorkflowActivityInfoPanel.AutoSize = true;
            this.WorkflowActivityInfoPanel.Controls.Add(this.ActivityNameLabel);
            this.WorkflowActivityInfoPanel.Controls.Add(this.WorkflowNameLbl);
            this.WorkflowActivityInfoPanel.Controls.Add(this.label2);
            this.WorkflowActivityInfoPanel.Controls.Add(this.label1);
            this.WorkflowActivityInfoPanel.Controls.Add(this.WorkFlowActivityLabel);
            this.WorkflowActivityInfoPanel.Location = new System.Drawing.Point(270, 27);
            this.WorkflowActivityInfoPanel.Name = "WorkflowActivityInfoPanel";
            this.WorkflowActivityInfoPanel.Size = new System.Drawing.Size(421, 74);
            this.WorkflowActivityInfoPanel.TabIndex = 0;
            // 
            // ActivityNameLabel
            // 
            this.ActivityNameLabel.AutoSize = true;
            this.ActivityNameLabel.Location = new System.Drawing.Point(148, 48);
            this.ActivityNameLabel.Name = "ActivityNameLabel";
            this.ActivityNameLabel.Size = new System.Drawing.Size(0, 13);
            this.ActivityNameLabel.TabIndex = 4;
            // 
            // WorkflowNameLbl
            // 
            this.WorkflowNameLbl.AutoSize = true;
            this.WorkflowNameLbl.Location = new System.Drawing.Point(145, 23);
            this.WorkflowNameLbl.Name = "WorkflowNameLbl";
            this.WorkflowNameLbl.Size = new System.Drawing.Size(0, 13);
            this.WorkflowNameLbl.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Activity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Workflow";
            // 
            // WorkFlowActivityLabel
            // 
            this.WorkFlowActivityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkFlowActivityLabel.AutoSize = true;
            this.WorkFlowActivityLabel.Location = new System.Drawing.Point(72, 0);
            this.WorkFlowActivityLabel.Name = "WorkFlowActivityLabel";
            this.WorkFlowActivityLabel.Size = new System.Drawing.Size(144, 13);
            this.WorkFlowActivityLabel.TabIndex = 0;
            this.WorkFlowActivityLabel.Text = "Workflow Activity Completion";
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.CancelBtn);
            this.panel2.Controls.Add(this.SaveChangesBtn);
            this.panel2.Controls.Add(this.CompleteBtn);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.TaskPanel);
            this.panel2.Controls.Add(this.WorkflowActivityInfoPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(890, 507);
            this.panel2.TabIndex = 1;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(528, 457);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(106, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // SaveChangesBtn
            // 
            this.SaveChangesBtn.Enabled = false;
            this.SaveChangesBtn.Location = new System.Drawing.Point(380, 457);
            this.SaveChangesBtn.Name = "SaveChangesBtn";
            this.SaveChangesBtn.Size = new System.Drawing.Size(106, 23);
            this.SaveChangesBtn.TabIndex = 4;
            this.SaveChangesBtn.Text = "Save Changes";
            this.SaveChangesBtn.UseVisualStyleBackColor = true;
            // 
            // CompleteBtn
            // 
            this.CompleteBtn.Enabled = false;
            this.CompleteBtn.Location = new System.Drawing.Point(270, 457);
            this.CompleteBtn.Name = "CompleteBtn";
            this.CompleteBtn.Size = new System.Drawing.Size(75, 23);
            this.CompleteBtn.TabIndex = 3;
            this.CompleteBtn.Text = "Complete";
            this.CompleteBtn.UseVisualStyleBackColor = true;
            this.CompleteBtn.Click += new System.EventHandler(this.Complete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Comments);
            this.panel1.Controls.Add(this.DelegatetoDropDown);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.VoteComboBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(15, 308);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 122);
            this.panel1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Comments";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Vote";
            // 
            // Comments
            // 
            this.Comments.Location = new System.Drawing.Point(39, 73);
            this.Comments.Multiline = true;
            this.Comments.Name = "Comments";
            this.Comments.Size = new System.Drawing.Size(779, 39);
            this.Comments.TabIndex = 5;
            // 
            // DelegatetoDropDown
            // 
            this.DelegatetoDropDown.Enabled = false;
            this.DelegatetoDropDown.FormattingEnabled = true;
            this.DelegatetoDropDown.Location = new System.Drawing.Point(365, 18);
            this.DelegatetoDropDown.Name = "DelegatetoDropDown";
            this.DelegatetoDropDown.Size = new System.Drawing.Size(121, 21);
            this.DelegatetoDropDown.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(294, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Delegate to:";
            // 
            // VoteComboBox
            // 
            this.VoteComboBox.FormattingEnabled = true;
            this.VoteComboBox.Location = new System.Drawing.Point(104, 15);
            this.VoteComboBox.Name = "VoteComboBox";
            this.VoteComboBox.Size = new System.Drawing.Size(121, 21);
            this.VoteComboBox.TabIndex = 1;
            this.VoteComboBox.SelectedIndexChanged += new System.EventHandler(this.Vote_Change);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Vote";
            // 
            // TaskPanel
            // 
            this.TaskPanel.Controls.Add(this.TaskDataGridView);
            this.TaskPanel.Controls.Add(this.label3);
            this.TaskPanel.Location = new System.Drawing.Point(15, 134);
            this.TaskPanel.Name = "TaskPanel";
            this.TaskPanel.Size = new System.Drawing.Size(857, 141);
            this.TaskPanel.TabIndex = 1;
            // 
            // TaskDataGridView
            // 
            this.TaskDataGridView.AllowUserToAddRows = false;
            this.TaskDataGridView.AllowUserToDeleteRows = false;
            this.TaskDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaskDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sequence,
            this.Required,
            this.Description,
            this.Complete,
            this.TaskID});
            this.TaskDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.TaskDataGridView.Location = new System.Drawing.Point(0, 23);
            this.TaskDataGridView.Name = "TaskDataGridView";
            this.TaskDataGridView.Size = new System.Drawing.Size(857, 118);
            this.TaskDataGridView.TabIndex = 1;
            this.TaskDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CheckBox_Click);
            // 
            // Sequence
            // 
            this.Sequence.HeaderText = "Sequence";
            this.Sequence.Name = "Sequence";
            this.Sequence.ReadOnly = true;
            this.Sequence.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Required
            // 
            this.Required.HeaderText = "Required";
            this.Required.Name = "Required";
            this.Required.ReadOnly = true;
            this.Required.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Complete
            // 
            this.Complete.FalseValue = "0";
            this.Complete.HeaderText = "Complete";
            this.Complete.Name = "Complete";
            this.Complete.ReadOnly = true;
            this.Complete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Complete.TrueValue = "1";
            // 
            // TaskID
            // 
            this.TaskID.HeaderText = "TaskID";
            this.TaskID.Name = "TaskID";
            this.TaskID.ReadOnly = true;
            this.TaskID.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tasks";
            // 
            // ActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(890, 507);
            this.Controls.Add(this.panel2);
            this.Name = "ActivityForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Activity Completion Form";
            this.Load += new System.EventHandler(this.ActivityForm_Load);
            this.WorkflowActivityInfoPanel.ResumeLayout(false);
            this.WorkflowActivityInfoPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TaskPanel.ResumeLayout(false);
            this.TaskPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WorkflowActivityInfoPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label WorkFlowActivityLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel TaskPanel;
        private System.Windows.Forms.DataGridView TaskDataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox VoteComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Comments;
        private System.Windows.Forms.ComboBox DelegatetoDropDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SaveChangesBtn;
        private System.Windows.Forms.Button CompleteBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ActivityNameLabel;
        private System.Windows.Forms.Label WorkflowNameLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sequence;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Required;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Complete;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskID;
    }
}