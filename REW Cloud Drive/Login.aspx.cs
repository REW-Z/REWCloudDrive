using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace REW_Cloud_Drive
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 登录按钮OnClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_login_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = (UserInfo)Session["UserInfo"];
            userinfo.name = TextBox_name.Text;
            userinfo.pwd = TextBox_pwd.Text;
            bool Success = userinfo.TryLogin();
            if (Success)
            {
                Response.Redirect("~/ProtectedPages/Default.aspx");
            }
            else
            {
                Response.Write("登陆失败");
            }
        }
    }
}