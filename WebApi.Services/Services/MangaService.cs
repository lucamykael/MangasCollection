using AutoMapper;
using WebApi.Domain.DTOs;
using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services;

namespace WebApi.Services.Services;

public class MangaService(IMangaRepository repository) : IMangaService
{
    private readonly IMangaRepository _repository = repository;

    public async Task Create(MangaDTO dto)
    {
        await _repository.CreateManga(dto);
    }

    public async Task<T> DirectSelect<T>(int? id)
    {
        if (id == null)
        {
            return (T)(object)await SelectAll();
        }
        else
        {
            var result = await SelectById(id.Value);

            return result != null ? (T)(object)result : default!;
        }
    }

    public async Task Edit(MangaEntity dto)
    {
        var manga = await _repository.SelectMangaById(dto.Id);

        if (manga == null)
            throw new Exception($"Manga with ID:{dto.Id} not found");

        manga.Name = dto.Name;
        manga.Description = dto.Description;
        manga.Stars = dto.Stars;

        await _repository.EditManga(manga);
    }

    public async Task Delete(int id)
    {
        var manga = await _repository.SelectMangaById(id);

        if (manga == null)
            throw new Exception($"Manga with ID:{id} not found");

        await _repository.DeleteManga(manga);
    }

    private async Task<IEnumerable<MangaEntity>> SelectAll()
    {
        return await _repository.SelectManga();
    }

    private async Task<MangaEntity?> SelectById(int id)
    {
        return await _repository.SelectMangaById(id);
    }
}