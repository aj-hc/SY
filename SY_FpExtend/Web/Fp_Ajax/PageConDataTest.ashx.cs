using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RuRo.Web.Fp_Ajax
{
    /// <summary>
    /// PageConDataTest 的摘要说明
    /// </summary>
    public class PageConDataTest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string username = Common.CookieHelper.GetCookieValue("username");
            string pwd = Common.CookieHelper.GetCookieValue("password");
            string departments = Common.CookieHelper.GetCookieValue("departments");
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
                    context.Response.Redirect("Login.aspx");
                }
            }
            FreezerProUtility.Fp_Common.UnameAndPwd up = new FreezerProUtility.Fp_Common.UnameAndPwd(username, password);
            string mark = context.Request.Params["conMarc"];
            switch (mark)
            {
                //case "SexFlag": Response.Write(ReturnGender()); break;
                //case "In_CodeType": Response.Write(ReturnIn_CodeType()); break;
                //case "BloodTypeFlag": Response.Write(ReturnBloodTypeFlag()); break;
                //case "SamplingMethod": Response.Write(ReturnSamplingMethodData()); break;
                //case "DiagnoseTypeFlag": Response.Write(ReturnDiagnoseTypeFlag()); break;
                //case "linkage": Response.Write(ReturnGet_Linkage()); break;
                //case "linkagefrom": Response.Write(ReturnGet_Linkage2()); break;
                //case "Employee": Response.Write(ReturnGet_Employee()); break;
                //case "SampleType": Response.Write(ReturnSampleType(up, username)); break;
                //case "departments": Response.Write(ReturnDepartments()); break;
                //case "SampleGroups": Response.Write(ReturnSampleGroups(up)); break;
                //case "SampleType_S": Response.Write(ReturnSampleType_S(up)); break;
                //case "SampleType_U": Response.Write(ReturnSampleType_U(up)); break;
                //case "SampleType_keti": Response.Write(Returnketi(up)); break;
                //case "ComSetting": Response.Write(ReturnComSetting()); break;
                case "QuerySetting": ReturnQuerySetting(context); break;
                default:
                    break;
            }

        }
        /// <summary>
        /// 查询设定字段
        /// </summary>
        /// <returns></returns>
        private void ReturnQuerySetting(HttpContext context)
        {
            string strJson = "";//返回的JSON
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();//存放数据
            Dictionary<string, string> dic = new Dictionary<string, string>();//数据转换
            string username = Common.CookieHelper.GetCookieValue("username");
            string keshi = Common.CookieHelper.GetCookieValue(username + "department");
            string type = context.Request.Params["valueType"].ToString().Trim();
            BLL.TB_SETTING_VALUE bll = new BLL.TB_SETTING_VALUE();
            //判断数据是否存在
            DataSet ds = bll.GetList("SETTING_TYPE='" + type + "' AND DEPARTMENTS='" + DecryptDepartments(keshi) + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //数据转换为JSON
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dic = new Dictionary<string, string>();
                    dic.Add("value", ds.Tables[0].Rows[i]["SETTING_VALUE"].ToString());
                    dic.Add("text", ds.Tables[0].Rows[i]["SETTING_VALUE"].ToString());
                    list.Add(dic);
                }
                strJson = FreezerProUtility.Fp_Common.FpJsonHelper.DictionaryListToJsonString(list);
            }
            context.Response.Write(strJson);
            context.Response.Flush();
            context.Response.End();
        }
        /// <summary>
        /// 返回当前科室
        /// </summary>
        /// <returns></returns>
        private string DecryptDepartments(string keshi)
        {
            string StrDepartments = "";
            try
            {
                keshi = Common.DEncrypt.DESEncrypt.Decrypt(keshi);
            }
            catch (Exception ex)
            {
                Common.LogHelper.WriteError(ex);
                keshi = "";
            }
            if (keshi != "")
            {
                StrDepartments = keshi;
            }
            return StrDepartments;
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