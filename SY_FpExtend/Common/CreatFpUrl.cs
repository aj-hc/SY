using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuRo.Common
{
    public class CreatFpUrl
    {
        static string url = System.Configuration.ConfigurationManager.AppSettings["FpUrl"];
        static string username = Common.CookieHelper.GetCookieValue("username");
        static string password = Common.DEncrypt.DESEncrypt.Decrypt(Common.CookieHelper.GetCookieValue("password"));
        /// <summary>
        /// FpUrl--用户登陆之后从cookie中获取--如果禁用cookie则会一直提醒登陆
        /// </summary>
        public static string FpUrl = string.Format("{0}/api?username={1}&password={2}", url, username, password);
    }
}
