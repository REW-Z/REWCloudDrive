using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace REW_Cloud_Drive
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_signup_Click(object sender, EventArgs e)
        {
            RCD_BLL.UserBLL bll = new RCD_BLL.UserBLL();
            bool IsSuccess = bll.SignupUser(TextBox_Name.Text, TextBox_Pwd.Text, "Normal");
            if (IsSuccess)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('注册失败')", true);
                TextBox_Pwd.Text = "";
            }

        }
        /// <summary>
        /// 取消注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}