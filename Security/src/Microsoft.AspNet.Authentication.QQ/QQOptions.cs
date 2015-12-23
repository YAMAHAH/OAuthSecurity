using Microsoft.AspNet.Authentication.OAuth;

namespace Microsoft.AspNet.Authentication.QQ
{
    public class QQOptions : OAuthOptions
    {
        public QQOptions()
        {
            AuthenticationScheme = QQDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = "/signin-qq"; // implicit
            AuthorizationEndpoint = QQDefaults.AuthorizationEndpoint;
            TokenEndpoint = QQDefaults.TokenEndpoint;
            UserInformationEndpoint = QQDefaults.UserInformationEndpoint;
            OpenIdEndpoint = QQDefaults.OpenIdEndpoint;
        }

        public string OpenIdEndpoint { get; }

        public string AppId
        {
            get { return ClientId; }
            set { ClientId = value; }
        }

        public string AppKey
        {
            get { return ClientSecret; }
            set { ClientSecret = value; }
        }

        public bool IsMobile { get; set; }
    }
}
