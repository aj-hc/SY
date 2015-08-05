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
            if (map.Width > 10000 || map.Height > 10240)//判断图片大小
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
                    string savePath = mapPath + "\\" + path + strUid + date+"1" + "." + SplitFileName[1];//设置路径+（文件名称：path + strUid + date +"."+ SplitFileName[1]）
                    map.Save(savePath);
                    map.Clone();
                    string imgName=strUid + date + "." + SplitFileName[1];//获取文件名称
                    #endregion
                   //将图片保存到FTP操作
                    string url = ConfigurationManager.AppSettings["FTPFolder"];
                    mes= Sel_Folder(url, dt, savePath, imgName);
                    if(mes=="上传成功")
                    {
                        
                        //写入Freezerpro文件
                        
                        //写入数据库
                    }
                    else
                    {
                        context.Response.Write(mes);
                    }
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
        #region FTP操作
        /// <summary>
        /// 上传到指定的FTP空间
        /// </summary>
        /// <param name="url">FTP地址</param>
        /// <param name="dt">前台传来的日期</param>
        /// <param name="path">图片保存在服务端的路径</param>
        /// <param name="strGuid">图片名称</param>
        /// <returns></returns>
        public string Sel_Folder(string url,DateTime dt,string path,string imgname) 
        {
            string mes = "";
            RuRo.Common.FTP.FTPHelper ftp = new Common.FTP.FTPHelper(url, "", "", "");
            string year = dt.Year.ToString();
            string Month = dt.Month.ToString();
            string strMemu = year + "\\" + Month;
            string[] YearFolder = ftp.GetDirectoryList();
            if (Get_FolderForBool(year, YearFolder))//判断是否存在年份命名的文件夹，没有则创建
            {
                ftp.MakeDir(year);//创建文件夹
                #region 判断所属的月份是否存在并操作
                ftp.GotoDirectory(year,true);//进入年份目录
                string[] MonthFolder = ftp.GetDirectoryList();
                if (Get_FolderForBool(Month, MonthFolder))
                {
                    ftp.MakeDir(Month);
                    mes= PostImg(path, imgname, strMemu);//上传到FTP
                    return mes;
                }
                else 
                {
                    mes = PostImg(path, imgname, strMemu);//上传到FTP
                    return mes;
                }
                #endregion
            }
            else
            {
                #region 判断所属的月份是否存在并操作
                ftp.GotoDirectory(year, true);//进入子目录
                string[] MonthFolder = ftp.GetDirectoryList();
                if (Get_FolderForBool(Month, MonthFolder))
                {
                    ftp.MakeDir(Month);
                    mes = PostImg(path, imgname, strMemu);//上传到FTP
                    return mes;
                }
                else
                {
                    mes = PostImg(path, imgname, strMemu);//上传到FTP
                    return mes;
                }
                #endregion
            }
            
        }
        #region 判断路径是否存在
        /// <summary>
        /// 判断根目录是否存在文件夹
        /// </summary>
        /// <param name="year">文件夹分类</param>
        /// <param name="yearfolder">文件夹集合</param>
        /// <returns></returns>
        public bool Get_FolderForBool(string date, string[] strfolder) 
        {
            for (int i = 0; i < strfolder.Length; i++)
            {
                if (date == strfolder[i])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
        /// <summary>
        /// 上传到FTP
        /// </summary>
        /// <param name="path">本地路径</param>
        /// <param name="imgname">本地文件名称</param>
        /// <param name="strMemu">存放子目录</param>
        /// <returns></returns>
        public string PostImg(string path, string imgname, string strMemu) 
        {
            //获取FTP地址，账号，密码
            string mes = "";
            try
            {
                string strftp = ConfigurationManager.AppSettings["FTPFolder"];
                string struser = ConfigurationManager.AppSettings["FTPUser"];
                string strpwd = ConfigurationManager.AppSettings["FTPPWD"];
                int InPort = Convert.ToInt32(ConfigurationManager.AppSettings["FTPPort"]);
                RuRo.Common.FTP.FTPClient ftpc = new Common.FTP.FTPClient();
                ftpc.RemoteHost = strftp;
                ftpc.RemoteUser = struser;
                ftpc.RemotePass = strpwd;
                ftpc.RemotePort = InPort;
                ftpc.RemotePath = strMemu;
                ftpc.PutByGuid(path, imgname);
                mes = strftp + strMemu + imgname;
                return mes;
            }
            catch(Exception ex) 
            {
                return ex.ToString() ;
            }

            
        }
        #endregion
    }
}