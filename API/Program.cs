using Microsoft.Extensions.DependencyInjection;
using Application.Extensions;
using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using Infrastructure.Data;
using Core.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddApiVersioning();
builder.Services.AddApplicationServices();
builder.Services.AddInfraServices(builder.Configuration);
//builder.Services.AddAutoMapper(typeof(Startup));
//builder.Services.AddScoped<BasketOrderingConsumer>();
//builder.Services.AddScoped<BasketOrderingConsumerV2>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "User.API", Version = "v1" });
});
builder.Services.Configure<AppSettingsHelper>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddHealthChecks().Services.AddDbContext<UsermanagementContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ordering.API v1"));
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
