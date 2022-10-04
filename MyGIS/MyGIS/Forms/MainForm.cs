using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.NetworkAnalysis;
using ESRI.ArcGIS.DataSourcesGDB;
using MyGIS.Classes;
using MyGIS.Forms;
using System.Threading;
namespace MyGIS
{
    public partial class MainForm : Form
    {
        //标记当前操作方式
        private string mTool;
        //查询方式
        private int mQueryMode;
        //图层索引
        private int mLayerIndex;
        //放大、缩小，漫游
        private ZoomIn mZoomIn;
        private ZoomOut mZoomOut;
        private Pan mPan;

        //网络分析成员变量
        //几何网络
        private IGeometricNetwork mGeometricNetwork;
        //给定点的集合
        private IPointCollection mPointCollection;
        //获取给定点最近的Network元素
        private IPointToEID mPointToEID;

        //返回结果变量
        private IEnumNetEID mEnumNetEID_Junctions;
        private IEnumNetEID mEnumNetEID_Edges;
        private double mdblPathCost;
        //地图编辑窗口
        private EditForm meditForm;
        public MainForm()
        {
            InitializeComponent();
            //设置axTOCControl1的伙伴控件
            this.axTOCControl1.SetBuddyControl(axMapControl1.Object);

        }
        

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        ///////////////////////////////////////////////
#region 地图
        //地图鼠标点击
        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            this.axMapControl1.Map.ClearSelection();
            //获取当前视图
            IActiveView pActiveView = this.axMapControl1.ActiveView;
            //获取鼠标点
            IPoint pPoint = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
            switch (mTool)
            {
                case "ZoomIn"://放大
                    this.mZoomIn.OnMouseDown(e.button, e.shift, e.x, e.y);
                    break;
                case "ZoomOut"://缩小
                    this.mZoomOut.OnMouseDown(e.button, e.shift, e.x, e.y);
                    break;
                case "Pan"://漫游
                    //设置鼠标形状
                    this.axMapControl1.MousePointer = esriControlsMousePointer.esriPointerPanning;
                    this.mPan.OnMouseDown(e.button, e.shift, e.x, e.y);
                    break;
                case "AttributeQuery"://属性查询
                    IFeatureLayer pFeatureLayer2 = this.axMapControl1.get_Layer(this.mLayerIndex) as IFeatureLayer;
                    DataTable pDataTable2 = this.LoadAttributeQueryResult(this.axMapControl1, pFeatureLayer2);
                    this.dataGridView1.DataSource = pDataTable2.DefaultView;
                    this.dataGridView1.Refresh();
                    break;

                case "SpaceQuery"://空间查询
                    IGeometry pGeometry = null;
                    if (this.mQueryMode == 0)//矩形查询
                    {
                        pGeometry = this.axMapControl1.TrackRectangle();
                    }
                    else if (this.mQueryMode == 1)//线查询
                    {
                        pGeometry = this.axMapControl1.TrackLine();
                    }
                    else if (this.mQueryMode == 2)//点查询
                    {
                        ITopologicalOperator pTopo;
                        IGeometry pBuffer;
                        pGeometry = pPoint;
                        pTopo = pGeometry as ITopologicalOperator;
                        //根据点位创建缓冲区，缓冲半径为0.1，可修改
                        pBuffer = pTopo.Buffer(0.1);
                        pGeometry = pBuffer.Envelope;
                    }
                    else if (this.mQueryMode == 3)//圆查询
                    {
                        pGeometry = this.axMapControl1.TrackCircle();
                    }
                    IFeatureLayer pFeatureLayer = this.axMapControl1.get_Layer(this.mLayerIndex) as IFeatureLayer;
                    DataTable pDataTable = this.LoadSpatialQueryResult(this.axMapControl1, pFeatureLayer, pGeometry);
                    this.dataGridView1.DataSource = pDataTable.DefaultView;

                    this.dataGridView1.Refresh();
                    break;
                case "Network":
                    //记录鼠标点击的点
                    IPoint pNewPoint = new PointClass();
                    pNewPoint.PutCoords(e.mapX, e.mapY);

                    if (mPointCollection == null)
                        mPointCollection = new MultipointClass();
                    //添加点，before和after标记添加点的索引，这里不定义
                    object before = Type.Missing;
                    object after = Type.Missing;
                    mPointCollection.AddPoint(pNewPoint, ref before, ref after);
                    break;
                case "Edit":
                    //判断是否鼠标左键
                    if (e.button != 1)
                        return;
                    //判断是否处于编辑状态
                    if (meditForm.mEdit.IsEditing())
                    {
                        switch (meditForm.cboTasks.SelectedIndex)
                        {
                            case 0:
                                meditForm.mEdit.CreateMouseDown(e.mapX, e.mapY);
                                break;
                            case 1:
                                meditForm.mEdit.PanMouseDown(e.mapX, e.mapY);
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }




        }
        //地图鼠标移动
        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            switch (mTool)
            {
                case "ZoomIn":
                    this.mZoomIn.OnMouseMove(e.button, e.shift, e.x, e.y);
                    break;
                case "ZoomOut":
                    this.mZoomOut.OnMouseMove(e.button, e.shift, e.x, e.y);
                    break;
                case "Pan":

                    this.mPan.OnMouseMove(e.button, e.shift, e.x, e.y);
                    break;
                case"Edit":
                    //判断是否处于编辑状态
                    if (meditForm.mEdit.IsEditing())
                    {
                        switch (meditForm.cboTasks.SelectedIndex)
                        {
                            case 0:
                            case 1:
                                meditForm.mEdit.MouseMove(e.mapX, e.mapY);
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
            // 显示当前比例尺
            this.statusScale.Text = " 比例尺 1:" + ((long)this.axMapControl1.MapScale).ToString();
            // 显示当前坐标
            this.statueCoordinate.Text = " 当前坐标 X = " + e.mapX.ToString() + " Y = " + e.mapY.ToString() + " " + this.axMapControl1.MapUnits;


        }
        //地图鼠标双击
        private void axMapControl1_OnDoubleClick(object sender, IMapControlEvents2_OnDoubleClickEvent e)
        {

            //判断是否鼠标左键
            if (e.button != 1)
                return;

            //判断是否处于编辑状态
            if (meditForm.mEdit.IsEditing())
            {
                switch (meditForm.cboTasks.SelectedIndex)
                {
                    case 0:
                        meditForm.mEdit.CreateDoubleClick(e.mapX, e.mapY);
                        break;
                    case 1:
                        break;
                }
            }
            if (mTool == "Network")
            {
                try
                {
                    //路径计算
                    //注意权重名称与设置保持一致
                    SolvePath("LENGTH");
                    //路径转换为几何要素
                    IPolyline pPolyLineResult = PathToPolyLine();
                    //获取屏幕显示
                    IActiveView pActiveView = this.axMapControl1.ActiveView;
                    IScreenDisplay pScreenDisplay = pActiveView.ScreenDisplay;
                    //设置显示符号
                    ILineSymbol pLineSymbol = new CartographicLineSymbolClass();
                    IRgbColor pColor = new RgbColorClass();
                    pColor.Red = 255;
                    pColor.Green = 0;
                    pColor.Blue = 0;
                    //设置线宽
                    pLineSymbol.Width = 4;
                    //设置颜色
                    pLineSymbol.Color = pColor as IColor;
                    //绘制线型符号
                    pScreenDisplay.StartDrawing(0, 0);
                    pScreenDisplay.SetSymbol((ISymbol)pLineSymbol);
                    pScreenDisplay.DrawPolyline(pPolyLineResult);
                    pScreenDisplay.FinishDrawing();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("路径分析出现错误:" + "\r\n" + ex.Message);
                }
                //点集设为空
                mPointCollection = null;
            
            }

        }
        //地图鼠标松开
        private void axMapControl1_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            switch (mTool)
            {
                case "ZoomIn":
                    this.mZoomIn.OnMouseUp(e.button, e.shift, e.x, e.y);
                    break;
                case "ZoomOut":
                    this.mZoomOut.OnMouseUp(e.button, e.shift, e.x, e.y);
                    break;
                case "Pan":
                    this.mPan.OnMouseUp(e.button, e.shift, e.x, e.y);
                    //设置鼠标形状
                    this.axMapControl1.MousePointer = esriControlsMousePointer.esriPointerPan;
                    break;
                case"Edit":
                    //判断是否鼠标左键
                    if (e.button != 1)
                        return;
                    //判断是否处于编辑状态
                    if (meditForm.mEdit.IsEditing())
                    {
                        switch (meditForm.cboTasks.SelectedIndex)
                        {
                            case 0:
                                break;
                            case 1:
                                meditForm.mEdit.PanMouseUp(e.mapX, e.mapY);
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

        }
        //地图画面变化
        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            //创建鹰眼中线框
            IEnvelope pEnv = (IEnvelope)e.newEnvelope;
            IRectangleElement pRectangleEle = new RectangleElementClass();
            IElement pEle = pRectangleEle as IElement;
            pEle.Geometry = pEnv;

            //设置线框的边线对象，包括颜色和线宽
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 255;
            // 产生一个线符号对象 
            ILineSymbol pOutline = new SimpleLineSymbolClass();
            pOutline.Width = 2;
            pOutline.Color = pColor;

            // 设置颜色属性 
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 0;

            // 设置线框填充符号的属性 
            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutline;
            IFillShapeElement pFillShapeEle = pEle as IFillShapeElement;
            pFillShapeEle.Symbol = pFillSymbol;

            // 得到鹰眼视图中的图形元素容器
            IGraphicsContainer pGra = axMapControl2.Map as IGraphicsContainer;
            IActiveView pAv = pGra as IActiveView;
            // 在绘制前，清除 axMapControl2 中的任何图形元素 
            pGra.DeleteAllElements();
            // 鹰眼视图中添加线框
            pGra.AddElement((IElement)pFillShapeEle, 0);
            // 刷新鹰眼
            pAv.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

        }

        private void axMapControl1_OnFullExtentUpdated(object sender, IMapControlEvents2_OnFullExtentUpdatedEvent e)
        {
 
            if (this.axMapControl1.Map.LayerCount != 0)
            {
                //获取鹰眼图层
                this.axMapControl2.AddLayer(this.GetOverviewLayer(this.axMapControl1.Map));
                // 设置 MapControl 显示范围至数据的全局范围
                this.axMapControl2.Extent = this.axMapControl1.FullExtent;
            }
            // 刷新鹰眼控件地图
            this.axMapControl2.Refresh();
        }
   
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //获取鹰眼图层
            this.axMapControl2.AddLayer(this.GetOverviewLayer(this.axMapControl1.Map));
            // 设置 MapControl 显示范围至数据的全局范围
            this.axMapControl2.Extent = this.axMapControl1.FullExtent;
            // 刷新鹰眼控件地图
            this.axMapControl2.Refresh();

        }
#endregion

#region 鹰眼
        //鹰眼鼠标点击
        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (this.axMapControl2.Map.LayerCount != 0)
            {
                // 按下鼠标左键移动矩形框 
                if (e.button == 1)
                {
                    IPoint pPoint = new PointClass();
                    pPoint.PutCoords(e.mapX, e.mapY);
                    IEnvelope pEnvelope = this.axMapControl1.Extent;
                    pEnvelope.CenterAt(pPoint);
                    this.axMapControl1.Extent = pEnvelope;
                    this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
                // 按下鼠标右键绘制矩形框 
                else if (e.button == 2)
                {
                    IEnvelope pEnvelop = this.axMapControl2.TrackRectangle();
                    this.axMapControl1.Extent = pEnvelop;
                    this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
            }

        }
        //鹰眼鼠标移动
        private void axMapControl2_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
          // 如果不是左键按下就直接返回 
            if (e.button != 1) return;
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(e.mapX, e.mapY);
            this.axMapControl1.CenterAt(pPoint);
            this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);

        }
        //获取主视图中的视图范围最大的图层
        private ILayer GetOverviewLayer(IMap map)
        {

            if (map.LayerCount == 0)
            {
                ILayer nlayer = null;
                return nlayer;
            }
            //获取主视图的第一个图层
            ILayer pLayer = map.get_Layer(0);
            //遍历其他图层，并比较视图范围的宽度，返回宽度最大的图层
            ILayer pTempLayer = null;
            for (int i = 1; i < map.LayerCount;i++ )
            {
                pTempLayer = map.get_Layer(i);
                if (pLayer.AreaOfInterest.Width < pTempLayer.AreaOfInterest.Width)
                    pLayer = pTempLayer;
            }
            return pLayer;
        }
        //////////////////////////////////////////////
#endregion
#region 菜单栏///////////////////////////////
        //文件
        //打开Mxd
        private void btnMxd_Click(object sender, EventArgs e)
        {
            //文件路径名称,包含文件名称和路径名称
            string strName = null;

            //定义OpenFileDialog，获取并打开地图文档
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开MXD";
            openFileDialog.Filter = "MXD文件（*.mxd）|*.mxd";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                strName = openFileDialog.FileName;
                if (strName != "")
                {
                    this.axMapControl1.LoadMxFile(strName);
                }
            }
            //地图文档全图显示
            this.axMapControl1.Extent = this.axMapControl1.FullExtent;
        }
        //添加数据
        private void menuAddData_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsAddDataCommandClass();
            cmd.OnCreate(this.axMapControl1.Object);
            cmd.OnClick();

        }
        //清除图层
        private void MenuClear_Click(object sender, EventArgs e)
        {
            this.axMapControl1.ClearLayers();
            this.axMapControl2.ClearLayers();
            this.axTOCControl1.Update();
        }

        
        //退出
        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
#endregion
        //////////////////////////////////////////////
#region 视图
        //放大功能 Tool
        private void menuZoomIn_Click(object sender, EventArgs e)
        {
            //初始化mZoomIn对象
            mZoomIn = new ZoomIn();
            //mZoomIn对象与MapControl关联
            mZoomIn.OnCreate(this.axMapControl1.Object);
            //设置鼠标形状
            this.axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoomIn;
            //标记操作为“ZoomIn”
            this.mTool = "ZoomIn";


        }
        //缩小功能 Tool
        private void menuZoomOut_Click(object sender, EventArgs e)
        {
             //初始化mZoomOut对象
            mZoomOut = new ZoomOut();
            //mZoomIn对象与MapControl关联
            mZoomOut.OnCreate(this.axMapControl1.Object);
            //设置鼠标形状
            this.axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoomOut;
            //标记操作为“ZoomOut”
            this.mTool = "ZoomOut";
        
        }
        //居中放大功能 Command
        private void menuFixedZoomIn_Click(object sender, EventArgs e)
        {
            FixedZoomIn fixedZoomin = new FixedZoomIn();
            //FullExtent对象与MapControl关联
            fixedZoomin.OnCreate(this.axMapControl1.Object);
            fixedZoomin.OnClick();
        }
        //居中缩小功能 Command
        private void menuFixedZoomOut_Click(object sender, EventArgs e)
        {
            FixedZoomout fixedZoomout = new FixedZoomout();
            //FullExtent对象与MapControl关联
            fixedZoomout.OnCreate(this.axMapControl1.Object);
            fixedZoomout.OnClick();
        }
        //漫游功能 Tool
        private void menuPan_Click(object sender, EventArgs e)
        {
            //初始化Pan对象
            mPan = new Pan();
            //Pan对象与MapControl关联
            mPan.OnCreate(this.axMapControl1.Object);
            //设置鼠标形状
            this.axMapControl1.MousePointer = esriControlsMousePointer.esriPointerPan;
            //标记操作为“Pan”
            this.mTool = "Pan";

        }
        //全图显示 Command
        private void menuFullExtent_Click(object sender, EventArgs e)
        {
            //初始化FullExtent对象
            FullExtent fullExtent = new FullExtent();
            //FullExtent对象与MapControl关联
            fullExtent.OnCreate(this.axMapControl1.Object);
            fullExtent.OnClick();

        }
#endregion
        /////////////////////////////////////////////
#region 查询
        //属性查询
        private DataTable LoadAttributeQueryResult(AxMapControl mapControl, IFeatureLayer featureLayer)
        {
            
          
            DataTable pDataTable = new DataTable();
        
            return pDataTable;
        }
        private void menuAttributeQuery_Click(object sender, EventArgs e)
        {
            //初始化属性查询窗体
            AttributeQueryForm attributeQueryForm = new AttributeQueryForm(this.axMapControl1);
            attributeQueryForm.Show();
            //标记为“属性查询”
            this.mTool = "AttributeQuery";
        }
        //空间查询
        //加载到数据表
        private DataTable LoadSpatialQueryResult(AxMapControl mapControl, IFeatureLayer featureLayer, IGeometry geometry)
        {
            IFeatureClass pFeatureClass = featureLayer.FeatureClass;

            //根据图层属性字段初始化DataTable
            IFields pFields = pFeatureClass.Fields;
            DataTable pDataTable = new DataTable();
            for (int i = 0; i < pFields.FieldCount; i++)
            {
                string strFldName;
                strFldName = pFields.get_Field(i).AliasName;
                pDataTable.Columns.Add(strFldName);
            }

            //空间过滤器
            ISpatialFilter pSpatialFilter = new SpatialFilterClass();
            pSpatialFilter.Geometry = geometry;

            //根据图层类型选择缓冲方式
            switch (pFeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    break;
            }
            //定义空间过滤器的空间字段
            pSpatialFilter.GeometryField = pFeatureClass.ShapeFieldName;

            IQueryFilter pQueryFilter;
            IFeatureCursor pFeatureCursor;
            IFeature pFeature;
            //利用要素过滤器查询要素
            pQueryFilter = pSpatialFilter as IQueryFilter;
            pFeatureCursor = featureLayer.Search(pQueryFilter, true);
            pFeature = pFeatureCursor.NextFeature();

            while (pFeature != null)
            {
                string strFldValue = null;
                DataRow dr = pDataTable.NewRow();
                //遍历图层属性表字段值，并加入pDataTable
                for (int i = 0; i < pFields.FieldCount; i++)
                {
                    string strFldName = pFields.get_Field(i).Name;
                    if (strFldName == "Shape")
                    {
                        strFldValue = Convert.ToString(pFeature.Shape.GeometryType);
                    }
                    else
                        strFldValue = Convert.ToString(pFeature.get_Value(i));
                    dr[i] = strFldValue;
                }
                pDataTable.Rows.Add(dr);
                //高亮选择要素
                mapControl.Map.SelectFeature((ILayer)featureLayer, pFeature);
                mapControl.ActiveView.Refresh();
                pFeature = pFeatureCursor.NextFeature();
            }
            return pDataTable;
        }
        private void menuSpatialQuery_Click(object sender, EventArgs e)
        {
            //初始化空间查询窗体
            SpatialQueryForm spatialQueryForm = new SpatialQueryForm(this.axMapControl1);
            if (spatialQueryForm.ShowDialog() == DialogResult.OK)
            {
                //标记为“空间查询”
                this.mTool = "SpaceQuery";
                //获取查询方式和图层
                this.mQueryMode = spatialQueryForm.mQueryMode;
                this.mLayerIndex = spatialQueryForm.mLayerIndex;
                //定义鼠标形状
                this.axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair;
            }

        }
#endregion


