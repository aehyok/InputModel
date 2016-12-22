namespace SinoSZToolFlowDesign.Controls
{
        partial class UC_FlowStatus
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.te_FlowList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.te_Order = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.te_Type = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.te_Display = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.te_FlowList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.te_Order.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Display.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Des.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_ID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(584, 202);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 27);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "保 存";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
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
            this.splitContainerControl1.Size = new System.Drawing.Size(882, 661);
            this.splitContainerControl1.SplitterPosition = 280;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(14, 61);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(854, 301);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "状态名称";
            this.gridColumn1.FieldName = "StateName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 182;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "状态显示名称";
            this.gridColumn2.FieldName = "DisplayName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 217;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "状态描述";
            this.gridColumn3.FieldName = "Description";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 291;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "状态类型";
            this.gridColumn4.FieldName = "Type";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 85;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "显示顺序";
            this.gridColumn5.FieldName = "Order";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SinoSZToolFlowDesign.Properties.Resources.caption;
            this.panel1.Controls.Add(this.simpleButton3);
            this.panel1.Controls.Add(this.te_FlowList);
            this.panel1.Controls.Add(this.simpleButton2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 47);
            this.panel1.TabIndex = 1;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(513, 9);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(83, 27);
            this.simpleButton3.TabIndex = 1;
            this.simpleButton3.Text = "删除状态";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // te_FlowList
            // 
            this.te_FlowList.Location = new System.Drawing.Point(84, 10);
            this.te_FlowList.Name = "te_FlowList";
            this.te_FlowList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.te_FlowList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.te_FlowList.Size = new System.Drawing.Size(317, 20);
            this.te_FlowList.TabIndex = 3;
            this.te_FlowList.SelectedIndexChanged += new System.EventHandler(this.te_FlowList_SelectedIndexChanged);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(421, 9);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(83, 27);
            this.simpleButton2.TabIndex = 0;
            this.simpleButton2.Text = "新建状态";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(3, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "业务流程:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.te_Order);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.te_Type);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.te_Display);
            this.groupControl1.Controls.Add(this.label5);
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
            this.groupControl1.Size = new System.Drawing.Size(854, 252);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "业务状态信息";
            // 
            // te_Order
            // 
            this.te_Order.Location = new System.Drawing.Point(475, 103);
            this.te_Order.Name = "te_Order";
            this.te_Order.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.te_Order.Properties.Appearance.Options.UseForeColor = true;
            this.te_Order.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.te_Order.Size = new System.Drawing.Size(184, 20);
            this.te_Order.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(401, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "显示顺序";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // te_Type
            // 
            this.te_Type.Location = new System.Drawing.Point(475, 70);
            this.te_Type.Name = "te_Type";
            this.te_Type.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.te_Type.Properties.Appearance.Options.UseForeColor = true;
            this.te_Type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.te_Type.Properties.Items.AddRange(new object[] {
            "开始",
            "通用",
            "结束",
            "删除"});
            this.te_Type.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.te_Type.Size = new System.Drawing.Size(184, 20);
            this.te_Type.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(365, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "状态类型";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // te_Display
            // 
            this.te_Display.Location = new System.Drawing.Point(138, 103);
            this.te_Display.Name = "te_Display";
            this.te_Display.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.te_Display.Properties.Appearance.Options.UseForeColor = true;
            this.te_Display.Size = new System.Drawing.Size(220, 20);
            this.te_Display.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(27, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "显示名称";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // te_Des
            // 
            this.te_Des.Location = new System.Drawing.Point(138, 134);
            this.te_Des.Name = "te_Des";
            this.te_Des.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.te_Des.Properties.Appearance.Options.UseForeColor = true;
            this.te_Des.Size = new System.Drawing.Size(521, 57);
            this.te_Des.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(27, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "描 述";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // te_Name
            // 
            this.te_Name.Location = new System.Drawing.Point(138, 71);
            this.te_Name.Name = "te_Name";
            this.te_Name.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.te_Name.Properties.Appearance.Options.UseForeColor = true;
            this.te_Name.Size = new System.Drawing.Size(220, 20);
            this.te_Name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(27, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "状态名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // te_ID
            // 
            this.te_ID.Location = new System.Drawing.Point(138, 40);
            this.te_ID.Name = "te_ID";
            this.te_ID.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.te_ID.Properties.Appearance.Options.UseBackColor = true;
            this.te_ID.Properties.ReadOnly = true;
            this.te_ID.Size = new System.Drawing.Size(521, 20);
            this.te_ID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "状态ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UC_FlowStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "UC_FlowStatus";
            this.Size = new System.Drawing.Size(882, 661);
            this.Load += new System.EventHandler(this.UC_FlowStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.te_FlowList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.te_Order.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Display.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Des.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_ID.Properties)).EndInit();
            this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private DevExpress.XtraGrid.GridControl gridControl1;
                private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
                private System.Windows.Forms.Panel panel1;
                private DevExpress.XtraEditors.SimpleButton simpleButton3;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private DevExpress.XtraEditors.GroupControl groupControl1;
                private DevExpress.XtraEditors.MemoEdit te_Des;
                private System.Windows.Forms.Label label3;
                private DevExpress.XtraEditors.TextEdit te_Name;
                private System.Windows.Forms.Label label2;
                private DevExpress.XtraEditors.TextEdit te_ID;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.ComboBoxEdit te_FlowList;
                private System.Windows.Forms.Label label4;
                private DevExpress.XtraEditors.ComboBoxEdit te_Type;
                private System.Windows.Forms.Label label6;
                private DevExpress.XtraEditors.TextEdit te_Display;
                private System.Windows.Forms.Label label5;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
                private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
                private DevExpress.XtraEditors.TextEdit te_Order;
                private System.Windows.Forms.Label label7;
        }
}
