using Microsoft.EntityFrameworkCore;
using ProEventos.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
  .AddDbContext<DataContext>(
      options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin());

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();