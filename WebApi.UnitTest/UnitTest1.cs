using Moq;
using WebApi.Domain.DTOs;
using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;
using WebApi.Services.Services;
using Xunit;

namespace WebApi.UnitTest;

public class MangaService_IsMangaShould
{
    private readonly Mock<IMangaRepository> _mangaRepositoryMock;

    public MangaService_IsMangaShould()
    {
        _mangaRepositoryMock = new Mock<IMangaRepository>();
    }

    [Fact]
    public async Task IsManga_InputIsEmpty_ReturnException()
    {
        var service = new MangaService(_mangaRepositoryMock.Object);
        var mangaEmpty = new MangaDTO();

        await Assert.ThrowsAsync<ArgumentException>(() => service.Create(mangaEmpty));
    }

    [Fact]
    public async Task IsManga_InputIsCorrect_ReturnSuccess()
    {
        var service = new MangaService(_mangaRepositoryMock.Object);

        var manga = new MangaDTO
        {
            Name = "Test",
            Description = "Test",
            Stars = 1
        };

        await service.Create(manga);

        _mangaRepositoryMock.Verify(repository => repository.CreateManga(It.Is<MangaDTO>(m =>
                                        m.Name == manga.Name &&
                                        m.Description == manga.Description &&
                                        m.Stars == manga.Stars)), Times.Once);
    }
}