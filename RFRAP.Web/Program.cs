using RFRAP.Web;

Host.CreateDefaultBuilder()
    .ConfigureWebHostDefaults(builder =>
    {
        builder.UseStartup<Startup>()
            .UseConfiguration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build());
    })
    .Build()
    .Run();