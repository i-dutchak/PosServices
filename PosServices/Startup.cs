using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(PosServices.Startup))]

namespace PosServices
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new AuthorizeAttribute());
            config.MessageHandlers.Add(new CustomCertificateMessageHandler());

            app.UseWebApi(config);
        }
    }
}
