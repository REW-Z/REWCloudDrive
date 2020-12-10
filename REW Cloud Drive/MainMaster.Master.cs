using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace REW_Cloud_Drive
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Image_profile.Visible = false;
        }
        protected void Page_PreRender(object sender,EventArgs e)
        {
            UserInfo userinfo = (UserInfo)Session["UserInfo"];
            if (userinfo.GetIsLogin())
            {
                Label_UserInfo.Text = userinfo.name;
                Image_profile.Visible = true;
                if(System.IO.File.Exists(Server.MapPath("~/ProfilePictures/") + ((UserInfo)Session["UserInfo"]).name + ".png"))
                {
                    Image_profile.ImageUrl = "/ProfilePictures/" + ((UserInfo)Session["UserInfo"]).name + ".png";
                }
                else
                {
                    Image_profile.ImageUrl = "/ProfilePictures/DefaultPic.png";
                }
                
                LinkButton_logout.Click += new System.EventHandler(this.LinkButton_logout_Click);
                LinkButton_logout.Text = "注销";
            }
            else
            {
                Label_UserInfo.Text = "请先登录。" + userinfo.name;
                LinkButton_logout.Click += new System.EventHandler(this.LinkButton_tologin_Click);
                LinkButton_logout.Text = "登录";
            }
        }
        /// <summary>
        /// 登出方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton_logout_Click(object sender, EventArgs e)
        {
            UserInfo userinfo = (UserInfo)Session["UserInfo"];
            userinfo.Logout();
            Response.Redirect("~/Login.aspx");

        }
        protected void LinkButton_tologin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}