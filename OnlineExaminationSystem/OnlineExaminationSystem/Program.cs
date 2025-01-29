using DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Windows.Forms;
using BusinessLogic.Repositories;
using UI;
using UI.AdminDashboard;
using BusinessLogi.Repositories;

internal static class Program
{
    public static IMapper Mapper { get; private set; }

    [STAThread]
    static void Main()
    {
        // Set up Dependency Injection (DI) container
        var serviceProvider = ConfigureServices();

        // Initialize the application
        ApplicationConfiguration.Initialize();

        // Run the application using a custom ApplicationContext
        var context = new MyApplicationContext(serviceProvider);
        Application.Run(context);
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Load configuration from appsettings.json
        services.AddSingleton<IConfiguration>(provider =>
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            return configurationBuilder.Build();
        });

        // Register application services
        services.AddSingleton<DBManager>();   // Database manager as singleton
        services.AddScoped<InstructorRepo>();
        services.AddScoped<ExamRepo>();
        // Repository for instructors

        // Register forms with Dependency Injection
        services.AddTransient<Form1>(provider => new Form1(provider));
        services.AddTransient<Form1>();
        services.AddTransient<Branches>();
        services.AddTransient<Reports>();
        services.AddTransient<Courses>();
        services.AddTransient<Tracks>();
        services.AddTransient<Dashboard>();

        return services.BuildServiceProvider();
    }
}

/// <summary>
/// Custom Application Context to manage form lifetime.
/// </summary>
public class MyApplicationContext : ApplicationContext
{
    private readonly IServiceProvider _serviceProvider;

    public MyApplicationContext(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        // Start with the main form (Form1)
        ShowForm<Form1>();
    }

    /// <summary>
    /// Generic method to show forms and handle their lifecycle.
    /// </summary>
    public void ShowForm<TForm>() where TForm : Form
    {
        var form = _serviceProvider.GetRequiredService<TForm>();
        form.FormClosed += OnFormClosed;
        form.Show();
    }

    private void OnFormClosed(object sender, FormClosedEventArgs e)
    {
        // Close application only if all forms are closed
        if (Application.OpenForms.Count == 0)
        {
            ExitThread();
        }
    }
}
