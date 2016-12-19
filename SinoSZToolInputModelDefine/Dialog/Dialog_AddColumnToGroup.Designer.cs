namespace SinoSZToolInputModelDefine.Dialog
{
        partial class Dialog_AddColumnToGroup
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
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// simpleButton1
			// 
			this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton1.Location = new System.Drawing.Point(197, 43);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(64, 24);
			this.simpleButton1.TabIndex = 0;
			this.simpleButton1.Text = "确定";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
			this.tableLayoutPanel1.Controls.Add(this.simpleButton1, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.simpleButton2, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.textEdit1, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 15);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 70);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// simpleButton2
			// 
			this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.simpleButton2.Location = new System.Drawing.Point(267, 43);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(64, 24);
			this.simpleButton2.TabIndex = 1;
			this.simpleButton2.Text = "取消";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 24);
			this.label1.TabIndex = 3;
			this.label1.Text = "字段名";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textEdit1
			// 
			this.textEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.textEdit1, 3);
			this.textEdit1.Location = new System.Drawing.Point(83, 3);
			this.textEdit1.Name = "textEdit1";
			this.textEdit1.Size = new System.Drawing.Size(248, 21);
			this.textEdit1.TabIndex = 4;
			// 
			// Dialog_AddColumnToGroup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 90);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Dialog_AddColumnToGroup";
			this.Padding = new System.Windows.Forms.Padding(5, 15, 5, 5);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "添加字段";
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
			this.ResumeLayout(false);

                }

                #endregion

                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private System.Windows.Forms.Label label1;
                private DevExpress.XtraEditors.TextEdit textEdit1;
        }
}