using System;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace RCD_DAL
{
    public class UserDAL
    {
        /// <summary>
        /// 测试是否能连接
        /// </summary>
        /// <returns></returns>
        public bool TryConnect() 
        {
            string conStr = WebConfigurationManager.ConnectionStrings["ConnectionString1"].ToString();
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
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
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString1"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT NAME FROM USERS WHERE ID=@ID", conn);
            cmd.Parameters.Add(new SqlParameter("@ID", userid));
            
            string name = (string)cmd.ExecuteScalar();
            conn.Close();
            return name;
        }
        
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="user"> 用户对象</param>
        /// <returns></returns>
        public int AddUser(Model.User user)
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString1"].ToString());
            conn.Open();

            string sql = "INSERT INTO USERS (NAME,PWD,ROLE) VALUES ('" + user.NAME + "','" + user.PWD + "','" + user.ROLE + "')";
            SqlCommand cmd = new SqlCommand(sql,conn);
            int result = cmd.ExecuteNonQuery();
            cmd.Dispose();

            conn.Close();

            return result;
        }
        /// <summary>
        /// 按Name字段查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Model.User SelectUserByName(string name)
        {
            User user = new User();
            string sql = "SELECT * FROM USERS WHERE NAME ='" + name + "'";
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString1"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Dispose();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                user.ID = (int)reader[0];
                user.NAME = (string)reader[1];
                user.PWD = (string)reader[2];
            }
            conn.Close();
            return user;
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int DeleteUser(int userid)
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString1"].ToString());
            string sql = "DELETE FROM USERS WHERE ID=@ID";
            SqlCommand cmd = new SqlCommand(sql,conn);
            conn.Open();
            cmd.Parameters.Add(new SqlParameter("@ID", userid));
            int result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

            return result;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int ChangePwd(int userid, string pwd)
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString1"].ToString());
            string sql = "UPDATE USERS SET PWD=@PWD WHERE ID=@ID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@PWD", pwd),new SqlParameter("@ID",userid) });
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}
