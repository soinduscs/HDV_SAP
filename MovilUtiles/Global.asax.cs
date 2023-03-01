using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace MovilUtiles
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e)
        {
            Session["glb_tipo_usuario"] = "";
            Session["glb_Referencia1"] = "";
            Session["glb_Referencia2"] = "";

            Session["glb_User_id"] = "";
            Session["glb_User_Code"] = "";
            Session["glb_User_Name"] = "";
            Session["glb_User_Psw"] = "";
            Session["glb_tipo_usuario"] = "";

            Session["accesoMenuPrincipal"] = "";
            

        }


    }
}