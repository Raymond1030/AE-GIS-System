namespace MyGIS.Forms
{
    partial class BufferForm
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
            this.cboLayers = new System.Windows.Forms.ComboBox();
            this.lblLayer = new System.Windows.Forms.Label();
            this.btnBuffer = new System.Windows.Forms.Button();
            this.lblBufferR = new System.Windows.Forms.Label();
            this.txtBufferDistance = new System.Windows.Forms.TextBox();
            this.txtOutputLayer = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOutputLayers = new System.Windows.Forms.Button();
            this.lblUnits = new System.Windows.Forms.Label();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboLayers
            // 
            this.cboLayers.FormattingEnabled = true;
            this.cboLayers.Location = new System.Drawing.Point(132, 41);
            this.cboLayers.Name = "cboLayers";
            this.cboLayers.Size = new System.Drawing.Size(121, 20);
            this.cboLayers.TabIndex = 5;
            // 
            // lblLayer
            // 
            this.lblLayer.AutoSize = true;
            this.lblLayer.Location = new System.Drawing.Point(44, 44);
            this.lblLayer.Name = "lblLayer";
            this.lblLayer.Size = new System.Drawing.Size(53, 12);
            this.lblLayer.TabIndex = 4;
            this.lblLayer.Text = "选择图层";
            // 
            // btnBuffer
            // 
            this.btnBuffer.Location = new System.Drawing.Point(46, 221);
            this.btnBuffer.Name = "btnBuffer";
            this.btnBuffer.Size = new System.Drawing.Size(75, 23);
            this.btnBuffer.TabIndex = 6;
            this.btnBuffer.Text = "分析";
            this.btnBuffer.UseVisualStyleBackColor = true;
            this.btnBuffer.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblBufferR
            // 
            this.lblBufferR.AutoSize = true;
            this.lblBufferR.Location = new System.Drawing.Point(44, 91);
            this.lblBufferR.Name = "lblBufferR";
            this.lblBufferR.Size = new System.Drawing.Size(53, 12);
            this.lblBufferR.TabIndex = 7;
            this.lblBufferR.Text = "缓冲半径";
            // 
            // txtBufferDistance
            // 
            this.txtBufferDistance.Location = new System.Drawing.Point(132, 88);
            this.txtBufferDistance.Name = "txtBufferDistance";
            this.txtBufferDistance.Size = new System.Drawing.Size(121, 21);
            this.txtBufferDistance.TabIndex = 8;
            this.txtBufferDistance.Text = "1.0";
            // 
            // txtOutputLayer
            // 
            this.txtOutputLayer.AutoSize = true;
            this.txtOutputLayer.Location = new System.Drawing.Point(44, 139);
            this.txtOutputLayer.Name = "txtOutputLayer";
            this.txtOutputLayer.Size = new System.Drawing.Size(53, 12);
            this.txtOutputLayer.TabIndex = 9;
            this.txtOutputLayer.Text = "输出图层";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(153, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOutputLayers
            // 
            this.btnOutputLayers.Location = new System.Drawing.Point(132, 135);
            this.btnOutputLayers.Name = "btnOutputLayers";
            this.btnOutputLayers.Size = new System.Drawing.Size(36, 22);
            this.btnOutputLayers.TabIndex = 11;
            this.btnOutputLayers.Text = "...";
            this.btnOutputLayers.UseVisualStyleBackColor = true;
            this.btnOutputLayers.Click += new System.EventHandler(this.btnOutputLayers_Click);
            // 
            // lblUnits
            // 
            this.lblUnits.AutoSize = true;
            this.lblUnits.Location = new System.Drawing.Point(103, 183);
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Size = new System.Drawing.Size(53, 12);
            this.lblUnits.TabIndex = 12;
            this.lblUnits.Text = "地图单位";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(165, 136);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(88, 21);
            this.txtOutputPath.TabIndex = 13;
            this.txtOutputPath.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BufferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 282);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.lblUnits);
            this.Controls.Add(this.btnOutputLayers);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtOutputLayer);
            this.Controls.Add(this.txtBufferDistance);
            this.Controls.Add(this.lblBufferR);
            this.Controls.Add(this.btnBuffer);
            this.Controls.Add(this.cboLayers);
            this.Controls.Add(this.lblLayer);
            this.Name = "BufferForm";
            this.Text = "缓冲区分析";
            this.Load += new System.EventHandler(this.BufferForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboLayers;
        private System.Windows.Forms.Label lblLayer;
        private System.Windows.Forms.Button btnBuffer;
        private System.Windows.Forms.Label lblBufferR;
        private System.Windows.Forms.TextBox txtBufferDistance;
        private System.Windows.Forms.Label txtOutputLayer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOutputLayers;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.TextBox txtOutputPath;
    }
}