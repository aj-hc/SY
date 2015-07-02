using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL
{
	/// <summary>
	/// 数据访问类:EmployeeInfo
	/// </summary>
	public partial class EmployeeInfo
	{
		public EmployeeInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL_SY.GetMaxIDSY("id", "EmployeeInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EmployeeInfo");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL_SY.ExistsSY(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(RuRo.Model.EmployeeInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EmployeeInfo(");
			strSql.Append("EmployeeName,EmployeeNo,EmployeeID)");
			strSql.Append(" values (");
			strSql.Append("@EmployeeName,@EmployeeNo,@EmployeeID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@EmployeeName", SqlDbType.NVarChar,30),
					new SqlParameter("@EmployeeNo", SqlDbType.NVarChar,10),
					new SqlParameter("@EmployeeID", SqlDbType.Int,4)};
			parameters[0].Value = model.EmployeeName;
			parameters[1].Value = model.EmployeeNo;
			parameters[2].Value = model.EmployeeID;

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
		public bool Update(RuRo.Model.EmployeeInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EmployeeInfo set ");
			strSql.Append("EmployeeName=@EmployeeName,");
			strSql.Append("EmployeeNo=@EmployeeNo,");
			strSql.Append("EmployeeID=@EmployeeID");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@EmployeeName", SqlDbType.NVarChar,30),
					new SqlParameter("@EmployeeNo", SqlDbType.NVarChar,10),
					new SqlParameter("@EmployeeID", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.EmployeeName;
			parameters[1].Value = model.EmployeeNo;
			parameters[2].Value = model.EmployeeID;
			parameters[3].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EmployeeInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EmployeeInfo ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public RuRo.Model.EmployeeInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,EmployeeName,EmployeeNo,EmployeeID from EmployeeInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			RuRo.Model.EmployeeInfo model=new RuRo.Model.EmployeeInfo();
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
		public RuRo.Model.EmployeeInfo DataRowToModel(DataRow row)
		{
			RuRo.Model.EmployeeInfo model=new RuRo.Model.EmployeeInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["EmployeeName"]!=null)
				{
					model.EmployeeName=row["EmployeeName"].ToString();
				}
				if(row["EmployeeNo"]!=null)
				{
					model.EmployeeNo=row["EmployeeNo"].ToString();
				}
				if(row["EmployeeID"]!=null && row["EmployeeID"].ToString()!="")
				{
					model.EmployeeID=int.Parse(row["EmployeeID"].ToString());
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
			strSql.Append("select id,EmployeeName,EmployeeNo,EmployeeID ");
			strSql.Append(" FROM EmployeeInfo ");
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
			strSql.Append(" id,EmployeeName,EmployeeNo,EmployeeID ");
			strSql.Append(" FROM EmployeeInfo ");
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
			strSql.Append("select count(1) FROM EmployeeInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL_SY.GetSingle2(strSql.ToString());
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from EmployeeInfo T ");
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
			parameters[0].Value = "EmployeeInfo";
			parameters[1].Value = "id";
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

