using AutoMapper;
using OnlineExaminationSystem.Mapping;

namespace OnlineExaminationSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static IMapper Mapper { get; private set; }

        [STAThread]

        static void Main()

        {
            // Configure AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InstructorProfile>();
            });
            Mapper = config.CreateMapper();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(Mapper));
        }
    }
}