using System.Web;
using System.Web.Routing;

namespace RandomAvatar
{
    public class MyHandlerRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new RandomAvatarHandler() { RequestContext = requestContext };
        }
    }
}