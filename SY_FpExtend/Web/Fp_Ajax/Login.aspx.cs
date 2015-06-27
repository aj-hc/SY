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
        string username = "", password = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["type"] == "logout")
            {
                Response.Cookies["loginCookie"].Expires.AddDays(0);
                Response.Write("<button style=\"width:50px;\" onclick=\"dologin()\">登录</button>使用FreezerPro协同助手");
            }
            else if (Request.Params["type"] == "login")
            {
                username = Request.Params["username"];
                password = Request.Params["password"];
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    if (checkToken(Context))
                    {
                        string newPassowrd = FreezerProUtility.Fp_Common.EncodeAndDecodeString.Encode(password);
                        HttpCookie loginCookie = new HttpCookie("loginCookie");
                        loginCookie.Values.Add("Username", username);
                        loginCookie.Values.Add("Password", newPassowrd);
                        loginCookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(loginCookie);
                        Context.Session.Add("Username", username);
                        Context.Session.Add("Password", newPassowrd);
                        Response.Write("{\"success\":true,\"msg\":\"恭喜你,登录成功,欢迎使用FreezerPro协同助手！\"}");
                    }
                }
                else
                {
                    Response.Write("{\"success\":false,\"msg\":\"对不起,用户名或密码错误,请重新输入！\"}");
                }
            }
        }
        public string checklogin(HttpContext context)
        {
            Response.ContentType = "text/html";
            if (Request.Cookies["loginCookie"] == null)
            {
                return ("<button id='dologin' style=\"width:40px;\" onclick=\"dologin()\">登录</button>FreezerPro协同助手");
            }
            else
            {
                return ("<button style=\"width:40px;\" onclick=\"doimport()\">导入</button><button style=\"width:40px;\" onclick=\"logout()\">注销</button>");
            }
        }
        /// <summary>
        /// 根据账号密码检查token
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool checkToken(HttpContext context)
        {
            //获取用户输入的账号密码验证数据是否正确
            username = Request.Params["username"];
            password = Request.Params["password"];
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                //通过api方法检查登陆，并将账号密码传入
                FreezerProUtility.Fp_BLL.Token token = new FreezerProUtility.Fp_BLL.Token(username,password);
                //return token.checkLogin();
            }
            return false;
        }
    }
}