using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZToolFlowDesign.BLL;
using DevExpress.XtraGrid.Views.Base;

namespace SinoSZToolFlowDesign.Controls
{
    public partial class UC_FlowStatus : DevExpress.XtraEditors.XtraUserControl
    {
        private Biz_FlowState CurrentState = null;
        private Biz_FlowProperties CurrentFlow = null;
        public UC_FlowStatus()
        {
            InitializeComponent();
        }

        private void UC_FlowStatus_Load(object sender, EventArgs e)
        {
            List<Biz_FlowProperties> _flows = Biz_FlowProperties.GetAllFlows();
            this.te_FlowList.Properties.Items.Clear();
            foreach (Biz_FlowProperties _fd in _flows)
            {
                this.te_FlowList.Properties.Items.Add(_fd);
            }
        }

        private void te_FlowList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (te_FlowList.SelectedItem == null) return;
            CurrentFlow = te_FlowList.SelectedItem as Biz_FlowProperties;
            if (CurrentFlow.Status == null) CurrentFlow.LoadStatus();
            this.gridControl1.BeginUpdate();
            this.gridControl1.DataSource = null;
            this.gridControl1.DataSource = CurrentFlow.Status;
            this.gridControl1.EndUpdate();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.CurrentFlow == null)
            {
                XtraMessageBox.Show("请选择一个业务流程！", "系统提示");
            }
            else
            {
                this.gridControl1.BeginUpdate();
                Biz_FlowState _newState = new Biz_FlowState(Guid.NewGuid().ToString(), CurrentFlow);
                this.CurrentFlow.Status.Add(_newState);
                this.gridControl1.EndUpdate();
                XtraMessageBox.Show("新状态已创建！", "系统提示");
            }
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                CurrentState = this.gridView1.GetRow(e.FocusedRowHandle) as Biz_FlowState;
                ShowStateData();
            }
        }

        private void ShowStateData()
        {
            this.te_ID.EditValue = CurrentState.StateID;
            this.te_Name.EditValue = CurrentState.StateName;
            this.te_Display.EditValue = CurrentState.DisplayName;
            this.te_Des.EditValue = CurrentState.Description;
            this.te_Type.SelectedIndex = 1;
            this.te_Order.EditValue = CurrentState.Order;
            for (int i = 0; i < this.te_Type.Properties.Items.Count; i++)
            {
                string _s = this.te_Type.Properties.Items[i].ToString();
                if (_s == CurrentState.Type)
                {
                    this.te_Type.SelectedIndex = i;
                    return;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveCurrentData();
        }

        private void SaveCurrentData()
        {
            CurrentState.StateName = this.te_Name.EditValue.ToString();
            CurrentState.Description = this.te_Des.EditValue.ToString();
            CurrentState.Type = this.te_Type.SelectedItem.ToString();
            CurrentState.DisplayName = this.te_Display.EditValue.ToString();
            CurrentState.Order = Convert.ToInt32(this.te_Order.EditValue);
            CurrentState.Save();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int _index = this.gridView1.FocusedRowHandle;
            if (_index >= 0)
            {
                CurrentState = this.gridView1.GetRow(_index) as Biz_FlowState;
                this.gridControl1.BeginUpdate();
                CurrentState.DeleteMe();
                this.CurrentFlow.Status.Remove(CurrentState);
                this.gridControl1.DataSource = null;
                this.gridControl1.DataSource = this.CurrentFlow.Status;
                this.gridControl1.EndUpdate();
            }
        }
    }
}
