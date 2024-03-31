using CadastroLivros.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static CadastroLivros.Core.API.DatabaseConfiguration.ProviderDatabase;
using static CadastroLivros.Core.API.DatabaseConfiguration.ProviderConfiguration;
using CadastroLivros.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureProviderForContext<CadastroLivrosContext>(DetectDatabase(builder.Configuration));

builder.Services.AddScoped<ILivroQuerie, LivroRepository>();
builder.Services.AddScoped<CadastroLivrosContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
