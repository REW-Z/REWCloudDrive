using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace REW_Cloud_Drive
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }
        void Session_Start(object sender, EventArgs e)
        {
            UserInfo userinfo = new UserInfo();
            Session["UserInfo"] = userinfo;
        }
    }
}