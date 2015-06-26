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
namespace RuRo.Web.FP_UserFields
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int userFieldId=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(userFieldId);
				}
			}
		}
			
	private void ShowInfo(int userFieldId)
	{
		RuRo.BLL.FP_UserFields bll=new RuRo.BLL.FP_UserFields();
		RuRo.Model.FP_UserFields model=bll.GetModel(userFieldId);
		this.lbluserFieldId.Text=model.userFieldId.ToString();
		this.txtid.Text=model.id.ToString();
		this.txtobj_id.Text=model.obj_id.ToString();
		this.txtdisplay_name.Text=model.display_name;
		this.txtname.Text=model.name;
		this.txttype.Text=model.type;
		this.txtvalues.Text=model.values;
		this.txtshow.Text=model.show;
		this.txtcreated_at.Text=model.created_at;
		this.txtupdated_at.Text=model.updated_at;
		this.txtinuse.Text=model.inuse;

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
			if(this.txtdisplay_name.Text.Trim().Length==0)
			{
				strErr+="display_name不能为空！\\n";	
			}
			if(this.txtname.Text.Trim().Length==0)
			{
				strErr+="name不能为空！\\n";	
			}
			if(this.txttype.Text.Trim().Length==0)
			{
				strErr+="type不能为空！\\n";	
			}
			if(this.txtvalues.Text.Trim().Length==0)
			{
				strErr+="values不能为空！\\n";	
			}
			if(this.txtshow.Text.Trim().Length==0)
			{
				strErr+="show不能为空！\\n";	
			}
			if(this.txtcreated_at.Text.Trim().Length==0)
			{
				strErr+="created_at不能为空！\\n";	
			}
			if(this.txtupdated_at.Text.Trim().Length==0)
			{
				strErr+="updated_at不能为空！\\n";	
			}
			if(this.txtinuse.Text.Trim().Length==0)
			{
				strErr+="inuse不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int userFieldId=int.Parse(this.lbluserFieldId.Text);
			int id=int.Parse(this.txtid.Text);
			int obj_id=int.Parse(this.txtobj_id.Text);
			string display_name=this.txtdisplay_name.Text;
			string name=this.txtname.Text;
			string type=this.txttype.Text;
			string values=this.txtvalues.Text;
			string show=this.txtshow.Text;
			string created_at=this.txtcreated_at.Text;
			string updated_at=this.txtupdated_at.Text;
			string inuse=this.txtinuse.Text;


			RuRo.Model.FP_UserFields model=new RuRo.Model.FP_UserFields();
			model.userFieldId=userFieldId;
			model.id=id;
			model.obj_id=obj_id;
			model.display_name=display_name;
			model.name=name;
			model.type=type;
			model.values=values;
			model.show=show;
			model.created_at=created_at;
			model.updated_at=updated_at;
			model.inuse=inuse;

			RuRo.BLL.FP_UserFields bll=new RuRo.BLL.FP_UserFields();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
