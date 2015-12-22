namespace Microsoft.AspNet.Authentication.WeChat
{
    public class WeChatDefaults
    {
        public const string AuthenticationScheme = "WeChat";

        public static readonly string AuthorizationEndpoint = "https://open.weixin.qq.com/connect/qrconnect";

        public static readonly string TokenEndpoint = "https://api.weixin.qq.com/sns/oauth2/access_token";

        public static readonly string UserInformationEndpoint = "https://api.weixin.qq.com/sns/userinfo";
    }
}
