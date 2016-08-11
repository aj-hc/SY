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
                baseinfo.GetList("PatientName='" + strPName + "'");
            }
            else if (string.IsNullOrEmpty(strPName))
            {
                baseinfo.GetList("PatientID=" + strPid );
            }
            else
            {
                baseinfo.GetList("PatientName='" + strPName + "' and PatientID=" + strPid);
            }
            return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
        }
        /// <summary>
        /// 添加家系联系
        /// </summary>
        private string AddFamily(HttpContext context) 
        {
            //1.读取传输过来的字段
            //2.插入Freezerpro
            //3.插入成功插入数据库
            //4.插入失败，记录并提醒
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