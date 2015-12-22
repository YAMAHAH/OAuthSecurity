using Microsoft.AspNet.Authentication.OAuth;

namespace Microsoft.AspNet.Authentication.WeChat
{
    public class WeChatOptions : OAuthOptions
    {
        public WeChatOptions()
        {
            AuthenticationScheme = WeChatDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = "/signin-WeChat";
            AuthorizationEndpoint = WeChatDefaults.AuthorizationEndpoint;
            TokenEndpoint = WeChatDefaults.TokenEndpoint;
            UserInformationEndpoint = WeChatDefaults.UserInformationEndpoint;
        }

        public string AppId
        {
            get
            {
                return this.ClientId;
            }
            set
            {
                this.ClientId = value;
            }
        }

        public string AppSecret
        {
            get
            {
                return this.ClientSecret;
            }
            set
            {
                this.ClientSecret = value;
            }
        }
    }
}
