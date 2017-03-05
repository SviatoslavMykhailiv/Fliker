using Topshelf;

namespace SelfHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(configurator =>
            {
                configurator.Service<Host>(host =>
                {
                    host.ConstructUsing(() => new Host());
                    host.WhenStarted(h =>
                    {
                        h.Start();
                    });
                    host.WhenStopped(h =>
                    {
                        h.Stop();
                    });
                });

                configurator.SetDisplayName("Usefa Service");
                configurator.SetInstanceName("UsefaService");
            });
        }
    }
}
