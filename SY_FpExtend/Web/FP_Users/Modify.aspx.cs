using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace RuRo.Web.FP_Users
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int userID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(userID);
				}
			}
		}
			
	private void ShowInfo(int userID)
	{
		RuRo.BLL.FP_Users bll=new RuRo.BLL.FP_Users();
		RuRo.Model.FP_Users model=bll.GetModel(userID);
		this.lbluserID.Text=model.userID.ToString();
		this.txtid.Text=model.id.ToString();
		this.txtobj_id.Text=model.obj_id.ToString();
		this.txtusername.Text=model.username;
		this.txtfullname.Text=model.fullname;
		this.txtemail.Text=model.email;
		this.txtcreated_at.Text=model.created_at;
		this.txtdisabled.Text=model.disabled;
		this.txtactive.Text=model.active;
		this.txtrole.Text=model.role;
		this.txtsamples.Text=model.samples;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtid.Text))
			{
				strErr+="id格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtobj_id.Text))
			{
				strErr+="obj_id格式错误！\\n";	
			}
			if(this.txtusername.Text.Trim().Length==0)
			{
				strErr+="username不能为空！\\n";	
			}
			if(this.txtfullname.Text.Trim().Length==0)
			{
				strErr+="fullname不能为空！\\n";	
			}
			if(this.txtemail.Text.Trim().Length==0)
			{
				strErr+="email不能为空！\\n";	
			}
			if(this.txtcreated_at.Text.Trim().Length==0)
			{
				strErr+="created_at不能为空！\\n";	
			}
			if(this.txtdisabled.Text.Trim().Length==0)
			{
				strErr+="disabled不能为空！\\n";	
			}
			if(this.txtactive.Text.Trim().Length==0)
			{
				strErr+="active不能为空！\\n";	
			}
			if(this.txtrole.Text.Trim().Length==0)
			{
				strErr+="role不能为空！\\n";	
			}
			if(this.txtsamples.Text.Trim().Length==0)
			{
				strErr+="samples不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int userID=int.Parse(this.lbluserID.Text);
			int id=int.Parse(this.txtid.Text);
			int obj_id=int.Parse(this.txtobj_id.Text);
			string username=this.txtusername.Text;
			string fullname=this.txtfullname.Text;
			string email=this.txtemail.Text;
			string created_at=this.txtcreated_at.Text;
			string disabled=this.txtdisabled.Text;
			string active=this.txtactive.Text;
			string role=this.txtrole.Text;
			string samples=this.txtsamples.Text;


			RuRo.Model.FP_Users model=new RuRo.Model.FP_Users();
			model.userID=userID;
			model.id=id;
			model.obj_id=obj_id;
			model.username=username;
			model.fullname=fullname;
			model.email=email;
			model.created_at=created_at;
			model.disabled=disabled;
			model.active=active;
			model.role=role;
			model.samples=samples;

			RuRo.BLL.FP_Users bll=new RuRo.BLL.FP_Users();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
