using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{
    public class SampleGroup
    {
        public static List<Fp_Model.Sample_Group> GetAll(string url)
        {
            List<Fp_Model.Sample_Group> freezersList = Fp_DAL.DataWithFP.getdata<Fp_Model.Sample_Group>(url, Fp_Common.FpMethod.sample_groups, "", "SampleGroups");
            return freezersList;
        }
        public static Fp_Model.Sample_Group GetBy(string url, string name)
        {
            Fp_Model.Sample_Group sample_Group = GetAll(url).Where<Fp_Model.Sample_Group>(a => a.name == name).FirstOrDefault();
            return sample_Group;
        }
        public static Dictionary<string, string> GetAllIdAndNamesDic(string url)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<Fp_Model.Sample_Group> sample_Group = GetAll(url);
            foreach (var item in sample_Group)
            {
                dic.Add(item.id, item.name);
            }
            return dic;
        }
    }
}
