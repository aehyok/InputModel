using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZToolInputModelDefine.EditPanel
{
	public partial class UC_GuideLineManager : DevExpress.XtraEditors.XtraUserControl
	{
		private MD_GuideLine _guideLine = null;
		public UC_GuideLineManager()
		{
			InitializeComponent();
		}

		public UC_GuideLineManager(MD_GuideLine _gline)
		{
			InitializeComponent();
			_guideLine = _gline;
			RefreshData();
		}

		private void RefreshData()
		{
			te_ID.EditValue = _guideLine.ID;
			te_Name.EditValue = _guideLine.GuideLineName;
			te_Order.EditValue = _guideLine.DisplayOrder;
			te_SF.EditValue = _guideLine.GuideLineMethod;
		}

		public void Save()
		{
			_guideLine.GuideLineName = (te_Name.EditValue == null) ? "" : this.te_Name.EditValue.ToString();
			_guideLine.DisplayOrder = (te_Order.EditValue == null) ? 0 : int.Parse(this.te_Order.EditValue.ToString());
			_guideLine.GuideLineMethod = (te_SF.EditValue == null) ? "" : this.te_SF.EditValue.ToString();
			DAConfig.DataAccess.SaveGuideLine(_guideLine);
		}
	}
}
