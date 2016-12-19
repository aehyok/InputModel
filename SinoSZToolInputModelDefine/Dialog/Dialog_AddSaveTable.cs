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
        public partial class Dialog_AddSaveTable : DevExpress.XtraEditors.XtraForm
        {
                public Dialog_AddSaveTable()
                {
                        InitializeComponent();
                }

                public string TableName
                {
                        get
                        {
                                if (this.buttonEdit1.EditValue == null) return "";
                                return this.buttonEdit1.EditValue.ToString().ToUpper();
                        }
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        if (this.TableName == "")
                        {
                                XtraMessageBox.Show("请输入表名称!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        if (DAConfig.DataAccess.OracleTableExist(this.TableName))
                        {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                        }
                        else
                        {
                                XtraMessageBox.Show("数据库中不存在此表!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                }

        }
}