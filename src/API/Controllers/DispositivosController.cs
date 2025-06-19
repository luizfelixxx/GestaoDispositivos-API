using Application.DTOs.Dispositivo;
using Application.UseCases.Dispositivos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/clientes/{clienteId:guid}/dispositivos")]
public class DispositivosController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DispositivoResponseDto>), 200)]
    public async Task<IActionResult> GetByClienteId(Guid clienteId, [FromServices] GetDispositivosByClienteUseCase useCase)
    {
        var dispositivos = await useCase.ExecuteAsync(clienteId);
        var response = dispositivos.Select(d => new DispositivoResponseDto(d.Id, d.Serial, d.IMEI, d.DataAtivacao, d.ClienteId));
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(DispositivoResponseDto), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create(Guid clienteId, [FromBody] CreateDispositivoDto dto, [FromServices] CreateDispositivoUseCase useCase)
    {
        var dispositivo = await useCase.ExecuteAsync(clienteId, dto);
        if (dispositivo == null)
        {
            return BadRequest(new { message = "Não foi possível criar o dispositivo. Verifique se o cliente existe e está ativo." });
        }
        var response = new DispositivoResponseDto(dispositivo.Id, dispositivo.Serial, dispositivo.IMEI, dispositivo.DataAtivacao, dispositivo.ClienteId);
        
        return StatusCode(201, response);
    }
}