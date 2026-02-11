var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); //Add endpoints to Swagger data
builder.Services.AddSwaggerGen(); // Generate Swagger UI from data

    builder.Services.AddCors((options) =>
        {
            options.AddPolicy("DevCors", (corsBuilder) =>
                {
                    corsBuilder.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:8000")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            options.AddPolicy("ProdCors", (corsBuilder) =>
                {
                    corsBuilder.WithOrigins("https://myProductionSite.com")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
        });
     
    var app = builder.Build();
     
    if (app.Environment.IsDevelopment())
    {
        app.UseCors("DevCors");
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseCors("ProdCors");
        app.UseHttpsRedirection();
    }

app.MapControllers();

app.Run();
