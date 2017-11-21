using System.Collections.Generic;
using JinhuaIntelligentSystem.Route;
using JinhuaIntelligentSystem.ServiceModel;

namespace JinhuaIntelligentSystem.Logic
{
    public interface ILogin
    {
        List<LoginReturn> UserLogin(RouteLogin request);

        LoginReturn GetUserInfo(RouteGetUserInfo request);

    }
}