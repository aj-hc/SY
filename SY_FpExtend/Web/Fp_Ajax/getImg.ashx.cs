using LTP.Accounts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System;

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
            string strUid = context.Request.Params["uid"].ToString();
            string strdate = context.Request.Params["timedate"].ToString();
            string path = "Consentimg\\";
            Bitmap map = new Bitmap(filePath);
            string mes = "";
            if (strUid==""||strdate=="")
            {
                mes = "请检查日期是否选择";
                context.Response.Write(mes);
                return;
            }
            if (map.Width > 1000 || map.Height > 1024)//判断图片大小
            {
                mes = "图片宽不能超过750像素，高不能超过1024像素";
                context.Response.Write(mes);
                return;
            }
            else 
            {
                try
                {
                    #region 将图片保存到本地 生成编码
                    DateTime dt = new DateTime();
                    dt = Convert.ToDateTime(strdate);
                    string date = dt.ToString("yyyyMMdd");
                    string fileName = Path.GetFileName(filePath);
                    string[] SplitFileName = fileName.Split('.');
                    string mapPath = context.Server.MapPath("~");
                    string savePath = mapPath + "\\" + path + strUid + date + "." + SplitFileName[1];//设置路径+（文件名称：path + strUid + date +"."+ SplitFileName[1]）
                    map.Save(savePath);
                    #endregion
                    #region 将图片保存到指定的空间 FTP操作
                    string url = ConfigurationManager.AppSettings["FTPFolder"];
                    Sel_Folder(url, dt, savePath);
                    #endregion
                    //上传成功后显示IMG文件
                    //StringBuilder sb = new StringBuilder();
                    //sb.Append("<img id=\"imgUpload\" src=\"" + path.Replace("\\", "/") + fileName + "\" />");
                    //context.Response.Write(sb.ToString());
                    //context.Response.End();
                }
                catch (Exception e) 
                {
                    mes = e.ToString();
                    context.Response.Write(mes);
                }
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 操作FTP上传到指定空间
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dt"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string Sel_Folder(string url,DateTime dt,string path) 
        {
            string mes = "";
            //Uri ui = new System.Uri(url);
            RuRo.Common.FTP.FtpWeb ftp = new Common.FTP.FtpWeb(url,"","","");
            string year = dt.Year.ToString();
            string Month = dt.Month.ToString();
            string[] YearFolder = ftp.GetDirectoryList();
            if (Get_YearFolder(year,YearFolder))//判断是否存在年份命名的文件夹，没有则创建
            {
                ftp.MakeDir(year);//创建文件夹
                #region 判断所属的月份是否存在并操作
                ftp.GotoDirectory(year,true);//进入年份目录
                string[] MonthFolder = ftp.GetDirectoryList();
                if (Get_MonthFolder(Month, MonthFolder))
                {
                    ftp.MakeDir(Month);
                    #region 上传
                    ftp.GotoDirectory(Month, true);//进入月份目录
                    
                    PostImg(ftp, path);
                    #endregion
                }
                else 
                {

                }
                #endregion
            }
            else
            {
                #region 判断所属的月份是否存在并操作
                ftp.GotoDirectory(year, true);//进入子目录
                string[] MonthFolder = ftp.GetDirectoryList();
                if (Get_MonthFolder(Month, MonthFolder))
                {
                    ftp.MakeDir(Month);
                    #region 上传
                    ftp.GotoDirectory(Month, true);//进入月份目录
                    PostImg(ftp,path);
                    #endregion
                }
                else
                {
                    #region 上传
                    ftp.GotoDirectory(Month, true);//进入月份目录
                    PostImg(ftp, path);
                    #endregion
                }
                #endregion
            }
            return "";
        }
        /// <summary>
        /// 判断根目录是否存在文件夹
        /// </summary>
        /// <param name="year"></param>
        /// <param name="yearfolder"></param>
        /// <returns></returns>
        public bool Get_YearFolder(string year, string[] yearfolder) 
        {
            for (int i = 0; i < yearfolder.Length; i++)
            {
                if (year==yearfolder[i])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 判断是否存在子文件夹
        /// </summary>
        /// <param name="month"></param>
        /// <param name="monthfolder"></param>
        /// <returns></returns>
        public bool Get_MonthFolder(string month, string[] monthfolder) 
        {
            for (int i = 0; i < monthfolder.Length; i++)
            {
                if (month == monthfolder[i])
                {
                    return false;
                }
            }
            return true;
        }
        public string PostImg(RuRo.Common.FTP.FtpWeb ftp,string path) 
        {
            ftp.Upload(path);
            return "";
        }
    }
}