        ////////////////////////////////////////////////
#region 工具条
        //放大
        private void toolZoomIn_Click(object sender, EventArgs e)
        {
            //初始化mZoomIn对象
            mZoomIn = new ZoomIn();
            //mZoomIn对象与MapControl关联
            mZoomIn.OnCreate(this.axMapControl1.Object);
            //设置鼠标形状
            this.axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoomIn;
            //标记操作为“ZoomIn”
            this.mTool = "ZoomIn";
        }
        //缩小
        private void toolZoomOut_Click(object sender, EventArgs e)
        {
            //初始化mZoomOut对象
            mZoomOut = new ZoomOut();
            //mZoomIn对象与MapControl关联
            mZoomOut.OnCreate(this.axMapControl1.Object);
            //设置鼠标形状
            this.axMapControl1.MousePointer = esriControlsMousePointer.esriPointerZoomOut;
            //标记操作为“ZoomOut”
            this.mTool = "ZoomOut";
        }
        //漫游
        private void toolPan_Click(object sender, EventArgs e)
        {

            //初始化Pan对象
            mPan = new Pan();
            //Pan对象与MapControl关联
            mPan.OnCreate(this.axMapControl1.Object);
            //设置鼠标形状
            this.axMapControl1.MousePointer = esriControlsMousePointer.esriPointerPan;
            //标记操作为“Pan”
            this.mTool = "Pan";

        }
        //居中放大
        private void toolFixedZoomIn_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsMapZoomInFixedCommandClass();
            cmd.OnCreate(this.axMapControl1.Object);
            cmd.OnClick();
        }
        //居中缩小
        private void toolFixedZoomOut_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ControlsMapZoomOutFixedCommandClass();
            cmd.OnCreate(this.axMapControl1.Object);
            cmd.OnClick();
        }
        //全图显示
        private void toolFullExtent_Click(object sender, EventArgs e)
        {
            //初始化FullExtent对象
            ICommand cmd = new ControlsMapFullExtentCommandClass();
            //FullExtent与MapControl的关联
            cmd.OnCreate(this.axMapControl1.Object);
            cmd.OnClick();

        }
