using System.Web;
using System.Web.Routing;

namespace RandomAvatar
{
    public class RandomAvatarHandler : IHttpHandler
    {
        public RequestContext RequestContext { get; set; }

        public void ProcessRequest(HttpContext context)
        {
            var bytes = RandomAvatarBuilder.Build(100).SetPadding(4).FixedSeed(FixedSeed, Seed).ToBytes();
            context.Response.BinaryWrite(bytes);
            context.Response.ContentType = "image/png";
            context.Response.End();
        }

        public bool IsReusable { get; set; }
        public bool FixedSeed { get; set; }
        public string Seed { get; set; }
    }
}