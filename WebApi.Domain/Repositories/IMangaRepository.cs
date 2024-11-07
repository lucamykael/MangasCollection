using WebApi.Domain.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Repositories;

public interface IMangaRepository
{
    Task CreateManga(MangaDTO dto);
    Task<IEnumerable<MangaEntity>> SelectManga();
}
