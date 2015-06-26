using System;
namespace RuRo.Model
{
	/// <summary>
	/// ExamineInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ExamineInfo
	{
		public ExamineInfo()
		{}
		#region Model
		private int _id;
		private int _examinerequestid;
		private string _itemsetno;
		private string _description;
		private int? _itemsetid;
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
		public int ExamineRequestID
		{
			set{ _examinerequestid=value;}
			get{return _examinerequestid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItemSetNo
		{
			set{ _itemsetno=value;}
			get{return _itemsetno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ItemSetID
		{
			set{ _itemsetid=value;}
			get{return _itemsetid;}
		}
		#endregion Model

	}
}

