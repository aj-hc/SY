using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace RuRo.Web.include.js
{
    /// <summary>
    /// getImg 的摘要说明
    /// </summary>
    public class getImg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //不知道为什么获取不到
            //HttpPostedFile file = context.Request.Files["userFile"];
            string filePath = context.Request["imgPath"];
            string path = "Consentimg\\";
            Bitmap map = new Bitmap(filePath);
            string fileName = Path.GetFileName(filePath);
            string mapPath = context.Server.MapPath("~");
            string savePath = mapPath + "\\" + path + fileName;
            map.Save(savePath);
            //上传成功后显示IMG文件
            StringBuilder sb = new StringBuilder();
            sb.Append("<img id=\"imgUpload\" src=\"" + path.Replace("\\", "/") + fileName + "\" />");
            context.Response.Write(sb.ToString());
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}