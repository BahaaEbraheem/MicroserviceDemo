using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace CurrencyManagment;

public class Program
{
    public static int Main(string[] args)
    {



        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.WithProperty("Application", "CurrencyManagment.HttpApi.Host")
            .Enrich.FromLogContext()
            .WriteTo.File("Logs/logs.txt")
            .WriteTo.Elasticsearch(
                new ElasticsearchSinkOptions(new Uri(configuration["ElasticSearch:Url"]))
                {
                    AutoRegisterTemplate = true,
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                    IndexFormat = "msdemo-log-{0:yyyy.MM}"
                })
            .CreateLogger();

        try
        {
            Log.Information("Starting CurrencyManagment.HttpApi.Host");
            CreateHostBuilder(args).Build().Run();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "CurrencyManagment.HttpApi.Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    internal static IHostBuilder CreateHostBuilder(string[] args) =>
        Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .UseAutofac()
            .UseSerilog();
}






//        Log.Logger = new LoggerConfiguration()
//#if DEBUG
//            .MinimumLevel.Debug()
//#else
//            .MinimumLevel.Information()
//#endif
//            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
//            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
//            .Enrich.FromLogContext()
//            .WriteTo.Async(c => c.File("Logs/logs.txt"))
//            .WriteTo.Async(c => c.Console())
//            .CreateLogger();

//        try
//        {
//            Log.Information("Starting web host.");
//            var builder = WebApplication.CreateBuilder(args);
//            builder.Host.AddAppSettingsSecretsJson()
//                .UseAutofac()
//                .UseSerilog();
//            await builder.AddApplicationAsync<CurrencyManagmentHttpApiHostModule>();
//            var app = builder.Build();
//            await app.InitializeApplicationAsync();
//            await app.RunAsync();
//            return 0;
//        }
//        catch (Exception ex)
//        {
//            Log.Fatal(ex, "Host terminated unexpectedly!");
//            return 1;
//        }
//        finally
//        {
//            Log.CloseAndFlush();
//        }
//    }
//}
