namespace SinoSZClientBase
{
        partial class frmSetParameter
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
                        this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
                        this.bLogin = new DevExpress.XtraEditors.SimpleButton();
                        this.bCancel = new DevExpress.XtraEditors.SimpleButton();
                        this.label1 = new System.Windows.Forms.Label();
                        this.te_type = new DevExpress.XtraEditors.ComboBoxEdit();
                        this.ck_compress = new DevExpress.XtraEditors.CheckEdit();
                        this.label2 = new System.Windows.Forms.Label();
                        this.te_tcpaddr = new DevExpress.XtraEditors.TextEdit();
                        this.label3 = new System.Windows.Forms.Label();
                        this.te_httpaddr = new DevExpress.XtraEditors.TextEdit();
                        this.label4 = new System.Windows.Forms.Label();
                        this.te_liveupdate = new DevExpress.XtraEditors.TextEdit();
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_type.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.ck_compress.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_tcpaddr.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_httpaddr.Properties)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_liveupdate.Properties)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // panelControl1
                        // 
                        this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                        this.panelControl1.Location = new System.Drawing.Point(-1, 205);
                        this.panelControl1.Name = "panelControl1";
                        this.panelControl1.Size = new System.Drawing.Size(650, 2);
                        this.panelControl1.TabIndex = 16;
                        // 
                        // bLogin
                        // 
                        this.bLogin.Location = new System.Drawing.Point(463, 222);
                        this.bLogin.Name = "bLogin";
                        this.bLogin.Size = new System.Drawing.Size(64, 23);
                        this.bLogin.TabIndex = 15;
                        this.bLogin.Text = "保存参数";
                        this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
                        // 
                        // bCancel
                        // 
                        this.bCancel.Location = new System.Drawing.Point(533, 222);
                        this.bCancel.Name = "bCancel";
                        this.bCancel.Size = new System.Drawing.Size(57, 23);
                        this.bCancel.TabIndex = 14;
                        this.bCancel.Text = "取消";
                        this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
                        // 
                        // label1
                        // 
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(24, 28);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(79, 14);
                        this.label1.TabIndex = 17;
                        this.label1.Text = "使用通道类型";
                        // 
                        // te_type
                        // 
                        this.te_type.Location = new System.Drawing.Point(109, 25);
                        this.te_type.Name = "te_type";
                        this.te_type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                        this.te_type.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                        this.te_type.Size = new System.Drawing.Size(166, 21);
                        this.te_type.TabIndex = 18;
                        // 
                        // ck_compress
                        // 
                        this.ck_compress.Location = new System.Drawing.Point(318, 26);
                        this.ck_compress.Name = "ck_compress";
                        this.ck_compress.Properties.Caption = "传输数据压缩";
                        this.ck_compress.Size = new System.Drawing.Size(106, 19);
                        this.ck_compress.TabIndex = 19;
                        // 
                        // label2
                        // 
                        this.label2.AutoSize = true;
                        this.label2.Location = new System.Drawing.Point(26, 63);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(77, 14);
                        this.label2.TabIndex = 20;
                        this.label2.Text = "TCP通道地址";
                        // 
                        // te_tcpaddr
                        // 
                        this.te_tcpaddr.Location = new System.Drawing.Point(109, 60);
                        this.te_tcpaddr.Name = "te_tcpaddr";
                        this.te_tcpaddr.Size = new System.Drawing.Size(481, 21);
                        this.te_tcpaddr.TabIndex = 21;
                        // 
                        // label3
                        // 
                        this.label3.AutoSize = true;
                        this.label3.Location = new System.Drawing.Point(17, 96);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(86, 14);
                        this.label3.TabIndex = 22;
                        this.label3.Text = "HTTP通道地址";
                        // 
                        // te_httpaddr
                        // 
                        this.te_httpaddr.Location = new System.Drawing.Point(109, 93);
                        this.te_httpaddr.Name = "te_httpaddr";
                        this.te_httpaddr.Size = new System.Drawing.Size(481, 21);
                        this.te_httpaddr.TabIndex = 23;
                        // 
                        // label4
                        // 
                        this.label4.AutoSize = true;
                        this.label4.Location = new System.Drawing.Point(24, 130);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(79, 14);
                        this.label4.TabIndex = 24;
                        this.label4.Text = "自动更新地址";
                        // 
                        // te_liveupdate
                        // 
                        this.te_liveupdate.Location = new System.Drawing.Point(109, 127);
                        this.te_liveupdate.Name = "te_liveupdate";
                        this.te_liveupdate.Size = new System.Drawing.Size(481, 21);
                        this.te_liveupdate.TabIndex = 25;
                        // 
                        // frmSetParameter
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(617, 257);
                        this.Controls.Add(this.te_liveupdate);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.te_httpaddr);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.te_tcpaddr);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.ck_compress);
                        this.Controls.Add(this.te_type);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.panelControl1);
                        this.Controls.Add(this.bLogin);
                        this.Controls.Add(this.bCancel);
                        this.Name = "frmSetParameter";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "配置系统参数";
                        ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_type.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.ck_compress.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_tcpaddr.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_httpaddr.Properties)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.te_liveupdate.Properties)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private DevExpress.XtraEditors.PanelControl panelControl1;
                private DevExpress.XtraEditors.SimpleButton bLogin;
                private DevExpress.XtraEditors.SimpleButton bCancel;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.ComboBoxEdit te_type;
                private DevExpress.XtraEditors.CheckEdit ck_compress;
                private System.Windows.Forms.Label label2;
                private DevExpress.XtraEditors.TextEdit te_tcpaddr;
                private System.Windows.Forms.Label label3;
                private DevExpress.XtraEditors.TextEdit te_httpaddr;
                private System.Windows.Forms.Label label4;
                private DevExpress.XtraEditors.TextEdit te_liveupdate;
        }
}