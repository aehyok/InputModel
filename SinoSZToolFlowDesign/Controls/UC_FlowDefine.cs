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
        public partial class UC_FlowDefine : DevExpress.XtraEditors.XtraUserControl
        {
                private List<Biz_FlowProperties> _flows = null;
                private Biz_FlowProperties _CurrentFlow = null;
                public UC_FlowDefine()
                {
                        InitializeComponent();
                }

                private void UC_FlowDefine_Load(object sender, EventArgs e)
                {
                        _flows = Biz_FlowProperties.GetAllFlows();
                        this.gridControl1.DataSource = _flows;
                }

                private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
                {
                        if (e.FocusedRowHandle >= 0)
                        {
                                _CurrentFlow = this.gridView1.GetRow(e.FocusedRowHandle) as Biz_FlowProperties;
                                ShowFlowData();
                        }
                }

                private void ShowFlowData()
                {
                        this.te_ID.EditValue = _CurrentFlow.ID;
                        this.te_Name.EditValue = _CurrentFlow.Name;
                        this.te_Des.EditValue = _CurrentFlow.Description;
                        this.TE_ROOTDWID.EditValue = _CurrentFlow.RootDWID;
                }

                private void memoEdit1_EditValueChanged(object sender, EventArgs e)
                {
                        
                }

                private void simpleButton1_Click(object sender, EventArgs e)
                {
                        SaveCurrentData();
                }

                private void SaveCurrentData()
                {
                        _CurrentFlow.RootDWID = (this.TE_ROOTDWID.EditValue == null) ? "0" : this.TE_ROOTDWID.EditValue.ToString();
                        _CurrentFlow.Name = this.te_Name.EditValue.ToString();
                        _CurrentFlow.Description = this.te_Des.EditValue.ToString();
                        _CurrentFlow.Save();
                }

                private void simpleButton2_Click(object sender, EventArgs e)
                {
                        this.gridControl1.BeginUpdate();
                        Biz_FlowProperties _newFlow = new Biz_FlowProperties(Guid.NewGuid().ToString());
                        this._flows.Add(_newFlow);
                        this.gridControl1.EndUpdate();
                        
                }

                private void simpleButton3_Click(object sender, EventArgs e)
                {
                        int _index = this.gridView1.FocusedRowHandle;
                        if ( _index>= 0)
                        {
                                _CurrentFlow = this.gridView1.GetRow(_index) as Biz_FlowProperties;
                                this.gridControl1.BeginUpdate();
                                _flows.Remove(_CurrentFlow);
                                _CurrentFlow.DeleteMe();
                                this.gridControl1.EndUpdate();

                        }
                }
        }
}
