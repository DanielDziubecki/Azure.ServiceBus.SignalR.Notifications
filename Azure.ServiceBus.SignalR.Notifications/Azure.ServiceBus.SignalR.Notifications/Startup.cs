using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Azure.ServiceBus.SignalR.Notifications.ServiceBus;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Azure.ServiceBus.SignalR.Notifications.Startup))]

namespace Azure.ServiceBus.SignalR.Notifications
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
           
            HttpConfiguration config = new HttpConfiguration();
            var globalConfig = GlobalConfiguration.Configuration;
            config.MapHttpAttributeRoutes();
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new SubscriptionService()).As<ISubscriptionService>().SingleInstance();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            globalConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration { };
                map.RunSignalR(hubConfiguration);
            });
            app.UseWebApi(globalConfig);
            
        }
    }
}
