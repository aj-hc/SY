
using System;
namespace RuRo.Web
{
    /// <summary>
    /// Login 的摘要说明。
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ViewState["GUID"] = System.Guid.NewGuid().ToString();
                if (CheckLoginByCookie())
                {
                    Response.Redirect("ExtendPage.aspx");
                }
            }

            //登陆
            //验证登陆
            //跳转扩展页面
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin.Click += new System.Web.UI.ImageClickEventHandler(this.btnLogin_Click);

        }
        #endregion

        private void btnLogin_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            #region 检查登陆
            string userName = RuRo.Common.PageValidate.InputText(txtUsername.Value.Trim(), 30);
            string passWord = RuRo.Common.PageValidate.InputText(txtPass.Value.Trim(), 30);
            if (checkToken(userName, passWord))
            {
                WriteCookie(userName, passWord);
                Response.Redirect("ExtendPage.aspx");
            }
            else
            {
                lblMsg.Text = "请检查账号密码";
                //Response.Redirect("Login.aspx");
            }
            #endregion
        }

        public bool CheckLoginByCookie()
        {
            string userName = Common.CookieHelper.GetCookieValue("username");
            string temPass = Common.CookieHelper.GetCookieValue("password");
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(temPass))
            {
              string   passWord = Common.DEncrypt.DESEncrypt.Decrypt(temPass);
                return checkToken(userName, passWord);
            }
            else
            {
                return false;
            }
        }
        void LoginOut()
        {
            Common.CookieHelper.ClearCookie("username");
            Common.CookieHelper.ClearCookie("password");
        }
        private bool checkToken(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            else
            {
                FreezerProUtility.Fp_BLL.Token token = new FreezerProUtility.Fp_BLL.Token(username, password);
                return token.checkAuth_Token();
            }
        }
        //写入cookie
        private void WriteCookie(string username, string password)
        {
            string DEnPassword = Common.DEncrypt.DESEncrypt.Encrypt(password);
            Common.CookieHelper.SetCookie("username", username);
            Common.CookieHelper.SetCookie("password", DEnPassword);
        }
    }
}
