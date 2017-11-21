using System.Collections.Generic;
using JinhuaIntelligentSystem.Logic;
using JinhuaIntelligentSystem.Route;
using JinhuaIntelligentSystem.ServiceModel;
using ServiceStack;

namespace JinhuaIntelligentSystem.ServiceInterface
{
    public class LoginService : Service
    {
        public ILogin _login { get; set; }

        public List<LoginReturn> Post(RouteLogin request)
        {
            return _login.UserLogin(request);
        }

        [Authenticate]
        public LoginReturn Post(RouteGetUserInfo request)
        {
            return _login.GetUserInfo(request);
        }
    }
}