using System.Reflection;
using Azure;
using Jogos_API.Context;
using Jogos_API.Interface;
using Jogos_API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Configura��o do Azure Content Safety sem vari�veis de ambiente
//var endpoint = "https://moderatorservice.cognitiveservices.azure.com/";
//var apiKey = "6F59xOioGcV9aN1jnUL2LXe9eTGO32E5J8rNeSoZ235FMvzZ86F0JQQJ99BDACYeBjFXJ3w3AAAHACOGpfCS";
//var client = new ContentSafetyClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
//builder.Services.AddSingleton(client);

// Configura��o do Azure Content Safety com vari�veis de ambiente
var endpoint = builder.Configuration["AzureContentSafety:Endpoint"];
var apiKey = builder.Configuration["AzureContentSafety:ApiKey"];


if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(apiKey))
{
    throw new InvalidOperationException("Azure Content Safety: Endpoint ou API Key n�o foram configurados.");
}



builder.Services // Acessa a cole��o de servi�os da aplica��o (Dependency Injection)
    .AddControllers() // Adiciona suporte a controladores na API (MVC ou Web API)
    .AddJsonOptions(options => // Configura as op��es do serializador JSON padr�o (System.Text.Json)
    {
        // Configura��o para ignorar propriedades nulas ao serializar objetos em JSON
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

        // Configura��o para evitar refer�ncia circular ao serializar objetos que possuem relacionamentos recursivos
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<JogosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adiciona o reposit�rio e a interface ao container de injecao de depend�ncia
builder.Services.AddScoped<IJogosRepository, JogosRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();


//Adiciona o servi�o de Controllers
builder.Services.AddControllers();




//Adiciona Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de Eventos",
        Description = "Aplica��o para gerenciamento de eventos",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Carlos Roque",
            Url = new Uri("https://www.linkedin.com/in/roquecarlos/")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    //Configura o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //Usando a autentica�ao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


// Adiciona CORS
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



if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });

    app.UseSwagger(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        using Microsoft.AspNetCore.Builder;
    });
}

//Adiciona o Cors(pol�tica criada)
app.UseCors("CorsPolicy");

app.Run();
