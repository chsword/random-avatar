using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RandomAvatar;

namespace random_avatar
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                if (!context.Request.Path.HasValue || context.Request.Path == "/")
                {
                    await RenderHome(context);
                    return;
                }
                else if(context.Request.Path.Value.StartsWith("/avatar/"))
                {
                    new RandomAvatarHandler() { }.ProcessRequest(context);
                    return;
                }
                else if (context.Request.Path.Value.StartsWith("/face/"))
                {
                    //fixed seed
                    new RandomAvatarHandler() {
                        FixedSeed = true,
                        Seed = context.Request.Path.Value.Substring(6)
                    }.ProcessRequest(context);
                    return;
                }
                await context.Response.WriteAsync("Hello World!");
            });
        }

        private static async Task RenderHome(HttpContext context)
        {
            await context.Response.WriteAsync(@"<!DOCTYPE html>
<html>
<head>
<meta http-equiv='Content-Type' content='text/html; charset=utf-8'/>
    <title></title>
	<meta charset='utf-8' />
</head>
<body>
<a href='https://github.com/random-avatar/random-avatar'>@random-avatar</a>
</body>
</html>
");
        }
    }
}
