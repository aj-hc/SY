using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace RuRo.DAL
{
    /// <summary>
    /// 数据访问类:BasedInfo
    /// </summary>
    public partial class BasedInfo
    {
        public BasedInfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL_SY.GetMaxIDSY("id", "BasedInfo");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BasedInfo");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL_SY.ExistsSY(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(RuRo.Model.BasedInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BasedInfo(");
            strSql.Append("PatientName,IPSeqNoText,PatientCardNo,SexFlag,Birthday,BloodTypeFlag,Phone,ContactPhone,ContactPerson,NativePlace,RegisterSeqNO,PatientID,RegisterID,InPatientID,IdentityCardNo,ADDTIME)");
            strSql.Append(" values (");
            strSql.Append("@PatientName,@IPSeqNoText,@PatientCardNo,@SexFlag,@Birthday,@BloodTypeFlag,@Phone,@ContactPhone,@ContactPerson,@NativePlace,@RegisterSeqNO,@PatientID,@RegisterID,@InPatientID,@IdentityCardNo,@ADDTIME)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PatientName", SqlDbType.NVarChar,30),
					new SqlParameter("@IPSeqNoText", SqlDbType.NVarChar,14),
					new SqlParameter("@PatientCardNo", SqlDbType.NVarChar,30),
					new SqlParameter("@SexFlag", SqlDbType.NVarChar,10),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@BloodTypeFlag", SqlDbType.NChar,10),
					new SqlParameter("@Phone", SqlDbType.NVarChar,20),
					new SqlParameter("@ContactPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,30),
					new SqlParameter("@NativePlace", SqlDbType.NVarChar,20),
					new SqlParameter("@RegisterSeqNO", SqlDbType.NVarChar,30),
					new SqlParameter("@PatientID", SqlDbType.Int,4),
					new SqlParameter("@RegisterID", SqlDbType.Int,4),
					new SqlParameter("@InPatientID", SqlDbType.Money,8),
                    new SqlParameter("@IdentityCardNo",SqlDbType.NVarChar,50),
					new SqlParameter("@ADDTIME", SqlDbType.DateTime)};
            parameters[0].Value = model.PatientName;
            parameters[1].Value = model.IPSeqNoText;
            parameters[2].Value = model.PatientCardNo;
            parameters[3].Value = model.SexFlag;
            parameters[4].Value = model.Birthday;
            parameters[5].Value = model.BloodTypeFlag;
            parameters[6].Value = model.Phone;
            parameters[7].Value = model.ContactPhone;
            parameters[8].Value = model.ContactPerson;
            parameters[9].Value = model.NativePlace;
            parameters[10].Value = model.RegisterSeqNO;
            parameters[11].Value = model.PatientID;
            parameters[12].Value = model.RegisterID;
            parameters[13].Value = model.InPatientID;
            parameters[14].Value = model.IdentityCardNo;
            parameters[15].Value = model.ADDTIME;

            object obj = DbHelperSQL_SY.GetSingleSY(strSql.ToString(), parameters);
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
        public bool Update(RuRo.Model.BasedInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BasedInfo set ");
            strSql.Append("PatientName=@PatientName,");
            strSql.Append("IPSeqNoText=@IPSeqNoText,");
            strSql.Append("PatientCardNo=@PatientCardNo,");
            strSql.Append("SexFlag=@SexFlag,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("BloodTypeFlag=@BloodTypeFlag,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("ContactPhone=@ContactPhone,");
            strSql.Append("ContactPerson=@ContactPerson,");
            strSql.Append("NativePlace=@NativePlace,");
            strSql.Append("RegisterSeqNO=@RegisterSeqNO,");
            strSql.Append("PatientID=@PatientID,");
            strSql.Append("RegisterID=@RegisterID,");
            strSql.Append("InPatientID=@InPatientID,");
            strSql.Append("IdentityCardNo=@IdentityCardNo");
            strSql.Append("ADDTIME=@ADDTIME");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@PatientName", SqlDbType.NVarChar,30),
					new SqlParameter("@IPSeqNoText", SqlDbType.NVarChar,14),
					new SqlParameter("@PatientCardNo", SqlDbType.NVarChar,30),
					new SqlParameter("@SexFlag", SqlDbType.NVarChar,10),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@BloodTypeFlag", SqlDbType.NChar,10),
					new SqlParameter("@Phone", SqlDbType.NVarChar,20),
					new SqlParameter("@ContactPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@ContactPerson", SqlDbType.NVarChar,30),
					new SqlParameter("@NativePlace", SqlDbType.NVarChar,20),
					new SqlParameter("@RegisterSeqNO", SqlDbType.NVarChar,30),
					new SqlParameter("@PatientID", SqlDbType.Int,4),
					new SqlParameter("@RegisterID", SqlDbType.Int,4),
					new SqlParameter("@InPatientID", SqlDbType.Money,8),
                    new SqlParameter("@IdentityCardNo",SqlDbType.NVarChar,50),
					new SqlParameter("@ADDTIME", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.PatientName;
            parameters[1].Value = model.IPSeqNoText;
            parameters[2].Value = model.PatientCardNo;
            parameters[3].Value = model.SexFlag;
            parameters[4].Value = model.Birthday;
            parameters[5].Value = model.BloodTypeFlag;
            parameters[6].Value = model.Phone;
            parameters[7].Value = model.ContactPhone;
            parameters[8].Value = model.ContactPerson;
            parameters[9].Value = model.NativePlace;
            parameters[10].Value = model.RegisterSeqNO;
            parameters[11].Value = model.PatientID;
            parameters[12].Value = model.RegisterID;
            parameters[13].Value = model.InPatientID;
            parameters[14].Value = model.ADDTIME;
            parameters[15].Value = model.IdentityCardNo;
            parameters[15].Value = model.id;
            int rows = DbHelperSQL_SY.ExecuteSqlSY(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BasedInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperSQL_SY.ExecuteSqlSY(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BasedInfo ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperSQL_SY.ExecuteSqlSY(strSql.ToString());
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
        public RuRo.Model.BasedInfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,PatientName,IPSeqNoText,PatientCardNo,SexFlag,Birthday,BloodTypeFlag,Phone,ContactPhone,ContactPerson,NativePlace,RegisterSeqNO,PatientID,RegisterID,InPatientID,ADDTIME from BasedInfo ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            RuRo.Model.BasedInfo model = new RuRo.Model.BasedInfo();
            DataSet ds = DbHelperSQL_SY.QuerySY(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public RuRo.Model.BasedInfo DataRowToModel(DataRow row)
        {
            RuRo.Model.BasedInfo model = new RuRo.Model.BasedInfo();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["PatientName"] != null)
                {
                    model.PatientName = row["PatientName"].ToString();
                }
                if (row["IPSeqNoText"] != null)
                {
                    model.IPSeqNoText = row["IPSeqNoText"].ToString();
                }
                if (row["PatientCardNo"] != null)
                {
                    model.PatientCardNo = row["PatientCardNo"].ToString();
                }
                if (row["SexFlag"] != null)
                {
                    model.SexFlag = row["SexFlag"].ToString();
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["BloodTypeFlag"] != null)
                {
                    model.BloodTypeFlag = row["BloodTypeFlag"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["ContactPhone"] != null)
                {
                    model.ContactPhone = row["ContactPhone"].ToString();
                }
                if (row["ContactPerson"] != null)
                {
                    model.ContactPerson = row["ContactPerson"].ToString();
                }
                if (row["NativePlace"] != null)
                {
                    model.NativePlace = row["NativePlace"].ToString();
                }
                if (row["RegisterSeqNO"] != null)
                {
                    model.RegisterSeqNO = row["RegisterSeqNO"].ToString();
                }
                if (row["PatientID"] != null && row["PatientID"].ToString() != "")
                {
                    model.PatientID = int.Parse(row["PatientID"].ToString());
                }
                if (row["RegisterID"] != null && row["RegisterID"].ToString() != "")
                {
                    model.RegisterID = int.Parse(row["RegisterID"].ToString());
                }
                if (row["InPatientID"] != null && row["InPatientID"].ToString() != "")
                {
                    model.InPatientID = decimal.Parse(row["InPatientID"].ToString());
                }
                if (row["ADDTIME"] != null && row["ADDTIME"].ToString() != "")
                {
                    model.ADDTIME = DateTime.Parse(row["ADDTIME"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,PatientName,IPSeqNoText,PatientCardNo,SexFlag,Birthday,BloodTypeFlag,Phone,ContactPhone,ContactPerson,NativePlace,RegisterSeqNO,PatientID,RegisterID,InPatientID,ADDTIME ");
            strSql.Append(" FROM BasedInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL_SY.QuerySY(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,PatientName,IPSeqNoText,PatientCardNo,SexFlag,Birthday,BloodTypeFlag,Phone,ContactPhone,ContactPerson,NativePlace,RegisterSeqNO,PatientID,RegisterID,InPatientID,ADDTIME ");
            strSql.Append(" FROM BasedInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL_SY.QuerySY(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM BasedInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from BasedInfo T ");
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
            parameters[0].Value = "BasedInfo";
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

