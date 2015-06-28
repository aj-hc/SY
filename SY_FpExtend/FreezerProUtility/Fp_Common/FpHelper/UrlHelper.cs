using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_Common
{
    public static class UrlHelper
    {
        /// <summary>
        /// 链接url
        /// </summary>
        /// <param name="url">带有ip，账号、密码的url字符串</param>
        /// <param name="fpMethod">方法</param>
        /// <param name="param">方法参数</param>
        /// <param name="check">链接是否成功</param>
        /// <returns></returns>
        public static string ConnectionUrlAndPar(string url, FpMethod fpMethod, string param,out  bool check)
        {
            StringBuilder rseUrl = new StringBuilder();
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(fpMethod.ToString()))
            {
                check = false;
                return "";
            }
            else
            {
                check = true;
                if (string.IsNullOrEmpty(param))
                {
                    rseUrl.AppendFormat("{0}&method={1}", url, fpMethod);
                }
                else
                {
                    rseUrl.AppendFormat("{0}&method={1}&{2}", url, fpMethod,param);
                }
                return rseUrl.ToString();
            }
        }
    }
}
