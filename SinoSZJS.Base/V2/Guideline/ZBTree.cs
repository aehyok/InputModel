
namespace SinoSZJS.Base.V2.Guideline
{
	public class ZBTree
	{
		/// <summary>
		/// 指标id
		/// </summary>
		public string ZBID { set; get; }

		/// <summary>
		/// 指标名称
		/// </summary>
		public string ZBMC { set; get; }

		/// <summary>
		/// 父指标id
		/// </summary>
		public string FID { set; get; }

		/// <summary>
		/// 显示序号
		/// </summary>
		public int Index { set; get; }

		/// <summary>
		/// 层级
		/// </summary>
		public int Level { set; get; }
	}
}
