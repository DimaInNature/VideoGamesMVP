namespace VideoGames.Presentation.Configurations;

internal static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(setupAction: c =>
        {
            c.SwaggerDoc(name: "v1", info: new OpenApiInfo
            {
                Version = "Demo v1",
                Title = "VideoGames",
                Contact = new()
                {
                    Name = "DimaInNature",
                    Url = new(uriString: "https://github.com/DimaInNature")
                }
            });

            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            string xmlPath = Path.Combine(path1: AppContext.BaseDirectory, path2: xmlFile);

            c.IncludeXmlComments(filePath: xmlPath);
        });
    }

    public static void UseSwaggerSetup(this IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "VideoGames V1");
        });
    }
}