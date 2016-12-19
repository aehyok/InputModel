namespace SinoSZToolInputModelDefine
{
	partial class Dialog_ExportInputModel
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
			this.label1 = new System.Windows.Forms.Label();
			this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "导出文件名";
			// 
			// buttonEdit1
			// 
			this.buttonEdit1.Location = new System.Drawing.Point(85, 22);
			this.buttonEdit1.Name = "buttonEdit1";
			this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.buttonEdit1.Size = new System.Drawing.Size(568, 21);
			this.buttonEdit1.TabIndex = 1;
			this.buttonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
			// 
			// simpleButton1
			// 
			this.simpleButton1.Location = new System.Drawing.Point(598, 60);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(55, 23);
			this.simpleButton1.TabIndex = 2;
			this.simpleButton1.Text = "取消";
			this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// simpleButton2
			// 
			this.simpleButton2.Location = new System.Drawing.Point(537, 60);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(55, 23);
			this.simpleButton2.TabIndex = 3;
			this.simpleButton2.Text = "导出";
			this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// Dialog_ExportInputModel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(665, 101);
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.buttonEdit1);
			this.Controls.Add(this.label1);
			this.Name = "Dialog_ExportInputModel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "导出录入模型";
			((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
	}
}