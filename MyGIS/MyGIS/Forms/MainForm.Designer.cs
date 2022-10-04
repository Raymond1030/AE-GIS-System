namespace MyGIS
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileMxdOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddData = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFixedZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFixedZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFullExtent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAttributeQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSpatialQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBufferAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOverlayAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNetworkAnalyst = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu3D = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMapEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolFixedZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolFixedZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolPan = new System.Windows.Forms.ToolStripButton();
            this.toolFullExtent = new System.Windows.Forms.ToolStripButton();
            this.statueCoordinate = new System.Windows.Forms.StatusStrip();
            this.StatusBlank = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusCoordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statueCoordinate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuView,
            this.menuQuery,
            this.menuAnalysis,
            this.MenuMapEdit,
            this.Menu3D});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(703, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileMxdOpen,
            this.menuAddData,
            this.MenuClear,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(44, 21);
            this.menuFile.Text = "文件";
            // 
            // menuFileMxdOpen
            // 
            this.menuFileMxdOpen.Name = "menuFileMxdOpen";
            this.menuFileMxdOpen.Size = new System.Drawing.Size(150, 22);
            this.menuFileMxdOpen.Text = "打开Mxd文件";
            this.menuFileMxdOpen.Click += new System.EventHandler(this.btnMxd_Click);
            // 
            // menuAddData
            // 
            this.menuAddData.Name = "menuAddData";
            this.menuAddData.Size = new System.Drawing.Size(150, 22);
            this.menuAddData.Text = "添加数据";
            this.menuAddData.Click += new System.EventHandler(this.menuAddData_Click);
            // 
            // MenuClear
            // 
            this.MenuClear.Name = "MenuClear";
            this.MenuClear.Size = new System.Drawing.Size(150, 22);
            this.MenuClear.Text = "清除图层";
            this.MenuClear.Click += new System.EventHandler(this.MenuClear_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(150, 22);
            this.menuExit.Text = "退出";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuZoomIn,
            this.menuZoomOut,
            this.menuFixedZoomIn,
            this.menuFixedZoomOut,
            this.menuPan,
            this.menuFullExtent});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 21);
            this.menuView.Text = "视图";
            // 
            // menuZoomIn
            // 
            this.menuZoomIn.Name = "menuZoomIn";
            this.menuZoomIn.Size = new System.Drawing.Size(124, 22);
            this.menuZoomIn.Text = "放大";
            this.menuZoomIn.Click += new System.EventHandler(this.menuZoomIn_Click);
            // 
            // menuZoomOut
            // 
            this.menuZoomOut.Name = "menuZoomOut";
            this.menuZoomOut.Size = new System.Drawing.Size(124, 22);
            this.menuZoomOut.Text = "缩小";
            this.menuZoomOut.Click += new System.EventHandler(this.menuZoomOut_Click);
            // 
            // menuFixedZoomIn
            // 
            this.menuFixedZoomIn.Name = "menuFixedZoomIn";
            this.menuFixedZoomIn.Size = new System.Drawing.Size(124, 22);
            this.menuFixedZoomIn.Text = "居中放大";
            this.menuFixedZoomIn.Click += new System.EventHandler(this.menuFixedZoomIn_Click);
            // 
            // menuFixedZoomOut
            // 
            this.menuFixedZoomOut.Name = "menuFixedZoomOut";
            this.menuFixedZoomOut.Size = new System.Drawing.Size(124, 22);
            this.menuFixedZoomOut.Text = "居中缩小";
            this.menuFixedZoomOut.Click += new System.EventHandler(this.menuFixedZoomOut_Click);
            // 
            // menuPan
            // 
            this.menuPan.Name = "menuPan";
            this.menuPan.Size = new System.Drawing.Size(124, 22);
            this.menuPan.Text = "漫游";
            this.menuPan.Click += new System.EventHandler(this.menuPan_Click);
            // 
            // menuFullExtent
            // 
            this.menuFullExtent.Name = "menuFullExtent";
            this.menuFullExtent.Size = new System.Drawing.Size(124, 22);
            this.menuFullExtent.Text = "全图显示";
            this.menuFullExtent.Click += new System.EventHandler(this.menuFullExtent_Click);
            // 
            // menuQuery
            // 
            this.menuQuery.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAttributeQuery,
            this.menuSpatialQuery});
            this.menuQuery.Name = "menuQuery";
            this.menuQuery.Size = new System.Drawing.Size(44, 21);
            this.menuQuery.Text = "查询";
            // 
            // menuAttributeQuery
            // 
            this.menuAttributeQuery.Name = "menuAttributeQuery";
            this.menuAttributeQuery.Size = new System.Drawing.Size(124, 22);
            this.menuAttributeQuery.Text = "属性查询";
            this.menuAttributeQuery.Click += new System.EventHandler(this.menuAttributeQuery_Click);
            // 
            // menuSpatialQuery
            // 
            this.menuSpatialQuery.Name = "menuSpatialQuery";
            this.menuSpatialQuery.Size = new System.Drawing.Size(124, 22);
            this.menuSpatialQuery.Text = "空间查询";
            this.menuSpatialQuery.Click += new System.EventHandler(this.menuSpatialQuery_Click);
            // 
            // menuAnalysis
            // 
            this.menuAnalysis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuBufferAnalysis,
            this.MenuOverlayAnalysis,
            this.MenuNetworkAnalyst});
            this.menuAnalysis.Name = "menuAnalysis";
            this.menuAnalysis.Size = new System.Drawing.Size(68, 21);
            this.menuAnalysis.Text = "空间分析";
            // 
            // MenuBufferAnalysis
            // 
            this.MenuBufferAnalysis.Name = "MenuBufferAnalysis";
            this.MenuBufferAnalysis.Size = new System.Drawing.Size(136, 22);
            this.MenuBufferAnalysis.Text = "缓冲区分析";
            this.MenuBufferAnalysis.Click += new System.EventHandler(this.MenuBufferAnalysis_Click);
            // 
            // MenuOverlayAnalysis
            // 
            this.MenuOverlayAnalysis.Name = "MenuOverlayAnalysis";
            this.MenuOverlayAnalysis.Size = new System.Drawing.Size(136, 22);
            this.MenuOverlayAnalysis.Text = "叠置分析";
            this.MenuOverlayAnalysis.Click += new System.EventHandler(this.MenuOverlayAnalysis_Click);
            // 
            // MenuNetworkAnalyst
            // 
            this.MenuNetworkAnalyst.Name = "MenuNetworkAnalyst";
            this.MenuNetworkAnalyst.Size = new System.Drawing.Size(136, 22);
            this.MenuNetworkAnalyst.Text = "网络分析";
            this.MenuNetworkAnalyst.Click += new System.EventHandler(this.MenuNetworkAnalyst_Click);
            // 
            // Menu3D
            // 
            this.Menu3D.Name = "Menu3D";
            this.Menu3D.Size = new System.Drawing.Size(68, 21);
            this.Menu3D.Text = "三维分析";
            this.Menu3D.Click += new System.EventHandler(this.Menu3D_Click);
            // 
            // MenuMapEdit
            // 
            this.MenuMapEdit.Name = "MenuMapEdit";
            this.MenuMapEdit.Size = new System.Drawing.Size(68, 21);
            this.MenuMapEdit.Text = "地图编辑";
            this.MenuMapEdit.Click += new System.EventHandler(this.MenuMapEdit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFixedZoomIn,
            this.toolFixedZoomOut,
            this.toolZoomIn,
            this.toolZoomOut,
            this.toolPan,
            this.toolFullExtent});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(703, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolFixedZoomIn
            // 
            this.toolFixedZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFixedZoomIn.Image = global::MyGIS.Properties.Resources.FixedZoomIn;
            this.toolFixedZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFixedZoomIn.Name = "toolFixedZoomIn";
            this.toolFixedZoomIn.Size = new System.Drawing.Size(23, 22);
            this.toolFixedZoomIn.Text = "居中放大";
            this.toolFixedZoomIn.Click += new System.EventHandler(this.toolFixedZoomIn_Click);
            // 
            // toolFixedZoomOut
            // 
            this.toolFixedZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFixedZoomOut.Image = global::MyGIS.Properties.Resources.FixedZoomOut;
            this.toolFixedZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFixedZoomOut.Name = "toolFixedZoomOut";
            this.toolFixedZoomOut.Size = new System.Drawing.Size(23, 22);
            this.toolFixedZoomOut.Text = "居中缩小";
            this.toolFixedZoomOut.Click += new System.EventHandler(this.toolFixedZoomOut_Click);
            // 
            // toolZoomIn
            // 
            this.toolZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolZoomIn.Image = global::MyGIS.Properties.Resources.ZoomIn;
            this.toolZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolZoomIn.Name = "toolZoomIn";
            this.toolZoomIn.Size = new System.Drawing.Size(23, 22);
            this.toolZoomIn.Text = "放大";
            this.toolZoomIn.Click += new System.EventHandler(this.toolZoomIn_Click);
            // 
            // toolZoomOut
            // 
            this.toolZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolZoomOut.Image = global::MyGIS.Properties.Resources.ZoomOut;
            this.toolZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolZoomOut.Name = "toolZoomOut";
            this.toolZoomOut.Size = new System.Drawing.Size(23, 22);
            this.toolZoomOut.Text = "缩小";
            this.toolZoomOut.Click += new System.EventHandler(this.toolZoomOut_Click);
            // 
            // toolPan
            // 
            this.toolPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPan.Image = global::MyGIS.Properties.Resources.Pan;
            this.toolPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPan.Name = "toolPan";
            this.toolPan.Size = new System.Drawing.Size(23, 22);
            this.toolPan.Text = "漫游";
            this.toolPan.Click += new System.EventHandler(this.toolPan_Click);
            // 
            // toolFullExtent
            // 
            this.toolFullExtent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFullExtent.Image = global::MyGIS.Properties.Resources.FullExtent;
            this.toolFullExtent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFullExtent.Name = "toolFullExtent";
            this.toolFullExtent.Size = new System.Drawing.Size(23, 22);
            this.toolFullExtent.Text = "全图显示";
            this.toolFullExtent.Click += new System.EventHandler(this.toolFullExtent_Click);
            // 
            // statueCoordinate
            // 
            this.statueCoordinate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBlank,
            this.statusScale,
            this.StatusCoordinate});
            this.statueCoordinate.Location = new System.Drawing.Point(0, 382);
            this.statueCoordinate.Name = "statueCoordinate";
            this.statueCoordinate.Size = new System.Drawing.Size(703, 22);
            this.statueCoordinate.TabIndex = 2;
            this.statueCoordinate.Text = "statusStrip1";
            // 
            // StatusBlank
            // 
            this.StatusBlank.Name = "StatusBlank";
            this.StatusBlank.Size = new System.Drawing.Size(588, 17);
            this.StatusBlank.Spring = true;
            // 
            // statusScale
            // 
            this.statusScale.Name = "statusScale";
            this.statusScale.Size = new System.Drawing.Size(44, 17);
            this.statusScale.Text = "比例尺";
            // 
            // StatusCoordinate
            // 
            this.StatusCoordinate.Name = "StatusCoordinate";
            this.StatusCoordinate.Size = new System.Drawing.Size(56, 17);
            this.StatusCoordinate.Text = "当前坐标";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(703, 332);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.axTOCControl1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.axMapControl2);
            this.splitContainer3.Size = new System.Drawing.Size(204, 332);
            this.splitContainer3.SplitterDistance = 235;
            this.splitContainer3.TabIndex = 0;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(204, 235);
            this.axTOCControl1.TabIndex = 0;
            // 
            // axMapControl2
            // 
            this.axMapControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl2.Location = new System.Drawing.Point(0, 0);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(204, 93);
            this.axMapControl2.TabIndex = 0;
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            this.axMapControl2.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl2_OnMouseMove);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.axLicenseControl1);
            this.splitContainer2.Panel1.Controls.Add(this.axMapControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(495, 332);
            this.splitContainer2.SplitterDistance = 235;
            this.splitContainer2.TabIndex = 0;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(358, 213);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(495, 235);
            this.axMapControl1.TabIndex = 0;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.axMapControl1_OnMouseUp);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnDoubleClick += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnDoubleClickEventHandler(this.axMapControl1_OnDoubleClick);
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated);
            this.axMapControl1.OnFullExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnFullExtentUpdatedEventHandler(this.axMapControl1_OnFullExtentUpdated);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(495, 93);
            this.dataGridView1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 404);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statueCoordinate);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MyGIS";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statueCoordinate.ResumeLayout(false);
            this.statueCoordinate.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileMxdOpen;
        private System.Windows.Forms.ToolStripMenuItem menuAddData;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuZoomIn;
        private System.Windows.Forms.ToolStripMenuItem menuZoomOut;
        private System.Windows.Forms.ToolStripMenuItem menuFixedZoomIn;
        private System.Windows.Forms.ToolStripMenuItem menuFixedZoomOut;
        private System.Windows.Forms.ToolStripMenuItem menuPan;
        private System.Windows.Forms.ToolStripMenuItem menuFullExtent;
        private System.Windows.Forms.ToolStripMenuItem menuQuery;
        private System.Windows.Forms.ToolStripMenuItem menuAttributeQuery;
        private System.Windows.Forms.ToolStripMenuItem menuSpatialQuery;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolFixedZoomIn;
        private System.Windows.Forms.ToolStripButton toolFixedZoomOut;
        private System.Windows.Forms.ToolStripButton toolZoomIn;
        private System.Windows.Forms.ToolStripButton toolZoomOut;
        private System.Windows.Forms.ToolStripButton toolPan;
        private System.Windows.Forms.ToolStripButton toolFullExtent;
        private System.Windows.Forms.StatusStrip statueCoordinate;
        private System.Windows.Forms.ToolStripStatusLabel StatusBlank;
        private System.Windows.Forms.ToolStripStatusLabel statusScale;
        private System.Windows.Forms.ToolStripStatusLabel StatusCoordinate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private System.Windows.Forms.ToolStripMenuItem menuAnalysis;
        private System.Windows.Forms.ToolStripMenuItem MenuBufferAnalysis;
        private System.Windows.Forms.ToolStripMenuItem MenuOverlayAnalysis;
        private System.Windows.Forms.ToolStripMenuItem MenuNetworkAnalyst;
        private System.Windows.Forms.ToolStripMenuItem Menu3D;
        private System.Windows.Forms.ToolStripMenuItem MenuClear;
        private System.Windows.Forms.ToolStripMenuItem MenuMapEdit;
    }
}

