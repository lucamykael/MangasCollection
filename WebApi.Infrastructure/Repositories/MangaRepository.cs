using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.DTOs;
using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;
using WebApi.Infrastructure.Data;

namespace WebApi.Infrastructure.Repositories;

public class MangaRepository(AppDbContext db, IMapper mapper) : IMangaRepository
{
    private readonly AppDbContext _db = db;
    private readonly IMapper _mapper = mapper;

    public async Task CreateManga(MangaDTO dto)
    {
        var manga = _mapper.Map<MangaEntity>(dto);

        _db.Mangas.Add(manga);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<MangaEntity>> SelectManga()
    {
        return await _db.Mangas.Select(m => m).ToListAsync();
    }
}
