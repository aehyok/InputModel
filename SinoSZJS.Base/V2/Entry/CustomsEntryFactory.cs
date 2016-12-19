using System;
using System.Collections.Generic;

namespace SinoSZJS.Base.V2.Entry
{
	public class CustomsEntryFactory
	{
		private static ICustomsEntry ics_CustomsEntry = null;
		public static ICustomsEntry ICS_CustomsEntry
		{
			get
			{
				if (ics_CustomsEntry == null)
				{
					throw new Exception("报关单接口未定义！");
				}
				else
				{
					return ics_CustomsEntry;
				}

			}
			set
			{
				ics_CustomsEntry = value;
			}
		}


		public static EntryItem CreateEntryHeadByDataRow(object data)
		{
			return ICS_CustomsEntry.CreateEntryHeadByDataRow(data);
		}

		public static bool CreateNewThread(string _xsid, string _xsbh, List<EntryItem> SelectedEntryList)
		{
			return ICS_CustomsEntry.CreateNewThread(_xsid, _xsbh, SelectedEntryList);
		}


        public static EntryItem GetEntryItem(string _entryid, string _xsid, string _userName)
		{
            return ICS_CustomsEntry.GetEntryItem(_entryid, _xsid, _userName);
		}

		public static EntryItem GetEntryFromDs(object data)
		{
			return ICS_CustomsEntry.GetEntryFromDs(data);
		}
	}
}
