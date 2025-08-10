using SignalRDemo.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", b =>
    {
          b.WithOrigins("http://localhost:5135")
         .AllowAnyHeader()
         .AllowAnyMethod()
         .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("AllowFrontend");

app.MapControllers();
app.MapHub<NotificacionesHub>("/hub/notificaciones");

app.Run();