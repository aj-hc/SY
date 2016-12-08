using System;
namespace RuRo.Model
{
    /// <summary>
    /// BasedInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BasedInfo
    {
        public BasedInfo()
        { }
        #region Model
        private int _id;
        private string _patientname;
        private string _ipseqnotext;
        private string _patientcardno;
        private string _sexflag;
        private DateTime? _birthday;
        private string _bloodtypeflag;
        private string _phone;
        private string _contactphone;
        private string _contactperson;
        private string _nativeplace;
        private string _registerseqno;
        private int? _patientid;
        private int? _registerid;
        private decimal? _inpatientid;
        private DateTime? _addtime;
        private string _identityCardNo;
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
        public string PatientName
        {
            set { _patientname = value; }
            get { return _patientname; }
        }
        public string IdentityCardNo
        {
            set { _identityCardNo = value; }
            get { return _identityCardNo; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string IPSeqNoText
        {
            set { _ipseqnotext = value; }
            get { return _ipseqnotext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PatientCardNo
        {
            set { _patientcardno = value; }
            get { return _patientcardno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SexFlag
        {
            set { _sexflag = value; }
            get { return _sexflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BloodTypeFlag
        {
            set { _bloodtypeflag = value; }
            get { return _bloodtypeflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContactPhone
        {
            set { _contactphone = value; }
            get { return _contactphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContactPerson
        {
            set { _contactperson = value; }
            get { return _contactperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NativePlace
        {
            set { _nativeplace = value; }
            get { return _nativeplace; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegisterSeqNO
        {
            set { _registerseqno = value; }
            get { return _registerseqno; }
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
        public int? RegisterID
        {
            set { _registerid = value; }
            get { return _registerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? InPatientID
        {
            set { _inpatientid = value; }
            get { return _inpatientid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ADDTIME
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model

    }
}

