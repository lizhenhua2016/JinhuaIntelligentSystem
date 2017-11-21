using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Funq;
using ServiceStack;
using ServiceStack.Razor;
using JinhuaIntelligentSystem.ServiceInterface;
using ServiceStack.Api.Swagger;
using ServiceStack.Logging;
using ServiceStack.Logging.Log4Net;
using ServiceStack.Caching;
using ServiceStack.Auth;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Configuration;
using Microsoft.SqlServer.Types;
using JinhuaIntelligentSystem.Common;
using JinhuaIntelligentSystem.Logic;

namespace JinhuaIntelligentSystem
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("JinhuaIntelligentSystem", typeof(MyServices).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());
            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
               new IAuthProvider[] {
                    new CustomCredentialsAuthProvider(), //HTML Form post of UserName/Password credentials
               }));
            Plugins.Add(new RegistrationFeature());
            this.Plugins.Add(new SwaggerFeature());
            LogManager.LogFactory = new Log4NetFactory(configureLog4Net: true);
            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;

            SqlServerDialect.Provider.RegisterConverter<SqlGeometry>(new SqlGeometryConverter());
            var connectionString = ConfigurationManager.ConnectionStrings["GrassrootsFloodCtrl"].ConnectionString;
            var connFactory = new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider);
            container.Register<IDbConnectionFactory>(c => connFactory);

            container.Register<ICacheClient>(new MemoryCacheClient());
            container.Register<ISessionFactory>(c => new SessionFactory(c.Resolve<ICacheClient>()));
            container.Register<IUserAuthRepository>(new OrmLiteAuthRepository(connFactory)
            {
                UseDistinctRoleTables = true
            });

            this.Plugins.Add(new RazorFormat());
            
            container.RegisterAs<LoginImpl, ILogin>();
            
        }
    }
}