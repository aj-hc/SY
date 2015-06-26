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
namespace RuRo.Web.FP_Users
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int userID=(Convert.ToInt32(strid));
					ShowInfo(userID);
				}
			}
		}
		
	private void ShowInfo(int userID)
	{
		RuRo.BLL.FP_Users bll=new RuRo.BLL.FP_Users();
		RuRo.Model.FP_Users model=bll.GetModel(userID);
		this.lbluserID.Text=model.userID.ToString();
		this.lblid.Text=model.id.ToString();
		this.lblobj_id.Text=model.obj_id.ToString();
		this.lblusername.Text=model.username;
		this.lblfullname.Text=model.fullname;
		this.lblemail.Text=model.email;
		this.lblcreated_at.Text=model.created_at;
		this.lbldisabled.Text=model.disabled;
		this.lblactive.Text=model.active;
		this.lblrole.Text=model.role;
		this.lblsamples.Text=model.samples;

	}


    }
}
