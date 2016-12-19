using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using SinoSZToolInputModelDefine.Define;
using SinoSZToolInputModelDefine.Dialog;
using SinoSZJS.Base.InputModel;

namespace SinoSZToolInputModelDefine.EditPanel
{
    public partial class UC_InputColumns : DevExpress.XtraEditors.XtraUserControl, IMenuControl
    {
        private MD_InputModel InputModel = null;
        private MD_InputModel_ColumnGroup InputGroup = null;
        private List<MD_InputModel_Column> DataSource = null;
        public UC_InputColumns()
        {
            InitializeComponent();
        }

        public UC_InputColumns(MD_InputModel _model)
        {
            InitializeComponent();
            InputModel = DAConfig.QueryDataAccess.GetInputModelByName(string.Format("{0}.{1}", _model.NameSpace, _model.ModelName));

            InitDataByModel();
        }

        public UC_InputColumns(MD_InputModel_ColumnGroup _group)
        {
            InitializeComponent();
            InputGroup = DAConfig.QueryDataAccess.GetInputGroupByID(_group.GroupID);
            InputModel = DAConfig.QueryDataAccess.GetInputModelByID(_group.ModelID);
            InitDataByGroup();
        }

        private void InitDataByGroup()
        {
            if (InputGroup != null)
            {
                this.te_Name.EditValue = InputGroup.DisplayTitle;
                this.te_Order.EditValue = InputGroup.DisplayOrder;
                this.te_Name.Properties.ReadOnly = false;
                this.te_Order.Properties.ReadOnly = false;
                switch (InputGroup.GroupType)
                {
                    case "APPREG":
                        this.te_GroupType.SelectedIndex = 1;
                        break;
                    case "QUERYMODEL":
                        this.te_GroupType.SelectedIndex = 2;
                        break;
                    default:
                        this.te_GroupType.SelectedIndex = 0;
                        break;
                }
                this.te_AppRegUrl.EditValue = InputGroup.AppRegUrl;
                this.te_Param.EditValue = InputGroup.GroupParam;
                this.gridControl1.DataSource = InputGroup.Columns;
                DataSource = InputGroup.Columns;
            }
        }

        private void InitDataByModel()
        {

            this.te_Name.EditValue = "未分组";
            this.te_Order.EditValue = "0";
            this.te_Name.Properties.ReadOnly = true;
            this.te_Order.Properties.ReadOnly = true;
            this.gridControl1.DataSource = InputModel.Columns;
            DataSource = InputModel.Columns;

        }


        private void MoveColumn()
        {
            if (this.gridView1.RowCount > 0 && this.gridView1.FocusedRowHandle >= 0)
            {
                MD_InputModel_Column _col = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as MD_InputModel_Column;
                Dialog_MoveColumnToGroup _f = new Dialog_MoveColumnToGroup(this.InputModel.Groups, _col);
                if (_f.ShowDialog() == DialogResult.OK) ;
                {
                    if (_f.SelectedGroup != null)
                    {
                        if (DAConfig.DataAccess.InputModel_MoveColumnToGroup(_col, _f.SelectedGroup))
                        {
                            ReInit();
                        }
                    }
                }
            }
        }

