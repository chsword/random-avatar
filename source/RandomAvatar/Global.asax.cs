using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace RandomAvatar
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new Route("avatar/{seed}", new AvatarHandlerRouteHandler()));
            RouteTable.Routes.Add(new Route("face/{seed}", new AvatarHandlerRouteHandler() {FixedSeed=true}));
        }
    }
}