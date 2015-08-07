using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web
{
    public partial class Encrypt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ok_Click(object sender, EventArgs e)
        {
            string strDes = "server=" + txtFuWu.Text.Trim() + ";database=" + txtSql.Text.Trim() + ";uid=" + txtUser.Text.Trim() + ";pwd=" + txtPwd.Text.Trim();
            txtEncrypt.Text = RuRo.Common.DEncrypt.DESEncrypt.Encrypt(strDes, "litianping");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = RuRo.Common.DEncrypt.DESEncrypt.Encrypt(txtFuWu.Text.Trim(), "litianping");
            string user = RuRo.Common.DEncrypt.DESEncrypt.Encrypt(txtUser.Text.Trim(), "litianping"); 
            string pwd = RuRo.Common.DEncrypt.DESEncrypt.Encrypt(txtPwd.Text.Trim(), "litianping");
            txtEncrypt.Text = "FTP路径：" + path + "\n 账号：" + user + "\n 密码："+pwd;
        }
    }
}