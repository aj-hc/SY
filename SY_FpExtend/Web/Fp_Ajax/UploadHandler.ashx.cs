﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace RuRo.Web.Fp_Ajax
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string straction = context.Request["action"].ToString();
            if (straction == "postimg")
            {
                HttpFileCollection files = context.Request.Files;//获取上传的文件
                string strsuid = context.Request["Iuid"].ToString();
                string strname = context.Request["Iname"].ToString();
                string strdate = context.Request["Idate"].ToString();
                string msg = string.Empty;
                string error = string.Empty;
                string res = "";
                if (files.Count > 0)
                {
                    res = PostConsentImg(files, strsuid, strname, strdate, context);
                    context.Response.Write(FreezerProUtility.Fp_Common.FpJsonHelper.SerializationStr(res));
                    context.Response.End();
                }
                else
                {
                    res =  "没有图片上传或图片格式不正确";
                    context.Response.Write(res);
                    context.Response.End();
                }
            }
        }
        /// <summary>
        /// 上传图片并导入FREEZERPRO
        /// </summary>
        /// <param name="files">路径</param>
        /// <param name="uid">参数</param>
        /// <param name="name">参数</param>
        /// <param name="date">参数</param>
        /// <returns></returns>
        private string PostConsentImg(HttpFileCollection files, string struid, string strname, string strdate, HttpContext context)
        {
            string mes = "";
            string keshi = GetKeshi();
            string strPy = keshicode(keshi);//将科室转化
            string newimgName = "";
            Dictionary<string, string> dickeshi = new Dictionary<string, string>();
            dickeshi.Add("keshi", keshi);
            dickeshi.Add("SP", strPy);
            //图片临时保存文件夹
            string strpath = @"IIII\";
            string newstrpath = context.Server.MapPath("~/IIII/");
            //必须传入绝对路径
            if (RuRo.Common.Filehleper.DirFileHelper.IsExistDirectory(newstrpath)) { }
            else { RuRo.Common.Filehleper.DirFileHelper.CreateDir(strpath); }
            //上传图片，名称为空时不上传
            if (files[0].FileName=="")
            {
                mes = "找不到图片";
            }
            else
            {
                mes = PostImg(newstrpath, files);
                if (mes.Contains(System.IO.Path.GetFileName(files[0].FileName)))
                {
                    mes = "";
                    //读取图片处理并保存到指定的文件夹中,并返回路径和图片名称；
                    mes = HandleImg(newstrpath + System.IO.Path.GetFileName(files[0].FileName), dickeshi["SP"], struid, strdate, files, context, ref newimgName);
                    //添加到Freezerpro诊断信息中
                    Dictionary<string, string> dicdata = new Dictionary<string, string>();//匹配传入系统的数据
                    if (mes.Contains(newimgName))
                    {
                        //删除服务器端的存放图片文件夹
                        string newpath = CreatDownUrl(mes);//生成导入的路径
                        dicdata = Set_dataDic(struid, strname, strdate, newpath);//添加到字典匹配
                        string msg = Import_TestData(dicdata, newpath, strname, dickeshi["keshi"].ToString());//提交到系统
                        if (msg.Contains("成功"))
                        {
                            RuRo.Common.Filehleper.DirFileHelper.ClearDirectory(newstrpath);//删除文件夹下面的文件
                        }
                        else
                        {
                            RuRo.Common.Filehleper.DirFileHelper.DeleteFile(mes);
                            RuRo.Common.Filehleper.DirFileHelper.ClearDirectory(newstrpath);//删除文件夹下面的文件
                        }
                    }
                }
            }
            return mes;
        }
        //修改图片
        #region 处理图片并保存
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">传入路径</param>
        /// <param name="keshi">科室</param>
        /// <param name="uid">样品源</param>
        /// <param name="date">日期</param>
        public string HandleImg(string path, string keshi, string uid, string date, HttpFileCollection files,HttpContext context, ref string imgname)
        {
            string mes = "";
            try
            {
                Bitmap map = new Bitmap(path);
                string savePathName = @"Consentimg\";
                string savePath =context.Server.MapPath("~/Consentimg/");
                string[] geshi = files[0].FileName.Split('.');
                DateTime dt = Convert.ToDateTime(date);
                string Random = IntRandom();
                imgname = keshi + "_" + uid + "-" + dt.ToString("yyyyMMdd") + "_" + Random + "." + geshi[1];
                string strSaveImgpath = "";
                string strhttpImgpath = "";//获取HTTP传入路径
                //根据文件各级情况创建文档
                if (RuRo.Common.Filehleper.DirFileHelper.IsExistDirectory(savePath))//必须传入绝对路径
                {
                    //使用委托把另外一个路径返回出来
                    strSaveImgpath = CreateFoloer(savePath, savePathName, dt, keshi, ref strhttpImgpath) + @"\" + imgname;
                }
                else
                {
                    RuRo.Common.Filehleper.DirFileHelper.CreateDir(savePathName);
                    strSaveImgpath = CreateFoloer(savePath, savePathName, dt, keshi, ref strhttpImgpath) + @"\" + imgname;
                }
                //map.Save(savePath);
                long quality = long.Parse(System.Configuration.ConfigurationManager.AppSettings["ImgQuality"]);
                Common.ImageHelper.ImageClass img = new Common.ImageHelper.ImageClass();
                //判断图片是否存在于数据库中
                Model.TB_IMGPATH imgModel = new Model.TB_IMGPATH();
                imgModel.IMGNAME = imgname;
                imgModel.IMGPATH = mes;
                imgModel.KESHI = keshi;
                imgModel.DATE = Convert.ToDateTime(date);
                BLL.TB_IMGPATH imgbll = new BLL.TB_IMGPATH();
                int count = imgbll.GetRecordCount("IMGNAME='" + imgname + "' and KESHI='" + keshi + "' and date='" + date + "'");
                if (count > 0)
                {
                    context.Response.Write("<script type='text/javascript'>alert('数据存在，请重新上传');</script>");
                    RuRo.Model.TB_SAMPLE_LOG log_model = new Model.TB_SAMPLE_LOG();//记录日志
                    log_model.MSG = "图片存在";
                    RuRo.BLL.TB_SAMPLE_LOG log_bll = new BLL.TB_SAMPLE_LOG();
                    log_bll.Add(log_model);

                }
                else
                {
                    //压缩图片并保存
                    img.Compress(path, strSaveImgpath, map.Width, map.Height, quality);
                    //map.Clone();
                    map.Dispose();
                    mes = strhttpImgpath + @"\" + imgname;
                    //写入数据库
                    try
                    {
                        imgModel.IMGPATH = mes;
                        imgbll.Add(imgModel);
                    }
                    catch (Exception ex)
                    {
                        RuRo.Model.TB_SAMPLE_LOG log_model = new Model.TB_SAMPLE_LOG();//记录日志
                        log_model.MSG = "添加图片错误：" + ex.ToString();
                        mes = ex.ToString();
                        RuRo.BLL.TB_SAMPLE_LOG log_bll = new BLL.TB_SAMPLE_LOG();
                        log_bll.Add(log_model);
                    }
                }
                return mes;
            }
            catch (Exception ex)
            {
                mes = ex.ToString();
                return mes;
            }
        }
        #endregion

        #region 动态创建文档
        public string CreateFoloer(string savepath, string newpath, DateTime dt, string keshi, ref string createpath)
        {
            string stryear = dt.Year.ToString();
            string strmonth = dt.Month.ToString();
            string path = savepath + keshi + @"\" + stryear + @"\" + strmonth;//存放路径
            createpath = newpath + keshi + @"\" + stryear + @"\" + strmonth;//创建用参数
            string mes = "";//返回的消息
            if (RuRo.Common.Filehleper.DirFileHelper.IsExistDirectory(path))//判断是否存在科室目录
            {
                mes = path;
            }
            else
            {
                RuRo.Common.Filehleper.DirFileHelper.CreateDir(createpath);
                mes = path;
            }
            return mes;
        }
        #endregion

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="path"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        public string PostImg(string path, HttpFileCollection files)
        {
            Boolean fileOk = false;
            string mes = "";
            //取得文件的扩展名,并转换成小写
            string fileExtension = System.IO.Path.GetExtension(files[0].FileName);
            //获取可以上传的格式
            //string[] allowExtension = { ".jpg", ".gif", ".txt", ".xls",".jpeg","JPG","JPEG" };
            string strallowExtension = System.Configuration.ConfigurationManager.AppSettings["allowExtension"];
            string[] allowExtension = strallowExtension.Split('|');
            for (int i = 0; i < allowExtension.Length; i++)
            {
                if (fileExtension.Contains(allowExtension[i]))
                {
                    fileOk = true;
                    break;
                }
            }
            if (files[0].ContentLength > 2048000)
            {
                fileOk = false;
                mes = "文件超过1M";
            }
            if (fileOk)
            {
                try
                {
                    files[0].SaveAs(path + System.IO.Path.GetFileName(files[0].FileName));
                    mes = path + System.IO.Path.GetFileName(files[0].FileName);
                }
                catch (Exception ex)
                {
                    mes = "文件上传错误";
                }
            }
            else
            {
                mes = "文件格式不符合";
            }
            return mes;
        }

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
                        model.Date =Convert.ToDateTime(datadic["上传日期"]);
                        //清空COOKIE
                        RuRo.Common.CookieHelper.ClearCookie("uid");
                        RuRo.Common.CookieHelper.ClearCookie("pname");
                        RuRo.BLL.TB_CONSENT_FORM bll = new BLL.TB_CONSENT_FORM();
                        int count= bll.Add(model);
                        if (count>0)
                        {
                            res = "导入知情同意书成功，图片地址:" + datadic["图片网络链接地址"];
                        }
                        else
                        {
                            res = "知情同意书导入系统成功，但网络有错误，无法检测到图片地址";
                        }
                        return res;
                    }
                    else
                    {
                        res = "系统不存在此样品源，导入失败，请录入样品源后重新上传！";
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

        /// <summary>
        /// 把信息添加到字典中
        /// </summary>
        /// <param name="uid">样品源的名称</param>
        /// <param name="path">存放的路径</param>
        /// <returns></returns>
        public Dictionary<string, string> Set_dataDic(string uid, string name, string adddate, string path)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Sample Source", uid);
            dic.Add("姓名", name);
            dic.Add("上传日期", adddate);
            dic.Add("图片网络链接地址", path);
            return dic;
        }

        /// <summary>
        /// 创建传入路径
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string CreatDownUrl(string name)
        {
            //string[] SplitFileName = name.Split('.');
            string url = System.Configuration.ConfigurationManager.AppSettings["host"];//读取发布包的页面路径
            string newname = name.Replace('\\', '/');
            string strDownUrl = string.Format(@"{0}/{1}", url, newname);
            return strDownUrl;
        }

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
        #region 生成随机数
        public string IntRandom()
        {
            Random ran = new Random();
            return ran.Next(1000, 9999).ToString();
        }
        #endregion

        #region 获取登陆信息
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

        /// <summary>
        /// 获取当前科室
        /// </summary>
        /// <returns></returns>
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