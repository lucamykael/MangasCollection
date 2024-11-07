using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.DTOs;
using WebApi.Domain.Entities;
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
            await _service.Create(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] int? id)
    {
        try
        {
            return Ok(await _service.DirectSelect<object>(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] MangaEntity dto)
    {
        try
        {
            await _service.Edit(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] int id)
    {
        try
        {
            await _service.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
