using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace RuRo.Web.Fp_Ajax
{
    /// <summary>
    /// DowImg 的摘要说明 FTP操作
    /// </summary>
    public class DowImg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string strImgName = context.Request["imgname"].ToString();
            string strDate = context.Request["imgdate"].ToString();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic = GetFtpPathAndLogin();
            RuRo.Common.FTP.FTPHelper ftpc = new Common.FTP.FTPHelper(dic["FTPFolder2"], "", dic["FTPUser"], dic["FTPPWD"]);
           // ftpc.Download(dic["SaveImgPath"], "100065631620151111.jpg");
            Stream  stream=  ftpc.DownloadInfo(strImgName);
            byte[] byteImg = StreamToBytes(stream).ToArray();
            context.Response.BinaryWrite(byteImg);
            
            context.Response.End();
        }


        /// <summary>
        /// 将Stream转化为byte[]
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public MemoryStream StreamToBytes(Stream stream)
        {
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[1024];

            while (true)
            {
                int sz = stream.Read(buffer, 0, 1024);
                if (sz == 0) break;
                ms.Write(buffer, 0, sz);
            }
            ms.Position = 0;
            return ms;
            //byte[] bytes = new byte[2048];
            //stream.Read(bytes, 0, bytes.Length);
            //// 设置当前流的位置为流的开始
            //stream.Seek(0, SeekOrigin.Begin);
            //return bytes;
        }
        /// <summary>
        /// 获取FTP
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetFtpPathAndLogin()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string strftp = RuRo.Common.DEncrypt.DESEncrypt.IsDesDecrypt(ConfigurationManager.AppSettings["FTPFolder"], "litianping");
            string strftp2 = RuRo.Common.DEncrypt.DESEncrypt.IsDesDecrypt(ConfigurationManager.AppSettings["FTPFolder2"], "litianping");
            string struser = RuRo.Common.DEncrypt.DESEncrypt.IsDesDecrypt(ConfigurationManager.AppSettings["FTPUser"], "litianping");
            string strpwd = RuRo.Common.DEncrypt.DESEncrypt.IsDesDecrypt(ConfigurationManager.AppSettings["FTPPWD"], "litianping");
            string strhost = RuRo.Common.DEncrypt.DESEncrypt.IsDesDecrypt(ConfigurationManager.AppSettings["SaveImgPath"], "litianping");
            int InPort = Convert.ToInt32(ConfigurationManager.AppSettings["FTPPort"].ToString());
            if (strftp == "TMD")
            {
                dic.Add("FTPFolder", ConfigurationManager.AppSettings["FTPFolder"].ToString());
            }
            else
            {
                dic.Add("FTPFolder", strftp);
            }
            if (strftp2 == "TMD")
            {
                dic.Add("FTPFolder2", ConfigurationManager.AppSettings["FTPFolder2"].ToString());
            }
            else
            {
                dic.Add("FTPFolder2", strftp2);
            }
            if (struser == "TMD")
            {
                dic.Add("FTPUser", ConfigurationManager.AppSettings["FTPUser"].ToString());
            }
            else
            {
                dic.Add("FTPUser", struser);
            }
            if (strpwd == "TMD")
            {
                dic.Add("FTPPWD", ConfigurationManager.AppSettings["FTPPWD"].ToString());
            }
            else
            {
                dic.Add("FTPPWD", strpwd);
            }
            if (strpwd == "TMD")
            {
                dic.Add("SaveImgPath", ConfigurationManager.AppSettings["SaveImgPath"].ToString());
            }
            else
            {
                dic.Add("SaveImgPath", strpwd);
            }
            dic.Add("FTPPort", InPort.ToString());
            return dic;
        }

        /// <summary>
        /// 获取FTP上面的图片
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="code">编码</param>
        /// <returns></returns>
        public string DowImgForFTP(string date, string code)
        {
            string strImgName = code + date;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic = GetFtpPathAndLogin();//获取FTP
            string url = dic["FTPFolder2"];
            string struser = dic["FTPUser"];
            string strpwd = dic["FTPPWD"];
            RuRo.Common.FTP.FTPOperater ftpp = new Common.FTP.FTPOperater();
            RuRo.Common.FTP.FTPHelper ftp = new Common.FTP.FTPHelper(url, "", struser, strpwd);
            ftp.Download("2015", strImgName);
            return "";
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