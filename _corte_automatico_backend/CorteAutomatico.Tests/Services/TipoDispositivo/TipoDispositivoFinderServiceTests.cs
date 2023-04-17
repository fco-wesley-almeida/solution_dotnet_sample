using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;
using CorteAutomatico.Core.Modules.TipoDispositivo.Queries;
using CorteAutomatico.Domain.Services.TipoDispositivo;
using CorteAutomatico.Tests.Fixtures;
using Moq;
using Xunit;

namespace CorteAutomatico.Tests.Services.TipoDispositivo;

public class TipoDispositivoFinderServiceTests: IClassFixture<JwtContextFixture>
{
    private readonly Mock<ITipoDispositivoDb> _tipoDispositivoDbMock;
    private readonly TipoDispositivoFinderService _sut;
    private readonly JwtContext _jwtContext;

    public TipoDispositivoFinderServiceTests(JwtContextFixture jwtContextFixture)
    {
        _jwtContext = jwtContextFixture.JwtContext;
        _tipoDispositivoDbMock = new Mock<ITipoDispositivoDb>();
        _sut = new TipoDispositivoFinderService(_tipoDispositivoDbMock.Object);
    }
    
    [Fact]
    public async Task FindAllAsync_WithPaginationAndSearchAndExistingResults_ReturnsAll()
    {
        // Arrange
        int page = Faker.RandomNumber.Next(1, int.MaxValue);
        int perPage = Faker.RandomNumber.Next(1, Pagination.MaxPerPage);
        var pagination = new Pagination(page, perPage);
        var expectedPaginatedList =
            new PaginatedList<TipoDispositivoDto>(
                Utils.FakeList<TipoDispositivoDto>(perPage),
                pagination.SetTotal(perPage * Faker.RandomNumber.Next(page, page * 10))
            ); 
        _tipoDispositivoDbMock
            .Setup(x => x.FindAllAsync(It.IsAny<Pagination>(), It.IsAny<Search>()))
            .ReturnsAsync(expectedPaginatedList);

        // Act
        var result = await _sut.FindAllAsync(
            Command<(Pagination?, Search?)>.Builder()
                .SetData((pagination, new Search(Faker.Lorem.GetFirstWord())))
                .SetJwtContext(_jwtContext)
                .Build()
        );

        // Assert
        Assert.NotNull(result.Pagination);
        Assert.Equal(pagination.Page, result.Pagination!.Page);
        Assert.Equal(pagination.PerPage, result.Pagination.PerPage);
        Assert.Equal(pagination.Total, result.Pagination.Total);
        Assert.Equal(
            JsonSerializer.Serialize(expectedPaginatedList),
            JsonSerializer.Serialize(result)
        );
        _tipoDispositivoDbMock.Verify(x => x.FindAllAsync(It.IsAny<Pagination>(), It.IsAny<Search>()), Times.Once());
    }
    
    [Fact]
    public async Task FindAllAsync_WithPaginationAndSearchAndNotExistingResults_ReturnsEmptyList()
    {
        // Arrange
        int page = Faker.RandomNumber.Next(1, int.MaxValue);
        int perPage = Faker.RandomNumber.Next(1, Pagination.MaxPerPage);
        var pagination = new Pagination(page, perPage);
        var expectedPaginatedList =
            new PaginatedList<TipoDispositivoDto>(
                new List<TipoDispositivoDto>(),
                pagination.SetTotal(perPage * Faker.RandomNumber.Next(page, page * 10))
            ); 
        _tipoDispositivoDbMock
            .Setup(x => x.FindAllAsync(It.IsAny<Pagination>(), It.IsAny<Search>()))
            .ReturnsAsync(expectedPaginatedList);

        // Act 
        var result = await _sut.FindAllAsync(
            Command<(Pagination?, Search?)>.Builder()
                .SetData((pagination, new Search(Faker.Lorem.GetFirstWord())))
                .SetJwtContext(_jwtContext)
                .Build()
        );
        // Assert
        Assert.Empty(result.List);
        _tipoDispositivoDbMock.Verify(x => x.FindAllAsync(It.IsAny<Pagination>(), It.IsAny<Search>()), Times.Once());
    }
    
