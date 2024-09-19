using Microsoft.EntityFrameworkCore;
using ProEventos.Application;
using ProEventos.Application.Contratos;
using ProEventos.Persistence;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);


    builder.Services.AddScoped<IEventosServices, EventoService>();
    builder.Services.AddScoped<IGeralPersist, GeralPersist>();
    builder.Services.AddScoped<IEventoPersist, EventosPersist>();
    builder.Services.AddControllers()
        .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );
    builder.Services.AddCors();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddEntityFrameworkSqlServer()
      .AddDbContext<ProEventosContext>(options =>
                                       options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

    var app = builder.Build();

    app.UseDefaultFiles();
    app.UseStaticFiles();

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

