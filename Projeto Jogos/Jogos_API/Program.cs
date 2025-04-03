using Jogos_API.Context;
using Jogos_API.Interface;
using Jogos_API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services // Acessa a coleção de serviços da aplicação (Dependency Injection)
    .AddControllers() // Adiciona suporte a controladores na API (MVC ou Web API)
    .AddJsonOptions(options => // Configura as opções do serializador JSON padrão (System.Text.Json)
    {
        // Configuração para ignorar propriedades nulas ao serializar objetos em JSON
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

        // Configuração para evitar referência circular ao serializar objetos que possuem relacionamentos recursivos
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<JogosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar o  e a interface ao container de injeção de dependência
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IJogosRepository, JogosRepository>();

//Adicionar o serviço de Controllers
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de Games",
        Description = "Aplicaçao para gerenciamento de Games",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Clara Crastechini",
            Url = new Uri("https://github.com/Clara-Crastechini")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});


var app = builder.Build();
app.Run();