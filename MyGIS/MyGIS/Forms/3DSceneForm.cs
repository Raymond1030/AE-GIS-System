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
using ESRI.ArcGIS.Analyst3D;
using ESRI.ArcGIS.DataSourcesRaster;
namespace MyGIS.Forms
{
    public partial class _3DSceneForm : Form
    {
        public _3DSceneForm()
        {
            InitializeComponent();
            //mTINType.SelectedIndex = 0;
        }
        //点查询接口
        private IHit3DSet mHit3DSet;
        private ResultForm mResultForm = new ResultForm();
        private void _3DSceneForm_Load(object sender, EventArgs e)
        {
            this.mSceneControl.BringToFront();
        }
        //打开sxd工程文件
        private void OpenSxdFile_Click(object sender, EventArgs e)
        {
            //文件过滤
            mOpenFileDialog.Filter = "sxd文件|*.sxd";
            //打开文件对话框打开事件
            if (mOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //从打开对话框中得到打开文件的全路径,并将该路径传入到mSceneControl中

                    string filenm = mOpenFileDialog.FileName;
                    this.mSceneControl.LoadSxFile(filenm);

                    this.mSceneControl.Refresh();

                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
  

        }
        //打开栅格数据
        private void OpenRasterFile_Click(object sender, EventArgs e)
        {
            string sFileName = null;
            //新建栅格图层
            IRasterLayer pRasterLayer = null;
            pRasterLayer = new RasterLayerClass();
            //取消文件过滤
            mOpenFileDialog.Filter = "所有文件|*.*";
            //打开文件对话框打开事件
            if (mOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                //从打开对话框中得到打开文件的全路径
                sFileName = mOpenFileDialog.FileName;
                //创建栅格图层
                pRasterLayer.CreateFromFilePath(sFileName);
                //将图层加入到控件中
                mSceneControl.Scene.AddLayer(pRasterLayer, true);
                //将当前视点跳转到栅格图层
                ICamera pCamera = mSceneControl.Scene.SceneGraph.ActiveViewer.Camera;
                //得到范围
                IEnvelope pEenvelop = pRasterLayer.VisibleExtent;
                //添加z轴上的范围
                pEenvelop.ZMin = mSceneControl.Scene.Extent.ZMin;
                pEenvelop.ZMax = mSceneControl.Scene.Extent.ZMax;
                //设置相机
                pCamera.SetDefaultsMBB(pEenvelop);
                mSceneControl.Refresh();
            }


        }
        //截图
        private void SaveImage_Click(object sender, EventArgs e)
        {
            string sFileName = "";
            //保存对话框的标题
            mSaveFileDialog.Title = "保存图片";
            //保存对话框过滤器
            mSaveFileDialog.Filter = "BMP图片|*.bmp|JPG图片|*.jpg";
            //图片的高度和宽度
            int Width = mSceneControl.Width;
            int Height = mSceneControl.Height;
            if (mSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                sFileName = mSaveFileDialog.FileName;
                if (mSaveFileDialog.FilterIndex == 1)//保存成BMP格式的文件
                {
                    mSceneControl.SceneViewer.GetSnapshot(Width, Height,
                        esri3DOutputImageType.BMP, sFileName);
                }
                else//保存成JPG格式的文件
                {
                    mSceneControl.SceneViewer.GetSnapshot(Width, Height,
                        esri3DOutputImageType.JPEG, sFileName);
                }
                MessageBox.Show("保存图片成功！");
                mSceneControl.Refresh();
            }

        }

        private ResultForm mRsultForm()
        {
            ResultForm resultForm = new ResultForm();
            return resultForm;
        }

  
        //地图鼠标点击事件
        //处理点查询
        private void mSceneControl_OnMouseDown(object sender, ISceneControlEvents_OnMouseDownEvent e)
        {
            if (mPointSearch.Checked)//check按钮处于打勾状态
            {
                //查询
                mSceneControl.SceneGraph.LocateMultiple(mSceneControl.SceneGraph.ActiveViewer,
                      e.x, e.y, esriScenePickMode.esriScenePickAll, false, out mHit3DSet);
                mHit3DSet.OnePerLayer();
                if (mHit3DSet == null)//没有选中对象
                {
                    MessageBox.Show("没有选中对象");
                }
                else
                {
                    //显示在ResultForm控件中。mHit3DSet为查询结果集合
                    mResultForm.Show();
                    mResultForm.refeshView(mHit3DSet);
                }
                mSceneControl.Refresh();
            }

        }
        //刷新图层
        private void RefreshLayer_Click(object sender, EventArgs e)
        {
            mLayerCombox.Items.Clear();
            //得到当前场景中所有图层
            int nCount = mSceneControl.Scene.LayerCount;
            if (nCount <= 0)//没有图层的情况
            {
                MessageBox.Show("场景中没有图层，请加入图层");
                return;
            }
            int i;
            ILayer pLayer = null;
            //将所有的图层的名称显示到复选框中
            for (i = 0; i < nCount; i++)
            {
                pLayer = mSceneControl.Scene.get_Layer(i);
                mLayerCombox.Items.Add(pLayer.Name);
            }
            //将复选框设置为选中第一项
            mLayerCombox.SelectedIndex = 0;
            addFieldNameToCombox(mLayerCombox.Items[mLayerCombox.SelectedIndex].ToString());

        }

        private void mLayerCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addFieldNameToCombox(mLayerCombox.Items[mLayerCombox.SelectedIndex].ToString());
        }
        //更加图层的名字将该图层的字段加入到combox中
        private void addFieldNameToCombox(string layerName)
        {
            mFeildCombox.Items.Clear();
            int i;
            IFeatureLayer pFeatureLayer = null;
            IFields pField = null;
            int nCount = mSceneControl.Scene.LayerCount;
            ILayer pLayer = null;
            //寻找名称为layerName的FeatureLayer;
            for (i = 0; i < nCount; i++)
            {
                pLayer = mSceneControl.Scene.get_Layer(i) as IFeatureLayer;
                if (pLayer.Name == layerName)//找到了layerName的Featurelayer
                {
                    pFeatureLayer = pLayer as IFeatureLayer;
                    break;
                }
            }
            if (pFeatureLayer != null)//判断是否找到
            {
                pField = pFeatureLayer.FeatureClass.Fields;
                nCount = pField.FieldCount;
                //将该图层中所用的字段写入到mFeildCombox中去
                for (i = 0; i < nCount; i++)
                {
                    mFeildCombox.Items.Add(pField.get_Field(i).Name);
                }
            }
            mFeildCombox.SelectedIndex = 0;
        }

