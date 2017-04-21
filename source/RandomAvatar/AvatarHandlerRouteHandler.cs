using System.Web;
using System.Web.Routing;

namespace RandomAvatar
{
    public class AvatarHandlerRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var handler = new RandomAvatarHandler()
            {
                RequestContext = requestContext,
                FixedSeed = FixedSeed
            };
            if (FixedSeed)
            {
                var seed = (requestContext.RouteData.Values["seed"] ?? "").ToString();
                handler.Seed = seed;
            }
            return handler;
        }

        public bool FixedSeed { get; set; }
    }
}