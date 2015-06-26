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
namespace RuRo.Web.EmployeeInfo
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
		RuRo.BLL.EmployeeInfo bll=new RuRo.BLL.EmployeeInfo();
		RuRo.Model.EmployeeInfo model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtEmployeeName.Text=model.EmployeeName;
		this.txtEmployeeNo.Text=model.EmployeeNo;
		this.txtEmployeeID.Text=model.EmployeeID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtEmployeeName.Text.Trim().Length==0)
			{
				strErr+="EmployeeName不能为空！\\n";	
			}
			if(this.txtEmployeeNo.Text.Trim().Length==0)
			{
				strErr+="EmployeeNo不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtEmployeeID.Text))
			{
				strErr+="EmployeeID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string EmployeeName=this.txtEmployeeName.Text;
			string EmployeeNo=this.txtEmployeeNo.Text;
			int EmployeeID=int.Parse(this.txtEmployeeID.Text);


			RuRo.Model.EmployeeInfo model=new RuRo.Model.EmployeeInfo();
			model.id=id;
			model.EmployeeName=EmployeeName;
			model.EmployeeNo=EmployeeNo;
			model.EmployeeID=EmployeeID;

			RuRo.BLL.EmployeeInfo bll=new RuRo.BLL.EmployeeInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
