using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REW_Cloud_Drive;

//要使用App_Code中的类，把类文件属性“生成操作“设置为”编译“；
namespace REW_Cloud_Drive.App_Code
{
    public class SessionAuthorization
    {
        public static void SessionAuthorizeRedirect()
        {
            UserInfo userinfo = (UserInfo)HttpContext.Current.Session["UserInfo"];
            if (!userinfo.GetIsLogin())
            {
                HttpContext.Current.Response.Redirect("~/Login.aspx");
            }
        }
        
    }
}