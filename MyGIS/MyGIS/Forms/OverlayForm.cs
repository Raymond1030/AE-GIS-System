﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Geoprocessing;

namespace MyGIS.Forms
{
    public partial class OverlayForm : Form
    {
        public string strOutputPath;
        public OverlayForm()
        {
            InitializeComponent();
        }

 
        private void OverlayForm_Load(object sender, EventArgs e)
        {
            //加载叠置方式
            this.cboOverLay.Items.Add("求交(Intersect)");
            this.cboOverLay.Items.Add("求并(Union)");
            this.cboOverLay.Items.Add("标识(Identity)");
            this.cboOverLay.SelectedIndex = 0;
            //设置默认输出路径
            string tempDir = @"E:\2019312130130\";
            txtOutputPath.Text = tempDir;

        }

        private void btnInputFeat_Click(object sender, EventArgs e)
        {
            //定义OpenfileDialog
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Shapefile (*.shp)|*.shp";
            openDlg.Title = "选择第一个要素";
            //检验文件和路径是否存在
            openDlg.CheckFileExists = true;
            openDlg.CheckPathExists = true;
            //初试化初试打开路径
            openDlg.InitialDirectory = @"E:\2019312130130\";
            //读取文件路径到txtFeature1中
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtInputFeat.Text = openDlg.FileName;
            }

        }

        private void btnOverlayFeat_Click(object sender, EventArgs e)
        {
            //定义OpenfileDialog
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Shapefile (*.shp)|*.shp";
            openDlg.Title = "选择第二个要素";
            //检验文件和路径是否存在
            openDlg.CheckFileExists = true;
            openDlg.CheckPathExists = true;
            //初试化初试打开路径
            openDlg.InitialDirectory = @"E:\2019312130130\";
            //读取文件路径到txtFeature2中
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtOverlayFeat.Text = openDlg.FileName;
            }

        }

        private void btnOutputLayer_Click(object sender, EventArgs e)
        {
            //定义输出文件路径
            SaveFileDialog saveDlg = new SaveFileDialog();
            //检查路径是否存在
            saveDlg.CheckPathExists = true;
            saveDlg.Filter = "Shapefile (*.shp)|*.shp";
            //保存时覆盖同名文件
            saveDlg.OverwritePrompt = true;
            saveDlg.Title = "输出路径";
            //对话框关闭前还原当前目录
            saveDlg.RestoreDirectory = true;
            saveDlg.FileName = (string)cboOverLay.SelectedItem + ".shp";

            //读取文件输出路径到txtOutputPath
            DialogResult dr = saveDlg.ShowDialog();
            if (dr == DialogResult.OK)
                txtOutputPath.Text = saveDlg.FileName;

        }

        private void btnBuffer_Click(object sender, EventArgs e)
        {
            //判断是否选择要素
            if (this.txtInputFeat.Text == "" || this.txtInputFeat.Text == null ||
                this.txtOverlayFeat.Text == "" || this.txtOverlayFeat.Text == null)
            {
                txtMessage.Text = "请设置叠置要素！";
                return;
            }
            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
            //OverwriteOutput为真时，输出图层会覆盖当前文件夹下的同名图层
            gp.OverwriteOutput = true;


            //设置参与叠置分析的多个对象
            object inputFeat = this.txtInputFeat.Text;
            object overlayFeat = this.txtOverlayFeat.Text;
            IGpValueTableObject pObject = new GpValueTableObjectClass();
            pObject.SetColumns(2);
            pObject.AddRow(ref inputFeat);
            pObject.AddRow(ref overlayFeat);

            //获取要素名称
            string str = System.IO.Path.GetFileName(this.txtInputFeat.Text);
            int index = str.LastIndexOf(".");
            string strName = str.Remove(index);

            //设置输出路径
            strOutputPath = txtOutputPath.Text;

            //叠置分析结果
            IGeoProcessorResult result = null;

            //创建叠置分析实例，执行叠置分析
            string strOverlay = cboOverLay.SelectedItem.ToString();
            try
            {
                //添加处理过程消息
                txtMessage.Text = "开始叠置分析……" + "\r\n";
                switch (strOverlay)
                {
                    case "求交(Intersect)":
                        Intersect intersectTool = new Intersect();
                        //设置输入要素
                        intersectTool.in_features = pObject;
                        //设置输出路径
                        strOutputPath += strName + "_" + "_intersect.shp";
                        intersectTool.out_feature_class = strOutputPath;
                        //执行求交运算
                        result = gp.Execute(intersectTool, null) as IGeoProcessorResult;
                        break;
                    case "求并(Union)":
                        Union unionTool = new Union();
                        //设置输入要素
                        unionTool.in_features = pObject;
                        //设置输出路径
                        strOutputPath += strName + "_" + "_union.shp";
                        unionTool.out_feature_class = strOutputPath;
                        //执行联合运算
                        result = gp.Execute(unionTool, null) as IGeoProcessorResult;
                        break;
                    case "标识(Identity)":
                        Identity identityTool = new Identity();
                        //设置输入要素
                        identityTool.in_features = inputFeat;
                        identityTool.identity_features = overlayFeat;
                        //设置输出路径
                        strOutputPath += strName + "_" + "_identity.shp";
                        identityTool.out_feature_class = strOutputPath;
                        //执行标识运算
                        result = gp.Execute(identityTool, null) as IGeoProcessorResult;
                        break;
                }
            }
            catch (System.Exception ex)
            {
                //添加处理过程消息
                txtMessage.Text += "叠置分析过程出现错误：" + ex.Message + "\r\n";
            }


            //判断叠置分析是否成功
            if (result.Status != ESRI.ArcGIS.esriSystem.esriJobStatus.esriJobSucceeded)
                txtMessage.Text += "叠置失败!";
            else
            {
                this.DialogResult = DialogResult.OK;
                txtMessage.Text += "叠置成功!";
            }

        }
    }
}
