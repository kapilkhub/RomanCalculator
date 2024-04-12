using FluentValidation;
using RomanCalculator.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddProblemDetails();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.RegisterRomanCalculatorEndpoints();


app.Run();


