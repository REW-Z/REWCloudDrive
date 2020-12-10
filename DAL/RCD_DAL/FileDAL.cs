using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace RCD_DAL
{
    public class FileDAL
    {
        /// <summary>
        /// 按UserID选取所有文件
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable SelectAllFilesByUserId(int userid)
        {
            DataSet ds = new DataSet();

            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString1"].ToString());
            conn.Open();

            string sql = "SELECT * FROM FILES WHERE UserID=@UserID";
            SqlCommand cmd = new SqlCommand(sql,conn);
            cmd.Parameters.Add(new SqlParameter("@UserID", userid));
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            
            sda.Fill(ds);

            sda.Dispose();
            cmd.Dispose();
            conn.Close();
            return ds.Tables[0] ;
        }
        /// <summary>
        /// 添加文件信息
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public int AddFileInfo(Model.File file)
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString1"].ToString());
            conn.Open();

            string sql = "INSERT INTO FILES (UserID,FileName,UploadTime,FileType) VALUES (@UserID,@FileName,@UploadTime,@FileType)";

            SqlCommand cmd = new SqlCommand(sql,conn);
            cmd.Parameters.AddRange(new SqlParameter[] {
                new SqlParameter("@UserID",file.UserID),
                new SqlParameter("@FileName",file.FileName),
                new SqlParameter("@UploadTime",file.UploadTime),
                new SqlParameter("@FileType",file.FileType) });
            int result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            return result;
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public int DeleteFileInfo(int fileId)
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString1"].ToString());
            string sql = "DELETE FROM FILES WHERE FileID=@FileID";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@FileID", fileId));

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();

            return result;
        }
        /// <summary>
        /// 根据文件ID查文件名
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns></returns>
        public string GetFileNameByFileID(int fileID)
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString1"].ToString());
            string sql = "SELECT FileName FROM FILES WHERE FileID=@FileID";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@FileID",fileID));
            string result = (string)cmd.ExecuteScalar();

            cmd.Dispose();
            conn.Close();
            return result;
        }
        /// <summary>
        /// 删除用户所有文件
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int DeleteAllUserFiles(int userid)
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString1"].ToString());
            string sql = "DELETE FROM FILES WHERE UserID=@UserID";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(new SqlParameter("@UserID", userid));
            int result = cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
            return result;
        }
        /// <summary>
        /// 分享与取消
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public int ChangeIsShared(int fileId)
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString1"].ToString());
            conn.Open();
            SqlCommand cmd_getisshare = new SqlCommand("SELECT IsShared FROM FILES WHERE FileID=@FileID", conn);
            cmd_getisshare.Parameters.Add(new SqlParameter("@FileID", fileId));
            bool isShared = (bool)cmd_getisshare.ExecuteScalar();
            cmd_getisshare.Dispose();


            int result;
            if (isShared)
            {
                SqlCommand cmd = new SqlCommand("UPDATE FILES SET IsShared=0 WHERE FileID=@FileID", conn);
                cmd.Parameters.Add(new SqlParameter("@FileID", fileId));
                result = cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("UPDATE FILES SET IsShared=1 WHERE FileID=@FileID", conn);
                cmd.Parameters.Add(new SqlParameter("@FileID", fileId));
                result = cmd.ExecuteNonQuery();
            }
            conn.Close();
            return result;
        }
        /// <summary>
        /// 获取所有被分享文件
        /// </summary>
        /// <returns></returns>
        public DataTable GetSharedFiles()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString1"].ToString()))
            {
                conn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM FILES WHERE IsShared=1", conn))
                {
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }
}