    [Fact]
    public async Task FindAllAsync_WithPaginationAndExistingResults_ReturnsAll()
    {
        // Arrange
        int page = Faker.RandomNumber.Next(1, int.MaxValue);
        int perPage = Faker.RandomNumber.Next(1, Pagination.MaxPerPage);
        var pagination = new Pagination(page, perPage);
        var expectedPaginatedList =
            new PaginatedList<TipoDispositivoDto>(
                Utils.FakeList<TipoDispositivoDto>(perPage),
                pagination.SetTotal(perPage * Faker.RandomNumber.Next(page, page * 10))
            ); 
        _tipoDispositivoDbMock
            .Setup(x => x.FindAllAsync(It.IsAny<Pagination>()))
            .ReturnsAsync(expectedPaginatedList);

        // Act
        var result = await _sut.FindAllAsync(
            Command<(Pagination?, Search?)>.Builder()
                .SetData((pagination, null))
                .SetJwtContext(_jwtContext)
                .Build()
        );

        // Assert
        Assert.NotNull(result.Pagination);
        Assert.Equal(pagination.Page, result.Pagination!.Page);
        Assert.Equal(pagination.PerPage, result.Pagination.PerPage);
        Assert.Equal(pagination.Total, result.Pagination.Total);
        Assert.Equal(
            JsonSerializer.Serialize(expectedPaginatedList),
            JsonSerializer.Serialize(result)
        );
        _tipoDispositivoDbMock.Verify(x => x.FindAllAsync(It.IsAny<Pagination>()), Times.Once());
    }
    
    [Fact]
    public async Task FindAllAsync_WithPaginationAndNotExistingResults_ReturnsEmptyList()
    {
        // Arrange
        int page = Faker.RandomNumber.Next(1, int.MaxValue);
        int perPage = Faker.RandomNumber.Next(1, Pagination.MaxPerPage);
        var pagination = new Pagination(page, perPage);
        var expectedPaginatedList =
            new PaginatedList<TipoDispositivoDto>(
                new List<TipoDispositivoDto>(),
                pagination.SetTotal(perPage * Faker.RandomNumber.Next(page, page * 10))
            ); 
        _tipoDispositivoDbMock
            .Setup(x => x.FindAllAsync(It.IsAny<Pagination>()))
            .ReturnsAsync(expectedPaginatedList);

        // Act
        var result = await _sut.FindAllAsync(
            Command<(Pagination?, Search?)>.Builder()
                .SetData((pagination, null))
                .SetJwtContext(_jwtContext)
                .Build()
        );

        // Assert
        Assert.Empty(result.List);
        _tipoDispositivoDbMock.Verify(x => x.FindAllAsync(It.IsAny<Pagination>()), Times.Once());
    }
    
    [Fact]
    public async Task FindAllAsync_WithSearchAndExistingResults_ReturnsAll()
    {
        // Arrange
        var expectedList = Utils.FakeList<TipoDispositivoDto>(Faker.RandomNumber.Next(1, 1000));
        _tipoDispositivoDbMock
            .Setup(x => x.FindAllAsync(It.IsAny<Search>()))
            .ReturnsAsync(expectedList);

        // Act
        var result = await _sut.FindAllAsync(
            Command<(Pagination?, Search?)>.Builder()
                .SetData((null, new Search(Utils.RandomString(3,100))))
                .SetJwtContext(_jwtContext)
                .Build()
        );

        // Assert
        Assert.Null(result.Pagination);
        Assert.Equal(
            JsonSerializer.Serialize(expectedList),
            JsonSerializer.Serialize(result.List)
        );
        _tipoDispositivoDbMock.Verify(x => x.FindAllAsync(It.IsAny<Search>()), Times.Once());
    }
    
