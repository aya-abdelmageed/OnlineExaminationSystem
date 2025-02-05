/*using System;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BusinessLogic.Repositories;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;
using UI.AdminDashboard;

namespace Front
{
    internal static class Program
    {
        [DllImport("user32.dll")]
       private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
               SetProcessDPIAware();  // Forces DPI awareness

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Setup Dependency Injection
            var serviceProvider = ConfigureServices();

            // Resolve the main form from the DI container
            var form1 = serviceProvider.GetRequiredService<Form1>();

            // Run the application
            Application.Run(form1);
        }

        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();



            services.AddTransient<Form1>();

            // Build and return the service provider
            return services.BuildServiceProvider();
        }
    }
}
*/
// To make Login Default Page

 using System;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BusinessLogic.Repositories;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;
using UI.AdminDashboard;

namespace Front
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();  // Forces DPI awareness

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Setup Dependency Injection
            var serviceProvider = ConfigureServices();

            // Resolve the Login form from the DI container
            var loginForm = serviceProvider.GetRequiredService<Login>();

            // Run the application with Login as the default form
            Application.Run(loginForm);
        }

        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Register Login form
            services.AddTransient<Login>();

            // Build and return the service provider
            return services.BuildServiceProvider();
        }
    }
}
