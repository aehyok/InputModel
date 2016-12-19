using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZToolInputModelDefine.Define;
using SinoSZToolInputModelDefine.Dialog;
using SinoSZJS.Base.InputModel;
using SinoSZJS.Base.MetaData.Define;

namespace SinoSZToolInputModelDefine.EditPanel
{
    public partial class UC_WriteTable : DevExpress.XtraEditors.XtraUserControl, IMenuControl
    {
        private MD_InputModel_SaveTable SaveTable = null;
        private List<MD_InputModel_SaveTableColumn> DataSource = null;
        public UC_WriteTable()
        {
            InitializeComponent();
        }

        public UC_WriteTable(MD_InputModel_SaveTable _table)
        {
            InitializeComponent();
            SaveTable = _table;
            InitForm();
        }

        private void InitForm()
        {
            this.te_Name.EditValue = SaveTable.TableName;
            this.te_DisplayName.EditValue = SaveTable.TableTitle;
            this.te_Order.EditValue = SaveTable.DisplayOrder;
            this.te_Lock.EditValue = SaveTable.IsLock;
            switch (SaveTable.SaveMode.ToUpper())
            {
                case "ONLYINSERT":
                    this.te_SaveMode.SelectedIndex = 1;
                    break;
                case "ONLYUPDATE":
                    this.te_SaveMode.SelectedIndex = 2;
                    break;
                default:
                    this.te_SaveMode.SelectedIndex = 0;
                    break;
            }
            this.gridControl1.DataSource = SaveTable.Columns;
            DataSource = SaveTable.Columns;
        }

        #region IMenuControl Members

