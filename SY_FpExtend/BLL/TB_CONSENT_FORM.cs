using System;
using System.Data;
using System.Collections.Generic;
using RuRo.Common;
using RuRo.Model;
using System.Configuration;
namespace RuRo.BLL
{
    /// <summary>
    /// TB_CONSENT_FORM
    /// </summary>
    public partial class TB_CONSENT_FORM
    {
        private readonly RuRo.DAL.TB_CONSENT_FORM dal = new RuRo.DAL.TB_CONSENT_FORM();
        public TB_CONSENT_FORM()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(RuRo.Model.TB_CONSENT_FORM model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(RuRo.Model.TB_CONSENT_FORM model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Consent_ID)
        {

            return dal.Delete(Consent_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Consent_IDlist)
        {
            return dal.DeleteList(Consent_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RuRo.Model.TB_CONSENT_FORM GetModel(int Consent_ID)
        {

            return dal.GetModel(Consent_ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public RuRo.Model.TB_CONSENT_FORM GetModelByCache(int Consent_ID)
        {

            string CacheKey = "TB_CONSENT_FORMModel-" + Consent_ID;
            object objModel = RuRo.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Consent_ID);
                    if (objModel != null)
                    {
                        int ModelCache = RuRo.Common.ConfigHelper.GetConfigInt("ModelCache");
                        RuRo.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (RuRo.Model.TB_CONSENT_FORM)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<RuRo.Model.TB_CONSENT_FORM> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<RuRo.Model.TB_CONSENT_FORM> DataTableToList(DataTable dt)
        {
            List<RuRo.Model.TB_CONSENT_FORM> modelList = new List<RuRo.Model.TB_CONSENT_FORM>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                RuRo.Model.TB_CONSENT_FORM model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获取存在的知情同意书数据，不存在返回空
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Json</returns>
        public string GetTB_CONSENT_FORM_BLL(RuRo.Model.TB_CONSENT_FORM model)
        {
            DataSet ds = new DataSet();
            ds = dal.GetTB_CONSENT_FORM(model);
            return FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
        }
        public int GetTB_CONSENT_FORM_BLL(RuRo.Model.TB_CONSENT_FORM model,int num)
        {
            DataSet ds = new DataSet();
            ds = dal.GetTB_CONSENT_FORM(model);
            int count = ds.Tables[0].Rows.Count;
            return count;
        }
        public string Sel_TB_CONSENT_FORM_Count_Bll(string patientID, string consent_from)
        {
            string str = "";
            str = dal.Sel_TB_CONSENT_FORM_Count(patientID, consent_from);
            return str;
        }

        /// <summary>
        /// 获取FTP
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> FtpPathAndLogin()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string strftp = RuRo.Common.DEncrypt.DESEncrypt.IsDesDecrypt(ConfigurationManager.AppSettings["FTPFolder"], "litianping");
            string strftp2 = RuRo.Common.DEncrypt.DESEncrypt.IsDesDecrypt(ConfigurationManager.AppSettings["FTPFolder2"], "litianping");
            string struser = RuRo.Common.DEncrypt.DESEncrypt.IsDesDecrypt(ConfigurationManager.AppSettings["FTPUser"], "litianping");
            string strpwd = RuRo.Common.DEncrypt.DESEncrypt.IsDesDecrypt(ConfigurationManager.AppSettings["FTPPWD"], "litianping");
            //string strhost = RuRo.Common.DEncrypt.DESEncrypt.IsDesDecrypt(ConfigurationManager.AppSettings["SaveImgPath"], "litianping");
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
            //if (strpwd == "TMD")
            //{
            //    dic.Add("SaveImgPath", ConfigurationManager.AppSettings["SaveImgPath"].ToString());
            //}
            //else
            //{
            //    dic.Add("SaveImgPath", strpwd);
            //}
            dic.Add("FTPPort", InPort.ToString());
            return dic;
        }
        #endregion  ExtensionMethod
    }
}