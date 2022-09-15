using Battleship.API.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BattleshipDbContext>(options =>
    options.UseInMemoryDatabase("BattleshipGameDb"));
builder.Services.AddScoped<IBattleshipDbContext>(provider =>
    provider.GetRequiredService<BattleshipDbContext>());

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<IBattleshipDbContext>();

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

app.MapControllers();

app.Run();

