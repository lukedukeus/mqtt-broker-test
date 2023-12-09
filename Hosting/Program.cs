using MQTTnet.AspNetCore;

namespace MQTTtest.Hosting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(
                        o =>
                        {
                            o.ListenAnyIP(1883, l => l.UseMqtt()); // MQTT pipeline
                            o.ListenAnyIP(5000); // Default HTTP pipeline
                        });

                    webBuilder.UseStartup<Startup>();
                });
    }
}
