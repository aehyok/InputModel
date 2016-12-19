using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.InputModel;

namespace SinoSZToolInputModelDefine.Dialog
{
        public partial class Dialog_AddInputModel : DevExpress.XtraEditors.XtraForm
        {
                private MD_Namespace ns = null;
                private MD_InputModel _newModel = null;
                public Dialog_AddInputModel()
                {
                        InitializeComponent();
                }

                public Dialog_AddInputModel(MD_Namespace _ns)
                {
                        InitializeComponent();
                        ns = _ns;
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        string _msg = "";
                        if (this.uC_InputModel1.InputValid(ref _msg))
                        {
                                MD_InputModel SaveModel = this.uC_InputModel1.GetInputData();
                                if (SaveModel != null)
                                {
                                        if (DAConfig.DataAccess.SaveNewInputModel(ns.NameSpace, SaveModel))
                                        {
                                                _newModel = DAConfig.DataAccess.GetInputModel(ns.NameSpace, SaveModel.ModelName);
                                        }
                                }
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                        }
                        else
                        {
                                XtraMessageBox.Show(_msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                        }


                }

                public MD_InputModel NewInputModel()
                {
                        return _newModel;
                }
        }
}