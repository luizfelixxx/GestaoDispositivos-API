using Application.UseCases.Clientes;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração dos Serviços
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Injeção de Dependência - Apenas Cliente
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<CreateClienteUseCase>();
builder.Services.AddScoped<UpdateClienteUseCase>();
builder.Services.AddScoped<DeleteClienteUseCase>();
builder.Services.AddScoped<GetClienteByIdUseCase>();
builder.Services.AddScoped<GetAllClientesUseCase>();

var app = builder.Build();

// Configuração do Pipeline HTTP
app.UseHttpsRedirection();
app.MapControllers();
app.Run();