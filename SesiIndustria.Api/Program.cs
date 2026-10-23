using Microsoft.EntityFrameworkCore;
using SesiIndustria.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do Banco de Dados SQLite (Open Source)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? "Data Source=sesi_cursos.db";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

// 2. Adicionar Controllers e Configuração JSON
builder.Services.AddControllers();

// 3. Configuração de CORS para permitir requisições locais e externas
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 4. Configuração do Swagger para documentação e testes da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "SESI Indústria - Catálogo de Cursos API",
        Version = "v1",
        Description = "API REST em C#/.NET 8 para consulta e filtragem de cursos do CTED - SESI/SENAI."
    });
});

var app = builder.Build();

// 5. Inicialização automática do Banco de Dados e Carga Inicial (Seed Data)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro ao inicializar o banco de dados.");
    }
}

// 6. Pipeline de Requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SESI Indústria API v1");
    c.RoutePrefix = "swagger";
});

app.UseCors("AllowAll");

// Habilitar servir arquivos estáticos do front-end (HTML, CSS, JS, Assets) na raiz
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

// Rota de fallback caso o usuário navegue diretamente
app.MapFallbackToFile("index.html");

app.Run();
