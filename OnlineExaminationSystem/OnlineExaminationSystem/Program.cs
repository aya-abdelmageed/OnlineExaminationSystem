using DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Windows.Forms;

using BusinessLogic.Repositories;
using UI;

internal static class Program
{
    public static IMapper Mapper { get; private set; }

    [STAThread]
    static void Main()
    {
        // Set up the DI container
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IConfiguration>(provider =>
            {
                var configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);  // Ensure it's required
                return configurationBuilder.Build();
            })
            .AddSingleton<DBManager>()  // DBManager registered as singleton
            .AddScoped<InstructorRepo>() // InstructorRepo registered as scoped
            .AddSingleton<Form1>() // Form1 registered as singleton
            .BuildServiceProvider();

        // Get IMapper instance from DI container

        // Initialize the application
        ApplicationConfiguration.Initialize();

        // Injecting InstructorRepo and other dependencies into Form1 via DI
        var form1 = serviceProvider.GetRequiredService<Form1>();

        // Run the form (Application entry point)
        Application.Run(form1);
    }
}