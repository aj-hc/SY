using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web
{
    public partial class Login : System.Web.UI.Page
    {
        string username, password, type;

        protected void Page_Load(object sender, EventArgs e)
        {
            //登陆
            //验证登陆
            //跳转扩展页面
            string SuccRediToUrl = "ExtendPage.aspx";
            if (!IsPostBack)
            {
                //页面第一次加载
                //判断是否有cookie
            }
            else
            {
                type = Context.Request.Params["type"];
                if (type == "login")
                {
                    username = Context.Request.Params["txtUsername"];
                    password = Context.Request.Params["txtPass"];
                    if (checkToken(username, password))
                    {
                        Response.Redirect(SuccRediToUrl);
                    }
                }
                else if (type == "logout")
                {
                    LoginOut(Context);
                }
            }
        }
        public bool CheckLoginByCookie()
        {
            username = Common.CookieHelper.GetCookieValue("username");
            string temPass = Common.CookieHelper.GetCookieValue("password");
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                password = Common.DEncrypt.DESEncrypt.Decrypt(temPass);
                return checkToken(username, password);
            }
            else
            {
                return false;
            }
        }
        void LoginOut(HttpContext context)
        {
            Common.CookieHelper.ClearCookie("username");
            Common.CookieHelper.ClearCookie("password");
        }
        private bool checkToken(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            else
            {
                FreezerProUtility.Fp_BLL.Token token = new FreezerProUtility.Fp_BLL.Token(username, password);
                return token.checkAuth_Token();
            }
        }

        //写入cookie
        private void WriteCookie(string username, string password)
        {
            string DEnPassword = Common.DEncrypt.DESEncrypt.Encrypt(password);
            Common.CookieHelper.SetCookie("username", username);
            Common.CookieHelper.SetCookie("password", DEnPassword);
        }
    }
}