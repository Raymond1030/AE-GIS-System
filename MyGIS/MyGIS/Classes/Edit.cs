using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
namespace MyGIS.Classes
{
    public class Edit
    {
        public bool mIsEditing;                          //编辑状态
        public bool mHasEditing;                         //是否编辑
        public IFeatureLayer mCurrentLayer;              //当前编辑图层
        public IWorkspaceEdit mWorkspaceEdit;            //编辑工作空间
        public IMap mMap;                                //地图
        public IDisplayFeedback mDisplayFeedback;        //用于鼠标与控件进行可视化交互
        public IFeature mPanFeature;                   //移动的要素

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="editLayer">图层</param>
        /// <param name="map">地图</param>
        public Edit(IFeatureLayer editLayer, IMap map)
        {
            mCurrentLayer = editLayer;
            this.mMap = map;
        }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Edit()
        {
        }
        public void pushLayerAndMap(IFeatureLayer editLayer, IMap map)
        {
              mCurrentLayer = editLayer;
              this.mMap = map;
        }
        #region 添加、选择要素方法
        /// <summary>
        /// /// 在当前图层添加要素
        /// /// </summary>
        /// <param name="geometry">几何要素</param>
        public void AddFeature(IGeometry geometry)
        {
            //判断当前编辑图层是否为空
            if (mCurrentLayer == null) return;
            IFeatureClass pFeatureClass = mCurrentLayer.FeatureClass;
            //几何要素与要素类类型一致
            if (pFeatureClass.ShapeType != geometry.GeometryType || geometry == null)
                return;
            //判断编辑状态
            if (!mIsEditing)
            {
                MessageBox.Show("请先开启编辑", "提示");
                return;
            }
            try
            {
                //开始编辑操作
                mWorkspaceEdit.StartEditOperation();
                //创建要素并保存
                IFeature pFeature;
                pFeature = pFeatureClass.CreateFeature();
                pFeature.Shape = geometry;
                pFeature.Store();
                //结束编辑操作
                mWorkspaceEdit.StopEditOperation();
                //高亮显示添加要素
                mMap.ClearSelection();
                mMap.SelectFeature(mCurrentLayer as ILayer, pFeature);
                ((IActiveView)mMap).PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                mHasEditing = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 点击选中要素
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public IFeature SelectFeature(IPoint point)
        {
            if (point == null)
                return null;

            //根据点击位置生成空间查询几何要素
            IActiveView pActiveView = mMap as IActiveView;
            //屏幕距离转换为地图距离
            double dblDistance = ConvertPixelToMapUnits(pActiveView, 2);
            ITopologicalOperator pTopo = point as ITopologicalOperator;
            IGeometry pGeoBuffer = pTopo.Buffer(dblDistance);

            //定义空间过滤器
            ISpatialFilter pSpatialFilter = new SpatialFilterClass();
            //空间过滤器参数设置
            pSpatialFilter.Geometry = pGeoBuffer;
            pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
            pSpatialFilter.GeometryField = mCurrentLayer.FeatureClass.ShapeFieldName;

            IFeatureClass pFeatureClass = mCurrentLayer.FeatureClass;
            //空间查询          
            IFeatureCursor pFeatureCursor = pFeatureClass.Search(pSpatialFilter, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            if (pFeature == null)
                return null;
            //要素设为选中状态
            mMap.SelectFeature(mCurrentLayer as ILayer, pFeature);
            ((IActiveView)mMap).PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            return pFeature;
        }
        /// <summary>
        /// 更新要素形状
        /// </summary>
        /// <param name="feature"></param>
        /// <param name="geometry"></param>
        private void UpdateFeature(IFeature feature, IGeometry geometry)
        {
            //确定当前图层处在编辑状态
            if (!mWorkspaceEdit.IsBeingEdited())
            {
                MessageBox.Show("当前图层不在编辑状态", "提示");
                return;
            }

            //开始编辑操作
            mWorkspaceEdit.StartEditOperation();
            //更新要素形状
            feature.Shape = geometry;
            feature.Store();
            //结束编辑操作
            mWorkspaceEdit.StopEditOperation();
            mHasEditing = true;
        }
        /// <summary>
        /// 清除地图上显示的选择要素集
        /// </summary>
        public void ClearSelection()
        {
            ((IActiveView)mMap).PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            mMap.ClearSelection();
            ((IActiveView)mMap).PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
        }

        #endregion


        #region 编辑状态
        /// <summary>
        /// 返回编辑状态
        /// </summary>
        /// <returns></returns>
        public bool IsEditing()
        {
            return mIsEditing;
        }
        /// <summary>
        /// 是否编辑
        /// </summary>
        /// <returns></returns>
        public bool HasEdited()
        {
            return mHasEditing;
        }
        /// <summary>
        /// 开始编辑
        /// </summary>
        public void StartEditing()
        {
            //获取要素工作空间
            IFeatureClass pFeatureClass = mCurrentLayer.FeatureClass;
            IWorkspace pWorkspace = (pFeatureClass as IDataset).Workspace;
            mWorkspaceEdit = pWorkspace as IWorkspaceEdit;
            if (mWorkspaceEdit == null)
                return;
            //开始编辑
            if (!mWorkspaceEdit.IsBeingEdited())
            {
                mWorkspaceEdit.StartEditing(true);
                mIsEditing = true;
            }
        }
        /// <summary>
        /// 保存编辑
        /// </summary>
        /// <param name="save">true时保存，false时不保存</param>
        public void SaveEditing(bool save)
        {
            if (!save)
            {
                mWorkspaceEdit.StopEditing(false);
            }
            else if (save && mHasEditing && mIsEditing)
            {
                mWorkspaceEdit.StopEditing(true);
            }
            mHasEditing = false;
        }
        /// <summary>
        /// 停止编辑
        /// </summary>
        /// <param name="save"></param>
        public void StopEditing(bool save)
        {
            this.SaveEditing(save);
            mIsEditing = false;
        }
        #endregion
        #region 鼠标与地图交互事件
        /// <summary>
        /// 创建要素时MouseDown事件的响应
        /// </summary>
        /// <param name="mapX"></param>
        /// <param name="mapY"></param>
        public void CreateMouseDown(double mapX, double mapY)
        {
            //鼠标点击位置
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(mapX, mapY);

            INewLineFeedback pNewLineFeedback;
            INewPolygonFeedback pNewPolygonFeedback;
            //判断编辑状态
            if (mIsEditing)
            {
                //针对线和多边形，判断交互状态，第一次时要初始化，再次点击则直接添加节点
                if (mDisplayFeedback == null)
                {
                    //根据图层类型创建不同要素
                    switch (mCurrentLayer.FeatureClass.ShapeType)
                    {
                        case esriGeometryType.esriGeometryPoint:
                            //添加点要素
                            AddFeature(pPoint);
                            break;
                        case esriGeometryType.esriGeometryPolyline:
                            mDisplayFeedback = new NewLineFeedbackClass();
                            //获取当前屏幕显示
                            mDisplayFeedback.Display = ((IActiveView)this.mMap).ScreenDisplay;
                            pNewLineFeedback = mDisplayFeedback as INewLineFeedback;
                            //开始追踪
                            pNewLineFeedback.Start(pPoint);
                            break;
                        case esriGeometryType.esriGeometryPolygon:
                            mDisplayFeedback = new NewPolygonFeedbackClass();
                            mDisplayFeedback.Display = ((IActiveView)this.mMap).ScreenDisplay;
                            pNewPolygonFeedback = mDisplayFeedback as INewPolygonFeedback;
                            //开始追踪
                            pNewPolygonFeedback.Start(pPoint);
                            break;
                    }

                }
                else //第一次之后的点击则添加节点
                {
                    if (mDisplayFeedback is INewLineFeedback)
                    {
                        pNewLineFeedback = mDisplayFeedback as INewLineFeedback;
                        pNewLineFeedback.AddPoint(pPoint);
                    }
                    else if (mDisplayFeedback is INewPolygonFeedback)
                    {
                        pNewPolygonFeedback = mDisplayFeedback as INewPolygonFeedback;
                        pNewPolygonFeedback.AddPoint(pPoint);
                    }
                }
            }
        }
        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="mapX"></param>
        /// <param name="mapY"></param>
        public void MouseMove(double mapX, double mapY)
        {
            if (mDisplayFeedback == null)
                return;
            //获取鼠标移动点位，并移动至当前点位
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(mapX, mapY);
            mDisplayFeedback.MoveTo(pPoint);
        }
        /// <summary>
        /// 创建要素的DoubleClick事件
        /// </summary>
        /// <param name="mapX"></param>
        /// <param name="mapY"></param>
        public void CreateDoubleClick(double mapX, double mapY)
        {
            if (mDisplayFeedback == null)
                return;
            IGeometry pGeometry = null;
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(mapX, mapY);

            INewLineFeedback pNewLineFeedback;
            INewPolygonFeedback pNewPolygonFeedback;
            IPointCollection pPointCollection;
            //判断编辑状态
            if (mIsEditing)
            {
                if (mDisplayFeedback is INewLineFeedback)
                {
                    pNewLineFeedback = mDisplayFeedback as INewLineFeedback;
                    //添加点击点
                    pNewLineFeedback.AddPoint(pPoint);
                    //结束Feedback
                    IPolyline pPolyline = pNewLineFeedback.Stop();
                    pPointCollection = pPolyline as IPointCollection;
                    //至少两点时才创建线要素
                    if (pPointCollection.PointCount < 2)
                        MessageBox.Show("至少需要两点才能建立线要素！", "提示");
                    else
                        pGeometry = pPolyline as IGeometry;
                }
                else if (mDisplayFeedback is INewPolygonFeedback)
                {
                    pNewPolygonFeedback = mDisplayFeedback as INewPolygonFeedback;
                    //添加点击点
                    pNewPolygonFeedback.AddPoint(pPoint);
                    //结束Feedback
                    IPolygon pPolygon = pNewPolygonFeedback.Stop();
                    pPointCollection = pPolygon as IPointCollection;
                    //至少三点才能创建线要素
                    if (pPointCollection.PointCount < 3)
                        MessageBox.Show("至少需要两点才能建立线要素！", "提示");
                    else
                        pGeometry = pPolygon as IGeometry;
                }
                mDisplayFeedback.Display = ((IActiveView)this.mMap).ScreenDisplay;
                //不为空时添加
                if (pGeometry != null)
                {
                    AddFeature(pGeometry);
                    //创建完成将DisplayFeedback置为空
                    mDisplayFeedback = null;
                }
            }
        }
        /// <summary>
        /// 移动要素的MouseDown事件
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public void PanMouseDown(double mapX, double mapY)
        {
            //清除地图选择集
            mMap.ClearSelection();
            //获取鼠标点击位置
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(mapX, mapY);

            IActiveView pActiveView = mMap as IActiveView;
            //获取点击到的要素
            mPanFeature = SelectFeature(pPoint);
            if (mPanFeature == null)
                return;
            //获取要素形状
            IGeometry pGeometry = mPanFeature.Shape;

            IMovePointFeedback pMovePointFeedback;
            IMoveLineFeedback pMoveLineFeedback;
            IMovePolygonFeedback pMovePolygonFeedback;
            //根据要素类型定义移动方式
            switch (pGeometry.GeometryType)
            {
                case esriGeometryType.esriGeometryPoint:
                    mDisplayFeedback = new MovePointFeedbackClass();
                    //获取屏幕显示
                    mDisplayFeedback.Display = pActiveView.ScreenDisplay;
                    //开始追踪
                    pMovePointFeedback = mDisplayFeedback as IMovePointFeedback;
                    pMovePointFeedback.Start((IPoint)pGeometry, pPoint);
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    mDisplayFeedback = new MoveLineFeedbackClass();
                    mDisplayFeedback.Display = pActiveView.ScreenDisplay;
                    //开始追踪
                    pMoveLineFeedback = mDisplayFeedback as IMoveLineFeedback;
                    pMoveLineFeedback.Start((IPolyline)pGeometry, pPoint);
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    mDisplayFeedback = new MovePolygonFeedbackClass();
                    mDisplayFeedback.Display = pActiveView.ScreenDisplay;
                    //开始追踪
                    pMovePolygonFeedback = mDisplayFeedback as IMovePolygonFeedback;
                    pMovePolygonFeedback.Start((IPolygon)pGeometry, pPoint);
                    break;
            }

        }
        /// <summary>
        /// 移动要素的MouseUp事件
        /// </summary>
        /// <param name="mapX"></param>
        /// <param name="mapY"></param>
        public void PanMouseUp(double mapX, double mapY)
        {
            if (mDisplayFeedback == null)
                return;
            //获取点位
            IActiveView pActiveView = mMap as IActiveView;
            IPoint pPoint = new PointClass();
            pPoint.PutCoords(mapX, mapY);

            IMovePointFeedback pMovePointFeedback;
            IMoveLineFeedback pMoveLineFeedback;
            IMovePolygonFeedback pMovePolygonFeedback;
            IGeometry pGeometry;
            //根据移动要素类型选择移动方式
            if (mDisplayFeedback is IMovePointFeedback)
            {
                pMovePointFeedback = mDisplayFeedback as IMovePointFeedback;
                //结束追踪
                pGeometry = pMovePointFeedback.Stop();
                //更新要素
                UpdateFeature(mPanFeature, pGeometry);
            }
            else if (mDisplayFeedback is IMoveLineFeedback)
            {
                pMoveLineFeedback = mDisplayFeedback as IMoveLineFeedback;
                //结束追踪
                pGeometry = pMoveLineFeedback.Stop();
                //更新要素
                UpdateFeature(mPanFeature, pGeometry);
            }
            else if (mDisplayFeedback is IMovePolygonFeedback)
            {
                pMovePolygonFeedback = mDisplayFeedback as IMovePolygonFeedback;
                pGeometry = pMovePolygonFeedback.Stop();
                UpdateFeature(mPanFeature, pGeometry);
            }
            mDisplayFeedback = null;
            pActiveView.Refresh();
        }
        #endregion
        /// <summary>
        /// 根据屏幕像素计算实际的地理距离
        /// </summary>
        /// <param name="activeView">屏幕视图</param>
        /// <param name="pixelUnits">像素个数</param>
        /// <returns></returns>
        public double ConvertPixelToMapUnits(IActiveView activeView, double pixelUnits)
        {
            double realWorldDiaplayExtent;
            int pixelExtent;
            double sizeOfOnePixel;
            double mapUnits;

            //获取设备中视图显示宽度，即像素个数
            pixelExtent = activeView.ScreenDisplay.DisplayTransformation.get_DeviceFrame().right - activeView.ScreenDisplay.DisplayTransformation.get_DeviceFrame().left;
            //获取地图坐标系中地图显示范围
            realWorldDiaplayExtent = activeView.ScreenDisplay.DisplayTransformation.VisibleBounds.Width;
            //每个像素大小代表的实际距离
            sizeOfOnePixel = realWorldDiaplayExtent / pixelExtent;
            //地理距离
            mapUnits = pixelUnits * sizeOfOnePixel;

            return mapUnits;
        }
    }
}
