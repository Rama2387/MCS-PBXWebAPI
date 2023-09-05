using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

public class Program
{
    public static void Main(string[] args)
    {      
        
        var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

        //IMPLEMENTING SERILOG---START
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("System", LogEventLevel.Warning)
            .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug || e.Level == LogEventLevel.Information)
                    .WriteTo.File(".\\Log\\infoLog-log", LogEventLevel.Information, "(Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level :u3}] {Message :lj}{NewLine}{Exception}", null, 99999999, null, false, true, null, RollingInterval.Day, true, 90))
            .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning || e.Level == LogEventLevel.Error || e.Level == LogEventLevel.Fatal)
                    .WriteTo.File(".\\Log\\infoLog-log", LogEventLevel.Information, "(Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level :u3}] {Message :lj}{NewLine}{Exception}", null, 99999999, null, false, true, null, RollingInterval.Day, true, 90))
            .CreateLogger();

        //IMPLEMENTING SERILOG---END
       

        try
        {
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception)
        {
            throw;
        }       
    }

    private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .UseSerilog()
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
      
}
