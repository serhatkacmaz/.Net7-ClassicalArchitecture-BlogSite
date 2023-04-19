namespace BlogSite.Web.Middleware
{
    public class JwtTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var accessToken = context.Request.Cookies["X-Access-Token"];

            if (!string.IsNullOrEmpty(accessToken))
            {
                context.Request.Headers.Add("Authorization", $"Bearer {accessToken}");
            }

            await _next.Invoke(context);
        }
    }
}