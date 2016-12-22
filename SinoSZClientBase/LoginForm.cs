using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Collections;
using System.IO;
using System.Configuration;
using SinoSZBaseClass.Authorize;
using SinoSZBaseClass.Misc;
using System.Runtime.Remoting.Messaging;



namespace SinoSZClientBase
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private int loginTimes = 0;
        private Thread initThread;
        private const string _schemaFile = "UserHistory.xml";
        private D_UserHistory _UserDs = new D_UserHistory();


        public LoginForm()
        {
            InitializeComponent();

        }

        public LoginForm(string _caption)
        {
            InitializeComponent();
            this.Text = _caption;
            initForm();
        }

        public LoginForm(string _caption, bool ShowAuthor)
        {
            InitializeComponent();
            this.Text = _caption;
            this.label4.Visible = ShowAuthor;
            this.CE_AuthorType.Visible = ShowAuthor;
            initForm();
        }

        public LoginForm(string _caption, Image _img)
        {
            InitializeComponent();
            this.Text = _caption;
            this.pictureBox1.Image = _img;
            initForm();
        }

        public LoginForm(string _caption, Image _img, bool ShowAuthor)
        {
            InitializeComponent();
            this.Text = _caption;
            this.pictureBox1.Image = _img;
            this.label4.Visible = ShowAuthor;
            this.CE_AuthorType.Visible = ShowAuthor;
            initForm();
        }

        public LoginForm(string _caption, string _fileName)
        {
            InitializeComponent();
            this.Text = _caption;
            if (File.Exists(_fileName))
            {
                Image _img = Image.FromFile(_fileName);
                this.pictureBox1.Image = _img;
            }
            initForm();
        }

        public LoginForm(string _caption, string _fileName, bool ShowAuthor)
        {
            InitializeComponent();
            this.Text = _caption;
            if (File.Exists(_fileName))
            {
                Image _img = Image.FromFile(_fileName);
                this.pictureBox1.Image = _img;
            }
            this.label4.Visible = ShowAuthor;
            this.CE_AuthorType.Visible = ShowAuthor;
            initForm();
        }

        private void initForm()
        {

            if (File.Exists(_schemaFile))
            {
                _UserDs.ReadXml(_schemaFile, XmlReadMode.Auto);
                foreach (DataRow _row in _UserDs.User)
                {
                    textUser.Properties.Items.Add(_row["Username"].ToString());
                }
            }

            if (SessionClass.SysAssemblyName != null)
            {
                this.label1.Text = string.Format("Version:{0}", SessionClass.SysAssemblyName.Version.ToString());
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            onClickEnter();
        }

        private void onClickEnter()
        {
            if (CheckInput())
            {
                textUser.Enabled = false;
                textPass.Enabled = false;
                this.labelMsg.Visible = true;
                this.labelMsg.Text = "正在连接服务器";
                this.progressBarControl1.Visible = true;
                this.progressBarControl1.EditValue = 0;
                this.bLogin.Visible = false;
                this.bSet.Visible = false;

                this.Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                initThread = new Thread(new ThreadStart(Login));
                initThread.IsBackground = true;
                initThread.Start();
            }
            else
            {
                XtraMessageBox.Show("请输入用户名和口令!");
            }
        }

        private bool CheckInput()
        {
            if (textUser.EditValue == null || textPass.EditValue == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public void Login()
        {
            try
            {
                string ls_name = textUser.EditValue.ToString().Trim();
                string ls_pass = textPass.EditValue.ToString();
                string ls_type = this.CE_AuthorType.EditValue.ToString();

                #region 取数据接口
                IAuthorize _authService = LoginConfig.GetAuthorizeInterface();
                if (_authService == null)
                {
                    throw new Exception("未找到服务器端登录服务!");
                }

                #endregion
                SinoUser _su = _authService.LoginSys(ConfigFile.SystemID, ls_name, ls_pass,ls_type);
                if (_su != null)
                {
                    SessionClass.CurrentLogonName = ls_name;
                    SessionClass.CurrentLogonPass = ls_pass;
                    SessionClass.CurrentSinoUser = _su;
                    SessionClass.CurrentTicket = new SinoSZTicketInfo(_su.LoginName, _su.IPAddress, _su.EncryptedTicket);
                    SessionClass.ServerConfigData = _authService.GetServerConfig();
                    DataRow[] _drs = _UserDs.User.Select(string.Format("Username='{0}'", ls_name));
                    if (_drs.Length == 0)
                    {
                        DataRow row = _UserDs.User.NewRow();
                        row["Username"] = ls_name;
                        _UserDs.User.Rows.Add(row);
                        _UserDs.WriteXml(_schemaFile, XmlWriteMode.IgnoreSchema);
                    }

                    _su.DwID = _su.CurrentPost.PostDwID;

                    loginTimes = 0;
                    System.ComponentModel.ISynchronizeInvoke synchronizer = this;
                    MethodInvoker invoker = new MethodInvoker(LoginSuccess);
                    synchronizer.Invoke(invoker, null);
                }
                else
                {
                    XtraMessageBox.Show("用户名/口令不正确或过期！", "系统提示");
                    System.ComponentModel.ISynchronizeInvoke synchronizer = this;
                    MethodInvoker invoker = new MethodInvoker(ResetForm);
                    synchronizer.Invoke(invoker, null);
                }


                loginTimes++;

                if (loginTimes > 2)
                {
                    System.ComponentModel.ISynchronizeInvoke synchronizer = this;
                    MethodInvoker invoker = new MethodInvoker(CancelApplicaton);
                    synchronizer.Invoke(invoker, null);
                }
            }
            catch (Exception e)
            {
                ShowMessageDelegate showProgress = new ShowMessageDelegate(ShowMessage);
                string _msg = string.Format("发生错误:{0}", e.Message);
                this.Invoke(showProgress, new object[] { _msg });

            }
        }

        /// <summary>
        /// 显示错误信息委托声明
        /// </summary>
        /// <param name="_msg"></param>
        delegate void ShowMessageDelegate(string _msg);

        private void ShowMessage(string _msg)
        {
            textUser.Enabled = true;
            textPass.Enabled = true;
            this.labelMsg.Visible = false;
            this.progressBarControl1.Visible = false;
            this.bLogin.Visible = true;
            this.bSet.Visible = true;
            this.Cursor = Cursors.Default;
            this.timer1.Enabled = false;
            XtraMessageBox.Show(_msg, "系统提示");
        }

        private void LoginSuccess()
        {
            loginTimes = 0;
            this.timer1.Enabled = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelApplicaton()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            Application.Exit();
        }

        private void ResetForm()
        {

            textUser.Enabled = true;
            textPass.Enabled = true;
            this.labelMsg.Visible = false;
            this.progressBarControl1.Visible = false;
            this.bLogin.Visible = true;
            this.bSet.Visible = true;
            this.textPass.EditValue = "";
            this.Cursor = Cursors.Default;
            this.timer1.Enabled = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBarControl1.Increment(5);
            if ((int)this.progressBarControl1.EditValue > 95) this.progressBarControl1.EditValue = 0;
            Application.DoEvents();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            loginTimes = 0;
            ResetForm();
        }

        private void textPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                onClickEnter();
            }
        }

        private void bSet_Click(object sender, EventArgs e)
        {
            //配置参数
            frmSetParameter _f = new frmSetParameter();
            _f.InitData();
            if (_f.ShowDialog() == DialogResult.OK)
            {
                XtraMessageBox.Show("系统参数修改成功!请退出后重新运行程序!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                Application.Exit();
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            _UserDs.User.Clear();
            _UserDs.WriteXml(_schemaFile, XmlWriteMode.IgnoreSchema);
            textUser.Properties.Items.Clear();
        }

    }
}