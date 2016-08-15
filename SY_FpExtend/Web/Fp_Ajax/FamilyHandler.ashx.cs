using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace RuRo.Web.Fp_Ajax
{
    /// <summary>
    /// FamilyHandler 的摘要说明
    /// </summary>
    public class FamilyHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string straction = context.Request["action"].ToString();
            switch (straction)
            {
                case "getSampleSource": context.Response.Write(getSampleSource(context)); break;
                case "PostSaveFamily": context.Response.Write(AddFamily(context)); break;
            }
        }
        /// <summary>
        /// 查询基本数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string getSampleSource(HttpContext context)
        {
            string strPid = context.Request["PId"].ToString();
            string strPName = context.Request["PName"].ToString();
            BLL.BasedInfo baseinfo = new BLL.BasedInfo();
            //获取数据
            DataSet ds = new DataSet();
            if (string.IsNullOrEmpty(strPid))
            {
                ds = baseinfo.GetList("PatientName='" + strPName + "'");
            }
            else if (string.IsNullOrEmpty(strPName))
            {
                ds = baseinfo.GetList("PatientID=" + strPid);
            }
            else
            {
                ds = baseinfo.GetList("PatientName='" + strPName + "' and PatientID=" + strPid);
            }
            return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
        }
        /// <summary>
        /// 添加家系联系
        /// </summary>
        private string AddFamily(HttpContext context)
        {
            string strMsg = "";
            //1.读取传输过来的字段
            string strFamilyJson = context.Request["fdata"].ToString();
            //2.插入Freezerpro
            FreezerProUtility.Fp_Common.UnameAndPwd up = GetUp();
            List<Dictionary<string, string>> dicList = new List<Dictionary<string, string>>();
            List<Dictionary<string, string>> AdddicList = new List<Dictionary<string, string>>();
            dicList = FreezerProUtility.Fp_Common.FpJsonHelper.JsonStrToObject<List<Dictionary<string, string>>>(strFamilyJson);
            AdddicList = MatchFamilyDic(dicList); ;
            string keshi = GetKeshi();
            string strReult = ImportData(up, AdddicList, keshi);
            //3.插入成功插入数据库
            if (strReult.Contains("\"status\":\"DONE\"") && strReult.Contains("\"success\":true,"))
            {
                RuRo.Model.TB_Family model = new Model.TB_Family();
                model = FreezerProUtility.Fp_Common.FpJsonHelper.JsonStrToObject<RuRo.Model.TB_Family>(strFamilyJson);
                RuRo.BLL.TB_Family bll = new BLL.TB_Family();
                int count= bll.Add(model);
                if (count>0)
                {
                    strMsg="导入成功";
                }
                else
                {
                    strMsg="导入数据日志失败,数据已添加到Freezerpro中";
                }
            }
            //4.插入失败，记录并提醒
            else
            {
                if (strReult.Contains("\u7684\u6837\u54c1\u6e90\u6ca1\u6709\u627e\u5230."))
                {
                    strMsg="找不到样本源";
                }
                else
                {
                    strMsg = "导入Freezerpro失败";
                }
            }
            return strMsg;
        }

        #region 匹配临床信息字典
        /// <summary>
        /// 匹配临床信息字典
        /// </summary>
        /// <param name="clinicalDicList">临床信息字典</param>
        /// <returns>匹配完成的字典</returns>
        private List<Dictionary<string, string>> MatchFamilyDic(List<Dictionary<string, string>> FamilyDicList)
        {
            Dictionary<string, string> dic = BLL.MatchFileds.FamilyMatchDic();
            List<Dictionary<string, string>> resDicList = new List<Dictionary<string, string>>();
            foreach (var family in FamilyDicList)
            {
                Dictionary<string, string> resDic = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> item in family)
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
        /// <summary>
        /// 导入系统
        /// </summary>
        /// <param name="up"></param>
        /// <param name="dataDicList"></param>
        /// <returns></returns>
        private string ImportData(FreezerProUtility.Fp_Common.UnameAndPwd up, List<Dictionary<string, string>> dataDicList,string keshi)
        {
            string test_data_type = "家系管理-"+keshi;
            string result = FreezerProUtility.Fp_BLL.TestData.ImportTestData(up, test_data_type, dataDicList);
            return result;
        }

        /// <summary>
        /// 获取登陆信息
        /// </summary>
        /// <returns></returns>
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}