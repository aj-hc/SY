using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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
            return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
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
            ds = dal.GetSY_HC_GetEmployeeInfo();
            dv = ds.Tables[0].DefaultView;
            if (string.IsNullOrEmpty(par))
            {
                 strdv = dv.RowFilter = "EmployeeNo=" + par;
                if (string.IsNullOrEmpty(strdv))
                {
                   strdv = dv.RowFilter = "EmployeeName=" + par;
                }
            }
            else
            {
               
            }
            return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(dal.GetSY_HC_GetEmployeeInfo());
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
            DateTime dt = new DateTime();
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
