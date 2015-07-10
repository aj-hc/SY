using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RuRo.BLL
{
    public partial class FP_SY_HIS_IP_PublicInterface_Bll
    {
        private readonly RuRo.DAL.FP_SY_HIS_IP_PublicInterface dal = new RuRo.DAL.FP_SY_HIS_IP_PublicInterface();


        #region 门诊住院诊断信息
        /// <summary>
        /// 门诊住院诊断信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSY_HC_GetDiagnoseInfoJson(RuRo.Model.FP_SY_HIS_IP_PublicInterface model)
        {
            DataSet ds = new DataSet();
            DateTime dt = new DateTime();
            ds = dal.GetSY_HC_GetDiagnoseInfo(model);
            for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
            {
                dt = Convert.ToDateTime(ds.Tables[0].Rows[i]["DiagnoseDateTime"]);
                string strdate = dt.ToString("yyyy-MM-dd");
                ds.Tables[0].Rows[i]["DiagnoseDateTime"] = strdate;
            }
            string res= FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
            //明天正式环境检测
            if (res == "{\"ds\":[]}")
            {
                res = "{\"ds\":[{\"msg\":\"临床数据为空\"}]}";
                return res;
            }
            else 
            {
                return res;
            }
        }
        #endregion

        #region 员工信息
        /// <summary>
        /// 员工信息
        /// </summary>
        /// <returns></returns>
        public string GetSY_HC_GetEmployeeInfoJson(string par)
        {
            string strdv = "";
            DataSet ds = new DataSet();
            DataView dv = new DataView();
            DataSet ds1 = new DataSet();
            //ds = dal.GetSY_HC_GetEmployeeInfo();//获取正式
            ds = dal.GetSY_HC_GetEmployeeInfoTest();//获取测试
            dv = ds.Tables[0].DefaultView;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["EmployeeNo"].ToString().Trim() == "" || ds.Tables[0].Rows[i]["EmployeeID"].ToString().Trim() == "0" || ds.Tables[0].Rows[i]["EmployeeNO"].ToString().Trim() == "t1" || ds.Tables[0].Rows[i]["EmployeeNO"].ToString().Trim() == "t2")
                {
                    ds.Tables[0].Rows[i].Delete();
                }
            }
            ds.Tables[0].Columns.Remove("EmployeeID");
            ds.AcceptChanges();
            if (par == ""){}
            else
            {
                if (RuRo.Common.UrlOper.IsChinaString(par) == true)
                {
                    dv.RowFilter = "EmployeeName LIKE '" + par + "%'";
                    ds1.Tables.Add(dv.ToTable());
                }
                else 
                {
                    dv.RowFilter = "EmployeeNo like '" + par + "%'";
                    ds1.Tables.Add(dv.ToTable());
                }
               
            }
            string strobj = FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds1);
            JObject obj = JObject.Parse(strobj);
            string strjson = obj["ds"].ToString();
            return strjson;
        }
        #endregion

        #region 检验申请单信息
        /// <summary>
        /// 检验申请单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSY_HC_GetExamineRequestJson(RuRo.Model.FP_SY_HIS_IP_PublicInterface model)
        {
            return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(dal.GetSY_HC_GetExamineRequest(model));
        }
        #endregion

        #region 患者门诊住院信息
        /// <summary>
        /// 患者门诊住院信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSY_HC_GetPatientInfoJson(RuRo.Model.FP_SY_HIS_IP_PublicInterface model)
        {
            DataSet ds = dal.GetSY_HC_GetPatientInfo(model);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (i == ds.Tables[0].Rows.Count - 1)
                    {
                        break;
                    }
                    ds.Tables[0].Rows[i].Delete();
                }
                ds.AcceptChanges();
                model.In_InPatientID = Convert.ToInt32(ds.Tables[0].Rows[0]["InPatientID"]);
                model.In_CodeType = Convert.ToInt32(ds.Tables[0].Rows[0]["InPatientID"]);
                string res = FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
                return res;
            }
            else
            {
                return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(dal.GetSY_HC_GetPatientInfo(model));
            }
        }
        #endregion

        #region 手术申请单信息
        /// <summary>
        /// 手术申请单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetSY_HC_GetSurgeryRequestJson(RuRo.Model.FP_SY_HIS_IP_PublicInterface model)
        {
            return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(dal.GetSY_HC_GetSurgeryRequest(model));
        }
        #endregion

        public DataSet GetSY_HC()
        {
            DataTable dt = new DataTable();
            return dal.GetSY_HC_GetEmployeeInfo();
        }
    }
}
