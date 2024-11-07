using WebApi.Domain.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Services;

public interface IMangaService
{
    Task CreateManga(MangaDTO dto);
    Task<IEnumerable<MangaEntity>> SelectManga();
}
