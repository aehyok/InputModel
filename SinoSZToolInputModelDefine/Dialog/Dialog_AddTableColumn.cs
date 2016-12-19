using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SinoSZToolInputModelDefine.Dialog
{
	public partial class Dialog_AddTableColumn : DevExpress.XtraEditors.XtraForm
	{
		public Dialog_AddTableColumn()
		{
			InitializeComponent();
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		public string FieldName
		{
			get
			{
				if (this.textEdit1.EditValue == null) return "";
				return this.textEdit1.EditValue.ToString().ToUpper();
			}
		}

		public string FieldType
		{
			get
			{
				if (this.comboBoxEdit1.EditValue == null) return "";
				return this.comboBoxEdit1.EditValue.ToString().ToUpper();
			}
		}

		public int FieldLength
		{
			get
			{
				if (this.textEdit2.EditValue == null) return 0;
				try
				{
					return int.Parse(this.textEdit2.EditValue.ToString());
				}
				catch
				{
					return 0;
				}
			}
		}


		private void simpleButton1_Click(object sender, EventArgs e)
		{
			if (FieldName == "")
			{
				XtraMessageBox.Show("请输入添加的字段名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (FieldType == "")
			{
				XtraMessageBox.Show("请选择字段类型！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (FieldType == "VARCHAR2" && FieldLength < 1)
			{
				XtraMessageBox.Show("请字段长度设置不正确！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			this.DialogResult = DialogResult.OK;
			this.Close();

		}

		private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBoxEdit1.SelectedIndex == 0)
			{
				this.textEdit2.Enabled = true;
			}
			else
			{
				this.textEdit2.Enabled = false;
			}


		}



		public string GetDataType()
		{
			if (FieldType == "") return "";
			if (FieldType == "VARCHAR2")
			{
				return string.Format("VARCHAR2({0})", this.FieldLength);
			}
			return FieldType;
		}
	}
}