using System;
namespace RuRo.Model
{
    /// <summary>
    /// TB_CONSENT_FORM:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TB_CONSENT_FORM
    {
        public TB_CONSENT_FORM()
        { }
        #region Model
        private int _consent_id;
        private string _path;
        private string _patientname;
        private string _consent_From;
        private DateTime _date;
        
        private int _patientid;

        /// <summary>
        /// 
        /// </summary>
        public int Consent_ID
        {
            set { _consent_id = value; }
            get { return _consent_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Path
        {
            set { _path = value; }
            get { return _path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PatientName
        {
            set { _patientname = value; }
            get { return _patientname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PatientID
        {
            set { _patientid = value; }
            get { return _patientid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Consent_From
        {
            set { _consent_From = value; }
            get { return _consent_From; }
        }
        public DateTime Date
        {
            set { _date = value; }
            get { return _date; }
        }
        #endregion Model

    }
}

