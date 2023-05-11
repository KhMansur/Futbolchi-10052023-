using Fulbolchi.Data.DbContexts;
using Futbolchi_10052023_.Extention;
using Futbolchi1.Services.IRepository;
using Futbolchi3.Services.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddDbcontexts(builder.Configuration);

builder.Services.AddSwaggerConfiguration();
builder.Services.AddConfigurationIdentity();
builder.Services.AddConfigurationJwt(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
