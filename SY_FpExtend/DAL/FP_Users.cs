using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL
{
	/// <summary>
	/// 数据访问类:FP_Users
	/// </summary>
	public partial class FP_Users
	{
		public FP_Users()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("userID", "FP_Users"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int userID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FP_Users");
			strSql.Append(" where userID=@userID ");
			SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.Int,4)			};
			parameters[0].Value = userID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(RuRo.Model.FP_Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FP_Users(");
			strSql.Append("userID,id,obj_id,username,fullname,email,created_at,disabled,active,role,samples)");
			strSql.Append(" values (");
			strSql.Append("@userID,@id,@obj_id,@username,@fullname,@email,@created_at,@disabled,@active,@role,@samples)");
			SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@obj_id", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.NChar,10),
					new SqlParameter("@fullname", SqlDbType.NChar,10),
					new SqlParameter("@email", SqlDbType.NChar,10),
					new SqlParameter("@created_at", SqlDbType.NChar,10),
					new SqlParameter("@disabled", SqlDbType.NChar,10),
					new SqlParameter("@active", SqlDbType.NChar,10),
					new SqlParameter("@role", SqlDbType.NChar,10),
					new SqlParameter("@samples", SqlDbType.NChar,10)};
			parameters[0].Value = model.userID;
			parameters[1].Value = model.id;
			parameters[2].Value = model.obj_id;
			parameters[3].Value = model.username;
			parameters[4].Value = model.fullname;
			parameters[5].Value = model.email;
			parameters[6].Value = model.created_at;
			parameters[7].Value = model.disabled;
			parameters[8].Value = model.active;
			parameters[9].Value = model.role;
			parameters[10].Value = model.samples;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(RuRo.Model.FP_Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FP_Users set ");
			strSql.Append("id=@id,");
			strSql.Append("obj_id=@obj_id,");
			strSql.Append("username=@username,");
			strSql.Append("fullname=@fullname,");
			strSql.Append("email=@email,");
			strSql.Append("created_at=@created_at,");
			strSql.Append("disabled=@disabled,");
			strSql.Append("active=@active,");
			strSql.Append("role=@role,");
			strSql.Append("samples=@samples");
			strSql.Append(" where userID=@userID ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@obj_id", SqlDbType.Int,4),
					new SqlParameter("@username", SqlDbType.NChar,10),
					new SqlParameter("@fullname", SqlDbType.NChar,10),
					new SqlParameter("@email", SqlDbType.NChar,10),
					new SqlParameter("@created_at", SqlDbType.NChar,10),
					new SqlParameter("@disabled", SqlDbType.NChar,10),
					new SqlParameter("@active", SqlDbType.NChar,10),
					new SqlParameter("@role", SqlDbType.NChar,10),
					new SqlParameter("@samples", SqlDbType.NChar,10),
					new SqlParameter("@userID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.obj_id;
			parameters[2].Value = model.username;
			parameters[3].Value = model.fullname;
			parameters[4].Value = model.email;
			parameters[5].Value = model.created_at;
			parameters[6].Value = model.disabled;
			parameters[7].Value = model.active;
			parameters[8].Value = model.role;
			parameters[9].Value = model.samples;
			parameters[10].Value = model.userID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int userID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FP_Users ");
			strSql.Append(" where userID=@userID ");
			SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.Int,4)			};
			parameters[0].Value = userID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string userIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FP_Users ");
			strSql.Append(" where userID in ("+userIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public RuRo.Model.FP_Users GetModel(int userID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 userID,id,obj_id,username,fullname,email,created_at,disabled,active,role,samples from FP_Users ");
			strSql.Append(" where userID=@userID ");
			SqlParameter[] parameters = {
					new SqlParameter("@userID", SqlDbType.Int,4)			};
			parameters[0].Value = userID;

			RuRo.Model.FP_Users model=new RuRo.Model.FP_Users();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public RuRo.Model.FP_Users DataRowToModel(DataRow row)
		{
			RuRo.Model.FP_Users model=new RuRo.Model.FP_Users();
			if (row != null)
			{
				if(row["userID"]!=null && row["userID"].ToString()!="")
				{
					model.userID=int.Parse(row["userID"].ToString());
				}
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["obj_id"]!=null && row["obj_id"].ToString()!="")
				{
					model.obj_id=int.Parse(row["obj_id"].ToString());
				}
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["fullname"]!=null)
				{
					model.fullname=row["fullname"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["created_at"]!=null)
				{
					model.created_at=row["created_at"].ToString();
				}
				if(row["disabled"]!=null)
				{
					model.disabled=row["disabled"].ToString();
				}
				if(row["active"]!=null)
				{
					model.active=row["active"].ToString();
				}
				if(row["role"]!=null)
				{
					model.role=row["role"].ToString();
				}
				if(row["samples"]!=null)
				{
					model.samples=row["samples"].ToString();
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
			strSql.Append("select userID,id,obj_id,username,fullname,email,created_at,disabled,active,role,samples ");
			strSql.Append(" FROM FP_Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" userID,id,obj_id,username,fullname,email,created_at,disabled,active,role,samples ");
			strSql.Append(" FROM FP_Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM FP_Users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
				strSql.Append("order by T.userID desc");
			}
			strSql.Append(")AS Row, T.*  from FP_Users T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
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
			parameters[0].Value = "FP_Users";
			parameters[1].Value = "userID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

