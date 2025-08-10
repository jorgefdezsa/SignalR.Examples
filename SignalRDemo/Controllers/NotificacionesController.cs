using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Hubs;

namespace SignalRDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionesController : ControllerBase
    {
        private readonly IHubContext<NotificacionesHub> _hub;

        public NotificacionesController(IHubContext<NotificacionesHub> hub)
        {
            _hub = hub;
        }

        [HttpPost("evento")]
        public async Task<IActionResult> LanzarEvento([FromBody] EventoDto dto)
        {
            // Envía evento a todos los clientes conectados
            await _hub.Clients.All.SendAsync("EventoRecibido", dto);
            return Ok(new { mensaje = "Evento enviado" });
        }
    }

    public record EventoDto(string Titulo, string Contenido);
}