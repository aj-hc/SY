using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL
{
	/// <summary>
	/// 数据访问类:FP_UserFields
	/// </summary>
	public partial class FP_UserFields
	{
		public FP_UserFields()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL_SY.GetMaxIDSY("userFieldId", "FP_UserFields"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int userFieldId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FP_UserFields");
			strSql.Append(" where userFieldId=@userFieldId");
			SqlParameter[] parameters = {
					new SqlParameter("@userFieldId", SqlDbType.Int,4)
			};
			parameters[0].Value = userFieldId;

			return DbHelperSQL_SY.ExistsSY(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(RuRo.Model.FP_UserFields model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FP_UserFields(");
			strSql.Append("id,obj_id,display_name,name,type,values,show,created_at,updated_at,inuse)");
			strSql.Append(" values (");
			strSql.Append("@id,@obj_id,@display_name,@name,@type,@values,@show,@created_at,@updated_at,@inuse)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@obj_id", SqlDbType.Int,4),
					new SqlParameter("@display_name", SqlDbType.NVarChar,128),
					new SqlParameter("@name", SqlDbType.NVarChar,128),
					new SqlParameter("@type", SqlDbType.NVarChar,128),
					new SqlParameter("@values", SqlDbType.NVarChar,-1),
					new SqlParameter("@show", SqlDbType.NVarChar,128),
					new SqlParameter("@created_at", SqlDbType.NVarChar,128),
					new SqlParameter("@updated_at", SqlDbType.NVarChar,128),
					new SqlParameter("@inuse", SqlDbType.NVarChar,128)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.obj_id;
			parameters[2].Value = model.display_name;
			parameters[3].Value = model.name;
			parameters[4].Value = model.type;
			parameters[5].Value = model.values;
			parameters[6].Value = model.show;
			parameters[7].Value = model.created_at;
			parameters[8].Value = model.updated_at;
			parameters[9].Value = model.inuse;

			object obj = DbHelperSQL_SY.GetSingleSY(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(RuRo.Model.FP_UserFields model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FP_UserFields set ");
			strSql.Append("id=@id,");
			strSql.Append("obj_id=@obj_id,");
			strSql.Append("display_name=@display_name,");
			strSql.Append("name=@name,");
			strSql.Append("type=@type,");
			strSql.Append("values=@values,");
			strSql.Append("show=@show,");
			strSql.Append("created_at=@created_at,");
			strSql.Append("updated_at=@updated_at,");
			strSql.Append("inuse=@inuse");
			strSql.Append(" where userFieldId=@userFieldId");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@obj_id", SqlDbType.Int,4),
					new SqlParameter("@display_name", SqlDbType.NVarChar,128),
					new SqlParameter("@name", SqlDbType.NVarChar,128),
					new SqlParameter("@type", SqlDbType.NVarChar,128),
					new SqlParameter("@values", SqlDbType.NVarChar,-1),
					new SqlParameter("@show", SqlDbType.NVarChar,128),
					new SqlParameter("@created_at", SqlDbType.NVarChar,128),
					new SqlParameter("@updated_at", SqlDbType.NVarChar,128),
					new SqlParameter("@inuse", SqlDbType.NVarChar,128),
					new SqlParameter("@userFieldId", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.obj_id;
			parameters[2].Value = model.display_name;
			parameters[3].Value = model.name;
			parameters[4].Value = model.type;
			parameters[5].Value = model.values;
			parameters[6].Value = model.show;
			parameters[7].Value = model.created_at;
			parameters[8].Value = model.updated_at;
			parameters[9].Value = model.inuse;
			parameters[10].Value = model.userFieldId;

			int rows=DbHelperSQL_SY.ExecuteSqlSY(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int userFieldId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FP_UserFields ");
			strSql.Append(" where userFieldId=@userFieldId");
			SqlParameter[] parameters = {
					new SqlParameter("@userFieldId", SqlDbType.Int,4)
			};
			parameters[0].Value = userFieldId;

			int rows=DbHelperSQL_SY.ExecuteSqlSY(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string userFieldIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FP_UserFields ");
			strSql.Append(" where userFieldId in ("+userFieldIdlist + ")  ");
			int rows=DbHelperSQL_SY.ExecuteSqlSY(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RuRo.Model.FP_UserFields GetModel(int userFieldId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 userFieldId,id,obj_id,display_name,name,type,values,show,created_at,updated_at,inuse from FP_UserFields ");
			strSql.Append(" where userFieldId=@userFieldId");
			SqlParameter[] parameters = {
					new SqlParameter("@userFieldId", SqlDbType.Int,4)
			};
			parameters[0].Value = userFieldId;

			RuRo.Model.FP_UserFields model=new RuRo.Model.FP_UserFields();
			DataSet ds=DbHelperSQL_SY.QuerySY(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RuRo.Model.FP_UserFields DataRowToModel(DataRow row)
		{
			RuRo.Model.FP_UserFields model=new RuRo.Model.FP_UserFields();
			if (row != null)
			{
				if(row["userFieldId"]!=null && row["userFieldId"].ToString()!="")
				{
					model.userFieldId=int.Parse(row["userFieldId"].ToString());
				}
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["obj_id"]!=null && row["obj_id"].ToString()!="")
				{
					model.obj_id=int.Parse(row["obj_id"].ToString());
				}
				if(row["display_name"]!=null)
				{
					model.display_name=row["display_name"].ToString();
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
				if(row["values"]!=null)
				{
					model.values=row["values"].ToString();
				}
				if(row["show"]!=null)
				{
					model.show=row["show"].ToString();
				}
				if(row["created_at"]!=null)
				{
					model.created_at=row["created_at"].ToString();
				}
				if(row["updated_at"]!=null)
				{
					model.updated_at=row["updated_at"].ToString();
				}
				if(row["inuse"]!=null)
				{
					model.inuse=row["inuse"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userFieldId,id,obj_id,display_name,name,type,values,show,created_at,updated_at,inuse ");
			strSql.Append(" FROM FP_UserFields ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL_SY.QuerySY(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" userFieldId,id,obj_id,display_name,name,type,values,show,created_at,updated_at,inuse ");
			strSql.Append(" FROM FP_UserFields ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL_SY.QuerySY(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM FP_UserFields ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL_SY.GetSingleSY(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.userFieldId desc");
			}
			strSql.Append(")AS Row, T.*  from FP_UserFields T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL_SY.QuerySY(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "FP_UserFields";
			parameters[1].Value = "userFieldId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL_SY.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

