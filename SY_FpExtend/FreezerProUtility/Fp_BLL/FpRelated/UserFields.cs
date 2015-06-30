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
        /// <summary>
        /// 获取自定义字段集合
        /// </summary>
        /// <returns> List<UserFields> </returns>
        public List<UserFields> UserFieldList()
        {
            List<UserFields> list_UserFields = new List<UserFields>() { };
            string str_Json = dataWithFP.getDateFromFp(FpMethod.userfields, "");
            try
            {
                string total = FpJsonHelper.GetStrFromJsonStr("Total", str_Json);
                if (Convert.ToInt32(total) > 0)
                {
                    list_UserFields = FpJsonHelper.JObjectToList<UserFields>("UserFields", str_Json);
                }
            }
            catch (Exception e)
            {
            }
            return list_UserFields;
        }
        #endregion

    }
}
