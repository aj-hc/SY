using FreezerProUtility.Fp_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_BLL.FpRelated
{
    public class Subdivisions
    {

        //{"Total":4,"Subdivisions":[{"id":2,"obj_id":2,"name":"层 1","access":0,"description":"层 1 Description","subdivisions":6,"boxes":0,"barcode_tag":"7000000002","rfid_tag":"355AB1CBC000007000000002"},{"id":51,"obj_id":51,"name":"层 2","access":0,"description":"层 2 Description","subdivisions":6,"boxes":0,"barcode_tag":"7000000051","rfid_tag":"355AB1CBC000007000000033"},{"id":100,"obj_id":100,"name":"层 3","access":0,"description":"层 3 Description","subdivisions":6,"boxes":0,"barcode_tag":"7000000100","rfid_tag":"355AB1CBC000007000000064"},{"id":149,"obj_id":149,"name":"层 4","access":0,"description":"层 4 Description","subdivisions":6,"boxes":0,"barcode_tag":"7000000149","rfid_tag":"355AB1CBC000007000000095"}]}
        public List<Subdivision> GetAll(string url, string id)
        {
            List<Subdivision> subdivisionList = Fp_DAL.DataWithFP.getdata<Subdivision>(url, Fp_Common.FpMethod.subdivisions, "&id=" + id, "Subdivision");
            return subdivisionList;
        }
    }
}
