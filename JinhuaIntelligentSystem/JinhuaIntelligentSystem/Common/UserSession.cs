using System.Runtime.Serialization;
using ServiceStack;

namespace JinhuaIntelligentSystem.Common
{
    public class UserSession: AuthUserSession
    {
        [DataMember]
        public string LoginName { get; set; }

        [DataMember]
        public string UserId { get; set; }
    }
}