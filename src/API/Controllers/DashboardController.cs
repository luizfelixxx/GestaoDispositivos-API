using Application.DTOs.Dashboard;
using Application.UseCases.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(DashboardResponseDto), 200)]
    public async Task<IActionResult> GetDashboard([FromServices] GetDashboardUseCase useCase)
    {
        var contagemEventos = await useCase.ExecuteAsync();
        var response = new DashboardResponseDto(contagemEventos);
        return Ok(response);
    }
}