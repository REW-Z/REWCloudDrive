using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REW_Cloud_Drive
{
    public class UserInfo
    {
        public int id;
        public string name;
        public string pwd;
        private bool IsLogin;
        private bool IsAutoLogin;
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserInfo()
        {
            id = 0;
            name = "";
            pwd = "";
            IsLogin = false;
            IsAutoLogin = false;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public bool TryLogin()
        {
            IsLogin = false;

            RCD_BLL.UserBLL bll = new RCD_BLL.UserBLL();
            Model.User user = bll.GetUser(name);
            if(user.PWD == pwd)
            {
                IsLogin = true;
                id = user.ID;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 登出
        /// </summary>
        public void Logout()
        {
            IsLogin = false;
        }
        /// <summary>
        /// 获取是否登陆字段
        /// </summary>
        /// <returns></returns>
        public bool GetIsLogin()
        {
            return IsLogin;
        }
        
    }
}