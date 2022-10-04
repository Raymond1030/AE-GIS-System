namespace MyGIS.Forms
{
    partial class EditForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefreshLayers = new System.Windows.Forms.Button();
            this.btnStopEditing = new System.Windows.Forms.Button();
            this.btnStartEditing = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTasks = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLayers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(37, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefreshLayers
            // 
            this.btnRefreshLayers.Location = new System.Drawing.Point(78, 26);
            this.btnRefreshLayers.Name = "btnRefreshLayers";
            this.btnRefreshLayers.Size = new System.Drawing.Size(130, 23);
            this.btnRefreshLayers.TabIndex = 18;
            this.btnRefreshLayers.Text = "更新图层";
            this.btnRefreshLayers.UseVisualStyleBackColor = true;
            this.btnRefreshLayers.Click += new System.EventHandler(this.btnRefreshLayers_Click);
            // 
            // btnStopEditing
            // 
            this.btnStopEditing.Enabled = false;
            this.btnStopEditing.Location = new System.Drawing.Point(155, 190);
            this.btnStopEditing.Name = "btnStopEditing";
            this.btnStopEditing.Size = new System.Drawing.Size(89, 23);
            this.btnStopEditing.TabIndex = 17;
            this.btnStopEditing.Text = "结束编辑";
            this.btnStopEditing.UseVisualStyleBackColor = true;
            this.btnStopEditing.Click += new System.EventHandler(this.btnStopEditing_Click);
            // 
            // btnStartEditing
            // 
            this.btnStartEditing.Location = new System.Drawing.Point(75, 107);
            this.btnStartEditing.Name = "btnStartEditing";
            this.btnStartEditing.Size = new System.Drawing.Size(133, 23);
            this.btnStartEditing.TabIndex = 14;
            this.btnStartEditing.Text = "开始编辑";
            this.btnStartEditing.UseVisualStyleBackColor = true;
            this.btnStartEditing.Click += new System.EventHandler(this.btnStartEditing_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "编辑任务:";
            // 
            // cboTasks
            // 
            this.cboTasks.FormattingEnabled = true;
            this.cboTasks.Location = new System.Drawing.Point(111, 144);
            this.cboTasks.Name = "cboTasks";
            this.cboTasks.Size = new System.Drawing.Size(133, 20);
            this.cboTasks.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "选择图层:";
            // 
            // cboLayers
            // 
            this.cboLayers.FormattingEnabled = true;
            this.cboLayers.Location = new System.Drawing.Point(111, 67);
            this.cboLayers.Name = "cboLayers";
            this.cboLayers.Size = new System.Drawing.Size(133, 20);
            this.cboLayers.TabIndex = 12;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRefreshLayers);
            this.Controls.Add(this.btnStopEditing);
            this.Controls.Add(this.btnStartEditing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTasks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboLayers);
            this.Name = "EditForm";
            this.Text = "地图编辑";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefreshLayers;
        private System.Windows.Forms.Button btnStopEditing;
        private System.Windows.Forms.Button btnStartEditing;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cboTasks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLayers;
    }
}