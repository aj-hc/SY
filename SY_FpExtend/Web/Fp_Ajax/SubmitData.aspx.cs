using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web.Fp_Ajax
{
    public partial class SubmitData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.Params["action"].ToString();
            string json = Request.Params["json"].ToString();
            Response.Write("成功获取"+json);
        }
    }
}