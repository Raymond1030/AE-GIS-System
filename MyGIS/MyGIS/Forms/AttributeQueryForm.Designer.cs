namespace MyGIS.Forms
{
    partial class AttributeQueryForm
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
            this.lblLayer = new System.Windows.Forms.Label();
            this.lblField = new System.Windows.Forms.Label();
            this.lblfind = new System.Windows.Forms.Label();
            this.cboLayer = new System.Windows.Forms.ComboBox();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLayer
            // 
            this.lblLayer.AutoSize = true;
            this.lblLayer.Location = new System.Drawing.Point(42, 48);
            this.lblLayer.Name = "lblLayer";
            this.lblLayer.Size = new System.Drawing.Size(53, 12);
            this.lblLayer.TabIndex = 0;
            this.lblLayer.Text = "选择图层";
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(42, 109);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(53, 12);
            this.lblField.TabIndex = 1;
            this.lblField.Text = "字段名称";
            // 
            // lblfind
            // 
            this.lblfind.AutoSize = true;
            this.lblfind.Location = new System.Drawing.Point(42, 167);
            this.lblfind.Name = "lblfind";
            this.lblfind.Size = new System.Drawing.Size(53, 12);
            this.lblfind.TabIndex = 2;
            this.lblfind.Text = "查找内容";
            // 
            // cboLayer
            // 
            this.cboLayer.FormattingEnabled = true;
            this.cboLayer.Location = new System.Drawing.Point(122, 45);
            this.cboLayer.Name = "cboLayer";
            this.cboLayer.Size = new System.Drawing.Size(121, 20);
            this.cboLayer.TabIndex = 3;
            this.cboLayer.SelectedIndexChanged += new System.EventHandler(this.cboLayer_SelectedIndexChanged);
            // 
            // cboField
            // 
            this.cboField.FormattingEnabled = true;
            this.cboField.Location = new System.Drawing.Point(122, 106);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(121, 20);
            this.cboField.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(44, 215);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "查找";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(122, 164);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(121, 21);
            this.txtValue.TabIndex = 6;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(158, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AttributeQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboField);
            this.Controls.Add(this.cboLayer);
            this.Controls.Add(this.lblfind);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.lblLayer);
            this.Name = "AttributeQueryForm";
            this.Text = "属性查询";
            this.Load += new System.EventHandler(this.AttributeQueryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLayer;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.Label lblfind;
        private System.Windows.Forms.ComboBox cboLayer;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnCancel;
    }
}