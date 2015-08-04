using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web
{
    public partial class Text : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFile file = Request.Files[i];
                if (file.ContentLength > 0)
                {
                    if (file.ContentType.Contains("image/"))
                    {
                        using (System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream))
                        {
                            string FileName = System.IO.Path.GetFileName(file.FileName);
                            string[] SplitFileName = FileName.Split('.');
                            string AtterFileName = DateTime.Now.ToString("yyyMMddHHmmss") + "." + SplitFileName[1];
                            img.Save(Server.MapPath("/Consentimg/" + AtterFileName));
                            this.Image1.ImageUrl = "Consentimg/" + AtterFileName;
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('该文件不是图片格式！');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('请选择要上传的图片');</script>");
                }
            }
        }
    }
}