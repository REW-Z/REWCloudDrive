using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace REW_Cloud_Drive.ProtectedPages
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            App_Code.SessionAuthorization.SessionAuthorizeRedirect();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)//验证控件里是否包含文件
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                FileUpload1.SaveAs(Server.MapPath("~/UploadFiles/") + FileUpload1.FileName);                //保存至服务器
                //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/UploadFiles/") + FileUpload1.FileName);   //实测这个也可以

                UserInfo userinfo = (UserInfo)Session["UserInfo"];
                Model.File file = new Model.File();
                file.UserID = userinfo.id;
                string filename = FileUpload1.PostedFile.FileName;
                file.FileName = filename.Substring(filename.LastIndexOf("\\") + 1);
                file.UploadTime = DateTime.Now.ToString();
                file.FileType = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();

                RCD_BLL.FileBLL bll_file = new RCD_BLL.FileBLL();
                bll_file.AddFileInfo(file);


                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + fileExtension + "类型文件已经上传')", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('没有文件')", true);
            }
        }
    }
}