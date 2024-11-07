using WebApi.Domain.DTOs;
using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services;

namespace WebApi.Services.Services;

public class MangaService(IMangaRepository repository) : IMangaService
{
    private readonly IMangaRepository _repository = repository;

    public async Task CreateManga(MangaDTO dto)
    {
		try
		{
			await _repository.CreateManga(dto);
		}
		catch (Exception)
		{
			throw;
		}
    }

    public async Task<IEnumerable<MangaEntity>> SelectManga()
    {
		try
		{
			return await _repository.SelectManga();
		}
		catch (Exception)
		{
			throw;
		}
    }
}