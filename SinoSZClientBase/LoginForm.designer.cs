namespace SinoSZClientBase
{
        partial class LoginForm
        {
                /// <summary>
                /// Required designer variable.
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                /// <summary>
                /// Clean up any resources being used.
                /// </summary>
                /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
                protected override void Dispose(bool disposing)
                {
                        if (disposing && (components != null))
                        {
                                components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                #region Windows Form Designer generated code

                /// <summary>
                /// Required method for Designer support - do not modify
                /// the contents of this method with the code editor.
                /// </summary>
                private void InitializeComponent()
                {
                    this.components = new System.ComponentModel.Container();
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
                    this.label1 = new System.Windows.Forms.Label();
                    this.label2 = new System.Windows.Forms.Label();
                    this.label3 = new System.Windows.Forms.Label();
                    this.textPass = new DevExpress.XtraEditors.TextEdit();
                    this.bCancel = new DevExpress.XtraEditors.SimpleButton();
                    this.bLogin = new DevExpress.XtraEditors.SimpleButton();
                    this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
                    this.labelMsg = new DevExpress.XtraEditors.LabelControl();
                    this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
                    this.textUser = new DevExpress.XtraEditors.ComboBoxEdit();
                    this.timer1 = new System.Windows.Forms.Timer(this.components);
                    this.pictureBox1 = new System.Windows.Forms.PictureBox();
                    this.bSet = new DevExpress.XtraEditors.SimpleButton();
                    this.panel1 = new System.Windows.Forms.Panel();
                    this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                    this.label4 = new System.Windows.Forms.Label();
                    this.CE_AuthorType = new DevExpress.XtraEditors.ComboBoxEdit();
                    ((System.ComponentModel.ISupportInitialize)(this.textPass.Properties)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this.textUser.Properties)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                    this.panel1.SuspendLayout();
                    ((System.ComponentModel.ISupportInitialize)(this.CE_AuthorType.Properties)).BeginInit();
                    this.SuspendLayout();
                    // 
                    // label1
                    // 
                    this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                    this.label1.BackColor = System.Drawing.Color.Transparent;
                    this.label1.Location = new System.Drawing.Point(287, 129);
                    this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                    this.label1.Name = "label1";
                    this.label1.Size = new System.Drawing.Size(336, 25);
                    this.label1.TabIndex = 1;
                    this.label1.Text = "Version:";
                    this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    // 
                    // label2
                    // 
                    this.label2.AutoSize = true;
                    this.label2.Location = new System.Drawing.Point(320, 180);
                    this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                    this.label2.Name = "label2";
                    this.label2.Size = new System.Drawing.Size(53, 18);
                    this.label2.TabIndex = 2;
                    this.label2.Text = "用户名";
                    // 
                    // label3
                    // 
                    this.label3.AutoSize = true;
                    this.label3.Location = new System.Drawing.Point(321, 214);
                    this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                    this.label3.Name = "label3";
                    this.label3.Size = new System.Drawing.Size(53, 18);
                    this.label3.TabIndex = 4;
                    this.label3.Text = "口   令";
                    this.label3.Click += new System.EventHandler(this.label3_Click);
                    // 
                    // textPass
                    // 
                    this.textPass.Location = new System.Drawing.Point(393, 210);
                    this.textPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                    this.textPass.Name = "textPass";
                    this.textPass.Properties.Appearance.BackColor = System.Drawing.Color.White;
                    this.textPass.Properties.Appearance.Options.UseBackColor = true;
                    this.textPass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                    this.textPass.Properties.PasswordChar = '*';
                    this.textPass.Size = new System.Drawing.Size(196, 25);
                    this.textPass.TabIndex = 1;
                    this.textPass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textPass_KeyUp);
                    // 
                    // bCancel
                    // 
                    this.bCancel.Location = new System.Drawing.Point(539, 0);
                    this.bCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                    this.bCancel.Name = "bCancel";
                    this.bCancel.Size = new System.Drawing.Size(76, 29);
                    this.bCancel.TabIndex = 3;
                    this.bCancel.Text = "取消";
                    this.bCancel.Click += new System.EventHandler(this.simpleButton2_Click);
                    // 
                    // bLogin
                    // 
                    this.bLogin.Location = new System.Drawing.Point(455, 0);
                    this.bLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                    this.bLogin.Name = "bLogin";
                    this.bLogin.Size = new System.Drawing.Size(76, 29);
                    this.bLogin.TabIndex = 2;
                    this.bLogin.Text = "登录";
                    this.bLogin.Click += new System.EventHandler(this.simpleButton1_Click);
                    // 
                    // progressBarControl1
                    // 
                    this.progressBarControl1.Location = new System.Drawing.Point(139, 6);
                    this.progressBarControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                    this.progressBarControl1.Name = "progressBarControl1";
                    this.progressBarControl1.Size = new System.Drawing.Size(269, 19);
                    this.progressBarControl1.TabIndex = 11;
                    this.progressBarControl1.Visible = false;
                    // 
                    // labelMsg
                    // 
                    this.labelMsg.Location = new System.Drawing.Point(21, 8);
                    this.labelMsg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                    this.labelMsg.Name = "labelMsg";
                    this.labelMsg.Size = new System.Drawing.Size(0, 18);
                    this.labelMsg.TabIndex = 12;
                    // 
                    // panelControl1
                    // 
                    this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                    this.panelControl1.Location = new System.Drawing.Point(-9, 279);
                    this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                    this.panelControl1.Name = "panelControl1";
                    this.panelControl1.Size = new System.Drawing.Size(655, 2);
                    this.panelControl1.TabIndex = 13;
                    // 
                    // textUser
                    // 
                    this.textUser.Location = new System.Drawing.Point(393, 176);
                    this.textUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                    this.textUser.Name = "textUser";
                    this.textUser.Properties.Appearance.BackColor = System.Drawing.Color.White;
                    this.textUser.Properties.Appearance.Options.UseBackColor = true;
                    this.textUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                    this.textUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                    this.textUser.Size = new System.Drawing.Size(196, 25);
                    this.textUser.TabIndex = 0;
                    // 
                    // timer1
                    // 
                    this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                    // 
                    // pictureBox1
                    // 
                    this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
                    this.pictureBox1.Image = global::SinoSZClientBase.Properties.Resources.login2;
                    this.pictureBox1.Location = new System.Drawing.Point(0, 0);
                    this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                    this.pictureBox1.Name = "pictureBox1";
                    this.pictureBox1.Size = new System.Drawing.Size(648, 125);
                    this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    this.pictureBox1.TabIndex = 0;
                    this.pictureBox1.TabStop = false;
                    // 
                    // bSet
                    // 
                    this.bSet.Location = new System.Drawing.Point(21, 0);
                    this.bSet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                    this.bSet.Name = "bSet";
                    this.bSet.Size = new System.Drawing.Size(88, 29);
                    this.bSet.TabIndex = 15;
                    this.bSet.Text = "配置参数";
                    this.bSet.Click += new System.EventHandler(this.bSet_Click);
                    // 
                    // panel1
                    // 
                    this.panel1.Controls.Add(this.bCancel);
                    this.panel1.Controls.Add(this.bSet);
                    this.panel1.Controls.Add(this.bLogin);
                    this.panel1.Controls.Add(this.labelMsg);
                    this.panel1.Controls.Add(this.progressBarControl1);
                    this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
                    this.panel1.Location = new System.Drawing.Point(0, 309);
                    this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                    this.panel1.Name = "panel1";
                    this.panel1.Size = new System.Drawing.Size(648, 48);
                    this.panel1.TabIndex = 16;
                    // 
                    // simpleButton1
                    // 
                    this.simpleButton1.Image = global::SinoSZClientBase.Properties.Resources.format1_16x16;
                    this.simpleButton1.Location = new System.Drawing.Point(591, 175);
                    this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                    this.simpleButton1.Name = "simpleButton1";
                    this.simpleButton1.Size = new System.Drawing.Size(32, 30);
                    this.simpleButton1.TabIndex = 17;
                    this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
                    // 
                    // label4
                    // 
                    this.label4.AutoSize = true;
                    this.label4.Location = new System.Drawing.Point(308, 251);
                    this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                    this.label4.Name = "label4";
                    this.label4.Size = new System.Drawing.Size(68, 18);
                    this.label4.TabIndex = 18;
                    this.label4.Text = "登录类型";
                    this.label4.Visible = false;
                    // 
                    // CE_AuthorType
                    // 
                    this.CE_AuthorType.EditValue = "海关员工号";
                    this.CE_AuthorType.Location = new System.Drawing.Point(393, 246);
                    this.CE_AuthorType.Margin = new System.Windows.Forms.Padding(4);
                    this.CE_AuthorType.Name = "CE_AuthorType";
                    this.CE_AuthorType.Properties.Appearance.BackColor = System.Drawing.Color.White;
                    this.CE_AuthorType.Properties.Appearance.Options.UseBackColor = true;
                    this.CE_AuthorType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
                    this.CE_AuthorType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                    this.CE_AuthorType.Properties.Items.AddRange(new object[] {
            "海关员工号",
            "普通表单",
            "域认证",
            "运行网域认证",
            "域和表单组合认证"});
                    this.CE_AuthorType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    this.CE_AuthorType.Size = new System.Drawing.Size(196, 25);
                    this.CE_AuthorType.TabIndex = 19;
                    this.CE_AuthorType.Visible = false;
                    // 
                    // LoginForm
                    // 
                    this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    this.ClientSize = new System.Drawing.Size(648, 357);
                    this.ControlBox = false;
                    this.Controls.Add(this.CE_AuthorType);
                    this.Controls.Add(this.label4);
                    this.Controls.Add(this.simpleButton1);
                    this.Controls.Add(this.panel1);
                    this.Controls.Add(this.textUser);
                    this.Controls.Add(this.panelControl1);
                    this.Controls.Add(this.textPass);
                    this.Controls.Add(this.label3);
                    this.Controls.Add(this.label2);
                    this.Controls.Add(this.label1);
                    this.Controls.Add(this.pictureBox1);
                    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                    this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                    this.Name = "LoginForm";
                    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    this.Text = "系统登录";
                    this.Load += new System.EventHandler(this.LoginForm_Load);
                    ((System.ComponentModel.ISupportInitialize)(this.textPass.Properties)).EndInit();
                    ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
                    ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
                    ((System.ComponentModel.ISupportInitialize)(this.textUser.Properties)).EndInit();
                    ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                    this.panel1.ResumeLayout(false);
                    this.panel1.PerformLayout();
                    ((System.ComponentModel.ISupportInitialize)(this.CE_AuthorType.Properties)).EndInit();
                    this.ResumeLayout(false);
                    this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.PictureBox pictureBox1;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.Label label3;
                private DevExpress.XtraEditors.TextEdit textPass;
                private DevExpress.XtraEditors.SimpleButton bCancel;
                private DevExpress.XtraEditors.SimpleButton bLogin;
                private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
                private DevExpress.XtraEditors.LabelControl labelMsg;
                private DevExpress.XtraEditors.PanelControl panelControl1;
                private DevExpress.XtraEditors.ComboBoxEdit textUser;
                private System.Windows.Forms.Timer timer1;
                private DevExpress.XtraEditors.SimpleButton bSet;
                private System.Windows.Forms.Panel panel1;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
            private System.Windows.Forms.Label label4;
            private DevExpress.XtraEditors.ComboBoxEdit CE_AuthorType;
        }
}