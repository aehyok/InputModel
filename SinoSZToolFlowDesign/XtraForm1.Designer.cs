namespace SinoSZToolFlowDesign
{
        partial class XtraForm1
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel_Access = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.te_mdb_file = new DevExpress.XtraEditors.ButtonEdit();
            this.te_mdb_user = new DevExpress.XtraEditors.TextEdit();
            this.te_mdb_pass = new DevExpress.XtraEditors.TextEdit();
            this.panelOracle = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.te_ora_user = new DevExpress.XtraEditors.TextEdit();
            this.te_ora_pass = new DevExpress.XtraEditors.TextEdit();
            this.te_ora_netserive = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel_Access.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.te_mdb_file.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_mdb_user.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_mdb_pass.Properties)).BeginInit();
            this.panelOracle.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.te_ora_user.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_ora_pass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_ora_netserive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "数据库类型";
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.EditValue = "Access";
            this.comboBoxEdit1.Location = new System.Drawing.Point(94, 12);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "Access",
            "Oracle"});
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new System.Drawing.Size(198, 20);
            this.comboBoxEdit1.TabIndex = 1;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panel_Access);
            this.panelControl1.Controls.Add(this.panelOracle);
            this.panelControl1.Location = new System.Drawing.Point(15, 51);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panelControl1.Size = new System.Drawing.Size(287, 101);
            this.panelControl1.TabIndex = 2;
            // 
            // panel_Access
            // 
            this.panel_Access.Controls.Add(this.tableLayoutPanel1);
            this.panel_Access.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Access.Location = new System.Drawing.Point(8, 8);
            this.panel_Access.Name = "panel_Access";
            this.panel_Access.Size = new System.Drawing.Size(271, 85);
            this.panel_Access.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.te_mdb_file, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.te_mdb_user, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.te_mdb_pass, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(271, 85);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(3, 62);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 16);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "密码";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(3, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "数据文件";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(3, 34);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "用户名";
            // 
            // te_mdb_file
            // 
            this.te_mdb_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.te_mdb_file.EditValue = "Data_Source\\FlowData.mdb";
            this.te_mdb_file.Location = new System.Drawing.Point(73, 4);
            this.te_mdb_file.Name = "te_mdb_file";
            this.te_mdb_file.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.te_mdb_file.Size = new System.Drawing.Size(195, 20);
            this.te_mdb_file.TabIndex = 4;
            // 
            // te_mdb_user
            // 
            this.te_mdb_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.te_mdb_user.Location = new System.Drawing.Point(73, 32);
            this.te_mdb_user.Name = "te_mdb_user";
            this.te_mdb_user.Size = new System.Drawing.Size(195, 20);
            this.te_mdb_user.TabIndex = 5;
            // 
            // te_mdb_pass
            // 
            this.te_mdb_pass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.te_mdb_pass.Location = new System.Drawing.Point(73, 60);
            this.te_mdb_pass.Name = "te_mdb_pass";
            this.te_mdb_pass.Properties.PasswordChar = '*';
            this.te_mdb_pass.Size = new System.Drawing.Size(195, 20);
            this.te_mdb_pass.TabIndex = 6;
            // 
            // panelOracle
            // 
            this.panelOracle.Controls.Add(this.tableLayoutPanel2);
            this.panelOracle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOracle.Location = new System.Drawing.Point(8, 8);
            this.panelOracle.Name = "panelOracle";
            this.panelOracle.Size = new System.Drawing.Size(271, 85);
            this.panelOracle.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.labelControl5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelControl6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.te_ora_user, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.te_ora_pass, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.te_ora_netserive, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(271, 85);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(3, 62);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 16);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "密码";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(3, 6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(76, 16);
            this.labelControl6.TabIndex = 1;
            this.labelControl6.Text = "NET服务名";
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Location = new System.Drawing.Point(3, 34);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(76, 16);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "用户名";
            // 
            // te_ora_user
            // 
            this.te_ora_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.te_ora_user.Location = new System.Drawing.Point(85, 32);
            this.te_ora_user.Name = "te_ora_user";
            this.te_ora_user.Size = new System.Drawing.Size(183, 20);
            this.te_ora_user.TabIndex = 5;
            // 
            // te_ora_pass
            // 
            this.te_ora_pass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.te_ora_pass.Location = new System.Drawing.Point(85, 60);
            this.te_ora_pass.Name = "te_ora_pass";
            this.te_ora_pass.Properties.PasswordChar = '*';
            this.te_ora_pass.Size = new System.Drawing.Size(183, 20);
            this.te_ora_pass.TabIndex = 6;
            // 
            // te_ora_netserive
            // 
            this.te_ora_netserive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.te_ora_netserive.Location = new System.Drawing.Point(85, 4);
            this.te_ora_netserive.Name = "te_ora_netserive";
            this.te_ora_netserive.Size = new System.Drawing.Size(183, 20);
            this.te_ora_netserive.TabIndex = 7;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(181, 177);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(57, 27);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "连接";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(245, 177);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(57, 27);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 211);
            this.ControlBox = false;
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.labelControl1);
            this.Name = "XtraForm1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "连接数据库";
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel_Access.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.te_mdb_file.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_mdb_user.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_mdb_pass.Properties)).EndInit();
            this.panelOracle.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.te_ora_user.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_ora_pass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_ora_netserive.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

                }

                #endregion

                private DevExpress.XtraEditors.LabelControl labelControl1;
                private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
                private DevExpress.XtraEditors.PanelControl panelControl1;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private System.Windows.Forms.Panel panel_Access;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private DevExpress.XtraEditors.LabelControl labelControl4;
                private DevExpress.XtraEditors.LabelControl labelControl2;
                private DevExpress.XtraEditors.LabelControl labelControl3;
                private DevExpress.XtraEditors.ButtonEdit te_mdb_file;
                private DevExpress.XtraEditors.TextEdit te_mdb_user;
                private DevExpress.XtraEditors.TextEdit te_mdb_pass;
                private System.Windows.Forms.Panel panelOracle;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
                private DevExpress.XtraEditors.LabelControl labelControl5;
                private DevExpress.XtraEditors.LabelControl labelControl6;
                private DevExpress.XtraEditors.LabelControl labelControl7;
                private DevExpress.XtraEditors.TextEdit te_ora_user;
                private DevExpress.XtraEditors.TextEdit te_ora_pass;
                private DevExpress.XtraEditors.TextEdit te_ora_netserive;
        }
}