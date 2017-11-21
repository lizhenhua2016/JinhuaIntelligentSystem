using System;
using JinhuaIntelligentSystem.ServiceModel;
using ServiceStack;

namespace JinhuaIntelligentSystem.Route
{
    [Route("/UserLogin/Login", "Post", Summary = "用户登录")]
    [Api("用户登录")]
    public class RouteLogin : IReturn<Boolean>
    {
        [ApiMember(IsRequired = true, DataType = "string", Description = "用户名")]
        public string Username { get; set; }

        [ApiMember(IsRequired = true, DataType = "string", Description = "密码")]
        public string Password { get; set; }
    }

    [Route("/UserLogin/GetUserInfo", "Post", Summary = "根据用户名获取用户信息")]
    [Api("用户登录")]
    public class RouteGetUserInfo : IReturn<LoginReturn>
    {
        [ApiMember(IsRequired = true, DataType = "string", Description = "用户名")]
        public string Username { get; set; }
    }
}