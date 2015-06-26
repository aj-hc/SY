using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace RuRo.DAL
{
    public partial class FP_Test
    {
        public FP_Test()
		{

        }

        public DataSet GetList(int uid)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int),
				
					};
            parameters[0].Value = uid;
            return DbHelperSQL.RunProcedure("P_FP_TEST_SEL", parameters, "ds");
		}

        public DataSet GetFP_Test() 
        {
            DataSet ds = new DataSet();
            ds=DbHelperSQL.Query("SELECT * FROM tb_Test");
            return ds;
        }
    }
}
