using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RuRo.BLL;
using RuRo.Model;

namespace RuRo.Web
{
    public partial class ExtendPage : System.Web.UI.Page
    {
        public bool loginState = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //页面第一次加载
                //判断是否有cookie
            }
        }
    }
}