    [Fact]
    public async Task FindAllAsync_WithSearchAndNotExistingResults_ReturnsEmptyList()
    {
        // Arrange
        var expectedList = new List<TipoDispositivoDto>();
        _tipoDispositivoDbMock
            .Setup(x => x.FindAllAsync(It.IsAny<Search>()))
            .ReturnsAsync(expectedList);

        // Act
        var result = await _sut.FindAllAsync(
            Command<(Pagination?, Search?)>.Builder()
                .SetData((null, new Search(Utils.RandomString(3,100))))
                .SetJwtContext(_jwtContext)
                .Build()
        );

        // Assert
        Assert.Null(result.Pagination);
        Assert.Empty(result.List);
        _tipoDispositivoDbMock.Verify(x => x.FindAllAsync(It.IsAny<Search>()), Times.Once());
    }
    
    [Fact]
    public async Task FindAllAsync_OnExistingResults_ReturnsAll()
    {
        // Arrange
        var expectedList = Utils.FakeList<TipoDispositivoDto>(Faker.RandomNumber.Next(1, 1000));
        _tipoDispositivoDbMock
            .Setup(x => x.FindAllAsync())
            .ReturnsAsync(expectedList);

        // Act
        var result = await _sut.FindAllAsync(
            Command<(Pagination?, Search?)>.Builder()
                .SetData((null, null))
                .SetJwtContext(_jwtContext)
                .Build()
        );

        // Assert
        Assert.Null(result.Pagination);
        Assert.Equal(
            JsonSerializer.Serialize(expectedList),
            JsonSerializer.Serialize(result.List)
        );
        _tipoDispositivoDbMock.Verify(x => x.FindAllAsync(), Times.Once());
    }
    
    [Fact]
    public async Task FindAllAsync_OnNotExistingResults_ReturnsEmptyList()
    {
        // Arrange
        var expectedList = new List<TipoDispositivoDto>();
        _tipoDispositivoDbMock
            .Setup(x => x.FindAllAsync())
            .ReturnsAsync(expectedList);

        // Act
        var result = await _sut.FindAllAsync(
            Command<(Pagination?, Search?)>.Builder()
                .SetData((null, null))
                .SetJwtContext(_jwtContext)
                .Build()
        );

        // Assert
        Assert.Null(result.Pagination);
        Assert.Empty(result.List);
        _tipoDispositivoDbMock.Verify(x => x.FindAllAsync(), Times.Once());
    }
    
    [Fact]
    public async Task FindByUuidAsync_OnExistingResults_ReturnsResult()
    {
        // Arrange
        var expectedTipoDispositivo = Utils.FakeObj<TipoDispositivoDto>();
        _tipoDispositivoDbMock
            .Setup(x => x.FindByUuidAsync(It.IsAny<Guid>()))
            .ReturnsAsync(expectedTipoDispositivo);

        // Act
        var result = await _sut.FindByUuid(
            Command<Guid>.Builder()
                .SetData(expectedTipoDispositivo.Uuid)
                .SetJwtContext(_jwtContext)
                .Build()
        );

        // Assert
        Assert.Equal(
            expected: JsonSerializer.Serialize(expectedTipoDispositivo),
            actual: JsonSerializer.Serialize(result)
        );
        _tipoDispositivoDbMock.Verify(x => x.FindByUuidAsync(It.IsAny<Guid>()), Times.Once());
    }
    
    [Fact]
    public async Task FindByUuidAsync_OnNotExistingResults_NotFoundException()
    {
        // Arrange
        _tipoDispositivoDbMock
            .Setup(x => x.FindByUuidAsync(It.IsAny<Guid>()))
            .ReturnsAsync((TipoDispositivoDto?) null);

        // Act And Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _sut.FindByUuid(
            Command<Guid>.Builder()
                .SetData(Guid.NewGuid())
                .SetJwtContext(_jwtContext)
                .Build()
        ));
        _tipoDispositivoDbMock.Verify(x => x.FindByUuidAsync(It.IsAny<Guid>()), Times.Once());
    }
}