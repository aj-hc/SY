using System;
using System.Data;
using System.Collections.Generic;
using RuRo.Common;
using RuRo.Model;
using Newtonsoft.Json.Linq;
namespace RuRo.BLL
{
    /// <summary>
    /// TB_Disease
    /// </summary>
    public partial class TB_Disease
    {
        private readonly RuRo.DAL.TB_Disease dal = new RuRo.DAL.TB_Disease();
        public TB_Disease()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(RuRo.Model.TB_Disease model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(RuRo.Model.TB_Disease model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(RuRo.Common.PageValidate.SafeLongFilter(IDlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RuRo.Model.TB_Disease GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public RuRo.Model.TB_Disease GetModelByCache(int ID)
        {

            string CacheKey = "TB_DiseaseModel-" + ID;
            object objModel = RuRo.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = RuRo.Common.ConfigHelper.GetConfigInt("ModelCache");
                        RuRo.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (RuRo.Model.TB_Disease)objModel;
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
        public List<RuRo.Model.TB_Disease> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<RuRo.Model.TB_Disease> DataTableToList(DataTable dt)
        {
            List<RuRo.Model.TB_Disease> modelList = new List<RuRo.Model.TB_Disease>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                RuRo.Model.TB_Disease model;
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
        //获取适应EASYUI的JSON格式数据
        public string GetSY_HC_GetDiseaseJson(string par)
        {
            string strjson = "";
            DataSet Diseaseds = new DataSet();//用来去读表中的数据
            DataSet ds = new DataSet();//排序,筛选
            DataSet ds1 = new DataSet();//新的数据
            DataView dv = new DataView();//视图
            Diseaseds = GetList("");
            dv = Diseaseds.Tables[0].DefaultView;
            if (par == "") { }
            else
            {
                if (RuRo.Common.UrlOper.IsChinaString(par))
                {
                    dv.RowFilter = "DiseaseName LIKE '" + par + "%'";
                    ds.Tables.Add(dv.ToTable());
                }
                //else if (par.Contains("ICD"))
                //{
                //    string[] array = par.Split('-');
                //    dv.RowFilter = "ICDCode = '" + array[1] + "'";
                //    ds.Tables.Add(dv.ToTable());
                //    ds.Tables[0].Columns.Remove("MnemonicCode");
                //    ds.Tables[0].Columns.Remove("ICDCode");
                //    ds.Tables[0].Columns.Remove("DiseaseID");
                //    ds.Tables[0].AcceptChanges();
                //}
                else
                {
                    dv.RowFilter = "MnemonicCode LIKE '" + par + "%'";
                    ds.Tables.Add(dv.ToTable());
                }
            }
            string strobj = "";
            strobj = FreezerProUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
            JObject obj = JObject.Parse(strobj);
            strjson = obj["ds"].ToString();
            //if (par.Contains("ICD"))
            //{
            //    strjson = ds.Tables[0].Rows[0][0].ToString();
            //}
            //else
            //{
               
            //}
            return strjson;
        }
        #endregion  ExtensionMethod
    }
}

