using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.InputModel;

namespace SinoSZToolInputModelDefine.Dialog
{
	public partial class Dialog_AddChildModel : DevExpress.XtraEditors.XtraForm
	{
		public Dialog_AddChildModel()
		{
			InitializeComponent();
		}
		private MD_InputModel childModel = null;

		public MD_InputModel ChildModel
		{
			get { return childModel; }
			set { childModel = value; }
		}

		public string ChildModelName
		{
			get
			{
				if (this.textEdit1.EditValue == null) return "";
				return this.textEdit1.EditValue.ToString().Trim();
			}
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			if (this.ChildModelName == "")
			{
				XtraMessageBox.Show("请输入子录入模型的名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			string[] _cns  = this.ChildModelName.Split('.');
			if (_cns.Length < 2)
			{
				XtraMessageBox.Show("录入模型的名称不正确！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			ChildModel = DAConfig.DataAccess.GetInputModel(_cns[0], _cns[1]);
			if (ChildModel == null)
			{
				XtraMessageBox.Show("此录入模型不存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (ChildModel.ModelType == "MIX")
			{
				XtraMessageBox.Show("子录入模型不可以为MIX类型！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}