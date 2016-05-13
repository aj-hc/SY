using System;
namespace RuRo.Model
{
    /// <summary>
    /// TB_SAMPLE_LOG:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TB_SAMPLE_LOG
    {
        public TB_SAMPLE_LOG()
        { }
        #region Model
        private int _log_id;
        private int? _patientid;
        private string _base_msg;
        private string _clinical_msg;
        private string _msg;
        private string _state;
        private DateTime? _log_date;
        private string _type;
        private string _log_up;
        /// <summary>
        /// 
        /// </summary>
        public int LOG_ID
        {
            set { _log_id = value; }
            get { return _log_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PatientID
        {
            set { _patientid = value; }
            get { return _patientid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BASE_MSG
        {
            set { _base_msg = value; }
            get { return _base_msg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CLINICAL_MSG
        {
            set { _clinical_msg = value; }
            get { return _clinical_msg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MSG
        {
            set { _msg = value; }
            get { return _msg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string STATE
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LOG_DATE
        {
            set { _log_date = value; }
            get { return _log_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LOG_UP
        {
            set { _log_up = value; }
            get { return _log_up; }
        }
        #endregion Model

    }
}

