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
            DataView dv = new DataView();
            DataSet ds1 = new DataSet();
            ds = dal.GetSY_HC_GetDiagnoseInfo(model);
            for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
            {
                dt = Convert.ToDateTime(ds.Tables[0].Rows[i]["DiagnoseDateTime"]);
                string strdate = dt.ToString("yyyy-MM-dd");
                ds.Tables[0].Rows[i]["DiagnoseDateTime"] = strdate;
            }
            string res= FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
            //排查，待测试
            if (res == "{\"ds\":[]}")
            {
                res = "{\"ds\":[{\"msg\":\"临床数据为空\"}]}";
                return res;
            }
            else 
            {
                #region fuck
                dv = ds.Tables[0].DefaultView;
                dv.RowFilter = "DiagnoseTypeFlag=2";
                dv.Sort = " DiagnoseDateTime ASC";
                if (dv.Count == 0 || object.Equals(dv, null))
                {
                    dv = new DataView();
                    dv = ds.Tables[0].DefaultView;
                    dv.RowFilter = "DiagnoseTypeFlag=1";
                    dv.Sort = " DiagnoseDateTime ASC";
                    if (dv.Count == 0 || object.Equals(dv, null))
                    {
                        dv = new DataView();
                        dv = ds.Tables[0].DefaultView;
                        dv.RowFilter = "DiagnoseTypeFlag=0";
                        dv.Sort = " DiagnoseDateTime ASC";
                        if (dv.Count == 0 || object.Equals(dv, null))
                        {
                            res = "{\"ds\":[{\"msg\":\"无标准临床数据返回\"}]}";
                        }
                        else 
                        {
                            ds1.Tables.Add(dv.ToTable());
                            res = FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds1);
                        }
                    }
                    else 
                    {
                        ds1.Tables.Add(dv.ToTable());
                        res = FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds1);
                    }
                }
                else 
                {
                    ds1.Tables.Add(dv.ToTable());
                    res = FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds1);
                }
                #endregion
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
            ds = dal.GetSY_HC_GetEmployeeInfo();//获取正式
            //ds = dal.GetSY_HC_GetEmployeeInfoTest();//获取测试
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
            if (par == "") { return ""; }
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
                string strobj = FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds1);
                JObject obj = JObject.Parse(strobj);
                string strjson = obj["ds"].ToString();
                return strjson;
            }

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
            DataView dv = new DataView();
            DataSet ds1 = new DataSet();
            dv = ds.Tables[0].DefaultView;
            dv.Sort = "OutDate ASC";
            //dv.RowFilter = "OutDate ASC";
            ds1.Tables.Add(dv.ToTable());
            ds1.AcceptChanges();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds1.Tables[0].Rows.Count - 1; i++)
                {
                    if (i == ds1.Tables[0].Rows.Count - 1)
                    {
                        break;
                    }
                    ds1.Tables[0].Rows[i].Delete();
                }
                ds1.AcceptChanges();
                model.In_InPatientID = Convert.ToInt32(ds1.Tables[0].Rows[0]["InPatientID"]);
                model.In_CodeType = Convert.ToInt32(ds1.Tables[0].Rows[0]["InPatientID"]);
                string res = FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds1);
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

        #region 添加信息访问到本地库
        /// <summary>
        /// 添加数据到ClinicalInfo表，记录
        /// </summary>
        /// <param name="ds"></param>
        public void InsertClinicalInfo(DataSet ds)
        {
            DAL.ClinicalInfo dal = new DAL.ClinicalInfo();
            Model.ClinicalInfo model = new Model.ClinicalInfo();
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.DiagnoseTypeFlag = ds.Tables[0].Rows[0]["DiagnoseTypeFlag"].ToString();
                model.DiagnoseDateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["DiagnoseDateTime"]);
                model.RegisterID = int.Parse(ds.Tables[0].Rows[0]["RegisterID"].ToString());
                model.InPatientID = int.Parse(ds.Tables[0].Rows[0]["InPatientID"].ToString());
                model.ICDCode = ds.Tables[0].Rows[0]["ICDCode"].ToString();
                model.DiseaseName = ds.Tables[0].Rows[0]["DiseaseName"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.type = ds.Tables[0].Rows[0]["type"].ToString();
                dal.Add(model);
            }
            else
            {
                //dal.Add(model); 数据为空暂不添加
            }
        }
        /// <summary>
        /// 添加数据到BaseInfo
        /// </summary>
        public void InsertBaseInfo(DataSet ds)
        {
            Model.BasedInfo baseinfo = new Model.BasedInfo();
            baseinfo.PatientName = ds.Tables[0].Rows[0]["PatientName"].ToString();
            baseinfo.IPSeqNoText = ds.Tables[0].Rows[0]["IPSeqNoText"].ToString();
            baseinfo.PatientCardNo = ds.Tables[0].Rows[0]["PatientCardNo"].ToString();
            baseinfo.SexFlag = ds.Tables[0].Rows[0]["SexFlag"].ToString();
            baseinfo.Birthday = Convert.ToDateTime(ds.Tables[0].Rows[0]["Birthday"].ToString());
            baseinfo.BloodTypeFlag = ds.Tables[0].Rows[0]["BloodTypeFlag"].ToString();
            baseinfo.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
            baseinfo.ContactPhone = ds.Tables[0].Rows[0]["ContactPhone"].ToString();
            baseinfo.ContactPerson = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
            baseinfo.NativePlace = ds.Tables[0].Rows[0]["NativePlace"].ToString();
            baseinfo.RegisterSeqNO = ds.Tables[0].Rows[0]["RegisterSeqNO"].ToString();
            baseinfo.PatientID = Convert.ToInt32(ds.Tables[0].Rows[0]["PatientID"]);
            baseinfo.RegisterID = Convert.ToInt32(ds.Tables[0].Rows[0]["RegisterID"]);
            baseinfo.InPatientID = Convert.ToInt32(ds.Tables[0].Rows[0]["InPatientID"]);
            DAL.BasedInfo baseinfo_dal = new DAL.BasedInfo();
            baseinfo_dal.Add(baseinfo);
        }
        #endregion

    }
}
