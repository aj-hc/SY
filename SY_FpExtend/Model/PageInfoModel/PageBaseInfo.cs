using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuRo.Model.PageInfoModel
{
    public class PageBaseInfo
    {
        public PageBaseInfo()
        { }
        #region Model
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
        private string _patientid;
        private string _registerid;
        private string _inpatientid;
       
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
        public DateTime? BirthDay
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
        public string PatientID
        {
            set { _patientid = value; }
            get { return _patientid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegisterID
        {
            set { _registerid = value; }
            get { return _registerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InPatientID
        {
            set { _inpatientid = value; }
            get { return _inpatientid; }
        }
        #endregion Model
    }
}
