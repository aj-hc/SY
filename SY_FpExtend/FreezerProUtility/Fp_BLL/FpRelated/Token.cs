using FreezerProUtility.Fp_Common;
using FreezerProUtility.Fp_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace FreezerProUtility.Fp_BLL
{
    public class Token
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public Token(string username, string password)
        {
            UserName = username;
            PassWord = password;
        }
        #endregion
        private string Get_Auth_Token()
        {
            FpUrlMaker FpUrlMaker = new Fp_BLL.FpUrlMaker();
            FpUrlMaker.UserName = UserName;
            FpUrlMaker.PassWord = PassWord;
            string connFpUrl = string.Format("{0}&method={1}", FpUrlMaker.CreatFpUrlMaker(), Fp_Common.FpMethod.gen_token);
            string result = DataWithFP.getDateFromFp(connFpUrl);
            return result;
        }

        /// <summary>
        /// 检查是否能获取到auth_token（能获取说明账号密码路径都没问题）
        /// </summary>
        /// <returns>返回检查结果</returns>
        public bool checkAuth_Token()
        {
            string auth_TokenStr = Get_Auth_Token();
            return ValidationData.checkAuth_Token(auth_TokenStr);
        }
    }
}
