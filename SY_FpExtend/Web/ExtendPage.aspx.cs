using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RuRo.BLL;
using RuRo.Model;
using System.Drawing;

namespace RuRo.Web
{
    public partial class ExtendPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Login login = new Login();
                //页面第一次加载
                if (!login.CheckLoginByCookie())
                {
                    //Response.Redirect("Login.aspx");
                    //Response.Redirect("index.aspx");
                }
                string username = Common.CookieHelper.GetCookieValue("username");
                string keshi = Common.CookieHelper.GetCookieValue(username + "department");
                try
                {
                    keshi = Common.DEncrypt.DESEncrypt.Decrypt(keshi);
                }
                catch (Exception ex)
                {
                    Common.LogHelper.WriteError(ex);
                    keshi = "";
                }
            }
        }
    }
}