using System;
namespace RuRo.Model
{
	/// <summary>
	/// Log_Import:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Log_Import
	{
		public Log_Import()
		{}
		#region Model
		private int _id;
		private string _patientid;
		private DateTime? _import_date= DateTime.Now;
		private bool _import_state;
		private string _import_date_msg;
		private string _import_user_id;
		private string _import_user_department;
		private string _import_type;
		private string _others;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 患者唯一标识
		/// </summary>
		public string PatientID
		{
			set{ _patientid=value;}
			get{return _patientid;}
		}
		/// <summary>
		/// 导入日期
		/// </summary>
		public DateTime? Import_Date
		{
			set{ _import_date=value;}
			get{return _import_date;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public bool Import_State
		{
			set{ _import_state=value;}
			get{return _import_state;}
		}
		/// <summary>
		/// 导入消息
		/// </summary>
		public string Import_Date_Msg
		{
			set{ _import_date_msg=value;}
			get{return _import_date_msg;}
		}
		/// <summary>
		/// 用户
		/// </summary>
		public string Import_User_Id
		{
			set{ _import_user_id=value;}
			get{return _import_user_id;}
		}
		/// <summary>
		/// 科室
		/// </summary>
		public string Import_User_Department
		{
			set{ _import_user_department=value;}
			get{return _import_user_department;}
		}
		/// <summary>
		/// 导入类型
		/// </summary>
		public string Import_Type
		{
			set{ _import_type=value;}
			get{return _import_type;}
		}
		/// <summary>
		/// 其他
		/// </summary>
		public string Others
		{
			set{ _others=value;}
			get{return _others;}
		}
		#endregion Model

	}
}

