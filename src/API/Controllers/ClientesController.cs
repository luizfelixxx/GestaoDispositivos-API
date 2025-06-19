namespace DefaultNamespace;

using Application.DTOs.Cliente;
using Application.UseCases.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ClienteResponseDto>), 200)]
    public async Task<IActionResult> GetAll([FromServices] GetAllClientesUseCase useCase)
    {
        var clientes = await useCase.ExecuteAsync();
        var response = clientes.Select(c => new ClienteResponseDto(c.Id, c.Nome, c.Email, c.Telefone, c.Status));
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ClienteResponseDto), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(Guid id, [FromServices] GetClienteByIdUseCase useCase)
    {
        var cliente = await useCase.ExecuteAsync(id);
        if (cliente == null) return NotFound();
        
        var response = new ClienteResponseDto(cliente.Id, cliente.Nome, cliente.Email, cliente.Telefone, cliente.Status);
        return Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ClienteResponseDto), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] CreateClienteDto dto, [FromServices] CreateClienteUseCase useCase)
    {
        try
        {
            var cliente = await useCase.ExecuteAsync(dto);
            var response = new ClienteResponseDto(cliente.Id, cliente.Nome, cliente.Email, cliente.Telefone, cliente.Status);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ClienteResponseDto), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateClienteDto dto, [FromServices] UpdateClienteUseCase useCase)
    {
        try
        {
            var cliente = await useCase.ExecuteAsync(id, dto);
            if (cliente == null) return NotFound();
            
            var response = new ClienteResponseDto(cliente.Id, cliente.Nome, cliente.Email, cliente.Telefone, cliente.Status);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(Guid id, [FromServices] DeleteClienteUseCase useCase)
    {
        var success = await useCase.ExecuteAsync(id);
        return success ? NoContent() : NotFound();
    }
}