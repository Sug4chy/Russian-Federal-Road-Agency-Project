using RFRAP.Web;

Host.CreateDefaultBuilder()
    .ConfigureWebHostDefaults(builder =>
    {
        builder.UseStartup<Startup>()
            .UseConfiguration(new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build());
    })
    .Build()
    .Run();