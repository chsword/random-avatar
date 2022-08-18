namespace RandomAvatar.Renders;

internal class PageRender
{
    private readonly IHttpContextAccessor _accessor;
    private readonly AvatarEnvironment _environment;

    public PageRender(IHttpContextAccessor accessor, AvatarEnvironment environment)
    {
        _accessor = accessor;
        _environment = environment;
    }

    public async Task HomeAsync()
    {
        
        if (_environment.IsHome)
            await _accessor.HttpContext?.Response?.WriteAsync(@"<!DOCTYPE html>
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