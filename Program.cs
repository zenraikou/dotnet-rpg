global using Microsoft.EntityFrameworkCore;
global using dotnet_rpg.Models;
global using dotnet_rpg.Data;
global using dotnet_rpg.Dtos.CharacterDto;
global using dotnet_rpg.Services.CharacterService;
global using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RPGContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RPGConnection"));
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICharacterService, CharacterService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
