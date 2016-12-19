using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZToolInputModelDefine.Define;
using SinoSZJS.Base.InputModel;

namespace SinoSZToolInputModelDefine.EditPanel
{
    public partial class UC_InputModel_Child : DevExpress.XtraEditors.XtraUserControl, IMenuControl
    {
        private MD_InputModel_Child inputModelChild = null;
        public UC_InputModel_Child()
        {
            InitializeComponent();
        }

        public UC_InputModel_Child(MD_InputModel_Child _InputModelChild)
        {
            InitializeComponent();
            inputModelChild = _InputModelChild;
            InitForm();
        }

        private void InitForm()
        {
            this.te_Name.EditValue = inputModelChild.ChildModelName;
            this.te_Display.EditValue = inputModelChild.ChildModel.DisplayName;
            this.te_Order.EditValue = inputModelChild.DisplayOrder;
            this.gridControl1.DataSource = inputModelChild.Parameters;
            this.te_ShowCondition.EditValue = inputModelChild.ShowCondition;
            this.te_SelectMode.SelectedIndex = inputModelChild.SelectMode;
        }

        public MD_InputModel_Child InputModelChild
        {
            get { return inputModelChild; }
            set { inputModelChild = value; }
        }



        #region IMenuControl Members

        public List<MenuGroup> GetMenuGroups()
        {
            List<MenuGroup> _ret = new List<MenuGroup>();
            MenuGroup _group1 = new MenuGroup("子模型参数管理");
            _group1.Buttons.Add("添加子模型参数");
            if (this.gridView1.RowCount > 0 && this.gridView1.FocusedRowHandle >= 0)
            {
                _group1.Buttons.Add("删除子模型参数");
            }
            _ret.Add(_group1);
            return _ret;
        }

        public event EventHandler<EventArgs> MenuChanged;

        public void RaiseMenuChanged()
        {
            if (MenuChanged != null)
            {
                MenuChanged(this, new EventArgs());
            }
        }

        public bool DataChanged
        {
            get { return true; }
        }


        public void DoSave()
        {
            this.gridView1.PostEditor();
            this.inputModelChild.DisplayOrder = Convert.ToInt32(this.te_Order.EditValue.ToString());
            this.inputModelChild.ShowCondition = (this.te_ShowCondition.EditValue == null) ? "" : this.te_ShowCondition.EditValue.ToString();
            this.inputModelChild.SelectMode = this.te_SelectMode.SelectedIndex;
            CurrencyManager cm_Meta1 = (CurrencyManager)this.BindingContext[this.inputModelChild.Parameters, ""];
            cm_Meta1.EndCurrentEdit();

            if (DAConfig.DataAccess.SaveInputModelChildDefine(this.inputModelChild))
            {
                RaiseMenuChanged();
            }
        }

        public void DoCancel()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void DoCommand(string CommandName)
        {
            switch (CommandName)
            {
                case "添加子模型参数":
                    AddParameter();
                    break;
                case "删除子模型参数":
                    DelParameter();
                    break;
            }
        }

        private void DelParameter()
        {
            if (this.gridView1.RowCount > 0 && this.gridView1.FocusedRowHandle >= 0)
            {
                MD_InputModel_ChildParam _p = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as MD_InputModel_ChildParam;
                this.gridView1.BeginUpdate();
                this.inputModelChild.Parameters.Remove(_p);
                this.gridView1.EndUpdate();
            }
            RaiseMenuChanged();
        }

        private void AddParameter()
        {
            this.gridView1.BeginUpdate();
            this.inputModelChild.Parameters.Add(new MD_InputModel_ChildParam("PARAM", "VARCHAR", ""));
            this.gridView1.EndUpdate();
            RaiseMenuChanged();
        }

        #endregion

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RaiseMenuChanged();
        }
    }
}
