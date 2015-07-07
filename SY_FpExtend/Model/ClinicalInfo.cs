using System;
namespace RuRo.Model
{
    /// <summary>
    /// ClinicalInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ClinicalInfo
    {
        public ClinicalInfo()
        { }
        #region Model
        private int _id;
        private string _diagnosetypeflag;
        private DateTime? _diagnosedatetime;
        private int? _registerid;
        private int? _inpatientid;
        private string _icdcode;
        private string _diseasename;
        private string _description;
        private string _type;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DiagnoseTypeFlag
        {
            set { _diagnosetypeflag = value; }
            get { return _diagnosetypeflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DiagnoseDateTime
        {
            set { _diagnosedatetime = value; }
            get { return _diagnosedatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RegisterID
        {
            set { _registerid = value; }
            get { return _registerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? InPatientID
        {
            set { _inpatientid = value; }
            get { return _inpatientid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ICDCode
        {
            set { _icdcode = value; }
            get { return _icdcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DiseaseName
        {
            set { _diseasename = value; }
            get { return _diseasename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        #endregion Model

    }
}

