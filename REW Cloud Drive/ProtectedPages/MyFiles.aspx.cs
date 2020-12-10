using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;    
using System.Web.UI;
using System.Web.UI.WebControls;

namespace REW_Cloud_Drive.ProtectedPages
{
    public partial class MyFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            App_Code.SessionAuthorization.SessionAuthorizeRedirect();

            if (!IsPostBack)
            {
                ListViewBind();
            }
        }

        private void ListViewBind()
        {
            RCD_BLL.FileBLL bll_files = new RCD_BLL.FileBLL();

            UserInfo userinfo = (UserInfo)Session["UserInfo"];
            int userid = userinfo.id;

            DataTable dt = bll_files.GetAllFilesByUserID(userid);


            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
        public string GetImgUrl(string type)
        {
            if(type == ".txt")
            {
                return "~/Images/ICON_File.png";
            }
            else if(type == ".jpg")
            {
                return "~/Images/ICON_Img.png";
            }
            else
            {
                return "~/Images/ICON_Unknow.png";
            }
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            RCD_BLL.FileBLL bll_files = new RCD_BLL.FileBLL();
            bll_files.DeleteFileInfoById((int)e.Keys[0]);

            ListViewBind();
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            
        }
        /// <summary>
        /// 下载OnCommand
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
        /// <summary>
        /// 分享与取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Share_Command(object sender, CommandEventArgs e)
        {

            RCD_BLL.FileBLL bll_file = new RCD_BLL.FileBLL();

            bool Success = bll_file.ShareOrNot(Convert.ToInt32(e.CommandArgument));
            if (Success)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('成功分享或取消分享')", true);
            }
            ListViewBind();
        }
    }
}