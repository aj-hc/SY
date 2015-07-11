using FreezerProUtility.Fp_Common;
using FreezerProUtility.Fp_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{
    public class UserFields
    {        //创建数据层对象
        DataWithFP dataWithFP = new DataWithFP();

        #region 获取自定义字段集合 + public List<UserFields> UserFields()
        public static List<Fp_Model.UserFields> GetAll(string url)
        {
            List<Fp_Model.UserFields> list = Fp_DAL.DataWithFP.getdata<Fp_Model.UserFields>(url, Fp_Common.FpMethod.userfields, "", "UserFields");
            return list;
        }
        #endregion

    }
}
