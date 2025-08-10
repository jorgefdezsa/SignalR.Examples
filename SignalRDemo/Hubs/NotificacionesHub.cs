using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo.Hubs
{
    public class NotificacionesHub : Hub
    {
        // Ejemplo para enviar un mensaje desde el cliente a todos
        public async Task EnviarMensaje(string usuario, string mensaje)
        {
            await Clients.All.SendAsync("RecibirMensaje", usuario, mensaje);
        }
    }
}