using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RuRo.BLL
{
    public partial class FP_Test_Bll
    {
        private readonly RuRo.DAL.FP_Test dal = new RuRo.DAL.FP_Test();
        public DataSet GetList(int id)
        {
            return dal.GetList(id);
        }
        public  DataSet GetDataset()
        {
            return dal.GetFP_Test();
        }
    }
}