        private void DelColumn()
        {
            if (this.gridView1.RowCount > 0 && this.gridView1.FocusedRowHandle >= 0)
            {
                MD_InputModel_Column _col = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as MD_InputModel_Column;
                if (XtraMessageBox.Show(string.Format("是否确定要删除字段{0}？", _col.ColumnName), "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                {
                    if (DAConfig.DataAccess.DelInputModelColumn(_col.ColumnID))
                    {
                        ReInit();
                    }
                    else
                    {
                        XtraMessageBox.Show("删除失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        private void AddColumn()
        {

            Dialog_AddColumnToGroup _f = new Dialog_AddColumnToGroup();
            if (_f.ShowDialog() == DialogResult.OK) 
            {
                string _cName = _f.ColumnName;
                if (_cName != "")
                {
                    if (DAConfig.DataAccess.FindInputModelColumnByName(this.InputModel.ID, _cName))
                    {
                        XtraMessageBox.Show("录入模型中已经存在此字段名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string _gid = "0";
                        if (this.InputGroup == null)
                        {
                            _gid = "0";
                        }
                        else
                        {
                            _gid = this.InputGroup.GroupID;
                        }

                        if (DAConfig.DataAccess.AddNewInputModelColumn(this.InputModel.ID, _gid, _cName))
                        {
                            ReInit();
                        }
                        else
                        {
                            XtraMessageBox.Show("添加失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }

        #region IMenuControl Members

        public List<MenuGroup> GetMenuGroups()
        {
            List<MenuGroup> _ret = new List<MenuGroup>();
            MenuGroup _group1 = new MenuGroup("录入界面字段管理");
            _group1.Buttons.Add("添加录入界面字段");
            _group1.Buttons.Add("删除录入界面字段");
            if (this.gridView1.RowCount > 0 && this.gridView1.FocusedRowHandle >= 0)
            {
                _group1.Buttons.Add("录入字段移往其它组");
            }
            _ret.Add(_group1);
            return _ret;
        }

        public event EventHandler<EventArgs> MenuChanged;

        public bool DataChanged
        {
            get { return true; }
        }

        private void ReInit()
        {
            if (InputGroup == null)
            {
                InputModel = DAConfig.QueryDataAccess.GetInputModelByName(string.Format("{0}.{1}", InputModel.NameSpace, InputModel.ModelName));
                InitDataByModel();
            }
            else
            {
                InputGroup = DAConfig.QueryDataAccess.GetInputGroupByID(InputGroup.GroupID);
                InputModel = DAConfig.QueryDataAccess.GetInputModelByID(InputGroup.ModelID);
                InitDataByGroup();
            }
        }
        #endregion

        #region IMenuControl Members


        public void DoSave()
        {
            string _msg = "";
            if (CheckValid(ref _msg))
            {
                MD_InputModel_ColumnGroup _group = GetGroupData();
                if (DAConfig.DataAccess.SaveInputModelColumnGroup(_group))
                {
                    ReInit();
                }
                else
                {
                    XtraMessageBox.Show("保存失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show(_msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private MD_InputModel_ColumnGroup GetGroupData()
        {
            MD_InputModel_ColumnGroup _ret = null;
            if (this.InputGroup == null)
            {
                _ret = new MD_InputModel_ColumnGroup("0", this.InputModel.ID, "未分组", 0);
            }
            else
            {
                _ret = this.InputGroup;
            }
            _ret.DisplayTitle = (this.te_Name.EditValue == null) ? "" : this.te_Name.EditValue.ToString();
            _ret.DisplayOrder = (this.te_Order.EditValue == null) ? 0 : Convert.ToInt32(this.te_Order.EditValue);
            _ret.GroupType = (this.te_GroupType.EditValue == null) ? "DEFAULT" : this.te_GroupType.EditValue.ToString();
            _ret.AppRegUrl = (this.te_AppRegUrl.EditValue == null) ? "" : this.te_AppRegUrl.EditValue.ToString();
            _ret.GroupParam = (this.te_Param.EditValue == null) ? "" : this.te_Param.EditValue.ToString();
            _ret.Columns = this.gridControl1.DataSource as List<MD_InputModel_Column>;
            return _ret;

        }

        private bool CheckValid(ref string _msg)
        {
            _msg = "";
            this.gridView1.PostEditor();
            CurrencyManager cm_Meta1 = (CurrencyManager)this.BindingContext[this.DataSource, ""];
            cm_Meta1.EndCurrentEdit();
            return true;
        }

        public void DoCancel()
        {
            ReInit();
        }



        public void DoCommand(string CommandName)
        {
            switch (CommandName)
            {
                case "录入字段移往其它组":
                    MoveColumn();
                    break;
                case "添加字段":
                    AddColumn();
                    break;
                case "删除字段":
                    DelColumn();
                    break;
            }
        }







        #endregion
    }
}
