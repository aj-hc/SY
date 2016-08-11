using System;
namespace RuRo.Model
{
    /// <summary>
    /// TB_Family:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TB_Family
    {
        public TB_Family()
        { }
        #region Model
        private int _id;
        private int _patientid;
        private string _patientname;
        private string _sexflag;
        private DateTime _birthday;
        private int _pfamilyid;
        private string _pfamilyname;
        private string _familyneuxs;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
        public string PatientName
        {
            set { _patientname = value; }
            get { return _patientname; }
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
        public DateTime Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PFamilyID
        {
            set { _pfamilyid = value; }
            get { return _pfamilyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PFamilyName
        {
            set { _pfamilyname = value; }
            get { return _pfamilyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FamilyNeuxs
        {
            set { _familyneuxs = value; }
            get { return _familyneuxs; }
        }
        #endregion Model

    }
}

