using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SinoSZMetaDataBase.InputModel
{
	[Serializable]
	public class MD_InputModel_Entity
	{
		private string inputModelName = "";
		private Dictionary<string, object> inputData = new Dictionary<string, object>();
		private Dictionary<string, object> childInputData = new Dictionary<string, object>();
		private bool isNewData = true;
		public MD_InputModel_Entity() { }
		public MD_InputModel_Entity(string _inputModelName)
		{
			inputModelName = _inputModelName;
		}

		public string InputModelName
		{
			get { return inputModelName; }
			set { inputModelName = value; }
		}

		public bool IsNewData
		{
			get { return isNewData; }
			set { isNewData = value; }
		}
		public Dictionary<string, object> ChildInputData
		{
			get { return childInputData; }
			set { childInputData = value; }
		}

		public bool HaveChildData(string _index)
		{
			if (ChildInputData.ContainsKey(_index))
			{
				DataTable _dt = ChildInputData[_index] as DataTable;			
				DataView _dv = new DataView(_dt, "", "", DataViewRowState.CurrentRows);
				return (_dv.Count > 0);
			}
			else
			{
				return false;
			}
		}

		public Dictionary<string, object> InputData
		{
			get
			{
				if (inputData == null) inputData = new Dictionary<string, object>();
				return inputData;
			}
			set { inputData = value; }
		}

	}
}
