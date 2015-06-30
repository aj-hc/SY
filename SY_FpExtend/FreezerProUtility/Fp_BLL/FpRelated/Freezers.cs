using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreezerProUtility.Fp_Model;

namespace FreezerProUtility.Fp_BLL.FpRelated
{
    public class Freezers
    {

        //{"Total":1,"Freezers":[{"id":1,"name":"001号冰箱","description":"001号冰箱","access":0,"subdivisions":4,"boxes":0,"barcode_tag":"7000000001","rfid_tag":"355AB1CBC000007000000001"}]}
        //获取冰箱结构
        public List<Fp_Model.Freezer> GetAll(string url)
        {
            return Fp_DAL.DataWithFP.getdata<Freezer>(url, Fp_Common.FpMethod.freezers, "", "Freezers");
        }
        public Freezer GetFreezerBy(string url,string name) 
        {
            return GetAll(url).Where<Freezer>(a => a.name == name).FirstOrDefault();
        }
    }
}
