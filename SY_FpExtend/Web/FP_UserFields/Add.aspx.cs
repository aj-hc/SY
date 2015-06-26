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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
