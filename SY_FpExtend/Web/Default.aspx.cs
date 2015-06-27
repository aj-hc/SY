using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FreezerProUrl();
                //访问页面时做登陆检查
                
            }
            
        }
        private void FreezerProUrl()
        {
            string s = System.Configuration.ConfigurationManager.AppSettings["FpUrl"];
            FreezerPro.Attributes.Add("src", s);
        }

        protected void but_Click(object sender, EventArgs e)
        {

        }
        //按时间循环遍历嵌套页面中的数据用以获取当前登录的用户，——>此处获取FP的信息可能出现问题无法获取。。
        //根据当前的用户去本地数据库中查找对应的账号、密码，根据账号密码判断是否正确
        //如果正确就弹出对应的菜单、如果不正确则弹出登陆框
        //登陆完成后获取用户表并更新到本地数据库

    }
}