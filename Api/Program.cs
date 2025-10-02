using Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Implementations;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Services.Implementations;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = builder.Configuration["TokenAuthentication:Audience"],
            ValidIssuer = builder.Configuration["TokenAuthentication:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("TokenAuthentication:SigningKey")
                ?? throw new ArgumentException("SigningKey not found in configuration."))
            )
        };
    });

// Add services to the container.
builder.Services.AddDbContext<TokenizeDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("TokenizeDbConnectionString"),
        opt => opt.MigrationsAssembly("Api")
    )
);

builder.Services.AddTransient<IAccountRepo, AccountRepo>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IBookRepo, BookRepo>();
builder.Services.AddTransient<IBookService, BookService>();

builder.Services.AddTransient<IJwtTokenService, JwtTokenService>();

builder.Services.AddHttpContextAccessor();

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
