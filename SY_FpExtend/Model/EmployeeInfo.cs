using System;
namespace RuRo.Model
{
	/// <summary>
	/// EmployeeInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EmployeeInfo
	{
		public EmployeeInfo()
		{}
		#region Model
		private int _id;
		private string _employeename;
		private string _employeeno;
		private int? _employeeid;
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
		public string EmployeeName
		{
			set{ _employeename=value;}
			get{return _employeename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmployeeNo
		{
			set{ _employeeno=value;}
			get{return _employeeno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmployeeID
		{
			set{ _employeeid=value;}
			get{return _employeeid;}
		}
		#endregion Model

	}
}

