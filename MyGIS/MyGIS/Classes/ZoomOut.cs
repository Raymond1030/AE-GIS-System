using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;

namespace MyGIS.Classes
{
    /// <summary>
    /// Summary description for Zoomoutcs.
    /// </summary>
    [Guid("75d0f61d-8b96-4b9f-9335-553d05505854")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("MyGIS.Classes.Zoomoutcs")]
    public sealed class ZoomOut : BaseTool
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            ControlsCommands.Unregister(regKey);

        }

        #endregion
        #endregion


        private IHookHelper m_hookHelper;
        //记录鼠标位置
        private IPoint m_point;
        //标记MouseDown是否发生
        private Boolean m_isMouseDown;
        //追踪鼠标移动产生新的Envelope
        private INewEnvelopeFeedback m_feedBack;
        public ZoomOut()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; //localizable text 
            base.m_caption = "缩小";  //localizable text 
            base.m_message = "缩小";  //localizable text
            base.m_toolTip = "缩小";  //localizable text
            base.m_name = "ZoomOut";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
            try
            {
                //
                // TODO: change resource name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
                base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();

            m_hookHelper.Hook = hook;

            // TODO:  Add Zoomoutcs.OnCreate implementation
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add Zoomoutcs.OnClick implementation
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ZoomOut.OnMouseDown implementation
            //当前地图视图为空时返回
            if (m_hookHelper.ActiveView == null)
                return;
            //获取鼠标点击位置
            m_point = m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            //

            m_isMouseDown = true;
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add Zoomoutcs.OnMouseMove implementation
            //MouseDown为发生时返回
            if (!m_isMouseDown)
                return;

            IActiveView pActiveView = m_hookHelper.ActiveView;
            //m_feedBack追踪鼠标移动
            if (m_feedBack == null)
            {
                m_feedBack = new NewEnvelopeFeedbackClass();
                m_feedBack.Display = pActiveView.ScreenDisplay;
                //开始追踪
                m_feedBack.Start(m_point);
            }
            //追踪鼠标移动位置
            m_feedBack.MoveTo(pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y));
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add Zoomoutcs.OnMouseUp implementation
            //MouseDown为发生时返回
            if (!m_isMouseDown) return;

            //新的范围的宽度和高度
            double newWidth, newHeight;

            IActiveView pActiveView = m_hookHelper.ActiveView;

            //获取MouseUp发生时的范围并缩小
            IEnvelope pEnvelope;
            //追踪获取的范围
            IEnvelope pFeedEnvelope;
            if (m_feedBack == null)//鼠标未拉框时进行固定比例尺缩小
            {
                pEnvelope = pActiveView.Extent;
                pEnvelope.Expand(2, 2, true);
                pEnvelope.CenterAt(m_point);
            }
            else
            {
                //停止追踪
                pFeedEnvelope = m_feedBack.Stop();

                //判断新的范围的高度和宽度是否为零
                if (pFeedEnvelope.Width == 0 || pFeedEnvelope.Height == 0)
                {
                    m_feedBack = null;
                    m_isMouseDown = false;
                }

                newWidth = pActiveView.Extent.Width * (pActiveView.Extent.Width / pFeedEnvelope.Width);
                newHeight = pActiveView.Extent.Height * (pActiveView.Extent.Height / pFeedEnvelope.Height);

                //新的范围
                pEnvelope = new EnvelopeClass();
                pEnvelope.PutCoords(pActiveView.Extent.XMin - ((pFeedEnvelope.XMin - pActiveView.Extent.XMin) * (pActiveView.Extent.Width / pFeedEnvelope.Width)),
                    pActiveView.Extent.YMin - ((pFeedEnvelope.YMin - pActiveView.Extent.YMin) * (pActiveView.Extent.Height / pFeedEnvelope.Height)),
                    (pActiveView.Extent.XMin - ((pFeedEnvelope.XMin - pActiveView.Extent.XMin) * (pActiveView.Extent.Width / pFeedEnvelope.Width))) + newWidth,
                    (pActiveView.Extent.YMin - ((pFeedEnvelope.YMin - pActiveView.Extent.YMin) * (pActiveView.Extent.Height / pFeedEnvelope.Height))) + newHeight);
            }
            //获取新的范围
            pActiveView.Extent = pEnvelope;
            //刷新视图
            pActiveView.Refresh();
            m_feedBack = null;
            m_isMouseDown = false;
        }
        #endregion
    }
}
