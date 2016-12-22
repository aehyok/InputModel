using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZBaseClass.Authorize;
using SinoSZBaseClass.Misc;
using System.Configuration;

namespace SinoSZClientBase
{
        public partial class frmSetParameter : DevExpress.XtraEditors.XtraForm
        {
                public frmSetParameter()
                {
                        InitializeComponent();
                }

                private void bCancel_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void bLogin_Click(object sender, EventArgs e)
                {
                        Configuration configuration = null;                 //Configuration对象
                        AppSettingsSection appSection = null;               //AppSection对象 

                        configuration = ConfigurationManager.OpenExeConfiguration(Utils.ExeFullPath);

                        //取得AppSetting节
                        appSection = configuration.AppSettings;

                        //赋值并保存
                        appSection.Settings["LiveUpdate_SvrInfoUrl"].Value = this.te_liveupdate.EditValue.ToString();
                        appSection.Settings["ICS_UriPrefix_TCP"].Value = this.te_tcpaddr.EditValue.ToString();
                        appSection.Settings["ICS_UriPrefix_HTTP"].Value = this.te_httpaddr.EditValue.ToString();
                        appSection.Settings["ICS_Channel"].Value = (this.te_type.EditValue == null) ? "TCP" : this.te_type.EditValue.ToString();
                        appSection.Settings["ICS_Compress"].Value = this.ck_compress.Checked ? "YES" : "NO";
                        configuration.Save();

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }

                public void InitData()
                {
                        this.te_type.Properties.Items.Add(Config_IcsChannel.Tcp);
                        this.te_type.Properties.Items.Add(Config_IcsChannel.Http);
                        this.te_type.EditValue = ConfigFile.ICS_Channel;
                        this.ck_compress.Checked = ConfigFile.ICS_Compress;
                        this.te_tcpaddr.EditValue = ConfigFile.ICS_UriPrefix_TCP;
                        this.te_httpaddr.EditValue = ConfigFile.ICS_UriPrefix_HTTP;
                        this.te_liveupdate.EditValue = ConfigFile.LiveUpdate_SvrInfoUrl;

                }
        }
}