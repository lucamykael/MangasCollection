using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.DTOs;
using WebApi.Domain.Services;

namespace WebApi.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MangaController(IMangaService service) : ControllerBase
{
    private readonly IMangaService _service = service;
    
    [HttpPost]
    public async Task<ActionResult> Post(MangaDTO dto)
    {
        try
        {
            await _service.CreateManga(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        try
        {
            return Ok(await _service.SelectManga());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
