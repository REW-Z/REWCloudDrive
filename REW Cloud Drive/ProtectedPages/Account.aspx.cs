using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace REW_Cloud_Drive.ProtectedPages
{
    public partial class Account : System.Web.UI.Page
    {
        RCD_BLL.UserBLL bll_user = new RCD_BLL.UserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            App_Code.SessionAuthorization.SessionAuthorizeRedirect();

            UserInfo userinfo = (UserInfo)Session["UserInfo"];
            string username = userinfo.name;

            ImageButton_profilePic.ImageUrl = "~/ProfilePictures/" + username + ".png";
        }

        protected void Button_deleteaccount_Click(object sender, EventArgs e)
        {
            RCD_BLL.UserBLL bll_user = new RCD_BLL.UserBLL();

            UserInfo userinfo = (UserInfo)Session["UserInfo"];
            
            bool Success = bll_user.DeleteUser(userinfo.id);
            if (Success)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功')", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败')", true);
            }
        }

        protected void Button_changeword_Click(object sender, EventArgs e)
        {
            RCD_BLL.UserBLL blll_user = new RCD_BLL.UserBLL();

            UserInfo userInfo = (UserInfo)Session["UserInfo"];
            int userid = userInfo.id;
            string pwd_new = TextBox_pwd.Text;

            bool Success = blll_user.ChangePwd(userid, pwd_new);

            if (Success)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改密码成功')", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改密码失败')", true);
            }
        }

        protected void Button_clearall_Click(object sender, EventArgs e)
        {
            RCD_BLL.FileBLL bll_files = new RCD_BLL.FileBLL();
            UserInfo userinfo = (UserInfo)Session["UserInfo"];

            int result = bll_files.DeleteAllFiles(userinfo.id);

            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('有" +result+ "个文件被删除')", true);
        }
        /// <summary>
        /// 点击上传头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_upload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                if(fileExtension == ".png")
                {
                    UserInfo userinfo = (UserInfo)Session["UserInfo"];
                    string username = userinfo.name;

                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/ProfilePictures/") + username + ".png");
                    Response.Redirect(Request.Url.ToString());
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('格式不正确')", true);
                }
            }
            
        }
    }
}