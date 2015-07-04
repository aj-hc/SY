using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuRo.Model.PageInfoModel
{
    public class PageClinicalInfo
    {
        public PageClinicalInfo()
		{}
		#region Model
		private string _diagnosetypeflag;
        private string _diagnosedatetime;
        private string _registerid;
        private string _inpatientid;
		private string _icdcode;
		private string _diseasename;
		private string _description;


		public string DiagnoseTypeFlag
		{
			set{ _diagnosetypeflag=value;}
			get{return _diagnosetypeflag;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string DiagnoseDateTime
		{
			set{ _diagnosedatetime=value;}
			get{return _diagnosedatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RegisterID
		{
			set{ _registerid=value;}
			get{return _registerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InPatientID
		{
			set{ _inpatientid=value;}
			get{return _inpatientid;}
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
		public string DiseaseName
		{
			set{ _diseasename=value;}
			get{return _diseasename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model
    }
}
