using System.Collections.Generic;

namespace SinoSZJS.Base.V2.BackLog
{
    //todo:aehyok 添加注释
	public class BackLogGroup
	{
		public string GroupName { set; get; }
		public string GroupTitle { set; get; }
		public List<BackLogRegInfo> BackLogs { set; get; }
	}
}
