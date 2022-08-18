namespace RandomAvatar.Renders;
public class AvatarRender
{
    private readonly IHttpContextAccessor _accessor;
    private readonly AvatarEnvironment _environment;

    public AvatarRender(IHttpContextAccessor accessor, AvatarEnvironment environment)
    {
        _accessor = accessor;
        _environment = environment;
    } 
    string? Seed { get; set; }

    public AvatarRender UseFixed()
    {
        Seed = $"{_accessor.HttpContext?.Request.Path.Value}Random"[6..];
        return this;
    }

    internal async void ProcessRequest(HttpContext context)
    {
        var setting = RandomAvatarBuilder.Build(_environment.Size, _environment.IsSymmetry, Seed)
            .SetPadding(_environment.Padding);
        var bytes = setting.ToBytes();
        context.Response.ContentType = "image/png";
        await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
    }
}