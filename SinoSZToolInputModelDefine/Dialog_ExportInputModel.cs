using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SinoSZJS.Base.InputModel;
using SinoSZJS.CS.BizMetaDataManager.DAL;

namespace SinoSZToolInputModelDefine
{
	public partial class Dialog_ExportInputModel : DevExpress.XtraEditors.XtraForm
	{
		private MD_InputModel InputModel = null;
		public Dialog_ExportInputModel()
		{
			InitializeComponent();
		}

		public Dialog_ExportInputModel(MD_InputModel _model)
		{
			InitializeComponent();
			InputModel = _model;
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{
			if (this.buttonEdit1.EditValue.ToString() != "")
			{
				OraMetaDataFactroy _of = new OraMetaDataFactroy();
				DataSet ExData = _of.GetInputModelDefineData(InputModel.ID);

				string _fname = this.buttonEdit1.EditValue.ToString();
				ExData.WriteXml(_fname, XmlWriteMode.WriteSchema);

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				XtraMessageBox.Show("请选择导出文件名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			SaveFileDialog _sf = new SaveFileDialog();
			_sf.Filter = "备份文件|*.XML";
			_sf.FilterIndex = 1;
			if (_sf.ShowDialog() == DialogResult.OK)
			{
				this.buttonEdit1.EditValue = _sf.FileName;
			}
		}


	}
}