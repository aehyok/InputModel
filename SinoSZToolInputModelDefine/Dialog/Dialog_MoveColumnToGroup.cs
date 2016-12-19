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
        public partial class Dialog_MoveColumnToGroup : DevExpress.XtraEditors.XtraForm
        {
                public Dialog_MoveColumnToGroup()
                {
                        InitializeComponent();
                }

                public Dialog_MoveColumnToGroup(List<MD_InputModel_ColumnGroup> groups, MD_InputModel_Column _col)
                {
                        InitializeComponent();
                        this.comboBoxEdit1.Properties.Items.Clear();
                        this.comboBoxEdit1.Properties.Items.Add(new MD_InputModel_ColumnGroup("0", "", "未分组", 0));
                        foreach (MD_InputModel_ColumnGroup _g in groups)
                        {

                                this.comboBoxEdit1.Properties.Items.Add(_g);
                        }
                }

                public MD_InputModel_ColumnGroup SelectedGroup
                {
                        get
                        {
                                if (this.comboBoxEdit1.SelectedItem == null) return null;
                                return this.comboBoxEdit1.SelectedItem as MD_InputModel_ColumnGroup;

                        }
                }
                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        if (this.comboBoxEdit1.SelectedItem != null)
                        {
                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                        }
                        else
                        {
                                XtraMessageBox.Show("请选择一个分组！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }

            
        }
}