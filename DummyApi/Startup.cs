﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(DummyApi.Startup))]

namespace DummyApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    EnableJSONP = true
                };

                map.RunSignalR(hubConfiguration);
            });

            //app.UseCors(CorsOptions.AllowAll);
            //app.MapSignalR();
        }
    }
}
