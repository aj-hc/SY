using System;
namespace RuRo.Model
{
	/// <summary>
	/// TB_Disease:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TB_Disease
	{
		public TB_Disease()
		{}
		#region Model
		private int _id;
		private int _diseaseid;
		private string _diseasename;
		private string _mnemoniccode;
		private string _icdcode;
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
		public int DiseaseID
		{
			set{ _diseaseid=value;}
			get{return _diseaseid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DiseaseName
		{
			set{ _diseasename=value;}
			get{return _diseasename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MnemonicCode
		{
			set{ _mnemoniccode=value;}
			get{return _mnemoniccode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ICDCode
		{
			set{ _icdcode=value;}
			get{return _icdcode;}
		}
		#endregion Model

	}
}

