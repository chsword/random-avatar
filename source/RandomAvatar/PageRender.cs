namespace RandomAvatar;

internal class PageRender
{
    public static async Task Home(HttpContext context)
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