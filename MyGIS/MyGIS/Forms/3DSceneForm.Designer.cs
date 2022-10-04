namespace MyGIS.Forms
{
    partial class _3DSceneForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_3DSceneForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.mSceneControl = new ESRI.ArcGIS.Controls.AxSceneControl();
            this.tab2 = new System.Windows.Forms.TabControl();
            this.Tab1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ConstructTin = new System.Windows.Forms.Button();
            this.mTINType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mFeildCombox = new System.Windows.Forms.ComboBox();
            this.mLayerCombox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RefreshLayer = new System.Windows.Forms.Button();
            this.mPointSearch = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SaveImage = new System.Windows.Forms.Button();
            this.OpenRasterFile = new System.Windows.Forms.Button();
            this.OpenSxdFile = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.mOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mSceneControl)).BeginInit();
            this.tab2.SuspendLayout();
            this.Tab1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.axToolbarControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(565, 363);
            this.splitContainer1.SplitterDistance = 31;
            this.splitContainer1.TabIndex = 0;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 0);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(565, 28);
            this.axToolbarControl1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.mSceneControl);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tab2);
            this.splitContainer2.Size = new System.Drawing.Size(565, 328);
            this.splitContainer2.SplitterDistance = 390;
            this.splitContainer2.TabIndex = 0;
            // 
            // mSceneControl
            // 
            this.mSceneControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mSceneControl.Location = new System.Drawing.Point(0, 0);
            this.mSceneControl.Name = "mSceneControl";
            this.mSceneControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mSceneControl.OcxState")));
            this.mSceneControl.Size = new System.Drawing.Size(390, 328);
            this.mSceneControl.TabIndex = 0;
            this.mSceneControl.OnMouseDown += new ESRI.ArcGIS.Controls.ISceneControlEvents_Ax_OnMouseDownEventHandler(this.mSceneControl_OnMouseDown);
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.Tab1);
            this.tab2.Controls.Add(this.tabPage2);
            this.tab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab2.Location = new System.Drawing.Point(0, 0);
            this.tab2.Name = "tab2";
            this.tab2.SelectedIndex = 0;
            this.tab2.Size = new System.Drawing.Size(171, 328);
            this.tab2.TabIndex = 0;
            // 
            // Tab1
            // 
            this.Tab1.Controls.Add(this.groupBox2);
            this.Tab1.Controls.Add(this.mPointSearch);
            this.Tab1.Controls.Add(this.groupBox1);
            this.Tab1.Location = new System.Drawing.Point(4, 22);
            this.Tab1.Name = "Tab1";
            this.Tab1.Padding = new System.Windows.Forms.Padding(3);
            this.Tab1.Size = new System.Drawing.Size(163, 302);
            this.Tab1.TabIndex = 0;
            this.Tab1.Text = "基本操作";
            this.Tab1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ConstructTin);
            this.groupBox2.Controls.Add(this.mTINType);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.mFeildCombox);
            this.groupBox2.Controls.Add(this.mLayerCombox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.RefreshLayer);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 158);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "矢量文件构建TIN";
            // 
            // ConstructTin
            // 
            this.ConstructTin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ConstructTin.Location = new System.Drawing.Point(3, 132);
            this.ConstructTin.Name = "ConstructTin";
            this.ConstructTin.Size = new System.Drawing.Size(151, 23);
            this.ConstructTin.TabIndex = 7;
            this.ConstructTin.Text = "构建TIN";
            this.ConstructTin.UseVisualStyleBackColor = true;
            this.ConstructTin.Click += new System.EventHandler(this.ConstructTin_Click);
            // 
            // mTINType
            // 
            this.mTINType.FormattingEnabled = true;
            this.mTINType.Items.AddRange(new object[] {
            "点",
            "直线",
            "光滑线"});
            this.mTINType.Location = new System.Drawing.Point(63, 107);
            this.mTINType.Name = "mTINType";
            this.mTINType.Size = new System.Drawing.Size(88, 20);
            this.mTINType.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "TIN类型：";
            // 
            // mFeildCombox
            // 
            this.mFeildCombox.FormattingEnabled = true;
            this.mFeildCombox.Location = new System.Drawing.Point(51, 80);
            this.mFeildCombox.Name = "mFeildCombox";
            this.mFeildCombox.Size = new System.Drawing.Size(100, 20);
            this.mFeildCombox.TabIndex = 4;
            // 
            // mLayerCombox
            // 
            this.mLayerCombox.FormattingEnabled = true;
            this.mLayerCombox.Location = new System.Drawing.Point(51, 51);
            this.mLayerCombox.Name = "mLayerCombox";
            this.mLayerCombox.Size = new System.Drawing.Size(100, 20);
            this.mLayerCombox.TabIndex = 3;
            this.mLayerCombox.SelectedIndexChanged += new System.EventHandler(this.mLayerCombox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "字段：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "图层：";
            // 
            // RefreshLayer
            // 
            this.RefreshLayer.BackColor = System.Drawing.Color.Transparent;
            this.RefreshLayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.RefreshLayer.Location = new System.Drawing.Point(3, 17);
            this.RefreshLayer.Name = "RefreshLayer";
            this.RefreshLayer.Size = new System.Drawing.Size(151, 23);
            this.RefreshLayer.TabIndex = 0;
            this.RefreshLayer.Text = "刷新图层";
            this.RefreshLayer.UseVisualStyleBackColor = false;
            this.RefreshLayer.Click += new System.EventHandler(this.RefreshLayer_Click);
            // 
            // mPointSearch
            // 
            this.mPointSearch.AutoSize = true;
            this.mPointSearch.Location = new System.Drawing.Point(3, 119);
            this.mPointSearch.Name = "mPointSearch";
            this.mPointSearch.Size = new System.Drawing.Size(60, 16);
            this.mPointSearch.TabIndex = 1;
            this.mPointSearch.Text = "点查询";
            this.mPointSearch.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SaveImage);
            this.groupBox1.Controls.Add(this.OpenRasterFile);
            this.groupBox1.Controls.Add(this.OpenSxdFile);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件基本操作";
            // 
            // SaveImage
            // 
            this.SaveImage.Location = new System.Drawing.Point(27, 80);
            this.SaveImage.Name = "SaveImage";
            this.SaveImage.Size = new System.Drawing.Size(97, 23);
            this.SaveImage.TabIndex = 2;
            this.SaveImage.Text = "保存图片文件";
            this.SaveImage.UseVisualStyleBackColor = true;
            this.SaveImage.Click += new System.EventHandler(this.SaveImage_Click);
            // 
            // OpenRasterFile
            // 
            this.OpenRasterFile.Location = new System.Drawing.Point(27, 51);
            this.OpenRasterFile.Name = "OpenRasterFile";
            this.OpenRasterFile.Size = new System.Drawing.Size(97, 23);
            this.OpenRasterFile.TabIndex = 1;
            this.OpenRasterFile.Text = "打开Raster文件";
            this.OpenRasterFile.UseVisualStyleBackColor = true;
            this.OpenRasterFile.Click += new System.EventHandler(this.OpenRasterFile_Click);
            // 
            // OpenSxdFile
            // 
            this.OpenSxdFile.Location = new System.Drawing.Point(27, 21);
            this.OpenSxdFile.Name = "OpenSxdFile";
            this.OpenSxdFile.Size = new System.Drawing.Size(97, 23);
            this.OpenSxdFile.TabIndex = 0;
            this.OpenSxdFile.Text = "打开sxd文件";
            this.OpenSxdFile.UseVisualStyleBackColor = true;
            this.OpenSxdFile.Click += new System.EventHandler(this.OpenSxdFile_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.axTOCControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(163, 302);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "图层";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(3, 3);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(157, 296);
            this.axTOCControl1.TabIndex = 0;
            // 
            // mOpenFileDialog
            // 
            this.mOpenFileDialog.FileName = "mOpenFileDialog";
            // 
            // _3DSceneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 363);
            this.Controls.Add(this.splitContainer1);
            this.Name = "_3DSceneForm";
            this.Text = "三维分析";
            this.Load += new System.EventHandler(this._3DSceneForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mSceneControl)).EndInit();
            this.tab2.ResumeLayout(false);
            this.Tab1.ResumeLayout(false);
            this.Tab1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ESRI.ArcGIS.Controls.AxSceneControl mSceneControl;
        private System.Windows.Forms.TabControl tab2;
        private System.Windows.Forms.TabPage Tab1;
        private System.Windows.Forms.TabPage tabPage2;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog mOpenFileDialog;
        private System.Windows.Forms.Button SaveImage;
        private System.Windows.Forms.Button OpenRasterFile;
        private System.Windows.Forms.Button OpenSxdFile;
        private System.Windows.Forms.SaveFileDialog mSaveFileDialog;
        private System.Windows.Forms.CheckBox mPointSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ConstructTin;
        private System.Windows.Forms.ComboBox mTINType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox mFeildCombox;
        private System.Windows.Forms.ComboBox mLayerCombox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RefreshLayer;

    }
}