using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZToolFlowDesign.Controls;

namespace SinoSZToolFlowDesign
{
        public partial class frmFlowDesignTool : DevExpress.XtraEditors.XtraForm
        {
                public frmFlowDesignTool()
                {
                        InitializeComponent();
                }

                private void frmFlowDesignTool_Load(object sender, EventArgs e)
                {

                }

                private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
                {
                        this.panelControl1.Controls.Clear();
                        UC_FlowDefine _f = new UC_FlowDefine();
                        _f.Dock = DockStyle.Fill;
                        _f.Visible = true;
                        
                        this.panelControl1.Controls.Add(_f);
                        _f.BringToFront();
                }

                private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
                {
                        this.panelControl1.Controls.Clear();
                        UC_FlowStatus _f = new UC_FlowStatus();
                        _f.Dock = DockStyle.Fill;
                        _f.Visible = true;

                        this.panelControl1.Controls.Add(_f);
                        _f.BringToFront();
                }

                private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
                {
                        this.panelControl1.Controls.Clear();
                        UC_FlowStatusTransition _f = new UC_FlowStatusTransition();
                        _f.Dock = DockStyle.Fill;
                        _f.Visible = true;

                        this.panelControl1.Controls.Add(_f);
                        _f.BringToFront();
                }

                private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
                {
                        this.panelControl1.Controls.Clear();
                        UC_FlowLocationStatus _f = new UC_FlowLocationStatus();
                         _f.Dock = DockStyle.Fill;
                        _f.Visible = true;

                        this.panelControl1.Controls.Add(_f);
                        _f.BringToFront();
                }
        }
}