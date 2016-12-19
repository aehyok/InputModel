using System.Collections.Generic;

namespace SinoSZJS.Base.V2.Entry
{
	public interface ICustomsEntry
	{
		EntryItem_List GetEntryItemByID(string _id);
		EntryItem CreateEntryHeadByDataRow(object dataSource);
		bool CreateNewThread(string _xsid, string _xsbh, List<EntryItem> SelectedEntryList);
        EntryItem GetEntryItem(string _entryid, string _xsid, string _userName);
		EntryItem GetEntryFromDs(object data);
	}
}
