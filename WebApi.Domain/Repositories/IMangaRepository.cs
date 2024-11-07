using WebApi.Domain.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Repositories;

public interface IMangaRepository
{
    Task CreateManga(MangaDTO dto);
    Task<IEnumerable<MangaEntity>> SelectManga();
    Task<MangaEntity?> SelectMangaById(int id);
    Task EditManga(MangaEntity dto);
    Task DeleteManga(MangaEntity manga);
}
