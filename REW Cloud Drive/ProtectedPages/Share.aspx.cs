using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace REW_Cloud_Drive.ProtectedPages
{
    public partial class Share : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            App_Code.SessionAuthorization.SessionAuthorizeRedirect();
            if (!IsPostBack)
            {
                ListViewBind();
            }
        }
        protected void ListViewBind()
        {
            RCD_BLL.FileBLL bll_files = new RCD_BLL.FileBLL();
            

            DataTable dt = bll_files.GetSharedFiles();


            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
        /// <summary>
        /// 获取图像URL
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetImgUrl(string type)
        {
            if (type == ".txt")
            {
                return "~/Images/ICON_File.png";
            }
            else if (type == ".jpg")
            {
                return "~/Images/ICON_Img.png";
            }
            else
            {
                return "~/Images/ICON_Unknow.png";
            }
        }
        /// <summary>
        /// 过去分享的用户名
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetUserName(int userid)
        {
            RCD_BLL.UserBLL bll_users = new RCD_BLL.UserBLL();
            return bll_users.GetUserNameByID(userid);
        }
        /// <summary>
        /// 获取分享的用户头像
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetUserPicURL(int userid)
        {
            RCD_BLL.UserBLL bll_users = new RCD_BLL.UserBLL();
            string str = "/ProfilePictures/" + bll_users.GetUserNameByID(userid) + ".png";
            return str;
        }
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Download_Command(object sender, CommandEventArgs e)
        {
            RCD_BLL.FileBLL bll_file = new RCD_BLL.FileBLL();

            FileInfo file = new FileInfo(bll_file.GetFullNameByFileID(Convert.ToInt32(e.CommandArgument)));
            if (file.Exists)
            {
                Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(file.Name));

                Response.Clear();
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('文件不存在')", true);
            }
        }
    }
}