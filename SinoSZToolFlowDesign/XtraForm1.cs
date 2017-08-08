using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZToolFlowDesign.DAL;
using SinoSZToolFlowDesign.BLL;
using SinoSZToolFlowDesign.Interface;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZToolFlowDesign
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public string ConnectStringSetting = "";
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }


        }

        private bool CheckInput()
        {
            switch (this.comboBoxEdit1.SelectedIndex)
            {
                case 0:
                    return CheckAccess();

                case 1:
                    return CheckOracle();
            }

            return false;
        }

        private bool CheckOracle()
        {
            if (this.te_ora_netserive.EditValue == null || this.te_ora_netserive.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("请输入Oracle的服务名！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (this.te_ora_user.EditValue == null || this.te_ora_user.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("请输入Oracle的用户名！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (this.te_ora_pass.EditValue == null || this.te_ora_pass.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("请输入用户的口令！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //string _cnString = string.Format("user id={0};data source={2};password={1};", this.te_ora_user.EditValue, this.te_ora_pass.EditValue, this.te_ora_netserive.EditValue);
            string _cnString = @"Data Source =.;Initial Catalog = ZHXTV3META;Integrated Security = SSPI;";
            if (SqlHelper.IsReady(_cnString))
            {
                ConnectStringSetting = _cnString;

                DA_FlowDefine _da = new DA_FlowDefine(_cnString);
                Biz_FlowProperties.FlowInterface = _da as ICS_Flow;
                return true;
            }
            else
            {
                XtraMessageBox.Show("数据库连接失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private bool CheckAccess()
        {
            if (this.te_mdb_file.EditValue == null || this.te_mdb_file.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("请输入MDB的文件！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            string _cnString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", this.te_mdb_file.EditValue);


            if (this.te_mdb_user.EditValue == null || this.te_mdb_user.EditValue.ToString() == "")
            {
                _cnString += "User Id=;Password=; ";
            }
            else
            {
                _cnString += string.Format("User Id={0};Password={1}; ", this.te_mdb_user.EditValue, (this.te_mdb_pass.EditValue == null) ? "" : this.te_mdb_pass.EditValue.ToString());
            }
            string _errmsg = "";
            if (DA_FlowDefine_Accesss.IsReady(_cnString, ref _errmsg))
            {
                ConnectStringSetting = _cnString;

                DA_FlowDefine_Accesss _da = new DA_FlowDefine_Accesss(_cnString);
                Biz_FlowProperties.FlowInterface = _da as ICS_Flow;
                return true;
            }
            else
            {
                XtraMessageBox.Show(string.Format("数据库连接失败！{0}", _errmsg), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBoxEdit1.SelectedIndex)
            {
                case 0:
                    this.panel_Access.Visible = true;
                    this.panelOracle.Visible = false;
                    break;
                case 1:
                    this.panel_Access.Visible = false;
                    this.panelOracle.Visible = true;
                    break;
            }
        }
    }
}