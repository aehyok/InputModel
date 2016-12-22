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
        public partial class UC_FlowLocationStatus : DevExpress.XtraEditors.XtraUserControl
        {
                private Biz_FlowProperties CurrentFlow = null;
                public UC_FlowLocationStatus()
                {
                        InitializeComponent();
                }

                private void UC_FlowLocationStatus_Load(object sender, EventArgs e)
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
                        this.sinoUC_OrgTree1.LoadOrgList(CurrentFlow.RootDWID);
                }
        }
}
