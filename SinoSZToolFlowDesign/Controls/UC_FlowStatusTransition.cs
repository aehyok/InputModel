using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZToolFlowDesign.BLL;

namespace SinoSZToolFlowDesign.Controls
{
        public partial class UC_FlowStatusTransition : DevExpress.XtraEditors.XtraUserControl
        {
                private Biz_FlowState CurrentState = null;
                private Biz_FlowProperties CurrentFlow = null;
                private Biz_StateAction CurrentAction = null;
                public UC_FlowStatusTransition()
                {
                        InitializeComponent();
                }

                private void UC_FlowStatusTransition_Load(object sender, EventArgs e)
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

                        this.te_ActionName.EditValue = "";
                        this.te_ActionTitle.EditValue = "";
                        this.te_StateName.EditValue = "";
                        this.te_EndState.EditValue = null;
                        CurrentState = null;
                        CurrentAction = null;
                        this.te_EndState.Properties.Items.Clear();
                        foreach (Biz_FlowState _st in CurrentFlow.Status)
                        {
                                this.te_EndState.Properties.Items.Add(_st);
                        }
                        this.gridControl2.BeginUpdate();
                        this.gridControl2.DataSource = null;
                        this.gridControl2.EndUpdate();
                        this.gridControl1.DataSource = CurrentFlow.Status;
                        this.gridControl1.EndUpdate();

                }

                private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
                {
                        ShowState();
                }

                private void ShowState()
                {
                        if (this.gridView1.FocusedRowHandle >= 0)
                        {
                                CurrentState = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Biz_FlowState;
                        }
                        else
                        {
                                CurrentState = null;
                        }

                        //显示状态
                        this.gridControl2.BeginUpdate();
                        this.gridControl2.DataSource = null;
                        if (CurrentState != null)
                        {
                                if (CurrentState.Actions == null) CurrentState.LoadActions();
                                this.gridControl2.DataSource = CurrentState.Actions;
                                ShowStateData();
                                ShowActionInfo();
                        }
                        else
                        {
                        }
                        this.gridControl2.EndUpdate();
                }

