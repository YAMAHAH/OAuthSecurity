using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using Microsoft.Extensions.WebEncoders;

namespace Microsoft.AspNet.Authentication.WeChat
{
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Middleware are not disposable.")]
    public class WeChatMiddleware : OAuthMiddleware<WeChatOptions>
    {
        public WeChatMiddleware(
         RequestDelegate next,
         IDataProtectionProvider dataProtectionProvider,
         ILoggerFactory loggerFactory,
         UrlEncoder encoder,
         IOptions<SharedAuthenticationOptions> sharedOptions,
         WeChatOptions options)
            : base(next, dataProtectionProvider, loggerFactory, encoder, sharedOptions, options)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            if (dataProtectionProvider == null)
            {
                throw new ArgumentNullException(nameof(dataProtectionProvider));
            }

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            if (encoder == null)
            {
                throw new ArgumentNullException(nameof(encoder));
            }

            if (sharedOptions == null)
            {
                throw new ArgumentNullException(nameof(sharedOptions));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (string.IsNullOrWhiteSpace(this.Options.AppId))
                throw new ArgumentException(nameof(options.AppId));

            if (string.IsNullOrWhiteSpace(this.Options.AppSecret))
                throw new ArgumentException(nameof(options.AppSecret));

            if (Options.Scope.Count == 0)
            {
                this.Options.Scope.Add("snsapi_login");
                this.Options.Scope.Add("snsapi_userinfo");
            }
        }

        protected override AuthenticationHandler<WeChatOptions> CreateHandler()
        {
            return new WeChatHandler(Backchannel);
        }
    }
}
