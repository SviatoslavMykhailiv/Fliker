using System;
using Microsoft.Owin.Hosting;

namespace SelfHost
{
    public class Host
    {
        private IDisposable _host;
        private readonly StartOptions _options;

        public Host()
        {
            _options = new StartOptions();
            _options.Urls.Add("http://localhost:5001");
            _options.Urls.Add("http://192.168.1.20:5001");
        }
        public void Start()
        {
            _host = WebApp.Start<Startup>(_options);
        }

        public void Stop()
        {
            _host?.Dispose();
        }
    }
}
