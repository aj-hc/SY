using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL
{
	/// <summary>
	/// 数据访问类:SurgeryInfo
	/// </summary>
	public partial class SurgeryInfo
	{
		public SurgeryInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL_SY.GetMaxIDSY("id", "SurgeryInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SurgeryInfo");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			return DbHelperSQL_SY.ExistsSY(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(RuRo.Model.SurgeryInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SurgeryInfo(");
			strSql.Append("id,SurgeryRequestID,ICDCode,SurgeryName,RequestExecutiveDateTime,RequestDoctorEmployeeID)");
			strSql.Append(" values (");
			strSql.Append("@id,@SurgeryRequestID,@ICDCode,@SurgeryName,@RequestExecutiveDateTime,@RequestDoctorEmployeeID)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@SurgeryRequestID", SqlDbType.Int,4),
					new SqlParameter("@ICDCode", SqlDbType.NVarChar,30),
					new SqlParameter("@SurgeryName", SqlDbType.NVarChar,50),
					new SqlParameter("@RequestExecutiveDateTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RequestDoctorEmployeeID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.SurgeryRequestID;
			parameters[2].Value = model.ICDCode;
			parameters[3].Value = model.SurgeryName;
			parameters[4].Value = model.RequestExecutiveDateTime;
			parameters[5].Value = model.RequestDoctorEmployeeID;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(RuRo.Model.SurgeryInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SurgeryInfo set ");
			strSql.Append("SurgeryRequestID=@SurgeryRequestID,");
			strSql.Append("ICDCode=@ICDCode,");
			strSql.Append("SurgeryName=@SurgeryName,");
			strSql.Append("RequestExecutiveDateTime=@RequestExecutiveDateTime,");
			strSql.Append("RequestDoctorEmployeeID=@RequestDoctorEmployeeID");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@SurgeryRequestID", SqlDbType.Int,4),
					new SqlParameter("@ICDCode", SqlDbType.NVarChar,30),
					new SqlParameter("@SurgeryName", SqlDbType.NVarChar,50),
					new SqlParameter("@RequestExecutiveDateTime", SqlDbType.SmallDateTime),
					new SqlParameter("@RequestDoctorEmployeeID", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.SurgeryRequestID;
			parameters[1].Value = model.ICDCode;
			parameters[2].Value = model.SurgeryName;
			parameters[3].Value = model.RequestExecutiveDateTime;
			parameters[4].Value = model.RequestDoctorEmployeeID;
			parameters[5].Value = model.id;

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
			strSql.Append("delete from SurgeryInfo ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
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
			strSql.Append("delete from SurgeryInfo ");
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
		public RuRo.Model.SurgeryInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,SurgeryRequestID,ICDCode,SurgeryName,RequestExecutiveDateTime,RequestDoctorEmployeeID from SurgeryInfo ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			RuRo.Model.SurgeryInfo model=new RuRo.Model.SurgeryInfo();
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
		public RuRo.Model.SurgeryInfo DataRowToModel(DataRow row)
		{
			RuRo.Model.SurgeryInfo model=new RuRo.Model.SurgeryInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["SurgeryRequestID"]!=null && row["SurgeryRequestID"].ToString()!="")
				{
					model.SurgeryRequestID=int.Parse(row["SurgeryRequestID"].ToString());
				}
				if(row["ICDCode"]!=null)
				{
					model.ICDCode=row["ICDCode"].ToString();
				}
				if(row["SurgeryName"]!=null)
				{
					model.SurgeryName=row["SurgeryName"].ToString();
				}
				if(row["RequestExecutiveDateTime"]!=null && row["RequestExecutiveDateTime"].ToString()!="")
				{
					model.RequestExecutiveDateTime=DateTime.Parse(row["RequestExecutiveDateTime"].ToString());
				}
				if(row["RequestDoctorEmployeeID"]!=null && row["RequestDoctorEmployeeID"].ToString()!="")
				{
					model.RequestDoctorEmployeeID=int.Parse(row["RequestDoctorEmployeeID"].ToString());
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
			strSql.Append("select id,SurgeryRequestID,ICDCode,SurgeryName,RequestExecutiveDateTime,RequestDoctorEmployeeID ");
			strSql.Append(" FROM SurgeryInfo ");
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
			strSql.Append(" id,SurgeryRequestID,ICDCode,SurgeryName,RequestExecutiveDateTime,RequestDoctorEmployeeID ");
			strSql.Append(" FROM SurgeryInfo ");
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
			strSql.Append("select count(1) FROM SurgeryInfo ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from SurgeryInfo T ");
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
			parameters[0].Value = "SurgeryInfo";
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

