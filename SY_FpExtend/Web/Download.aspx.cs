using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace RuRo.Web
{
    public partial class Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string strImgName = Request["imgname"].ToString();
                string strDate = Request["imgdate"].ToString();
                DateTime dt = Convert.ToDateTime(strDate);
                string strpath = dt.Year + "/" + dt.Month;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic = GetFtpPathAndLogin();
                RuRo.Common.FTP.FTPHelper ftpc = new Common.FTP.FTPHelper(dic["FTPFolder2"], strpath, dic["FTPUser"], dic["FTPPWD"]);
                Stream stream = ftpc.DownloadInfo(strImgName);
                byte[] byteImg = StreamToBytes(stream).ToArray();//将图片转化为二进制流输出
                Response.ContentType = "image/jpeg";//设定格式
                Response.BinaryWrite(byteImg);//打印出来
                Response.End();//结束坑爹的
            }
            catch (Exception ex) 
            {
                Response.Write("查询有误，请检查网络");
            }
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

    }
}