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
namespace RuRo.Web.Fp_UserFields_Match
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(id);
				}
			}
		}
			
	private void ShowInfo(int id)
	{
		RuRo.BLL.Fp_UserFields_Match bll=new RuRo.BLL.Fp_UserFields_Match();
		RuRo.Model.Fp_UserFields_Match model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtFpudf_Id.Text=model.Fpudf_Id.ToString();
		this.txtMatchFields.Text=model.MatchFields;
		this.txtIsSearch.Text=model.IsSearch;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtFpudf_Id.Text))
			{
				strErr+="Fpudf_Id格式错误！\\n";	
			}
			if(this.txtMatchFields.Text.Trim().Length==0)
			{
				strErr+="MatchFields不能为空！\\n";	
			}
			if(this.txtIsSearch.Text.Trim().Length==0)
			{
				strErr+="是否是检索值不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			int Fpudf_Id=int.Parse(this.txtFpudf_Id.Text);
			string MatchFields=this.txtMatchFields.Text;
			string IsSearch=this.txtIsSearch.Text;


			RuRo.Model.Fp_UserFields_Match model=new RuRo.Model.Fp_UserFields_Match();
			model.id=id;
			model.Fpudf_Id=Fpudf_Id;
			model.MatchFields=MatchFields;
			model.IsSearch=IsSearch;

			RuRo.BLL.Fp_UserFields_Match bll=new RuRo.BLL.Fp_UserFields_Match();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
