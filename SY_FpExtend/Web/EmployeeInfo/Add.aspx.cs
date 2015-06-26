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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			string EmployeeName=this.txtEmployeeName.Text;
			string EmployeeNo=this.txtEmployeeNo.Text;
			int EmployeeID=int.Parse(this.txtEmployeeID.Text);

			RuRo.Model.EmployeeInfo model=new RuRo.Model.EmployeeInfo();
			model.EmployeeName=EmployeeName;
			model.EmployeeNo=EmployeeNo;
			model.EmployeeID=EmployeeID;

			RuRo.BLL.EmployeeInfo bll=new RuRo.BLL.EmployeeInfo();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
