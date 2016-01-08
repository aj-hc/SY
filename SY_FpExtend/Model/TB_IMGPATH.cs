using System;
namespace RuRo.Model
{
	[Serializable]
	public partial class TB_IMGPATH
	{
		public TB_IMGPATH()
		{}
		#region Model
		private int _id;
		private string _imgname;
		private string _keshi;
		private DateTime? _date;
		private string _imgpath;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IMGNAME
		{
			set{ _imgname=value;}
			get{return _imgname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KESHI
		{
			set{ _keshi=value;}
			get{return _keshi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DATE
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IMGPATH
		{
			set{ _imgpath=value;}
			get{return _imgpath;}
		}
		#endregion Model

	}
}

