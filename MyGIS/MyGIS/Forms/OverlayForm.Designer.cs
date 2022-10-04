namespace MyGIS.Forms
{
    partial class OverlayForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboOverLay = new System.Windows.Forms.ComboBox();
            this.btnOverlayFeat = new System.Windows.Forms.Button();
            this.btnInputFeat = new System.Windows.Forms.Button();
            this.btnOutputLayer = new System.Windows.Forms.Button();
            this.btnBuffer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.GroupBox();
            this.txtInputFeat = new System.Windows.Forms.TextBox();
            this.txtOverlayFeat = new System.Windows.Forms.TextBox();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入要素";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "叠置要素";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "叠置方式";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "输出图层";
            // 
            // cboOverLay
            // 
            this.cboOverLay.FormattingEnabled = true;
            this.cboOverLay.Location = new System.Drawing.Point(133, 113);
            this.cboOverLay.Name = "cboOverLay";
            this.cboOverLay.Size = new System.Drawing.Size(146, 20);
            this.cboOverLay.TabIndex = 4;
            // 
            // btnOverlayFeat
            // 
            this.btnOverlayFeat.Location = new System.Drawing.Point(133, 71);
            this.btnOverlayFeat.Name = "btnOverlayFeat";
            this.btnOverlayFeat.Size = new System.Drawing.Size(40, 23);
            this.btnOverlayFeat.TabIndex = 5;
            this.btnOverlayFeat.Text = "...";
            this.btnOverlayFeat.UseVisualStyleBackColor = true;
            this.btnOverlayFeat.Click += new System.EventHandler(this.btnOverlayFeat_Click);
            // 
            // btnInputFeat
            // 
            this.btnInputFeat.Location = new System.Drawing.Point(133, 34);
            this.btnInputFeat.Name = "btnInputFeat";
            this.btnInputFeat.Size = new System.Drawing.Size(40, 23);
            this.btnInputFeat.TabIndex = 6;
            this.btnInputFeat.Text = "...";
            this.btnInputFeat.UseVisualStyleBackColor = true;
            this.btnInputFeat.Click += new System.EventHandler(this.btnInputFeat_Click);
            // 
            // btnOutputLayer
            // 
            this.btnOutputLayer.Location = new System.Drawing.Point(133, 151);
            this.btnOutputLayer.Name = "btnOutputLayer";
            this.btnOutputLayer.Size = new System.Drawing.Size(40, 23);
            this.btnOutputLayer.TabIndex = 7;
            this.btnOutputLayer.Text = "...";
            this.btnOutputLayer.UseVisualStyleBackColor = true;
            this.btnOutputLayer.Click += new System.EventHandler(this.btnOutputLayer_Click);
            // 
            // btnBuffer
            // 
            this.btnBuffer.Location = new System.Drawing.Point(76, 198);
            this.btnBuffer.Name = "btnBuffer";
            this.btnBuffer.Size = new System.Drawing.Size(75, 23);
            this.btnBuffer.TabIndex = 8;
            this.btnBuffer.Text = "分析";
            this.btnBuffer.UseVisualStyleBackColor = true;
            this.btnBuffer.Click += new System.EventHandler(this.btnBuffer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(179, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(60, 241);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(200, 98);
            this.txtMessage.TabIndex = 10;
            this.txtMessage.TabStop = false;
            this.txtMessage.Text = "处理过程消息";
            // 
            // txtInputFeat
            // 
            this.txtInputFeat.Location = new System.Drawing.Point(179, 36);
            this.txtInputFeat.Name = "txtInputFeat";
            this.txtInputFeat.ReadOnly = true;
            this.txtInputFeat.Size = new System.Drawing.Size(100, 21);
            this.txtInputFeat.TabIndex = 11;
            // 
            // txtOverlayFeat
            // 
            this.txtOverlayFeat.Location = new System.Drawing.Point(179, 73);
            this.txtOverlayFeat.Name = "txtOverlayFeat";
            this.txtOverlayFeat.ReadOnly = true;
            this.txtOverlayFeat.Size = new System.Drawing.Size(100, 21);
            this.txtOverlayFeat.TabIndex = 12;
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(179, 153);
            this.txtOutputPath.Multiline = true;
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.ReadOnly = true;
            this.txtOutputPath.Size = new System.Drawing.Size(100, 21);
            this.txtOutputPath.TabIndex = 13;
            // 
            // OverlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 363);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.txtOverlayFeat);
            this.Controls.Add(this.txtInputFeat);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBuffer);
            this.Controls.Add(this.btnOutputLayer);
            this.Controls.Add(this.btnInputFeat);
            this.Controls.Add(this.btnOverlayFeat);
            this.Controls.Add(this.cboOverLay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OverlayForm";
            this.Text = "叠置分析";
            this.Load += new System.EventHandler(this.OverlayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboOverLay;
        private System.Windows.Forms.Button btnOverlayFeat;
        private System.Windows.Forms.Button btnInputFeat;
        private System.Windows.Forms.Button btnOutputLayer;
        private System.Windows.Forms.Button btnBuffer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox txtMessage;
        private System.Windows.Forms.TextBox txtInputFeat;
        private System.Windows.Forms.TextBox txtOverlayFeat;
        private System.Windows.Forms.TextBox txtOutputPath;
    }
}