        public List<MenuGroup> GetMenuGroups()
        {
            List<MenuGroup> _ret = new List<MenuGroup>();
            MenuGroup _group1 = new MenuGroup("д������");
            _group1.Buttons.Add("ͬ��д����ֶ�");
            if (!SaveTable.IsLock)
            {
                _group1.Buttons.Add("���д����ֶ�");
                _group1.Buttons.Add("ɾ��д����ֶ�");
            }
            _ret.Add(_group1);
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

        public event EventHandler<EventArgs> MenuChanged;

        public bool DataChanged
        {
            get { return true; }
        }

        public void DoSave()
        {
            string _msg = "";
            if (CheckValid(ref _msg))
            {
                MD_InputModel_SaveTable _newTable = GetInputData();
                if (DAConfig.DataAccess.SaveInputModelSaveTable(_newTable))
                {
                    ReInit(_newTable);
                }
                else
                {
                    XtraMessageBox.Show("����ʧ�ܣ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show(_msg, "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ReInit(MD_InputModel_SaveTable _newTable)
        {
            this.SaveTable.TableTitle = _newTable.TableTitle;
            this.SaveTable.DisplayOrder = _newTable.DisplayOrder;
            this.SaveTable.IsLock = _newTable.IsLock;
            this.SaveTable.Columns = _newTable.Columns;
            this.SaveTable.SaveMode = _newTable.SaveMode;
            InitForm();
        }

        private MD_InputModel_SaveTable GetInputData()
        {
            MD_InputModel_SaveTable _ret = new MD_InputModel_SaveTable();
            _ret.ID = this.SaveTable.ID;
            _ret.InputModelID = this.SaveTable.InputModelID;
            _ret.TableName = this.SaveTable.TableName;
            _ret.TableTitle = this.te_DisplayName.EditValue.ToString();
            _ret.IsLock = (bool)this.te_Lock.EditValue;
            _ret.SaveMode = this.te_SaveMode.EditValue.ToString();
            _ret.DisplayOrder = Convert.ToInt32(this.te_Order.EditValue.ToString());
            _ret.Columns = this.gridControl1.DataSource as List<MD_InputModel_SaveTableColumn>;
            return _ret;
        }

        public void DoCancel()
        {
            InitForm();
        }

        public void DoCommand(string CommandName)
        {
            switch (CommandName)
            {
                case "ͬ���ֶ�":
                    ColumnSync();
                    break;
                case "���д����ֶ�":
                    AddTableColumn();
                    break;
                case "ɾ��д����ֶ�":
                    DelTableColumn();
                    break;
            }
        }

        private void DelTableColumn()
        {
            if (this.gridView1.RowCount > 0 && this.gridView1.FocusedRowHandle >= 0)
            {
                MD_InputModel_SaveTableColumn _col = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as MD_InputModel_SaveTableColumn;
                List<string> PrimayKeyList = DAConfig.DataAccess.GetDBPrimayKeyList(this.SaveTable.TableName);
                foreach (string _s in PrimayKeyList)
                {
                    if (_s == _col.DesColumn)
                    {
                        XtraMessageBox.Show("���ֶ�Ϊ�����ֶΣ�����ɾ����", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (DAConfig.DataAccess.DelInputModelTableColumn(this.SaveTable.TableName, _col.DesColumn))
                {
                    ColumnSync();
                    DoSave();
                }
                else
                {
                    XtraMessageBox.Show("ɾ���ֶ�ʧ�ܣ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void AddTableColumn()
        {
            Dialog_AddTableColumn _f = new Dialog_AddTableColumn();
            if (_f.ShowDialog() == DialogResult.OK)
            {
                string _msg = "";
                //�ж��ֶ��Ƿ��Ѵ���
                IList<DB_ColumnMeta> _dbColumnList = DAConfig.DataAccess.GetDBColumnsOfTable(this.SaveTable.TableName);
                bool _find = false;
                foreach (DB_ColumnMeta _c in _dbColumnList)
                {
                    if (_c.ColumnName == _f.FieldName)
                    {
                        _find = true;
                        break;
                    }
                }

                if (_find)
                {
                    XtraMessageBox.Show("���ֶ��Ѿ����ڣ�����ֶ�ʧ�ܣ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (DAConfig.DataAccess.AddInputModelTableColumn(this.SaveTable.TableName, _f.FieldName, _f.GetDataType()))
                    {
                        ColumnSync();
                        DoSave();
                    }
                    else
                    {
                        XtraMessageBox.Show("����ֶ�ʧ�ܣ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        private void ColumnSync()
        {
            IList<DB_ColumnMeta> _dbColumnList = DAConfig.DataAccess.GetDBColumnsOfTable(this.SaveTable.TableName);
            List<MD_InputModel_SaveTableColumn> _newColumns = new List<MD_InputModel_SaveTableColumn>();
            foreach (MD_InputModel_SaveTableColumn _col in this.SaveTable.Columns)
            {
                if (FindInRealTable(_col, _dbColumnList))
                {
                    _newColumns.Add(_col);
                }
            }

            foreach (DB_ColumnMeta _dbcol in _dbColumnList)
            {
                if (!FindInOldTable(_dbcol, this.SaveTable.Columns))
                {
                    _newColumns.Add(new MD_InputModel_SaveTableColumn(DAConfig.DataAccess.GetNewID(), "", _dbcol.ColumnName, "", ""));
                }
            }

            this.gridView1.BeginUpdate();
            this.gridControl1.DataSource = _newColumns;
            this.gridView1.EndUpdate();
            DataSource = _newColumns;
        }

        private bool FindInOldTable(DB_ColumnMeta _dbcol, List<MD_InputModel_SaveTableColumn> list)
        {
            foreach (MD_InputModel_SaveTableColumn _c in list)
            {
                if (_dbcol.ColumnName == _c.SrcColumn) return true;
            }
            return false;
        }

        private bool FindInRealTable(MD_InputModel_SaveTableColumn _col, IList<DB_ColumnMeta> _dbColumnList)
        {
            foreach (DB_ColumnMeta _c in _dbColumnList)
            {
                if (_c.ColumnName == _col.SrcColumn)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
