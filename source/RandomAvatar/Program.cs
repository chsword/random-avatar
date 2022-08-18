using RandomAvatar;
using RandomAvatar.Renders;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AvatarRender>();
builder.Services.AddScoped<PageRender>();
builder.Services.AddSingleton<AvatarEnvironment>();
var app = builder.Build();
if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();
app.Run(async context =>
{
    if (!context.Request.Path.HasValue || context.Request.Path == "/")
    {
        var pageRender = context.RequestServices.GetService<PageRender>()!;
        await pageRender.HomeAsync();
        return;
    }
    try
    {
        if (context.Request.Path.Value.StartsWith("/avatar/"))
        {
            var avatarRender = context.RequestServices.GetService<AvatarRender>();
            avatarRender?.ProcessRequest(context);
            return;
        }

        if (context.Request.Path.Value.StartsWith("/face/"))
        {
            var avatarRender = context.RequestServices.GetService<AvatarRender>();
            //fixed seed
            avatarRender?.UseFixed().ProcessRequest(context);
        }
    }
    catch (Exception ex)
    {
        await context.Response.WriteAsync(ex.ToString());
    }
});
app.Run();