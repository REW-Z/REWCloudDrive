using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace RCD_BLL
{
    public class FileBLL
    {
        RCD_DAL.FileDAL dal_files = new RCD_DAL.FileDAL();
        /// <summary>
        /// 获取用户所有文件
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable GetAllFilesByUserID(int userid)
        {
            return dal_files.SelectAllFilesByUserId(userid);
        }
        /// <summary>
        /// 添加文件信息，返回是否成功
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool AddFileInfo(Model.File file)
        {
            int i = dal_files.AddFileInfo(file);
            if(i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns></returns>
        public bool DeleteFileInfoById(int fileID)
        {
            int result = dal_files.DeleteFileInfo(fileID);
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
        /// 获得文件完全限定名
        /// </summary>
        /// <param name="fileid"></param>
        /// <returns></returns>
        public string GetFullNameByFileID(int fileid)
        {
            return HttpContext.Current.Server.MapPath("~/UploadFiles/" + dal_files.GetFileNameByFileID(fileid));
        }
        /// <summary>
        /// 删除用户所有文件
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public int DeleteAllFiles(int userid)
        {
            return dal_files.DeleteAllUserFiles(userid);
        }
        /// <summary>
        /// 分享与取消
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns></returns>
        public bool ShareOrNot(int fileID)
        {
            int result = dal_files.ChangeIsShared(fileID);
            return result > 0 ? true : false;
        }
        /// <summary>
        /// 获取分享文件
        /// </summary>
        /// <returns></returns>
        public DataTable GetSharedFiles()
        {
            return dal_files.GetSharedFiles();
        }
    }
}
