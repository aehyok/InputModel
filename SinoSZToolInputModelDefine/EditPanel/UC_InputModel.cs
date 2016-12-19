using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using SinoSZToolInputModelDefine.Define;
using SinoSZToolInputModelDefine.Dialog;
using SinoSZJS.Base.InputModel;

namespace SinoSZToolInputModelDefine.EditPanel
{
    public partial class UC_InputModel : DevExpress.XtraEditors.XtraUserControl, IMenuControl
    {
        private string inputModelFullName = "";
        private MD_InputModel inputModel = null;
        public UC_InputModel()
        {
            InitializeComponent();
        }

        public UC_InputModel(string _modelName)
        {
            InitializeComponent();
            inputModelFullName = _modelName;
            inputModel = DAConfig.QueryDataAccess.GetInputModelByName(inputModelFullName);
            InitData();
        }

        private void InitData()
        {
            this.te_DelRule.EditValue = inputModel.DeleteRule;
            this.te_Descript.EditValue = inputModel.Descript;
            this.te_Display.EditValue = inputModel.DisplayName;
            this.te_DWDM.EditValue = inputModel.DWDM;
            this.te_GetZB.EditValue = inputModel.GetDataGuideLine;
            this.te_InitZB.EditValue = inputModel.InitGuideLine;
            this.te_NewZB.EditValue = inputModel.GetNewRecordGuideLine;
            this.te_Order.EditValue = inputModel.DisplayOrder;
            this.te_ParamType.EditValue = inputModel.ParamterType;
            this.te_ModelType.EditValue = inputModel.ModelType;
            this.te_Name.EditValue = inputModel.ModelName;
            this.te_ResType.EditValue = inputModel.ResourceType;
            this.te_IntApp.EditValue = inputModel.IntegretedApplication;
            this.te_beforewrite.EditValue = inputModel.BeforeWrite;
            this.te_afterwrite.EditValue = inputModel.AfterWrite;

        }

        #region IMenuControl Members

        public List<MenuGroup> GetMenuGroups()
        {
            List<MenuGroup> _ret = new List<MenuGroup>();
            //MenuGroup _group1 = new MenuGroup("录入界面字段管理");
            //_group1.Buttons.Add("添加录入界面字段");
            //_group1.Buttons.Add("删除录入界面字段");                    

            //_ret.Add(_group1);
            return _ret;
        }


        public event EventHandler<EventArgs> MenuChanged;
        virtual public void RaiseMenuChanged()
        {
            //if (this._initFinished && MenuChanged != null)
            //{
            //        MenuChanged(this, new EventArgs());
            //}
        }


        public bool DataChanged
        {
            get { return true; }
        }

        #endregion

        public bool InputValid(ref string _msg)
        {
            return true;
        }

        public MD_InputModel GetInputData()
        {
            if (inputModel == null)
            {
                inputModel = new MD_InputModel();
            }

            inputModel.DeleteRule = (this.te_DelRule.EditValue == null) ? "" : this.te_DelRule.EditValue.ToString();
            inputModel.Descript = (this.te_Descript.EditValue == null) ? "" : this.te_Descript.EditValue.ToString();
            inputModel.DisplayName = (this.te_Display.EditValue == null) ? "" : this.te_Display.EditValue.ToString();
            inputModel.DWDM = (this.te_DWDM.EditValue == null) ? "" : this.te_DWDM.EditValue.ToString();
            inputModel.GetDataGuideLine = (this.te_GetZB.EditValue == null) ? "" : this.te_GetZB.EditValue.ToString();
            inputModel.InitGuideLine = (this.te_InitZB.EditValue == null) ? "" : this.te_InitZB.EditValue.ToString();
            inputModel.GetNewRecordGuideLine = (this.te_NewZB.EditValue == null) ? "" : this.te_NewZB.EditValue.ToString();
            inputModel.DisplayOrder = (this.te_Order.EditValue == null) ? 0 : int.Parse(this.te_Order.EditValue.ToString());
            inputModel.ParamterType = (this.te_ParamType.EditValue == null) ? "" : this.te_ParamType.EditValue.ToString();
            inputModel.ModelType = (this.te_ModelType.EditValue == null) ? "" : this.te_ModelType.EditValue.ToString();
            inputModel.ModelName = (this.te_Name.EditValue == null) ? "" : this.te_Name.EditValue.ToString();
            inputModel.IntegretedApplication = (this.te_IntApp.EditValue == null) ? "" : this.te_IntApp.EditValue.ToString();
            inputModel.ResourceType = (this.te_ResType.EditValue == null) ? "" : this.te_ResType.EditValue.ToString();
            inputModel.AfterWrite = (this.te_afterwrite.EditValue == null) ? "" : this.te_afterwrite.EditValue.ToString();
            inputModel.BeforeWrite = (this.te_beforewrite.EditValue == null) ? "" : this.te_beforewrite.EditValue.ToString();

            return inputModel;
        }



        #region IMenuControl Members


        public void DoSave()
        {
            string _msg = "";
            if (InputValid(ref _msg))
            {
                MD_InputModel SaveModel = GetInputData();
                if (SaveModel != null)
                {
                    if (DAConfig.DataAccess.SaveInputModel(SaveModel))
                    {

                    }
                }

            }
            else
            {
                XtraMessageBox.Show(_msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void DoCancel()
        {
            InitData();
            RaiseMenuChanged();
        }



        public void DoCommand(string CommandName)
        {
            switch (CommandName)
            {

            }
        }

        #endregion

        private void te_GetZB_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string _glid = (this.te_GetZB.EditValue == null) ? "" : this.te_GetZB.EditValue.ToString();
            Dialog_GuideLine _f = new Dialog_GuideLine(_glid);
            if (_f.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void te_NewZB_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string _glid = (this.te_NewZB.EditValue == null) ? "" : this.te_NewZB.EditValue.ToString();
            Dialog_GuideLine _f = new Dialog_GuideLine(_glid);
            if (_f.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void te_InitZB_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string _glid = (this.te_InitZB.EditValue == null) ? "" : this.te_InitZB.EditValue.ToString();
            Dialog_GuideLine _f = new Dialog_GuideLine(_glid);
            if (_f.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void te_ResType_EditValueChanged(object sender, EventArgs e)
        {

        }
    }


}
