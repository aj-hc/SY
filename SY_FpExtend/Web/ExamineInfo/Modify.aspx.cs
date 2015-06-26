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
		RuRo.BLL.ExamineInfo bll=new RuRo.BLL.ExamineInfo();
		RuRo.Model.ExamineInfo model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtExamineRequestID.Text=model.ExamineRequestID.ToString();
		this.txtItemSetNo.Text=model.ItemSetNo;
		this.txtDescription.Text=model.Description;
		this.txtItemSetID.Text=model.ItemSetID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int id=int.Parse(this.lblid.Text);
			int ExamineRequestID=int.Parse(this.txtExamineRequestID.Text);
			string ItemSetNo=this.txtItemSetNo.Text;
			string Description=this.txtDescription.Text;
			int ItemSetID=int.Parse(this.txtItemSetID.Text);


			RuRo.Model.ExamineInfo model=new RuRo.Model.ExamineInfo();
			model.id=id;
			model.ExamineRequestID=ExamineRequestID;
			model.ItemSetNo=ItemSetNo;
			model.Description=Description;
			model.ItemSetID=ItemSetID;

			RuRo.BLL.ExamineInfo bll=new RuRo.BLL.ExamineInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
