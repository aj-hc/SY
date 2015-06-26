using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web.Fp_Ajax
{
    public partial class L : System.Web.UI.Page
    {
        string username = "", password = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/html";
            if (Request.Params["type"] == "checklogin")
            {
            }
            if (Request.Params["type"] == "logout")
            {
                Response.Cookies["loginCookie"].Expires.AddDays(0);
                Response.Write("<button style=\"width:50px;\" onclick=\"dologin()\">登录</button>使用FreezerPro协同助手");
            }
            else if (Request.Params["type"] == "login")
            {
                username = Request.Params["username"];
                password = Request.Params["password"];
                if (true)
                {
                    HttpCookie loginCookie = new HttpCookie("loginCookie");
                    loginCookie.Values.Add("Username", username);
                    loginCookie.Values.Add("Password", password);
                    loginCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(loginCookie);
                    Response.Write("恭喜你,登录成功,欢迎使用FreezerPro协同助手！");
                }
                else
                {
                    Response.Write("对不起,用户名或密码错误,请重新输入！");
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
                //BLL.Token token = new BLL.Token(username, password);
                //return token.checkAuth_Token();
            }
            return false;
        }
    }
}