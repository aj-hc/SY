using System;
namespace RuRo.Model
{
	/// <summary>
	/// Fp_UserFields_Match:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Fp_UserFields_Match
	{
		public Fp_UserFields_Match()
		{}
		#region Model
		private int _id;
		private int _fpudf_id;
		private string _matchfields;
		private string _issearch;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Fpudf_Id
		{
			set{ _fpudf_id=value;}
			get{return _fpudf_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MatchFields
		{
			set{ _matchfields=value;}
			get{return _matchfields;}
		}
		/// <summary>
		/// 是否是检索值
		/// </summary>
		public string IsSearch
		{
			set{ _issearch=value;}
			get{return _issearch;}
		}
		#endregion Model

	}
}

