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
using MyGIS.Classes;
namespace MyGIS.Forms
{
    public partial class EditForm : Form
    {
        public Edit mEdit;
        //获取主界面的MapControl对象
        private AxMapControl mMapControl;
        public EditForm(AxMapControl mapControl)
        {
            InitializeComponent();
            this.mMapControl = mapControl;
            mEdit = new Edit();
        }
        private void EditForm_Load(object sender, EventArgs e)
        {   
            //加载编辑任务
            cboTasks.Items.Add("新建");
            cboTasks.Items.Add("移动");
            cboTasks.SelectedIndex = 0;

            //开始编辑之前，将编辑按钮设为不可用
            this.cboTasks.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnStopEditing.Enabled = false;

        }
        private void btnRefreshLayers_Click(object sender, EventArgs e)
        {
            //清空原有选项
            cboLayers.Items.Clear();
            //没有添加图层时返回
            if (this.mMapControl.Map.LayerCount == 0)
            {
                MessageBox.Show("MapControl中未添加图层！", "提示");
                return;
            }
            //加载图层
            for (int i = 0; i < this.mMapControl.Map.LayerCount; i++)
            {
                ILayer pLayer = this.mMapControl.get_Layer(i);
                cboLayers.Items.Add(pLayer.Name);
            }
            this.mMapControl.Refresh();
            cboLayers.SelectedIndex = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //判断编辑是否初始化
            if (mEdit == null)
                return;
            //处于编辑状态且已编辑则保存
            if (mEdit.IsEditing() && mEdit.HasEdited())
            {
                mEdit.SaveEditing(true);
            }
        }

        private void btnStartEditing_Click(object sender, EventArgs e)
        {
            //判断是否存在可编辑图层
            if (this.mMapControl.Map.LayerCount == 0)
                return;
            if (this.cboLayers.Items.Count == 0)
            {
                MessageBox.Show("请选择要编辑的图层", "提示");
                return;
            }

            //获取编辑图层
            IMap pMap = this.mMapControl.Map;
            IFeatureLayer pFeatureLayer = this.mMapControl.get_Layer(cboLayers.SelectedIndex) as IFeatureLayer;
            //初始化编辑
            if (mEdit == null)
            {
                mEdit = new Edit(pFeatureLayer, pMap);
            }
            else
            {
                mEdit.pushLayerAndMap(pFeatureLayer, pMap);
            }
            //开始编辑
            mEdit.StartEditing();
            //开始编辑设为不可用，将其他编辑按钮设为可用
            this.btnStartEditing.Enabled = false;
            this.cboTasks.Enabled = true;
            this.btnStopEditing.Enabled = true;
            this.btnSave.Enabled = true;

        }

        private void btnStopEditing_Click(object sender, EventArgs e)
        {

            if (mEdit == null)
                return;
            if (mEdit.HasEdited())
            {
                DialogResult dr = MessageBox.Show("图层已编辑，是否保存？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                    mEdit.StopEditing(true);
                else
                    mEdit.StopEditing(false);
            }
            this.Dispose();
        }

       

    
    }
}
