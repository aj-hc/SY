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
            //string strPP = "C7858DB550DCB5F335580D4F9628066F7579DE0866A0DC7609FE656A87A31203C3DEE08FDEDD5825BAF4040A622DCFC9F71CCD2A0525AAF607FAD2B5357A16EFB872D1B6F8C135C08C041C8F84E21F4E";
            //txtEncrypt.Text = RuRo.Common.DEncrypt.DESEncrypt.Decrypt(strPP, "litianping");
            string strDes = "server=" + txtFuWu.Text.Trim() + ";database=" + txtSql.Text.Trim() + ";uid=" + txtUser.Text.Trim() + ";pwd=" + txtPwd.Text.Trim();
            txtEncrypt.Text = RuRo.Common.DEncrypt.DESEncrypt.Encrypt(strDes, "litianping");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = RuRo.Common.DEncrypt.DESEncrypt.Encrypt(txtFuWu.Text.Trim(), "litianping");
            string user = RuRo.Common.DEncrypt.DESEncrypt.Encrypt(txtUser.Text.Trim(), "litianping"); 
            string pwd = RuRo.Common.DEncrypt.DESEncrypt.Encrypt(txtPwd.Text.Trim(), "litianping");
            txtEncrypt.Text = "";
            txtEncrypt.Text = "FTP路径：" + path + "\n 账号：" + user + "\n 密码："+pwd;
            string str = "FTP路径：" + path + "\n 账号：" + user + "\n 密码：" + pwd;
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = RuRo.Common.DEncrypt.DESEncrypt.Decrypt(txtEncrypt.Text.Trim(), "litianping");
            txtEncrypt.Text = "";
            txtEncrypt.Text = str;
        }
    }
}