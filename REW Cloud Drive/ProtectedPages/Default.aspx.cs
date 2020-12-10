using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace REW_Cloud_Drive
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            App_Code.SessionAuthorization.SessionAuthorizeRedirect();
        }
        /// <summary>
        /// OnclickMyFiles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton_MyFiles_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/ProtectedPages/MyFiles.aspx");
        }

        protected void ImageButton_Upload_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/ProtectedPages/Upload.aspx");
        }

        protected void ImageButton_Account_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/ProtectedPages/Account.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/ProtectedPages/Share.aspx");
        }
    }
}