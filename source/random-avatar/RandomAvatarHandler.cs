using Microsoft.AspNetCore.Http;
using System;
namespace RandomAvatar
{
    public class RandomAvatarHandler
    {
        
        public bool FixedSeed { get; set; }
        public string Seed { get; set; }

        internal async void ProcessRequest(HttpContext context)
        {
            var bytes = RandomAvatarBuilder.Build(100)
                .SetPadding(4)
                .FixedSeed(FixedSeed, Seed)
                .ToBytes();
            context.Response.ContentType = "image/png";
            await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);           
        }
    }
}