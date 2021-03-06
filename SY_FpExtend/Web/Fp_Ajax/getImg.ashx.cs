﻿using LTP.Accounts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web.include.js
{
    /// <summary>
    /// getImg 的摘要说明
    /// </summary>
    public class getImg : IHttpHandler
    {
        //存放FTP的话把这个加到文件里面
        //<add key="FTPFolder" value="192.168.1.101"/>
        //<add key="FTPFolder2" value="192.168.1.101:23"/>
        //<add key="FTPUser" value="admin"/>
        //<add key="FTPPWD" value="admin123"/>
        //<add key="FTPPort" value="23"/>
        public void ProcessRequest(HttpContext context)
        {
            //不知道为什么获取不到
            //HttpPostedFile file = context.Request.Files["userFile"];
            #region 获取基本参数
            string filePath = context.Request["imgpath"];
            string strUid = context.Request.Params["suid"].ToString();
            string strName = context.Request.Params["spname"].ToString();
            string strdate = context.Request.Params["timedate"].ToString();
            string keshi = GetKeshi();
            string strPy = keshicode(keshi);//将科室转化
            Dictionary<string, string> dickeshi = new Dictionary<string, string>();
            dickeshi.Add("keshi", keshi);
            dickeshi.Add("SP", strPy);
            //FileUpload myfile = new FileUpload();

            HttpPostedFile myfile = context.Request.Files["imgpath"];
            #endregion
            Dictionary<string, string> dicdata = new Dictionary<string, string>();
            string path = @"Consentimg\";
            myfile.SaveAs(path);
            RuRo.Common.Filehleper.DirFileHelper.CreateDir(path);
            string mes = "";
            if (strUid == "" || strdate == "")
            {
                mes = "请检查日期是否选择";
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
                    string savePath = mapPath + @"\" + path + dickeshi["SP"].ToString() + "_" + strUid + "-" + date + "." + SplitFileName[1];//设置路径+（文件名称：path + strUid + date +"."+ SplitFileName[1]）
                    string imgName = dickeshi["SP"].ToString() + "_" + strUid + "-" + date + "." + SplitFileName[1];//获取文件名称
                    string imgGuid = dickeshi["SP"].ToString() + "_" + strUid + "-" + date;//生成唯一标识
                    //判断数据是否存在
                    BLL.TB_CONSENT_FORM bll = new BLL.TB_CONSENT_FORM();
                    string strJson = bll.Sel_TB_CONSENT_FORM_Count_Bll(strUid, imgGuid);
                    if (strJson == "")
                    {
                        try
                        {
                            Bitmap map = new Bitmap(filePath);
                            //map.Save(savePath);
                            long quality = long.Parse(System.Configuration.ConfigurationManager.AppSettings["ImgQuality"]);
                            Common.ImageHelper.ImageClass img = new Common.ImageHelper.ImageClass();
                            //压缩图片并保存
                            img.Compress(filePath, savePath, map.Width, map.Height, quality);
                            //map.Clone();
                            map.Dispose();
                        }
                        catch (System.Exception ex)
                        {
                            Common.LogHelper.WriteError("MAP文件未找到");
                        }

                        //上传到指定的FTP空间
                        mes = Sel_Folder(dt, savePath, imgName, dickeshi);
                        if (mes.Contains("Download"))
                        {
                            //写入Freezerpro文件和数据库
                            dicdata = Set_dataDic(strUid, mes);
                            mes = Import_TestData(dicdata, imgGuid, strName, dickeshi["keshi"].ToString());
                            //清空Consentimg目录下的图片
                            if (RuRo.Common.Filehleper.DirFileHelper.IsExistDirectory(mapPath + "\\" + path))
                            {
                                RuRo.Common.Filehleper.DirFileHelper.DeleteDirectory(mapPath + "\\" + path);
                            }
                            context.Response.Write(mes);
                        }
                        else
                        {
                            //context.Response.Write(mes);
                            //context.Response.End();
                            //写日志
                            RuRo.Model.TB_SAMPLE_LOG log_model = new Model.TB_SAMPLE_LOG();
                            log_model.MSG = "知情同意书管理：" + mes;
                            RuRo.BLL.TB_SAMPLE_LOG log_bll = new BLL.TB_SAMPLE_LOG();
                            log_bll.Add(log_model);
                            //返回消息
                            context.Response.Write(mes);
                            context.Response.End();
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

        #region FTP操作
        /// <summary>
        /// 上传到指定的FTP空间
        /// </summary>
        /// <param name="url">FTP地址</param>
        /// <param name="dt">前台传来的日期</param>
        /// <param name="path">图片保存在服务端的路径</param>
        /// <param name="strGuid">图片名称</param>
        /// <param name="host">网页主机名称</host>
        /// <returns></returns>
        public string Sel_Folder(DateTime dt, string path, string imgname, Dictionary<string, string> dickeshi)
        {
            string mes = "";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            // dic = GetFtpPathAndLogin();
            dic = RuRo.BLL.TB_CONSENT_FORM.FtpPathAndLogin();
            string url = dic["FTPFolder2"];
            string struser = dic["FTPUser"];
            string strpwd = dic["FTPPWD"];
            RuRo.Common.FTP.FTPHelper ftp = new Common.FTP.FTPHelper(url, "", struser, strpwd);
            string year = dt.Year.ToString();
            string Month = dt.Month.ToString();
            string strMemu = dickeshi["SP"].ToString() + "/" + year + "/" + Month;
            string[] YearFolder = ftp.GetDirectoryList();//获取所有文件夹列表
            string[] Folders = ftp.GetFilesDetailList();//获取所有文件夹列表
            if (Get_FolderForBool(dickeshi["SP"].ToString(), YearFolder))//判断是否存在科室文件夹
            {
                ftp.MakeDir(dickeshi["SP"].ToString());//创建文件夹
                ftp.GotoDirectory(dickeshi["SP"].ToString(), true);//进入科室目录
                if (Get_FolderForBool(year, YearFolder))//判断是否存在年份命名的文件夹，没有则创建//没有返回true
                {
                    ftp.MakeDir(year);//创建文件夹
                    #region 判断所属的月份是否存在并操作
                    ftp.GotoDirectory(dickeshi["SP"].ToString() + "/" + year, true);//进入年份目录
                    string[] MonthFolder = ftp.GetDirectoryList();
                    if (Get_FolderForBool(Month, MonthFolder))
                    {
                        ftp.MakeDir(Month);
                        mes = PostImg(path, imgname, strMemu + "/", dt);//上传图片到FTP，并返回访问字符串
                        return mes;
                    }
                    else
                    {
                        mes = PostImg(path, imgname, strMemu + "/", dt);//上传图片到FTP，并返回访问字符串
                        return mes;
                    }
                    #endregion
                }
                else
                {
                    #region 判断所属的月份是否存在并操作
                    ftp.GotoDirectory(dickeshi["SP"].ToString() + "/" + year, true);//进入年份目录
                    string[] MonthFolder = ftp.GetDirectoryList();
                    if (Get_FolderForBool(Month, MonthFolder))
                    {
                        ftp.MakeDir(Month);
                        mes = PostImg(path, imgname, strMemu + "/", dt);//上传图片到FTP，并返回访问字符串
                        return mes;
                    }
                    else
                    {
                        mes = PostImg(path, imgname, strMemu + "/", dt);//上传图片到FTP，并返回访问字符串
                        return mes;
                    }
                    #endregion
                }
            }
            else
            {
                ftp.GotoDirectory(dickeshi["SP"].ToString(), true);//进入科室目录
                if (Get_FolderForBool(year, YearFolder))//判断是否存在年份命名的文件夹，没有则创建//没有返回true
                {
                    ftp.MakeDir(year);//创建文件夹
                    #region 判断所属的月份是否存在并操作
                    ftp.GotoDirectory(year, true);//进入年份目录
                    string[] MonthFolder = ftp.GetDirectoryList();
                    if (Get_FolderForBool(Month, MonthFolder))
                    {
                        ftp.MakeDir(Month);
                        mes = PostImg(path, imgname, strMemu + "/", dt);//上传图片到FTP，并返回访问字符串
                        return mes;
                    }
                    else
                    {
                        mes = PostImg(path, imgname, strMemu + "/", dt);//上传图片到FTP，并返回访问字符串
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
                        mes = PostImg(path, imgname, strMemu + "/", dt);//上传图片到FTP，并返回访问字符串
                        return mes;
                    }
                    else
                    {
                        mes = PostImg(path, imgname, strMemu + "/", dt);//上传图片到FTP，并返回访问字符串
                        return mes;
                    }
                    #endregion
                }
            }


        }

        /// <summary>
        /// 上传到FTP
        /// </summary>
        /// <param name="path">本地路径</param>
        /// <param name="imgname">本地文件名称</param>
        /// <param name="strMemu">存放子目录</param>
        /// <returns></returns>
        public string PostImg(string path, string imgname, string strMemu, DateTime dt)
        {
            //获取FTP地址，账号，密码
            string mes = "";
            try
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                //dic = GetFtpPathAndLogin();
                dic = RuRo.BLL.TB_CONSENT_FORM.FtpPathAndLogin();
                RuRo.Common.FTP.FTPHelper ftpf = new Common.FTP.FTPHelper(dic["FTPFolder2"], strMemu, dic["FTPUser"], dic["FTPPWD"]);
                ftpf.Upload(path);
                string date = dt.ToString("yyyy-MM-dd");
                mes = CreatDownUrl(imgname);
                //mes = "https://" + host + "/Download.aspx?imgname=" + imgname + "&imgdate=" + date;
                //mes = "ftp://" + dic["FTPFolder"] + "/" + strMemu + imgname;
                //mes = "http://localhost:3448/Download.aspx?imgname=XYS_2065459-20151101.jpg";
                return mes;
            }
            catch (Exception ex)
            {
                string strex = ex.ToString();
                if (strex.Contains("已经存在"))
                {
                    return "该文件已经存在";
                }
                if (strex.Contains("另外进程"))
                {
                    return "请关闭该文件再上传";
                }
                else
                {
                    return ex.ToString();
                }
            }
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
            dic.Add("FTPPort", InPort.ToString());
            return dic;
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
        public string Import_TestData(Dictionary<string, string> datadic, string imgguid, string PatientName, string keshi)
        {
            string res = "";
            //获取账号密码
            Dictionary<string, string> logDic = new Dictionary<string, string>();//操作日志记录
            Dictionary<string, string> importResult = new Dictionary<string, string>();//返回信息
            List<Dictionary<string, string>> dataDicList = new List<Dictionary<string, string>>();//存放临床数据
            if (datadic.Count > 0)
            {
                dataDicList.Add(datadic);
                if (dataDicList.Count > 0)
                {
                    FreezerProUtility.Fp_Common.UnameAndPwd up = GetUp();
                    string improtTestDataResult = ImportTestData(dataDicList, up, keshi);
                    if (improtTestDataResult.Contains("\"status\":\"DONE\"") && improtTestDataResult.Contains("\"success\":true,"))
                    {
                        //导入成功--保存数据到本地数据库
                        RuRo.Model.TB_CONSENT_FORM model = new Model.TB_CONSENT_FORM();
                        model.Path = datadic["图片网络链接地址"];
                        model.PatientID = Convert.ToInt32(datadic["Sample Source"]);
                        model.Consent_From = imgguid;
                        model.PatientName = PatientName;
                        RuRo.BLL.TB_CONSENT_FORM bll = new BLL.TB_CONSENT_FORM();
                        bll.Add(model);
                        RuRo.Common.CookieHelper.ClearCookie("uid");
                        RuRo.Common.CookieHelper.ClearCookie("pname");
                        res = "导入知情同意书成功，图片地址:" + datadic["图片网络链接地址"];
                        return res;
                    }
                    else
                    {
                        res = "系统不存在此样品源，图片已保存到FTP，请录入样品源后重新上传！";
                        return res;
                    }

                }
                else
                {
                    res = "导入系统失败，请检查网络是否通畅";
                }
            }
            return res;
        }
        #region 读取科室和登陆up
        public FreezerProUtility.Fp_Common.UnameAndPwd GetUp()
        {
            string username = Common.CookieHelper.GetCookieValue("username");
            string pwd = Common.CookieHelper.GetCookieValue("password");
            string keshi = Common.CookieHelper.GetCookieValue(username + "department");
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
            return up;
        }
        public string GetKeshi()
        {
            string username = Common.CookieHelper.GetCookieValue("username");
            string pwd = Common.CookieHelper.GetCookieValue("password");
            string keshi = Common.CookieHelper.GetCookieValue(username + "department");
            string k = string.Empty;
            if (!string.IsNullOrEmpty(keshi))
            {
                try
                {
                    k = Common.DEncrypt.DESEncrypt.Decrypt(keshi);
                }
                catch (Exception ex)
                {
                    Common.LogHelper.WriteError(ex);
                    HttpContext.Current.Response.Redirect("Login.aspx");
                }
            }
            return k;
        }
        #endregion
        #endregion

        #region 把信息添加到字典中
        /// <summary>
        /// 把信息添加到字典中
        /// </summary>
        /// <param name="uid">样品源的名称</param>
        /// <param name="path">存放在FTP的路径</param>
        /// <returns></returns>
        public Dictionary<string, string> Set_dataDic(string uid, string path)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Sample Source", uid);
            dic.Add("图片网络链接地址", path);
            //dic.Add("NIMABI", path);
            return dic;
        }
        #endregion

        #region 导入临床数据 + private string ImportTestData(Dictionary<string, string> dataDic)
        /// <summary>
        /// 导入临床数据
        /// </summary>
        /// <param name="dataDic"></param>
        /// <returns></returns>
        private string ImportTestData(List<Dictionary<string, string>> dataDicList, FreezerProUtility.Fp_Common.UnameAndPwd up, string keshi)
        {
            string test_data_type = "知情同意书管理" + "-" + keshi;
            string result = FreezerProUtility.Fp_BLL.TestData.ImportTestData(up, test_data_type, dataDicList);
            return result;
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

        /// <summary>
        /// 创建访问图片URL
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string CreatDownUrl(string name)
        {
            //string[] SplitFileName = name.Split('.');
            string url = System.Configuration.ConfigurationManager.AppSettings["host"];//读取发布包的页面路径
            string page = "Download.aspx";
            string strDownUrl = string.Format(@"{0}/Download.aspx?imgname={1}", url, name);
            return strDownUrl;
        }

        public string keshicode(string keshi)
        {
            if (keshi == "心研所")
            {
                return "XYS";
            }
            else
            {
                return "FAS";
            }
        }

        #endregion


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}