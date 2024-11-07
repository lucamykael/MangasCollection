using WebApi.Domain.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Services;

public interface IMangaService
{
    Task Create(MangaDTO dto);
    Task<T> DirectSelect<T>(int? id);
    Task Edit(MangaEntity dto);
    Task Delete(int id);
}
