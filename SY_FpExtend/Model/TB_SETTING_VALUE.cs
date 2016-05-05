using System;
namespace RuRo.Model
{
    /// <summary>
    /// TB_SETTING_VALUE:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TB_SETTING_VALUE
    {
        public TB_SETTING_VALUE()
        { }
        #region Model
        private int _setting_id;
        private string _setting_type;
        private string _setting_value;
        private string _departments;
        private DateTime? _add_time;
        /// <summary>
        /// 
        /// </summary>
        public int SETTING_ID
        {
            set { _setting_id = value; }
            get { return _setting_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SETTING_TYPE
        {
            set { _setting_type = value; }
            get { return _setting_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SETTING_VALUE
        {
            set { _setting_value = value; }
            get { return _setting_value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DEPARTMENTS
        {
            set { _departments = value; }
            get { return _departments; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ADD_TIME
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model

    }
}

