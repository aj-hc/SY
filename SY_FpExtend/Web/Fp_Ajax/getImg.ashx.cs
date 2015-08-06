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
            string strUid = context.Request.Params["suid"].ToString();
            string strName = context.Request.Params["spname"].ToString();
            string strdate = context.Request.Params["timedate"].ToString();
            int InWidth = Convert.ToInt32(ConfigurationManager.AppSettings["ImgWidth"]);
            int InHeight = Convert.ToInt32(ConfigurationManager.AppSettings["ImgHeight"]);
            Dictionary<string, string> dicdata = new Dictionary<string, string>();
            string path = "Consentimg\\";
            Bitmap map = new Bitmap(filePath);
            string mes = "";
            if (strUid==""||strdate=="")
            {
                mes = "请检查日期是否选择";
                context.Response.Write(mes);
            }
            if (map.Width > InWidth || map.Height > InHeight)//判断图片大小
            {
                mes = "图片宽不能超过750像素，高不能超过1024像素";
                context.Response.Write(mes);
            }
            else
            {
                #region 上传
                try
                {
                    #region 将图片保存到本地 生成编码 再判断是否存在
                    DateTime dt = new DateTime();
                    dt = Convert.ToDateTime(strdate);
                    string date = dt.ToString("yyyyMMdd");
                    string fileName = Path.GetFileName(filePath);
                    string[] SplitFileName = fileName.Split('.');
                    string mapPath = context.Server.MapPath("~");
                    string savePath = mapPath + "\\" + path + strUid + date+"1" + "." + SplitFileName[1];//设置路径+（文件名称：path + strUid + date +"."+ SplitFileName[1]）
                    string imgName = strUid + date + "." + SplitFileName[1];//获取文件名称
                    string imgGuid = strUid + date;//生成唯一标识
                    //判断数据是否存在
                    Model.TB_CONSENT_FORM consent = new Model.TB_CONSENT_FORM();
                    consent.PatientName = strName;
                    consent.PatientID = Convert.ToInt32(strUid);
                    BLL.TB_CONSENT_FORM bll = new BLL.TB_CONSENT_FORM();
                    string strJson = bll.Sel_TB_CONSENT_FORM_Count_Bll(strUid, imgGuid);
                    if (strJson == "")
                    {
                        map.Save(savePath);
                        map.Clone();
                        string url = ConfigurationManager.AppSettings["FTPFolder"];
                        mes = Sel_Folder(url, dt, savePath, imgName);
                        if (mes.Contains("ftp"))
                        {
                            //写入Freezerpro文件和数据库
                            dicdata = Set_dataDic(strUid, mes);
                            mes = Import_TestData(dicdata, imgGuid, strName);
                            context.Response.Write(mes);
                        }
                        else
                        {
                            context.Response.Write(mes);
                            context.Response.End();
                            RuRo.Model.TB_SAMPLE_LOG log_model = new Model.TB_SAMPLE_LOG();
                            log_model.MSG ="知情同意书管理："+ mes;
                            RuRo.BLL.TB_SAMPLE_LOG log_bll = new BLL.TB_SAMPLE_LOG();
                            log_bll.Add(log_model);
                        }
                    }
                    else
                    {
                        mes = "该知情同意书已经存在";
                        context.Response.Write(mes);
                    }
                    #endregion
                   //将图片保存到FTP操作
                }
                catch (Exception e) 
                {
                    mes = e.ToString();
                    context.Response.Write(mes);
                }
                #endregion
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
            string strMemu = year + "/" + Month;
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
                    mes = PostImg(path, imgname, strMemu + "/");//上传到FTP
                    return mes;
                }
                else 
                {
                    mes = PostImg(path, imgname, strMemu + "/");//上传到FTP
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
                    mes = PostImg(path, imgname, strMemu+"/");//上传到FTP
                    return mes;
                }
                else
                {
                    mes = PostImg(path, imgname, strMemu + "/");//上传到FTP
                    return mes;
                }
                #endregion
            }
            
        }

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
                mes ="ftp://"+ strftp+"/"+strMemu + imgname;
                return mes;
            }
            catch(Exception ex) 
            {
                return ex.ToString() ;
            }

            
        }
        #endregion

        #region 写入临床数据
        #region 写入freezer临床数据和添加FTP
        /// <summary>
        /// 写入freezer临床数据和添加FTP
        /// </summary>
        /// <param name="datadic"></param>
        /// <param name="imgguid"></param>
        /// <returns></returns>
        public string Import_TestData(Dictionary<string, string> datadic, string imgguid, string PatientName) 
        {
            string res = "";
            //获取账号密码
            string  username = Common.CookieHelper.GetCookieValue("username");
            string pwd = Common.CookieHelper.GetCookieValue("password");
            string password = string.Empty;
            if (!string.IsNullOrEmpty(pwd))
            {
                try
                {
                    password = Common.DEncrypt.DESEncrypt.Decrypt(pwd);
                }
                catch (Exception ex)
                {
                    Common.LogHelper.WriteError(ex);
                    HttpContext.Current.Response.Redirect("Login.aspx");
                }
            }
            FreezerProUtility.Fp_Common.UnameAndPwd up = new FreezerProUtility.Fp_Common.UnameAndPwd(username, password);//存放登陆账号密码
            Dictionary<string, string> logDic = new Dictionary<string, string>();//操作日志记录
            Dictionary<string, string> importResult = new Dictionary<string, string>();//返回信息
            List<Dictionary<string, string>> dataDicList = new List<Dictionary<string, string>>();//存放临床数据
            if (datadic.Count>0)
            {
                dataDicList.Add(datadic);
                if (dataDicList.Count > 0)
                {
                    string improtTestDataResult = ImportTestData(dataDicList, up);
                    if (improtTestDataResult.Contains("\"status\":\"DONE\"") && improtTestDataResult.Contains("\"success\":true,"))
                    {
                        //导入成功--保存数据到本地数据库
                        RuRo.Model.TB_CONSENT_FORM model = new Model.TB_CONSENT_FORM();
                        model.Path = datadic["图片网络链接地址"];
                        model.PatientID =Convert.ToInt32(datadic["Sample Source"]);
                        model.Consent_From = imgguid;
                        model.PatientName = PatientName;
                        RuRo.BLL.TB_CONSENT_FORM bll = new BLL.TB_CONSENT_FORM();
                        bll.Add(model);
                        RuRo.Common.CookieHelper.ClearCookie("uid");
                        RuRo.Common.CookieHelper.ClearCookie("pname");
                        
                    }
                    res = "导入知情同意书成功，图片地址:" + datadic["图片网络链接地址"];
                }
                else
                {
                    res = "导入系统失败，请检查网络是否通畅";
                }
            }
            return res;
        }
        #endregion

        #region 把信息添加到字典中
        /// <summary>
        /// 把信息添加到字典中
        /// </summary>
        /// <param name="uid">样品源的名称</param>
        /// <param name="path">存放在FTP的路径</param>
        /// <returns></returns>
        public Dictionary<string, string> Set_dataDic(string uid,string path) 
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Sample Source", uid);
            dic.Add("图片网络链接地址", path);
            return dic;
        }
        #endregion

        #region 导入临床数据 + private string ImportTestData(Dictionary<string, string> dataDic)
        /// <summary>
        /// 导入临床数据
        /// </summary>
        /// <param name="dataDic"></param>
        /// <returns></returns>
        private string ImportTestData(List<Dictionary<string, string>> dataDicList, FreezerProUtility.Fp_Common.UnameAndPwd up)
        {
            string test_data_type = "知情同意书管理";
            string result = FreezerProUtility.Fp_BLL.TestData.ImportTestData(up, test_data_type, dataDicList);
            return result;
        }
        #endregion

        #region 匹配临床信息字典
        /// <summary>
        /// 匹配临床信息字典
        /// </summary>
        /// <param name="clinicalDicList">临床信息字典</param>
        /// <returns>匹配完成的字典</returns>
        private List<Dictionary<string, string>> MatchClinicalDic(List<Dictionary<string, string>> clinicalDicList)
        {
            Dictionary<string, string> dic = BLL.MatchFileds.ClinicalFiledsMatchDic();
            List<Dictionary<string, string>> resDicList = new List<Dictionary<string, string>>();
            foreach (var clinicalDic in clinicalDicList)
            {
                Dictionary<string, string> resDic = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> item in clinicalDic)
                {
                    if (dic.ContainsKey(item.Key))
                    {
                        string key = dic[item.Key];
                        if (!resDic.ContainsKey(key))
                        {
                            resDic.Add(key, item.Value);
                        }
                    }
                }
                resDicList.Add(resDic);
            }
            return resDicList;
        }
        #endregion

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
        #endregion

    }
}