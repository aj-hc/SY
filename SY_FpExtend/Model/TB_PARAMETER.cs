using System;
namespace RuRo.Model
{
    /// <summary>
    /// TB_PARAMETER:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TB_PARAMETER
    {
        public TB_PARAMETER()
        { }
        #region Model
        private int _pid;
        private string _type;
        private string _name;
        private string _textid;
        private string _py;
        private bool _isactive;
        /// <summary>
        /// 参数设定表
        /// </summary>
        public int PID
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TYPE
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TEXTID
        {
            set { _textid = value; }
            get { return _textid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PY
        {
            set { _py = value; }
            get { return _py; }
        }
        /// <summary>
        /// 0:启用,1:关闭
        /// </summary>
        public bool ISACTIVE
        {
            set { _isactive = value; }
            get { return _isactive; }
        }
        #endregion Model

    }
}

