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
        private int _base_id;
        private int _clinical_id;
        private string _sample_type;
        private string _sample_tiji;
        private int? _sample_qty;
        private string _status;
        private string _msg;
        private DateTime _log_date;
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
        public int BASE_ID
        {
            set { _base_id = value; }
            get { return _base_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CLINICAL_ID
        {
            set { _clinical_id = value; }
            get { return _clinical_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SAMPLE_TYPE
        {
            set { _sample_type = value; }
            get { return _sample_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SAMPLE_TIJI
        {
            set { _sample_tiji = value; }
            get { return _sample_tiji; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SAMPLE_QTY
        {
            set { _sample_qty = value; }
            get { return _sample_qty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string STATUS
        {
            set { _status = value; }
            get { return _status; }
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
        public DateTime LOG_DATE
        {
            set { _log_date = value; }
            get { return _log_date; }
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

