using DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Windows.Forms;
using BusinessLogic.Repositories;
using UI;
using UI.AdminDashboard;

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
            .AddTransient<Form1>() // Form1 registered as transient
            .AddTransient<Branches>() // Branches registered as transient
            .AddTransient<Reports>()
            .AddTransient<Courses>()
            .AddTransient<Tracks>()
            .AddTransient<Dashboard>()
            .BuildServiceProvider();

        // Initialize the application
        ApplicationConfiguration.Initialize();

        // Create a custom ApplicationContext to manage form lifetime
        var context = new MyApplicationContext(serviceProvider);
        Application.Run(context);
    }
}

public class MyApplicationContext : ApplicationContext
{
    private readonly IServiceProvider _serviceProvider;

    public MyApplicationContext(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        // Start with Form1
        ShowForm<Form1>();
    }

    public void ShowForm<TForm>() where TForm : Form
    {
        var form = _serviceProvider.GetRequiredService<TForm>();
        form.FormClosed += OnFormClosed; // Handle form closing
        form.Show();
    }

    private void OnFormClosed(object sender, FormClosedEventArgs e)
    {
        // When a form is closed, check if there are any other open forms
        if (Application.OpenForms.Count == 0)
        {
            ExitThread(); // Exit the application only if no forms are open
        }
    }
}