                private void ShowStateData()
                {
                        //显示状态属性
                        if (CurrentState != null)
                        {
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
                                this.Button_SaveState.Enabled = true;
                        }
                        else
                        {
                                this.te_Name.EditValue = "";
                                this.te_Name.EditValue = "";
                                this.te_Display.EditValue = "";
                                this.te_Des.EditValue = "";
                                this.te_Type.SelectedIndex = 1;
                                this.te_Order.EditValue = "";
                                this.Button_SaveState.Enabled = false;
                        }
                }


                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        //添加动作
                        if (CurrentState != null)
                        {
                                this.gridControl2.BeginUpdate();
                                Biz_StateAction _newAction = new Biz_StateAction(Guid.NewGuid().ToString(), CurrentState);
                                this.CurrentState.Actions.Add(_newAction);
                                this.gridControl2.EndUpdate();
                        }
                }

                private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
                {

                        ShowActionInfo();

                }

                private void ShowActionInfo()
                {
                        //显示动作信息
                        int _index = this.gridView2.FocusedRowHandle;
                        if (_index >= 0)
                        {
                                CurrentAction = this.gridView2.GetRow(_index) as Biz_StateAction;
                        }
                        else
                        {
                                CurrentAction = null;
                        }

                        if (CurrentAction != null)
                        {
                                this.te_StateName.EditValue = CurrentAction.BeginStateName;
                                this.te_ActionName.EditValue = CurrentAction.ActionName;
                                this.te_ActionTitle.EditValue = CurrentAction.ActionTitle;
                                this.te_EndState.SelectedItem = CurrentFlow.GetStateDefine(CurrentAction.EndState);
                                this.te_Aorder.EditValue = CurrentAction.DisplayOrder;
                                this.te_ActionParam.EditValue = CurrentAction.ParamDefine;
                                for (int i = 0; i < this.te_ATYPE.Properties.Items.Count; i++)
                                {
                                        string _s = this.te_ATYPE.Properties.Items[i].ToString();
                                        if (_s == CurrentAction.ActionType)
                                        {
                                                this.te_ATYPE.SelectedIndex = i;
                                                break;
                                        }
                                }
                                this.te_UTYPE.SelectedIndex = CurrentAction.UserType;

                        }
                        else
                        {
                                this.te_StateName.EditValue = "";
                                this.te_ActionName.EditValue = "";
                                this.te_ActionTitle.EditValue = "";
                                this.te_EndState.SelectedItem = null;
                        }

                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        //保存动作
                        this.gridControl2.BeginUpdate();
                        if (CurrentAction == null) return;
                        CurrentAction.ActionName = this.te_ActionName.EditValue.ToString();
                        CurrentAction.ActionTitle = this.te_ActionTitle.EditValue.ToString();
                        CurrentAction.ActionType = this.te_ATYPE.SelectedItem.ToString();
                        CurrentAction.UserType = this.te_UTYPE.SelectedIndex;
                        CurrentAction.DisplayOrder = int.Parse(this.te_Aorder.EditValue.ToString());
                        CurrentAction.ParamDefine = this.te_ActionParam.EditValue.ToString();
                        if (this.te_EndState.SelectedItem == null)
                        {
                                XtraMessageBox.Show("请输入目标状态！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                                //CurrentAction.EndState = null;
                        }
                        else
                        {
                                Biz_FlowState _selectedEndState = this.te_EndState.SelectedItem as Biz_FlowState;
                                CurrentAction.EndState = _selectedEndState.StateDefine;
                        }

                        CurrentAction.Save();
                        this.gridControl2.EndUpdate();

                }

                private void simpleButton3_Click(object sender, EventArgs e)
                {
                        //删除动作
                        int _index = this.gridView2.FocusedRowHandle;
                        if (_index >= 0)
                        {
                                CurrentAction = this.gridView2.GetRow(_index) as Biz_StateAction;
                                this.gridControl2.BeginUpdate();
                                CurrentAction.DeleteMe();
                                this.CurrentState.Actions.Remove(CurrentAction);
                                this.gridControl2.DataSource = null;
                                this.gridControl2.DataSource = this.CurrentState.Actions;
                                this.gridControl2.EndUpdate();
                        }
                }

                private void label6_Click(object sender, EventArgs e)
                {

                }

                private void simpleButton6_Click(object sender, EventArgs e)
                {
                        //删除状态
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
                                ShowState();
                        }
                }

                private void Button_SaveState_Click(object sender, EventArgs e)
                {
                        //保存状态属性
                        SaveCurrentStateData();
                }

                private void SaveCurrentStateData()
                {
                        if (CurrentState != null)
                        {
                                CurrentState.StateName = this.te_Name.EditValue.ToString();
                                CurrentState.Description = this.te_Des.EditValue.ToString();
                                CurrentState.Type = this.te_Type.SelectedItem.ToString();
                                CurrentState.DisplayName = this.te_Display.EditValue.ToString();
                                CurrentState.Order = Convert.ToInt32(this.te_Order.EditValue);
                                CurrentState.Save();
                        }
                }

                private void simpleButton5_Click(object sender, EventArgs e)
                {
                        //添加状态
                        this.gridControl1.BeginUpdate();
                        Biz_FlowState _newState = new Biz_FlowState(Guid.NewGuid().ToString(), CurrentFlow);
                        this.CurrentFlow.Status.Add(_newState);
                        this.gridControl1.DataSource = null;
                        this.gridControl1.DataSource = this.CurrentFlow.Status;
                        this.gridControl1.EndUpdate();
                        ShowState();
                }

                private void label14_Click(object sender, EventArgs e)
                {

                }
        }
}
