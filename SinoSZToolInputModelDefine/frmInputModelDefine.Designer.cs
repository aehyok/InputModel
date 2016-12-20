namespace SinoSZToolInputModelDefine
{
        partial class frmInputModelDefine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputModelDefine));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bt_AddInputModel = new DevExpress.XtraBars.BarButtonItem();
            this.bt_DelInputModel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.bt_AddGroup = new DevExpress.XtraBars.BarButtonItem();
            this.bt_DelGroup = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.bt_AddSaveTable = new DevExpress.XtraBars.BarButtonItem();
            this.bt_DelSaveTable = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.bt_AddChild = new DevExpress.XtraBars.BarButtonItem();
            this.bt_DelChild = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.bt_ImportModel = new DevExpress.XtraBars.BarButtonItem();
            this.bt_ExportModel = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RPG_MODEL = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RPG_GROUP = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RPG_SAVE = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RPG_DESTABLE = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RPG_CHILD = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.clientPanel = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).BeginInit();
            this.clientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::SinoSZToolInputModelDefine.Properties.Resources.ni_png_0734;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bt_AddInputModel,
            this.bt_DelInputModel,
            this.barButtonItem3,
            this.bt_AddGroup,
            this.bt_DelGroup,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8,
            this.bt_AddSaveTable,
            this.bt_DelSaveTable,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem4,
            this.barButtonItem5,
            this.bt_AddChild,
            this.bt_DelChild,
            this.barButtonItem9,
            this.barButtonItem10,
            this.bt_ImportModel,
            this.bt_ExportModel});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ribbon.MaxItemId = 20;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1186, 147);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bt_AddInputModel
            // 
            this.bt_AddInputModel.Caption = "添加模型";
            this.bt_AddInputModel.Id = 0;
            this.bt_AddInputModel.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.g14;
            this.bt_AddInputModel.LargeWidth = 80;
            this.bt_AddInputModel.Name = "bt_AddInputModel";
            this.bt_AddInputModel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // bt_DelInputModel
            // 
            this.bt_DelInputModel.Caption = "删除模型";
            this.bt_DelInputModel.Id = 1;
            this.bt_DelInputModel.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.g15;
            this.bt_DelInputModel.LargeWidth = 80;
            this.bt_DelInputModel.Name = "bt_DelInputModel";
            this.bt_DelInputModel.Tag = "";
            this.bt_DelInputModel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_DelInputModel_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "保存";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.xx;
            this.barButtonItem3.LargeWidth = 80;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // bt_AddGroup
            // 
            this.bt_AddGroup.Caption = "添加分组";
            this.bt_AddGroup.Id = 3;
            this.bt_AddGroup.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.g9;
            this.bt_AddGroup.LargeWidth = 80;
            this.bt_AddGroup.Name = "bt_AddGroup";
            this.bt_AddGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // bt_DelGroup
            // 
            this.bt_DelGroup.Caption = "删除分组";
            this.bt_DelGroup.Id = 4;
            this.bt_DelGroup.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.g10;
            this.bt_DelGroup.LargeWidth = 80;
            this.bt_DelGroup.Name = "bt_DelGroup";
            this.bt_DelGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_DelGroup_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "取消";
            this.barButtonItem6.Id = 5;
            this.barButtonItem6.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.x1;
            this.barButtonItem6.LargeWidth = 80;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "添加字段";
            this.barButtonItem7.Id = 6;
            this.barButtonItem7.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.g14;
            this.barButtonItem7.LargeWidth = 80;
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.Tag = "添加录入界面字段";
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "删除字段";
            this.barButtonItem8.Id = 7;
            this.barButtonItem8.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.g15;
            this.barButtonItem8.LargeWidth = 80;
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.Tag = "删除录入界面字段";
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // bt_AddSaveTable
            // 
            this.bt_AddSaveTable.Caption = "添加写入表";
            this.bt_AddSaveTable.Id = 8;
            this.bt_AddSaveTable.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.g28;
            this.bt_AddSaveTable.LargeWidth = 80;
            this.bt_AddSaveTable.Name = "bt_AddSaveTable";
            this.bt_AddSaveTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick);
            // 
            // bt_DelSaveTable
            // 
            this.bt_DelSaveTable.Caption = "删除写入表";
            this.bt_DelSaveTable.Id = 9;
            this.bt_DelSaveTable.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.g29;
            this.bt_DelSaveTable.LargeWidth = 80;
            this.bt_DelSaveTable.Name = "bt_DelSaveTable";
            this.bt_DelSaveTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_DelSaveTable_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "移往其它组";
            this.barButtonItem1.Id = 10;
            this.barButtonItem1.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.ff;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.Tag = "录入字段移往其它组";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_1);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "同步字段";
            this.barButtonItem2.Id = 11;
            this.barButtonItem2.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.b25;
            this.barButtonItem2.LargeWidth = 80;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.Tag = "同步写入表字段";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "添加字段";
            this.barButtonItem4.Id = 12;
            this.barButtonItem4.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.e14;
            this.barButtonItem4.LargeWidth = 80;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.Tag = "添加写入表字段";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick_1);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "删除字段";
            this.barButtonItem5.Id = 13;
            this.barButtonItem5.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.e15;
            this.barButtonItem5.LargeWidth = 80;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.Tag = "删除写入表字段";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // bt_AddChild
            // 
            this.bt_AddChild.Caption = "添加子模型";
            this.bt_AddChild.Id = 14;
            this.bt_AddChild.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.g40;
            this.bt_AddChild.LargeWidth = 80;
            this.bt_AddChild.Name = "bt_AddChild";
            this.bt_AddChild.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_AddChild_ItemClick);
            // 
            // bt_DelChild
            // 
            this.bt_DelChild.Caption = "删除子模型";
            this.bt_DelChild.Id = 15;
            this.bt_DelChild.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.g41;
            this.bt_DelChild.LargeWidth = 80;
            this.bt_DelChild.Name = "bt_DelChild";
            this.bt_DelChild.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_DelChild_ItemClick);
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "添加参数";
            this.barButtonItem9.Id = 16;
            this.barButtonItem9.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.g12;
            this.barButtonItem9.LargeWidth = 80;
            this.barButtonItem9.Name = "barButtonItem9";
            this.barButtonItem9.Tag = "添加子模型参数";
            this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick_1);
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "删除参数";
            this.barButtonItem10.Id = 17;
            this.barButtonItem10.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.g13;
            this.barButtonItem10.LargeWidth = 80;
            this.barButtonItem10.Name = "barButtonItem10";
            this.barButtonItem10.Tag = "删除子模型参数";
            this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem10_ItemClick);
            // 
            // bt_ImportModel
            // 
            this.bt_ImportModel.Caption = "导入模型";
            this.bt_ImportModel.Id = 18;
            this.bt_ImportModel.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.g7;
            this.bt_ImportModel.LargeWidth = 80;
            this.bt_ImportModel.Name = "bt_ImportModel";
            this.bt_ImportModel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_ImportModel_ItemClick);
            // 
            // bt_ExportModel
            // 
            this.bt_ExportModel.Caption = "导出模型";
            this.bt_ExportModel.Id = 19;
            this.bt_ExportModel.LargeGlyph = global::SinoSZToolInputModelDefine.Properties.Resources.g8;
            this.bt_ExportModel.LargeWidth = 80;
            this.bt_ExportModel.Name = "bt_ExportModel";
            this.bt_ExportModel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_ExportModel_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RPG_MODEL,
            this.RPG_GROUP,
            this.RPG_SAVE,
            this.RPG_DESTABLE,
            this.RPG_CHILD});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "录入模型";
            // 
            // RPG_MODEL
            // 
            this.RPG_MODEL.ItemLinks.Add(this.bt_AddInputModel);
            this.RPG_MODEL.ItemLinks.Add(this.bt_DelInputModel);
            this.RPG_MODEL.ItemLinks.Add(this.bt_ImportModel);
            this.RPG_MODEL.ItemLinks.Add(this.bt_ExportModel);
            this.RPG_MODEL.Name = "RPG_MODEL";
            this.RPG_MODEL.Text = "录入模型定义";
            // 
            // RPG_GROUP
            // 
            this.RPG_GROUP.ItemLinks.Add(this.bt_AddGroup);
            this.RPG_GROUP.ItemLinks.Add(this.bt_DelGroup);
            this.RPG_GROUP.Name = "RPG_GROUP";
            this.RPG_GROUP.Text = "录入字段分组";
            // 
            // RPG_SAVE
            // 
            this.RPG_SAVE.ItemLinks.Add(this.barButtonItem3);
            this.RPG_SAVE.ItemLinks.Add(this.barButtonItem6);
            this.RPG_SAVE.Name = "RPG_SAVE";
            this.RPG_SAVE.Text = "保存和修改";
            // 
            // RPG_DESTABLE
            // 
            this.RPG_DESTABLE.ItemLinks.Add(this.bt_AddSaveTable);
            this.RPG_DESTABLE.ItemLinks.Add(this.bt_DelSaveTable);
            this.RPG_DESTABLE.Name = "RPG_DESTABLE";
            this.RPG_DESTABLE.Text = "数据写入的表定义";
            // 
            // RPG_CHILD
            // 
            this.RPG_CHILD.ItemLinks.Add(this.bt_AddChild);
            this.RPG_CHILD.ItemLinks.Add(this.bt_DelChild);
            this.RPG_CHILD.Name = "RPG_CHILD";
            this.RPG_CHILD.Text = "子录入模型";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 681);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1186, 31);
            // 
            // clientPanel
            // 
            this.clientPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.clientPanel.Controls.Add(this.splitContainerControl1);
            this.clientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientPanel.Location = new System.Drawing.Point(0, 147);
            this.clientPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clientPanel.Name = "clientPanel";
            this.clientPanel.Size = new System.Drawing.Size(1186, 534);
            this.clientPanel.TabIndex = 2;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeList1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1186, 534);
            this.splitContainerControl1.SplitterPosition = 406;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeList1
            // 
            this.treeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.treeList1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeList1.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Blue;
            this.treeList1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedCell.Options.UseBorderColor = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.SelectImageList = this.imageList1;
            this.treeList1.Size = new System.Drawing.Size(406, 534);
            this.treeList1.TabIndex = 4;
            this.treeList1.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.treeList1_BeforeExpand);
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "DisplayTitle";
            this.treeListColumn1.MinWidth = 95;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 79;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "y1.ico");
            this.imageList1.Images.SetKeyName(1, "world.png");
            this.imageList1.Images.SetKeyName(2, "bin_closed.png");
            this.imageList1.Images.SetKeyName(3, "layout.png");
            this.imageList1.Images.SetKeyName(4, "y16.ico");
            this.imageList1.Images.SetKeyName(5, "chart_organisation.png");
            this.imageList1.Images.SetKeyName(6, "plugin_edit.png");
            this.imageList1.Images.SetKeyName(7, "pictures.png");
            // 
            // frmInputModelDefine
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 712);
            this.Controls.Add(this.clientPanel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmInputModelDefine";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "数据录入定义工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInputModelDefine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientPanel)).EndInit();
            this.clientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
                private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
                private DevExpress.XtraBars.Ribbon.RibbonPageGroup RPG_MODEL;
                private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
                private DevExpress.XtraEditors.PanelControl clientPanel;
                private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
                private DevExpress.XtraTreeList.TreeList treeList1;
                private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
                private System.Windows.Forms.ImageList imageList1;
                private DevExpress.XtraBars.BarButtonItem bt_AddInputModel;
                private DevExpress.XtraBars.BarButtonItem bt_DelInputModel;
                private DevExpress.XtraBars.BarButtonItem barButtonItem3;
                private DevExpress.XtraBars.Ribbon.RibbonPageGroup RPG_SAVE;
                private DevExpress.XtraBars.BarButtonItem bt_AddGroup;
                private DevExpress.XtraBars.BarButtonItem bt_DelGroup;
                private DevExpress.XtraBars.Ribbon.RibbonPageGroup RPG_GROUP;
                private DevExpress.XtraBars.BarButtonItem barButtonItem6;
                private DevExpress.XtraBars.BarButtonItem barButtonItem7;
                private DevExpress.XtraBars.BarButtonItem barButtonItem8;
                private DevExpress.XtraBars.BarButtonItem bt_AddSaveTable;
                private DevExpress.XtraBars.BarButtonItem bt_DelSaveTable;
                private DevExpress.XtraBars.Ribbon.RibbonPageGroup RPG_DESTABLE;
                private DevExpress.XtraBars.BarButtonItem barButtonItem1;
                private DevExpress.XtraBars.BarButtonItem barButtonItem2;
			private DevExpress.XtraBars.BarButtonItem barButtonItem4;
			private DevExpress.XtraBars.BarButtonItem barButtonItem5;
		private DevExpress.XtraBars.BarButtonItem bt_AddChild;
		private DevExpress.XtraBars.BarButtonItem bt_DelChild;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup RPG_CHILD;
		private DevExpress.XtraBars.BarButtonItem barButtonItem9;
		private DevExpress.XtraBars.BarButtonItem barButtonItem10;
		private DevExpress.XtraBars.BarButtonItem bt_ImportModel;
		private DevExpress.XtraBars.BarButtonItem bt_ExportModel;
        }
}