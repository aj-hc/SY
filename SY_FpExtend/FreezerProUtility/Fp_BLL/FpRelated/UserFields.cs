using FreezerProUtility.Fp_Common;
using FreezerProUtility.Fp_DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{
    public class UserFields
    {        //创建数据层对象

        #region 获取自定义字段集合 + public List<UserFields> UserFields()
        public static List<Fp_Model.UserFields> GetAll(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.userfields.ToString());
            Fp_DAL.CallApi call = new CallApi(dic);
            List<Fp_Model.UserFields> list = call.getdata<Fp_Model.UserFields>("UserFields");
            return list;
        }
        #endregion
        /// <summary>
        /// 获取传回来的数据转化为字典
        /// </summary>
        /// <param name="up"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllIdAndNamesDic(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<FreezerProUtility.Fp_Model.UserFields> list = GetAll(up);
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    dic.Add(item.name, item.values);
                }
            }
            return dic;
        }
        /// <summary>
        /// 转化一下
        /// </summary>
        /// <param name="up"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Fp_Model.UserFields GetBy(Fp_Common.UnameAndPwd up, string name)
        {
            List<Fp_Model.UserFields> List = GetAll(up);
            Fp_Model.UserFields userFields = new Fp_Model.UserFields();
            if (List != null && List.Count > 0)
            {
               
            }
            return userFields;
        }
    }
}
