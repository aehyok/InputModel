using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using SinoSZToolInputModelDefine.EditPanel;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZToolInputModelDefine.Dialog
{
	public partial class Dialog_GuideLine : DevExpress.XtraEditors.XtraForm
	{
		private string GuideLineID = "";
		private MD_GuideLine GuideLine = null;
		private UC_GuideLineManager Manager = null;
		public Dialog_GuideLine()
		{
			InitializeComponent();
		}

		public Dialog_GuideLine(string _guideLineID)
		{
			InitializeComponent();
			GuideLineID = _guideLineID;
		}

		private void Dialog_GuideLine_Load(object sender, EventArgs e)
		{
			ShowNodeData();
		}

		private void ShowNodeData()
		{
			if (GuideLineID == "") return;
			GuideLine = DAConfig.DataAccess.GetGuideLineDefine(GuideLineID);
			if (GuideLine != null)
			{
				this.panel1.Controls.Clear();
				Manager = new UC_GuideLineManager(GuideLine);
				Manager.Dock = DockStyle.Fill;
				this.panel1.Controls.Add(Manager);
			}

		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			if (this.GuideLine != null && Manager!=null)
			{
				Manager.Save();
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

	}

}