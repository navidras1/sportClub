#define sqlite
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SportClubFaratechno
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //OpenBrowser("http://localhost:5000/");
            //Directory.CreateDirectory(@"C:\Sqllite");
            //CreateHostBuilder(args).Build().Run();
#if sqlite
            CreateHostBuilder(args).Build().Start();
            //OpenBrowser("http://localhost:449/");
#else
            CreateHostBuilder(args).Build().Run();
#endif



        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
#if sqlite
                    webBuilder.UseUrls("http://*:449");
#endif
                    webBuilder.UseStartup<Startup>();
                    //OpenBrowser("http://localhost:5000/");
                   
                });

        public static void OpenBrowser(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
            else
            {
                // throw 
            }
        }


    }
}
