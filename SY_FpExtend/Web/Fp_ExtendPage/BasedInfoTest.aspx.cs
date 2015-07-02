using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web.Fp_ExtendPage
{
    public partial class BasedInfoTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ok_Click(object sender, EventArgs e)
        {
            RuRo.BLL.BasedInfo baseinfo = new BLL.BasedInfo();
            txtBasedInfo.Text = baseinfo.Exists(1).ToString();
        }
    }
}