using Application.UseCases.Clientes;
using Application.UseCases.Dispositivos;
using Application.UseCases.Eventos;
using Application.UseCases.Dashboard;
using API.Middleware;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- Configuração dos Serviços ---
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Cliente
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<CreateClienteUseCase>();
builder.Services.AddScoped<UpdateClienteUseCase>();
builder.Services.AddScoped<DeleteClienteUseCase>();
builder.Services.AddScoped<GetClienteByIdUseCase>();
builder.Services.AddScoped<GetAllClientesUseCase>();

// Dispositivo
builder.Services.AddScoped<IDispositivoRepository, DispositivoRepository>();
builder.Services.AddScoped<CreateDispositivoUseCase>();
builder.Services.AddScoped<GetDispositivosByClienteUseCase>();

// Evento
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<CreateEventoUseCase>();
builder.Services.AddScoped<GetEventosUseCase>();

// Dashboard
builder.Services.AddScoped<GetDashboardUseCase>();

var app = builder.Build();

// --- Configuração do Pipeline HTTP ---
app.UseMiddleware<GlobalExceptionHandler>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

void ApplyMigrations(IApplicationBuilder webApp)
{
    using var scope = webApp.ApplicationServices.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        var retryCount = 10;
        while(retryCount > 0)
        {
            try
            {
                context.Database.Migrate();
                Console.WriteLine("Migrações aplicadas com sucesso.");
                break;
            }
            catch (Exception)
            {
                Console.WriteLine($"Não foi possível conectar ao banco de dados. Tentando novamente em 5s... Tentativas restantes: {retryCount-1}");
                retryCount--;
                Thread.Sleep(5000);
            }
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro ao aplicar as migrações.");
    }
}

ApplyMigrations(app);

app.Run();