        private void ConstructTin_Click(object sender, EventArgs e)
        {
            if (mLayerCombox.Text == "" || mFeildCombox.Text == "")//判断输入合法性
            {
                MessageBox.Show("没有相应的图层");
                return;
            }
            ITinEdit pTin = new TinClass();
            //寻找Featurelayer
            IFeatureLayer pFeatureLayer =
                mSceneControl.Scene.get_Layer(mLayerCombox.SelectedIndex) as IFeatureLayer;
            if (pFeatureLayer != null)
            {
                IEnvelope pEnvelope = new EnvelopeClass();
                IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                IQueryFilter pQueryFilter = new QueryFilterClass();
                IField pField = null;
                //找字段
                pField = pFeatureClass.Fields.get_Field(pFeatureClass.Fields.FindField(mFeildCombox.Text));
                if (pField.Type == esriFieldType.esriFieldTypeInteger ||
                     pField.Type == esriFieldType.esriFieldTypeDouble ||
                     pField.Type == esriFieldType.esriFieldTypeSingle)//判断类型
                {
                    IGeoDataset pGeoDataset = pFeatureLayer as IGeoDataset;
                    pEnvelope = pGeoDataset.Extent;
                    //设置空间参考系
                    ISpatialReference pSpatialReference;
                    pSpatialReference = pGeoDataset.SpatialReference;
                    //选择生成TIN的输入类型
                    esriTinSurfaceType pSurfaceTypeCount =
esriTinSurfaceType.esriTinMassPoint;
                    switch (mTINType.Text)
                    {
                        case "点":
                            pSurfaceTypeCount = esriTinSurfaceType.esriTinMassPoint;
                            break;
                        case "直线":
                            pSurfaceTypeCount = esriTinSurfaceType.esriTinSoftLine;
                            break;
                        case "光滑线":
                            pSurfaceTypeCount = esriTinSurfaceType.esriTinHardLine;
                            break;
                    }
                    //创建TIN
                    pTin.InitNew(pEnvelope);
                    object missing = Type.Missing;
                    //生成TIN
                    pTin.AddFromFeatureClass(pFeatureClass, pQueryFilter, pField, pField, pSurfaceTypeCount, ref missing);
                    pTin.SetSpatialReference(pGeoDataset.SpatialReference);
                    //创建Tin图层并将Tin图层加入到场景中去
                    ITinLayer pTinLayer = new TinLayerClass();
                    pTinLayer.Dataset = pTin as ITin;
                    mSceneControl.Scene.AddLayer(pTinLayer, true);
                }
                else
                {
                    MessageBox.Show("该字段的类型不符合构建TIN的条件");
                }
            }

        }




    }
}
