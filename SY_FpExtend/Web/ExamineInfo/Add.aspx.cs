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
namespace RuRo.Web.ExamineInfo
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtExamineRequestID.Text))
			{
				strErr+="ExamineRequestID格式错误！\\n";	
			}
			if(this.txtItemSetNo.Text.Trim().Length==0)
			{
				strErr+="ItemSetNo不能为空！\\n";	
			}
			if(this.txtDescription.Text.Trim().Length==0)
			{
				strErr+="Description不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtItemSetID.Text))
			{
				strErr+="ItemSetID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ExamineRequestID=int.Parse(this.txtExamineRequestID.Text);
			string ItemSetNo=this.txtItemSetNo.Text;
			string Description=this.txtDescription.Text;
			int ItemSetID=int.Parse(this.txtItemSetID.Text);

			RuRo.Model.ExamineInfo model=new RuRo.Model.ExamineInfo();
			model.ExamineRequestID=ExamineRequestID;
			model.ItemSetNo=ItemSetNo;
			model.Description=Description;
			model.ItemSetID=ItemSetID;

			RuRo.BLL.ExamineInfo bll=new RuRo.BLL.ExamineInfo();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
