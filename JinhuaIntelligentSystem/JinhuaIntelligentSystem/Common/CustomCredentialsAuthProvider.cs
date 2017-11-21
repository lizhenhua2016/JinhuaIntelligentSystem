using System;
using System.Collections.Generic;
using JinhuaIntelligentSystem.Route;
using JinhuaIntelligentSystem.ServiceInterface;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Web;

namespace JinhuaIntelligentSystem.Common
{
    public class CustomCredentialsAuthProvider: CredentialsAuthProvider
    {
        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
        {
            var service = HostContext.Resolve<LoginService>();
            //return service.Post(new RouteLogin() { RouteLogin().Username = userName});
            return true;
        }

        public override IHttpResult OnAuthenticated(IServiceBase authService, IAuthSession session, IAuthTokens tokens,
            Dictionary<string, string> authInfo)
        {
            var service = HostContext.Resolve<LoginService>();
            if (service != null)
            {
                var user = service.Post(new RouteGetUserInfo() {Username = session.UserAuthName});
                var model = (UserSession) session;
                model.UserId = user.Id.ToString();
                model.LoginName = user.Username;
                model.UserName = user.UserRealName;
            }
            authService.SaveSession(session, new TimeSpan(0, 0, 50));
            return null;
        }

        public override bool IsAuthorized(IAuthSession session, IAuthTokens tokens, Authenticate request = null)
        {
            return !string.IsNullOrEmpty(session.UserName);
        }
    }
}