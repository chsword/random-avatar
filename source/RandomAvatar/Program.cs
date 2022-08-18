using RandomAvatar;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();
var app = builder.Build();
if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();
app.Run(async context =>
{
    if (!context.Request.Path.HasValue || context.Request.Path == "/")
    {
        await PageRender.Home(context);
        return;
    }

    if (context.Request.Path.Value.StartsWith("/avatar/"))
    {
        try
        {
            new RandomAvatarHandler().ProcessRequest(context);
        }
        catch (Exception ex)
        {
            await context.Response.WriteAsync(ex.ToString());
        }

        return;
    }

    if (context.Request.Path.Value.StartsWith("/face/"))
    {
        try
        {
            //fixed seed
            new RandomAvatarHandler
            {
                FixedSeed = true,
                Seed = context.Request.Path.Value.Substring(6)
            }.ProcessRequest(context);
        }
        catch (Exception ex)
        {
            await context.Response.WriteAsync(ex.ToString());
        }

        return;
    }

    await context.Response.WriteAsync("Hello World!");
});
app.Run();