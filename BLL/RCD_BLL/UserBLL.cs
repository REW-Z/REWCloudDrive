using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Configuration;

namespace RCD_BLL
{
    public class UserBLL
    {
        private RCD_DAL.UserDAL dal = new RCD_DAL.UserDAL();
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <returns></returns>
        public bool CanConnect()
        {
            return dal.TryConnect();
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool SignupUser(string name, string pwd, string role)
        {
            Model.User user = new Model.User();
            user.NAME = name;
            user.PWD = pwd;
            user.ROLE = role;

            int exeresult = dal.AddUser(user);

            if(exeresult > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据姓名获取用户
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Model.User GetUser(string username)
        {
            Model.User user = dal.SelectUserByName(username);
            return user;
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool DeleteUser(int userid)
        {
            int result = dal.DeleteUser(userid);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool ChangePwd(int userid, string pwd)
        {
            int result = dal.ChangePwd(userid, pwd);
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据用户ID获得用户名
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetUserNameByID(int userid)
        {
            return dal.GetUserNameByID(userid);
        }
        
    }
}
