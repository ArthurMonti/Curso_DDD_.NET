using Api.CrossCutting.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
ConfigureService.ConfigureDependencyInjection(builder.Services);
ConfigureRepository.ConfigureDependencyInjection(builder.Services);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Curso de API",
        Description = "Arquitetura DDD",
        TermsOfService = new Uri("http://google.com"),
        Contact = new OpenApiContact
        {
            Name = "Arthur Monti",
            Email = "email@email.com",
            Url = new Uri("http://google.com")
        },
        License = new OpenApiLicense
        {
            Name = "Termo de Licença de Uso",
            Url = new Uri("http://google.com")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso de API");
        c.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
