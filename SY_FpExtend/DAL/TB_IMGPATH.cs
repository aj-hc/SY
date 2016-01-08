using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL
{
	/// <summary>
	/// ���ݷ�����:TB_IMGPATH
	/// </summary>
	public partial class TB_IMGPATH
	{
		public TB_IMGPATH()
		{}
		#region  BasicMethod

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL_SY.GetMaxIDSY("ID", "TB_IMGPATH"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TB_IMGPATH");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = ID;

			return DbHelperSQL_SY.ExistsSY(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Add(RuRo.Model.TB_IMGPATH model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TB_IMGPATH(");
			strSql.Append("IMGNAME,KESHI,DATE,IMGPATH)");
			strSql.Append(" values (");
			strSql.Append("@IMGNAME,@KESHI,@DATE,@IMGPATH)");
			SqlParameter[] parameters = {
					new SqlParameter("@IMGNAME", SqlDbType.VarChar,50),
					new SqlParameter("@KESHI", SqlDbType.VarChar,50),
					new SqlParameter("@DATE", SqlDbType.DateTime),
					new SqlParameter("@IMGPATH", SqlDbType.VarChar,-1)};
			parameters[0].Value = model.IMGNAME;
			parameters[1].Value = model.KESHI;
			parameters[2].Value = model.DATE;
			parameters[3].Value = model.IMGPATH;
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
		/// ����һ������
		/// </summary>
		public bool Update(RuRo.Model.TB_IMGPATH model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TB_IMGPATH set ");
			strSql.Append("IMGNAME=@IMGNAME,");
			strSql.Append("KESHI=@KESHI,");
			strSql.Append("DATE=@DATE,");
			strSql.Append("IMGPATH=@IMGPATH");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@IMGNAME", SqlDbType.VarChar,50),
					new SqlParameter("@KESHI", SqlDbType.VarChar,50),
					new SqlParameter("@DATE", SqlDbType.DateTime),
					new SqlParameter("@IMGPATH", SqlDbType.NVarChar,-1),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.IMGNAME;
			parameters[1].Value = model.KESHI;
			parameters[2].Value = model.DATE;
			parameters[3].Value = model.IMGPATH;
			parameters[4].Value = model.ID;

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
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TB_IMGPATH ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = ID;

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
		/// ����ɾ������
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TB_IMGPATH ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		/// �õ�һ������ʵ��
		/// </summary>
		public RuRo.Model.TB_IMGPATH GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,IMGNAME,KESHI,DATE,IMGPATH from TB_IMGPATH ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = ID;

			RuRo.Model.TB_IMGPATH model=new RuRo.Model.TB_IMGPATH();
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
		/// �õ�һ������ʵ��
		/// </summary>
		public RuRo.Model.TB_IMGPATH DataRowToModel(DataRow row)
		{
			RuRo.Model.TB_IMGPATH model=new RuRo.Model.TB_IMGPATH();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["IMGNAME"]!=null)
				{
					model.IMGNAME=row["IMGNAME"].ToString();
				}
				if(row["KESHI"]!=null)
				{
					model.KESHI=row["KESHI"].ToString();
				}
				if(row["DATE"]!=null && row["DATE"].ToString()!="")
				{
					model.DATE=DateTime.Parse(row["DATE"].ToString());
				}
				if(row["IMGPATH"]!=null)
				{
					model.IMGPATH=row["IMGPATH"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,IMGNAME,KESHI,DATE,IMGPATH ");
			strSql.Append(" FROM TB_IMGPATH ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL_SY.QuerySY(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,IMGNAME,KESHI,DATE,IMGPATH ");
			strSql.Append(" FROM TB_IMGPATH ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL_SY.QuerySY(strSql.ToString());
		}

		/// <summary>
		/// ��ȡ��¼����
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM TB_IMGPATH ");
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
		/// ��ҳ��ȡ�����б�
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from TB_IMGPATH T ");
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
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "TB_IMGPATH";
			parameters[1].Value = "ID";
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

