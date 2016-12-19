namespace SinoSZToolInputModelDefine.Dialog
{
        partial class Dialog_AddInputModel
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
                        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                        this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
                        this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
                        this.uC_InputModel1 = new SinoSZToolInputModelDefine.EditPanel.UC_InputModel();
                        this.tableLayoutPanel1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.ColumnCount = 3;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
                        this.tableLayoutPanel1.Controls.Add(this.simpleButton1, 1, 1);
                        this.tableLayoutPanel1.Controls.Add(this.simpleButton2, 2, 1);
                        this.tableLayoutPanel1.Controls.Add(this.uC_InputModel1, 0, 0);
                        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 2;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(645, 428);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // simpleButton1
                        // 
                        this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.simpleButton1.Location = new System.Drawing.Point(489, 398);
                        this.simpleButton1.Margin = new System.Windows.Forms.Padding(4);
                        this.simpleButton1.Name = "simpleButton1";
                        this.simpleButton1.Size = new System.Drawing.Size(72, 26);
                        this.simpleButton1.TabIndex = 0;
                        this.simpleButton1.Text = "确定";
                        this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
                        // 
                        // simpleButton2
                        // 
                        this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.simpleButton2.Location = new System.Drawing.Point(569, 398);
                        this.simpleButton2.Margin = new System.Windows.Forms.Padding(4);
                        this.simpleButton2.Name = "simpleButton2";
                        this.simpleButton2.Size = new System.Drawing.Size(72, 26);
                        this.simpleButton2.TabIndex = 1;
                        this.simpleButton2.Text = "取消";
                        this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
                        // 
                        // uC_InputModel1
                        // 
                        this.uC_InputModel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel1.SetColumnSpan(this.uC_InputModel1, 3);
                        this.uC_InputModel1.Location = new System.Drawing.Point(3, 3);
                        this.uC_InputModel1.Name = "uC_InputModel1";
                        this.uC_InputModel1.Size = new System.Drawing.Size(639, 388);
                        this.uC_InputModel1.TabIndex = 2;
                        // 
                        // Dialog_AddInputModel
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(655, 438);
                        this.Controls.Add(this.tableLayoutPanel1);
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                        this.Name = "Dialog_AddInputModel";
                        this.Padding = new System.Windows.Forms.Padding(5);
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "添加录入模型";
                        this.tableLayoutPanel1.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
                private DevExpress.XtraEditors.SimpleButton simpleButton1;
                private DevExpress.XtraEditors.SimpleButton simpleButton2;
                private SinoSZToolInputModelDefine.EditPanel.UC_InputModel uC_InputModel1;
        }
}