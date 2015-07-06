using FreezerProUtility.Fp_DAL;
using FreezerProUtility.Fp_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{
    public class Users
    {

        //获取用户信息
        private static List<User> GetUsers(string url)
        {
            List<User> usersList = DataWithFP.getdata<User>(url, Fp_Common.FpMethod.users, "", "Users");
            return usersList;
        }
        public static List<User> GetAllUser(string url)
        {
            return GetUsers(url);
        }

        /// <summary>
        /// 根据登录名获取用户对象
        /// </summary>
        /// <param name="url">连接地址</param>
        /// <param name="name">登录名</param>
        /// <returns></returns>
        public static User GetUsersBy(string url, string name)
        {
            List<User> Users = GetUsers(url);
            return Users.Where(a => a.uesrname == name).FirstOrDefault();
        }

        //public static User GetUsersBy(string url,Expression<Func<User,bool>> predicate)
        //{
        //    List<User> Users = GetUsers(url);

        //    return Users.Where(predicate).FirstOrDefault();
        //}
    }
}
