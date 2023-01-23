using RESTful.Data;
using RESTful.Extensions;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSqlInMemory();
builder.Services.AddHobbyService();

builder.Services.AddControllers()
    .AddJsonOptions(ops =>
    {
        ops.JsonSerializerOptions.IgnoreNullValues = true;
        ops.JsonSerializerOptions.WriteIndented = true;
        ops.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        ops.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        ops.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

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
