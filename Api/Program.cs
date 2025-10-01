using Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TokenizeDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("TokenizeDbConnectionString"),
        opt => opt.MigrationsAssembly("Api")
    )
);

builder.Services.AddTransient<IAccountRepo, AccountRepo>();
builder.Services.AddTransient<IBookRepo, BookRepo>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
