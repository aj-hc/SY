using System;
using System.Data;
using System.Collections.Generic;
namespace RuRo.BLL
{
	/// <summary>
	/// FP_UserFields
	/// </summary>
	public partial class FP_UserFields
	{
		private readonly RuRo.DAL.FP_UserFields dal=new RuRo.DAL.FP_UserFields();
		public FP_UserFields()
		{}
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
		public bool Exists(int userFieldId)
		{
			return dal.Exists(userFieldId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(RuRo.Model.FP_UserFields model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(RuRo.Model.FP_UserFields model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int userFieldId)
		{
			
			return dal.Delete(userFieldId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string userFieldIdlist )
		{
			return dal.DeleteList(Common.PageValidate.SafeLongFilter(userFieldIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RuRo.Model.FP_UserFields GetModel(int userFieldId)
		{
			
			return dal.GetModel(userFieldId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public RuRo.Model.FP_UserFields GetModelByCache(int userFieldId)
		{
			
			string CacheKey = "FP_UserFieldsModel-" + userFieldId;
			object objModel = Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(userFieldId);
					if (objModel != null)
					{
						int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
						Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (RuRo.Model.FP_UserFields)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<RuRo.Model.FP_UserFields> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<RuRo.Model.FP_UserFields> DataTableToList(DataTable dt)
		{
			List<RuRo.Model.FP_UserFields> modelList = new List<RuRo.Model.FP_UserFields>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				RuRo.Model.FP_UserFields model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

		#endregion  ExtensionMethod
	}
}

