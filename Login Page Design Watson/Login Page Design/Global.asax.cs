﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Login_Page_Design
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHttpRoute(
                name: "MyAPI",
                routeTemplate: "api/{controller}/{id}",
                defaults: new
                {
                    id = System.Web.Http.RouteParameter.Optional
                }
            );
        }
    }
}