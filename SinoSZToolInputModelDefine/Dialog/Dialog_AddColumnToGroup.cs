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
        public partial class Dialog_AddColumnToGroup : DevExpress.XtraEditors.XtraForm
        {
                public Dialog_AddColumnToGroup()
                {
                        InitializeComponent();
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                public string ColumnName
                {
                        get
                        {
                                if (this.textEdit1.EditValue == null) return "";
                                return this.textEdit1.EditValue.ToString().Trim().ToUpper();
                        }
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        if (this.textEdit1.EditValue != null && this.textEdit1.EditValue.ToString().Trim() != "")
                        {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                        }
                        else
                        {
                                XtraMessageBox.Show("请输入字段名!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                        }
                }
        }
}