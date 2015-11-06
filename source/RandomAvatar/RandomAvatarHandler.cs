using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Routing;

namespace RandomAvatar
{
    public class RandomAvatarHandler: IHttpHandler
    {


        public RequestContext RequestContext { get; set; }
        public void ProcessRequest(HttpContext context)
        {
            var image = new RandomAvatarBuilder(12).Build().generate();

            context.Response.BinaryWrite(ImageToBuffer(image, ImageFormat.Png));
            context.Response.ContentType = "image/png";
            context.Response.End();
        }
         public static byte[] ImageToBuffer(Image image, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            if (image == null) { return null; }
            byte[] data = null;
            using (MemoryStream oMemoryStream = new MemoryStream())
            {
                using (Bitmap oBitmap = new Bitmap(image))
                {
                    oBitmap.Save(oMemoryStream, imageFormat);
                    oMemoryStream.Position = 0;
                    data = new byte[oMemoryStream.Length];
                    oMemoryStream.Read(data, 0, Convert.ToInt32(oMemoryStream.Length));
                    oMemoryStream.Flush();
                }
            }
            return data;
        }
        public bool IsReusable { get; }
    }
}