#endregion
     
#region 分析
        //缓冲区分析
        private void MenuBufferAnalysis_Click(object sender, EventArgs e)
        {
            BufferForm bufferForm = new BufferForm(this.axMapControl1.Object);
            if (bufferForm.ShowDialog() == DialogResult.OK)
            {
                //获取输出文件路径
                string strBufferPath = bufferForm.strOutputPath;
                //缓冲区图层载入到MapControl
                int index = strBufferPath.LastIndexOf("\\");
                this.axMapControl1.AddShapeFile(strBufferPath.Substring(0, index), strBufferPath.Substring(index));
            }

        }
        //叠置分析
        private void MenuOverlayAnalysis_Click(object sender, EventArgs e)
        {
            OverlayForm overlapForm = new OverlayForm();
            if (overlapForm.ShowDialog() == DialogResult.OK)
            {
                //获取输出文件路径
                string strOverlapPath = overlapForm.strOutputPath;
                //叠置分析结果载入到MapControl
                int index = strOverlapPath.LastIndexOf("\\");
                this.axMapControl1.AddShapeFile(strOverlapPath.Substring(0, index), strOverlapPath.Substring(index));
            }
        }
        //网络分析
        //路径计算
        private void SolvePath(string weightName)
        {
            //创建ITraceFlowSolverGEN
            ITraceFlowSolverGEN pTraceFlowSolverGEN = new TraceFlowSolverClass();
            INetSolver pNetSolver = pTraceFlowSolverGEN as INetSolver;
            //初始化用于路径计算的Network
            INetwork pNetWork = mGeometricNetwork.Network;
            pNetSolver.SourceNetwork = pNetWork;

            //获取分析经过的点的个数
            int intCount = mPointCollection.PointCount;
            if (intCount < 1)
                return;


            INetFlag pNetFlag;
            //用于存储路径计算得到的边
            IEdgeFlag[] pEdgeFlags = new IEdgeFlag[intCount];


            IPoint pEdgePoint = new PointClass();
            int intEdgeEID;
            IPoint pFoundEdgePoint;
            double dblEdgePercent;

            //用于获取几何网络元素的UserID, UserClassID,UserSubID
            INetElements pNetElements = pNetWork as INetElements;
            int intEdgeUserClassID;
            int intEdgeUserID;
            int intEdgeUserSubID;
            for (int i = 0; i < intCount; i++)
            {
                pNetFlag = new EdgeFlagClass();
                //获取用户点击点
                pEdgePoint = mPointCollection.get_Point(i);
                //获取距离用户点击点最近的边
                mPointToEID.GetNearestEdge(pEdgePoint, out intEdgeEID, out pFoundEdgePoint, out dblEdgePercent);
                if (intEdgeEID <= 0)
                    continue;
                //根据得到的边查询对应的几何网络中的元素UserID, UserClassID,UserSubID
                pNetElements.QueryIDs(intEdgeEID, esriElementType.esriETEdge,
                    out intEdgeUserClassID, out intEdgeUserID, out intEdgeUserSubID);
                if (intEdgeUserClassID <= 0 || intEdgeUserID <= 0)
                    continue;

                pNetFlag.UserClassID = intEdgeUserClassID;
                pNetFlag.UserID = intEdgeUserID;
                pNetFlag.UserSubID = intEdgeUserSubID;
                pEdgeFlags[i] = pNetFlag as IEdgeFlag;
            }
            //设置路径求解的边
            pTraceFlowSolverGEN.PutEdgeOrigins(ref pEdgeFlags);

            //路径计算权重
            INetSchema pNetSchema = pNetWork as INetSchema;
            INetWeight pNetWeight = pNetSchema.get_WeightByName(weightName);
            if (pNetWeight == null)
                return;

            //设置权重，这里双向的权重设为一致
            INetSolverWeights pNetSolverWeights = pTraceFlowSolverGEN as INetSolverWeights;
            pNetSolverWeights.ToFromEdgeWeight = pNetWeight;
            pNetSolverWeights.FromToEdgeWeight = pNetWeight;

            object[] arrResults = new object[intCount - 1];
            //执行路径计算
            pTraceFlowSolverGEN.FindPath(esriFlowMethod.esriFMConnected, esriShortestPathObjFn.esriSPObjFnMinSum,
                out mEnumNetEID_Junctions, out mEnumNetEID_Edges, intCount - 1, ref arrResults);

            //获取路径计算总代价（cost）
            mdblPathCost = 0;
            for (int i = 0; i < intCount - 1; i++)
                mdblPathCost += (double)arrResults[i];
        }
        //路径转换为几何要素
        private IPolyline PathToPolyLine()
        {
            IPolyline pPolyLine = new PolylineClass();
            IGeometryCollection pNewGeometryCollection = pPolyLine as IGeometryCollection;
            if (mEnumNetEID_Edges == null)
                return null;

            IEIDHelper pEIDHelper = new EIDHelperClass();
            //获取几何网络
            pEIDHelper.GeometricNetwork = mGeometricNetwork;
            //获取地图空间参考
            ISpatialReference pSpatialReference = this.axMapControl1.Map.SpatialReference;
            pEIDHelper.OutputSpatialReference = pSpatialReference;
            pEIDHelper.ReturnGeometries = true;
            //根据边的ID获取边的信息
            IEnumEIDInfo pEnumEIDInfo = pEIDHelper.CreateEnumEIDInfo(mEnumNetEID_Edges);
            int intCount = pEnumEIDInfo.Count;
            pEnumEIDInfo.Reset();

            IEIDInfo pEIDInfo;
            IGeometry pGeometry;
            for (int i = 0; i < intCount; i++)
            {
                pEIDInfo = pEnumEIDInfo.Next();
                //获取边的几何要素
                pGeometry = pEIDInfo.Geometry;
                pNewGeometryCollection.AddGeometryCollection((IGeometryCollection)pGeometry);
            }
            return pPolyLine;
        }
        //
        private void MenuNetworkAnalyst_Click(object sender, EventArgs e)
        {
            //修改当前工具
            mTool = "Network";
            //获取几何网络文件路径
            //注意修改此路径为当前存储路径
            string strPath = @"D:\GIS综合实习2022\例子数据\例子数据\Network\USA_Highway_Network_GDB.mdb";
            //打开工作空间
            IWorkspaceFactory pWorkspaceFactory = new AccessWorkspaceFactory();
            IFeatureWorkspace pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(strPath, 0) as IFeatureWorkspace;
            //获取要素数据集
            //注意名称的设置要与上面创建保持一致
            IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset("high");

            //获取network集合
            INetworkCollection pNetWorkCollection = pFeatureDataset as INetworkCollection;
            //获取network的数量,为零时返回
            int intNetworkCount = pNetWorkCollection.GeometricNetworkCount;
            if (intNetworkCount < 1)
                return;
            //FeatureDataset可能包含多个network，我们获取指定的network
            //注意network的名称的设置要与上面创建保持一致
            mGeometricNetwork = pNetWorkCollection.get_GeometricNetworkByName("high_net");

            //将Network中的每个要素类作为一个图层加入地图控件
            IFeatureClassContainer pFeatClsContainer = mGeometricNetwork as IFeatureClassContainer;
            //获取要素类数量，为零时返回
            int intFeatClsCount = pFeatClsContainer.ClassCount;
            if (intFeatClsCount < 1)
                return;
            IFeatureClass pFeatureClass;
            IFeatureLayer pFeatureLayer;
            for (int i = 0; i < intFeatClsCount; i++)
            {
                //获取要素类
                pFeatureClass = pFeatClsContainer.get_Class(i);
                pFeatureLayer = new FeatureLayerClass();
                pFeatureLayer.FeatureClass = pFeatureClass;
                pFeatureLayer.Name = pFeatureClass.AliasName;
                //加入地图控件
                this.axMapControl1.AddLayer((ILayer)pFeatureLayer, 0);
            }

            //计算snap tolerance为图层最大宽度的1/100
            //获取图层数量
            int intLayerCount = this.axMapControl1.LayerCount;
            IGeoDataset pGeoDataset;
            IEnvelope pMaxEnvelope = new EnvelopeClass();
            for (int i = 0; i < intLayerCount; i++)
            {
                //获取图层
                pFeatureLayer = this.axMapControl1.get_Layer(i) as IFeatureLayer;
                pGeoDataset = pFeatureLayer as IGeoDataset;
                //通过Union获得较大图层范围
                pMaxEnvelope.Union(pGeoDataset.Extent);
            }
            double dblWidth = pMaxEnvelope.Width;
            double dblHeight = pMaxEnvelope.Height;
            double dblSnapTol;
            if (dblHeight < dblWidth)
                dblSnapTol = dblWidth * 0.01;
            else
                dblSnapTol = dblHeight * 0.01;

            //设置源地图，几何网络以及捕捉容差
            mPointToEID = new PointToEIDClass();
            mPointToEID.SourceMap = this.axMapControl1.Map;
            mPointToEID.GeometricNetwork = mGeometricNetwork;
            mPointToEID.SnapTolerance = dblSnapTol;
        }


#endregion

        //三维分析
        private void Menu3D_Click(object sender, EventArgs e)
        {
            _3DSceneForm scene3Dform = new _3DSceneForm();
            scene3Dform.Show();
        }

        //地图编辑
        private void MenuMapEdit_Click(object sender, EventArgs e)
        {
            mTool="Edit";
            meditForm= new EditForm(axMapControl1);
            
            meditForm.Show();


        }
    

     



  

    





    }
}
