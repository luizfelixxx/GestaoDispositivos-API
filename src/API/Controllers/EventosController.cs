using Application.DTOs.Evento;
using Application.UseCases.Eventos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(EventoResponseDto), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] CreateEventoDto dto, [FromServices] CreateEventoUseCase useCase)
    {
        var evento = await useCase.ExecuteAsync(dto);
        if (evento == null)
        {
            return BadRequest(new { message = "Não foi possível registrar o evento. Verifique se o dispositivo existe." });
        }
        var response = new EventoResponseDto(evento.Id, evento.DispositivoId, evento.Tipo, evento.DataHora);
        return StatusCode(201, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<EventoResponseDto>), 200)]
    public async Task<IActionResult> Get(
        [FromQuery] DateTime? startDate, 
        [FromQuery] DateTime? endDate, 
        [FromQuery] Guid? dispositivoId,
        [FromServices] GetEventosUseCase useCase)
    {
        var eventos = await useCase.ExecuteAsync(startDate, endDate, dispositivoId);
        var response = eventos.Select(e => new EventoResponseDto(e.Id, e.DispositivoId, e.Tipo, e.DataHora));
        return Ok(response);
    }
}