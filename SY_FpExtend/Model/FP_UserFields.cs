using System;
namespace RuRo.Model
{
	/// <summary>
	/// FP_UserFields:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FP_UserFields
	{
		public FP_UserFields()
		{}
		#region Model
		private int _userfieldid;
		private int _id;
		private int _obj_id;
		private string _display_name;
		private string _name;
		private string _type;
		private string _values;
		private string _show;
		private string _created_at;
		private string _updated_at;
		private string _inuse;
		/// <summary>
		/// 
		/// </summary>
		public int userFieldId
		{
			set{ _userfieldid=value;}
			get{return _userfieldid;}
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
		public string display_name
		{
			set{ _display_name=value;}
			get{return _display_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string values
		{
			set{ _values=value;}
			get{return _values;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string show
		{
			set{ _show=value;}
			get{return _show;}
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
		public string updated_at
		{
			set{ _updated_at=value;}
			get{return _updated_at;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string inuse
		{
			set{ _inuse=value;}
			get{return _inuse;}
		}
		#endregion Model

	}
}

