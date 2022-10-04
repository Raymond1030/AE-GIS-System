using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace MyGIS.Forms
{
    public partial class AttributeQueryForm : Form
    {

        //地图数据
        private AxMapControl mMapControl;
        //选中图层
        private IFeatureLayer mFeatureLayer;
   

        public AttributeQueryForm(AxMapControl mapControl)
        {
            InitializeComponent();
            this.mMapControl = mapControl;
        }
        //获取图层名称
        private void AttributeQueryForm_Load(object sender, EventArgs e)
        {
            //MapControl中没有图层时返回
            if (this.mMapControl.LayerCount <= 0)
                return;

            //获取MapControl中的全部图层名称，并加入ComboBox
            //图层
            ILayer pLayer;
            //图层名称
            string strLayerName;
            for (int i = 0; i < this.mMapControl.LayerCount; i++)
            {
                pLayer = this.mMapControl.get_Layer(i);
                strLayerName = pLayer.Name;
                //图层名称加入cboLayer
                this.cboLayer.Items.Add(strLayerName);
            }
            //默认显示第一个选项
            this.cboLayer.SelectedIndex = 0;

        }
        
        //图层发生改变重新获取
        private void cboLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取cboLayer中选中的图层
            mFeatureLayer = mMapControl.get_Layer(cboLayer.SelectedIndex) as IFeatureLayer;
            IFeatureClass pFeatureClass = mFeatureLayer.FeatureClass;
            //字段名称
            string strFldName;
            for (int i = 0; i < pFeatureClass.Fields.FieldCount; i++)
            {
                strFldName = pFeatureClass.Fields.get_Field(i).Name;
                //图层名称加入cboField
                this.cboField.Items.Add(strFldName);
            }
            //默认显示第一个选项
            this.cboField.SelectedIndex = 0;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //获取cboLayer中选中的图层
            mFeatureLayer = mMapControl.get_Layer(cboLayer.SelectedIndex) as IFeatureLayer;
            //查找内容为空时返回
            if (txtValue.Text == null)
                return;
            IQueryFilter pQueryFilter = new QueryFilterClass();
            IFeatureCursor pFeatureCursor;
            IFeature pFeature;
            //pQueryFilter.WhereClause = cboField.Text + "=" + txtValue.Text.ToString()
            int tmp;
            if (int.TryParse(txtValue.Text,out tmp))
            {
                pQueryFilter.WhereClause = cboField.Text + "=" + txtValue.Text.ToString();
                //MessageBox.Show("查询" + cboField.Text + "=" + txtValue.Text + "提示");
            }
            else
            {
                  pQueryFilter.WhereClause = cboField.Text + "='" + txtValue.Text + "'"; ;
            }
          
            //MessageBox.Show("查询" + cboField.Text+"="+txtValue.Text+"提示");
            pFeatureCursor = mFeatureLayer.Search(pQueryFilter, true);
            pFeature = pFeatureCursor.NextFeature();

            //判断是否获取到要素
            if (pFeature != null)
            {
                //选择要素
                mMapControl.Map.SelectFeature(mFeatureLayer, pFeature);
                //放大到要素
                mMapControl.Extent = pFeature.Shape.Envelope;
            }
            else
            {
                //没有得到pFeature的提示
                MessageBox.Show("没有找到" + txtValue.Text + "。", "提示");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
