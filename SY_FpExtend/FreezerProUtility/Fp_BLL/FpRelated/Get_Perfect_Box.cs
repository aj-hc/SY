using FreezerProUtility.Fp_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{
    public class Get_Perfect_Box
    {
        /// <summary>
        /// 查询指定冰箱指定位置是否存在符合条件的盒子
        /// </summary>
        /// <param name="url">链接fp的url包含账号密码信息</param>
        /// <param name="space">需要的空孔数量</param>
        /// <param name="freezer_name">冰箱名称</param>
        /// <returns></returns>
        public static string get_perfect_box(string url, string space, string freezer_name)
        {
            string resultStr = string.Empty;
            bool check;
            string param = string.Format("{&space={0}&freezer_name={1}}", space, freezer_name);
            string connUrl = UrlHelper.ConnectionUrlAndPar(url, FpMethod.get_perfect_box, param, out check);
            resultStr = Fp_DAL.DataWithFP.getDateFromFp(connUrl);
            return resultStr;
            //暂时如此，直接返回查询之后的结果，能不能查到得到都返回，后期需要将返回结果解析之后返回
            //http://192.168.183.130/api?username=admin&password=123456&method=get_perfect_box&freezer_name=tem->admin->06&space=8
            //{"success":true,"box_id":1351,"location":"tem->admin->06->02->1"}
        }


    }
}
