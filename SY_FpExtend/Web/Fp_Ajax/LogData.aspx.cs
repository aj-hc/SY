using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web.Fp_Ajax
{
    public partial class LogData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/plain";
            string username = Common.CookieHelper.GetCookieValue("username");
            RuRo.Model.BasedInfo baseinfo = new Model.BasedInfo();
            RuRo.Model.ClinicalInfo clincicalinfo = new Model.ClinicalInfo();
            RuRo.Model.TB_SAMPLE_LOG log = new Model.TB_SAMPLE_LOG();

        }
    }
}