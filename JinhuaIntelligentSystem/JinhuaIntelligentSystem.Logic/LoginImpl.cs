using System.Collections.Generic;
using JinhuaIntelligentSystem.Route;
using JinhuaIntelligentSystem.ServiceModel;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace JinhuaIntelligentSystem.Logic
{
    public class LoginImpl: ILogin
    {
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public IDbConnectionFactory DbFactory { get; set; }
        
        public List<LoginReturn> UserLogin(RouteLogin request)
        {
            using (var authService = HostContext.ResolveService<AuthenticateService>())
            {
                var response = authService.Authenticate(new Authenticate
                {
                    provider = CredentialsAuthProvider.Name,
                    UserName = request.Username,
                    Password = request.Password,
                    RememberMe = true,
                });
            }
            using (var db= DbFactory.Open())
            {
                var list = db.SqlList<LoginReturn>("exec UserLogin @username,@password",new {username= request.Username, password= request.Password});
                
                return list;
            }
        }

        public LoginReturn GetUserInfo(RouteGetUserInfo request)
        {
            return new LoginReturn(){Username = "abc",Adcd="3202"};
        }
    }
}