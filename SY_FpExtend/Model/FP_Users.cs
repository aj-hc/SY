using System;
namespace RuRo.Model
{
	/// <summary>
	/// FP_Users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FP_Users
	{
		public FP_Users()
		{}
		#region Model
		private int _userid;
		private int _id;
		private int _obj_id;
		private string _username;
		private string _fullname;
		private string _email;
		private string _created_at;
		private string _disabled;
		private string _active;
		private string _role;
		private string _samples;
		/// <summary>
		/// 
		/// </summary>
		public int userID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
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
		public int obj_id
		{
			set{ _obj_id=value;}
			get{return _obj_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fullname
		{
			set{ _fullname=value;}
			get{return _fullname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string created_at
		{
			set{ _created_at=value;}
			get{return _created_at;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string disabled
		{
			set{ _disabled=value;}
			get{return _disabled;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string active
		{
			set{ _active=value;}
			get{return _active;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string role
		{
			set{ _role=value;}
			get{return _role;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string samples
		{
			set{ _samples=value;}
			get{return _samples;}
		}
		#endregion Model

	}
}

