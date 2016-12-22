namespace SinoSZToolFlowDesign.Controls
{
        partial class UC_FlowDefine
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

                #region Component Designer generated code

                /// <summary> 
                /// Required method for Designer support - do not modify 
                /// the contents of this method with the code editor.
                /// </summary>
                private void InitializeComponent()
                {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.TE_ROOTDWID = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.te_Des = new DevExpress.XtraEditors.MemoEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.te_Name = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.te_ID = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TE_ROOTDWID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Des.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_ID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(14);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(14);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(857, 612);
            this.splitContainerControl1.SplitterPosition = 289;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(14, 51);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(829, 253);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "流程ID";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 182;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "业务流程名称";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 217;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "业务流程说明";
            this.gridColumn3.FieldName = "Description";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 291;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SinoSZToolFlowDesign.Properties.Resources.caption;
            this.panel1.Controls.Add(this.simpleButton2);
            this.panel1.Controls.Add(this.simpleButton3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 37);
            this.panel1.TabIndex = 1;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(17, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(71, 27);
            this.simpleButton2.TabIndex = 0;
            this.simpleButton2.Text = "新 建";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(93, 4);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(71, 27);
            this.simpleButton3.TabIndex = 1;
            this.simpleButton3.Text = "删 除";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.TE_ROOTDWID);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.te_Des);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.te_Name);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.te_ID);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(14, 14);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(829, 261);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "业务流程信息";
            // 
            // TE_ROOTDWID
            // 
            this.TE_ROOTDWID.Location = new System.Drawing.Point(136, 104);
            this.TE_ROOTDWID.Name = "TE_ROOTDWID";
            this.TE_ROOTDWID.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TE_ROOTDWID.Properties.Appearance.Options.UseForeColor = true;
            this.TE_ROOTDWID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TE_ROOTDWID.Size = new System.Drawing.Size(521, 20);
            this.TE_ROOTDWID.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(26, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "组织机构根ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(584, 187);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 27);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "保 存";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // te_Des
            // 
            this.te_Des.Location = new System.Drawing.Point(138, 135);
            this.te_Des.Name = "te_Des";
            this.te_Des.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.te_Des.Properties.Appearance.Options.UseForeColor = true;
            this.te_Des.Size = new System.Drawing.Size(521, 41);
            this.te_Des.TabIndex = 5;
            this.te_Des.EditValueChanged += new System.EventHandler(this.memoEdit1_EditValueChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(27, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "流程说明";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // te_Name
            // 
            this.te_Name.Location = new System.Drawing.Point(138, 72);
            this.te_Name.Name = "te_Name";
            this.te_Name.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.te_Name.Properties.Appearance.Options.UseForeColor = true;
            this.te_Name.Size = new System.Drawing.Size(521, 20);
            this.te_Name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(27, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "流程名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // te_ID
            // 
            this.te_ID.Location = new System.Drawing.Point(138, 41);
            this.te_ID.Name = "te_ID";
            this.te_ID.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.te_ID.Properties.Appearance.Options.UseBackColor = true;
            this.te_ID.Properties.ReadOnly = true;
            this.te_ID.Size = new System.Drawing.Size(521, 20);
            this.te_ID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "业务流程ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UC_FlowDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "UC_FlowDefine";
            this.Size = new System.Drawing.Size(857, 612);
            this.Load += new System.EventHandler(this.UC_FlowDefine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TE_ROOTDWID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Des.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_ID.Properties)).EndInit();
            this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private DevExpress.XtraGrid.GridControl gridControl1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraEditors.GroupControl groupControl1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
                private DevExpress.XtraEditors.MemoEdit te_Des;
                private System.Windows.Forms.Label label3;
                private DevExpress.XtraEditors.TextEdit te_Name;
                private System.Windows.Forms.Label label2;
                private DevExpress.XtraEditors.TextEdit te_ID;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private System.Windows.Forms.Panel panel1;
                private DevExpress.XtraEditors.SimpleButton simpleButton3;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraEditors.TextEdit TE_ROOTDWID;
                private System.Windows.Forms.Label label4;
        }
}
