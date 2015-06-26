using System;
namespace RuRo.Model
{
	/// <summary>
	/// SurgeryInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SurgeryInfo
	{
		public SurgeryInfo()
		{}
		#region Model
		private int _id;
		private int _surgeryrequestid;
		private string _icdcode;
		private string _surgeryname;
		private DateTime? _requestexecutivedatetime;
		private int? _requestdoctoremployeeid;
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
		public int SurgeryRequestID
		{
			set{ _surgeryrequestid=value;}
			get{return _surgeryrequestid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ICDCode
		{
			set{ _icdcode=value;}
			get{return _icdcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SurgeryName
		{
			set{ _surgeryname=value;}
			get{return _surgeryname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RequestExecutiveDateTime
		{
			set{ _requestexecutivedatetime=value;}
			get{return _requestexecutivedatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RequestDoctorEmployeeID
		{
			set{ _requestdoctoremployeeid=value;}
			get{return _requestdoctoremployeeid;}
		}
		#endregion Model

	}
}

