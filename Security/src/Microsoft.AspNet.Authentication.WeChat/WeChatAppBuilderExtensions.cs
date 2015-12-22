using System;
using Microsoft.AspNet.Builder;

namespace Microsoft.AspNet.Authentication.WeChat
{
    public static class WeChatAppBuilderExtensions
    {
        public static IApplicationBuilder UseWeChatAuthentication(this IApplicationBuilder app, WeChatOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<WeChatMiddleware>(options);
        }

        public static IApplicationBuilder UseWeChatAuthentication(this IApplicationBuilder app, Action<WeChatOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new WeChatOptions();
            if (configureOptions != null)
            {
                configureOptions(options);
            }

            return app.UseWeChatAuthentication(options);
        }
    }
}
