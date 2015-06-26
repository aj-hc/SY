using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuRo.Model
{
    public partial class FP_SY_HIS_IP_PublicInterface
    {
        public FP_SY_HIS_IP_PublicInterface()
		{
        }
        #region Model
        private int  _In_RegisterID;//门诊挂号ID
        private int _In_InPatientID;//住院ID
        private int _In_CodeType;//卡类型
        private string _In_Code;//卡号
        public int In_RegisterID 
        {
            set { _In_RegisterID = value; }
            get { return _In_RegisterID; }
        }
        public int In_InPatientID
        {
            set { _In_InPatientID = value; }
            get { return _In_InPatientID; }
        }
        public int In_CodeType
        {
            set { _In_CodeType = value; }
            get { return _In_CodeType; }
        }
        public string In_Code 
        {
            set { _In_Code = value; }
            get { return _In_Code; }
        }

        #endregion
    }
}
