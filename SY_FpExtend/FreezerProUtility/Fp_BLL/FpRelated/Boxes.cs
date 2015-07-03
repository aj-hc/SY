using FreezerProUtility.Fp_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{
    public class Boxes
    {
        /// <summary>
        /// 返回指定节点下的boxes
        /// </summary>
        /// <param name="url">链接fp字符串，带有账号密码信息</param>
        /// <param name="id">节点id（freezer or subdivision id）</param>
        /// <returns></returns>
        public static List<Box> GetAll(string url, string id)
        {
            List<Box> boxes = Fp_DAL.DataWithFP.getdata<Box>(url, Fp_Common.FpMethod.boxes, "&id=" + id, "Boxes");
            return boxes;
        }

        //判断指定名称的盒子是否存在
        /// <summary>
        /// 判断指定节点下是否存在符合条件的盒子
        /// </summary>
        /// <param name="url">链接fp字符串，带有账号密码信息</param>
        /// <param name="id">节点id（freezer or subdivision id）</param>
        /// <param name="boxName">根据名称查</param>
        /// <returns></returns>
        public static bool CheckBoxesBy(string url, string id, string boxName)
        {
            List<Box> boxes = Fp_DAL.DataWithFP.getdata<Box>(url, Fp_Common.FpMethod.boxes, "&id=" + id, "Boxes");

            Box box = boxes.Where(a => a.name == boxName).FirstOrDefault();
            if (box==null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
