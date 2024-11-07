using AutoMapper;
using WebApi.Domain.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Mapper;

public class MangaProfile : Profile
{
    public MangaProfile()
    {
        CreateMap<MangaDTO, MangaEntity>();
    }
}
