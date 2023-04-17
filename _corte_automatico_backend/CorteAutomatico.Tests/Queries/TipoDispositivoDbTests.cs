using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.DatabaseContext;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;
using CorteAutomatico.Core.Modules.TipoDispositivo.Queries;
using CorteAutomatico.Data.Queries;
using CorteAutomatico.Tests.DatabasePreConditions;
using CorteAutomatico.Tests.Fixtures;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CorteAutomatico.Tests.Queries;

public class TipoDispositivoDbTests: IClassFixture<TestDatabaseFixture>
{
    private readonly ITipoDispositivoDb _tipoDispositivoDb;
    private readonly CorteAutomaticoContext _context;
    public TipoDispositivoDbTests()
    {
        _tipoDispositivoDb = new TipoDispositivoDb(Utils.Connection());
        _context = new();
    }

    [Fact]
    public async Task FindAllAsync_WhenCalled_ReturnsAllRecordsIncludingInactives()
    {
        var actualTipoDispositivos = await _tipoDispositivoDb.FindAllAsync();
        Assert.Equal(
            expected: TipoDispositivoSeeder.TotalTipoDispositivos, 
            actual: actualTipoDispositivos.Count()
        );
    }
    
    [Fact]
    public async Task FindAllAsync_WhenCalled_ReturnsAllRecordsSortedByNome()
    {
        var actualTipoDispositivos = await _tipoDispositivoDb.FindAllAsync() as List<TipoDispositivoDto>;
        Assert.True(Utils.IsSortedBy(actualTipoDispositivos!, x => x.Nome));
    }
    
    [Fact]
    public async Task FindAllAsync_WhenCalled_ObjectIsComplete()
    {
        var actualTipoDispositivos = await _tipoDispositivoDb.FindAllAsync() as List<TipoDispositivoDto>;
        Assert.True(actualTipoDispositivos!.Exists(x => x.Ativo));
        Assert.All(actualTipoDispositivos, AssertObjectIntegrity);
    }
    
    [Fact]
    public async Task FindAllAsync_WithSearch_ReturnsAllRecordsFilteringBySearchCaseInsensitiveIncludingInactives()
    {
        var seeds = await _context.TipoDispositivos.ToListAsync();
        var search = Utils.RandomItem(seeds).Nome[..3];
        var actualTipoDispositivos = await _tipoDispositivoDb.FindAllAsync(new Search(search)) as List<TipoDispositivoDto>;
        bool filterWorks = true;
        for (int i = 0; i < seeds.Count(x => x.Nome.ToLower().Contains(search.ToLower())); i++)
        {
            filterWorks = filterWorks && actualTipoDispositivos![i].Nome.ToLower().Contains(search.ToLower());
        }
        Assert.True(filterWorks);
    }
    
    [Fact]
    public async Task FindAllAsync_WithSearch_RecordsAreSortedByNome()
    {
        var seeds = await _context.TipoDispositivos.ToListAsync();
        var search = new Search(Utils.RandomItem(seeds).Nome[..3]);
        var actualTipoDispositivos = await _tipoDispositivoDb.FindAllAsync(search) as List<TipoDispositivoDto>;
        Assert.True(Utils.IsSortedBy(actualTipoDispositivos!, x => x.Nome));
    }
    
    [Fact]
    public async Task FindAllAsync_WithSearch_AllFieldsMustToBeReturned()
    {
        var seeds = await _context.TipoDispositivos.ToListAsync();
        var search = new Search(Utils.RandomItem(seeds).Nome[..3]);
        var actualTipoDispositivos = await _tipoDispositivoDb.FindAllAsync(search) as List<TipoDispositivoDto>;
        Assert.All(actualTipoDispositivos!, AssertObjectIntegrity);
    }
    
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task FindByUuidAsync_WhenRecordExists_ReturnsARecordFilteringByUuidIncludingInactives(bool ativo)
    {
        var expectedTipoDispositivo = await _context.TipoDispositivos.FirstAsync(x => x.Ativo == ativo);
        var actualTipoDispositivo = await _tipoDispositivoDb.FindByUuidAsync(expectedTipoDispositivo.Uuid);
        Assert.Equal(expectedTipoDispositivo.Uuid.ToString(), actualTipoDispositivo!.Uuid.ToString());
    }
    
    [Fact]
    public async Task FindByUuidAsync_WhenRecordDoesNotExists_ReturnsNull()
    {
        var actualTipoDispositivo = await _tipoDispositivoDb.FindByUuidAsync(Guid.NewGuid());
        Assert.Null(actualTipoDispositivo);
    }
    
    [Fact]
    public async Task FindByUuidAsync_WhenRecordDoesNotExists_ObjectIsComplete()
    {
        var expectedTipoDispositivo = await _context.TipoDispositivos.FirstAsync(x => x.Ativo);
        var actualTipoDispositivo = await _tipoDispositivoDb.FindByUuidAsync(expectedTipoDispositivo.Uuid);
        AssertObjectIntegrity(actualTipoDispositivo!);
    }
    
    
    [Theory]
    [InlineData(1,10)]
    [InlineData(10,5)]
    [InlineData(TipoDispositivoSeeder.ActiveTipoDispositivos + 1, 1)]
    [InlineData(TipoDispositivoSeeder.ActiveTipoDispositivos + TipoDispositivoSeeder.ActiveTipoDispositivos,1)]
    [InlineData(int.MaxValue,1)]
    public async Task FindAllAsync_WithPagination_ReturnsPaginatedIncludeInactives(int page, int perPage)
    {
        var pagination = new Pagination(page, perPage);
        var seeds = await _context.TipoDispositivos.OrderBy(x => x.Nome).ToListAsync();
        var expectedPaginatedList = seeds.Skip((page - 1) * perPage)
            .Take(perPage)
            .ToList();
        var actualTipoDispositivos = await _tipoDispositivoDb.FindAllAsync(pagination);
        Assert.Equal(
            expected: expectedPaginatedList.Select(x=>x.Uuid),
            actual: actualTipoDispositivos.List.Select(x=>x.Uuid)
        );
        Assert.Equal(seeds.Count, actualTipoDispositivos.Pagination?.Total);
    }
    
    [Theory]
    [InlineData(1,10)]
    [InlineData(10,5)]
    public async Task FindAllAsync_WithPagination_RecordsAreSortedByNome(int page, int perPage)
    {
        var pagination = new Pagination(page, perPage);
        var actualTipoDispositivos = await _tipoDispositivoDb.FindAllAsync(pagination);
        Assert.True(Utils.IsSortedBy(actualTipoDispositivos.List, x => x.Nome));
    }
    
    [Theory]
    [InlineData(1,10)]
    public async Task FindAllAsync_WithPagination_ObjectIsComplete(int page, int perPage)
    {
        var pagination = new Pagination(page, perPage);
        var actualTipoDispositivos = await _tipoDispositivoDb.FindAllAsync(pagination);
        Assert.All(actualTipoDispositivos.List,AssertObjectIntegrity);
    }
    [Theory]
    [InlineData(1,10)]
    [InlineData(10,5)]
    [InlineData(TipoDispositivoSeeder.ActiveTipoDispositivos + 1, 1)]
    [InlineData(TipoDispositivoSeeder.ActiveTipoDispositivos + TipoDispositivoSeeder.ActiveTipoDispositivos,1)]
    [InlineData(int.MaxValue,1)]
    public async Task FindAllAsync_WithPaginationAndSearch_ReturnsPaginatedIncludeInactives(int page, int perPage)
    {
        var pagination = new Pagination(page, perPage);
        var seeds = await _context.TipoDispositivos.ToListAsync();
        var search = Utils.RandomItem(seeds).Nome[..3];
        seeds = seeds
            .Where(x=> x.Nome.ToLower().Contains(search.ToLower()))
            .OrderBy(x => x.Nome).ToList();
        var expectedPaginatedList = seeds.Skip((page - 1) * perPage)
            .Take(perPage)
            .ToList();
        var actualTipoDispositivos = await _tipoDispositivoDb.FindAllAsync(pagination, new(search));
        Assert.Equal(
            expected: expectedPaginatedList.Select(x=>x.Uuid),
            actual: actualTipoDispositivos.List.Select(x=>x.Uuid)
        );
        Assert.Equal(seeds.Count, actualTipoDispositivos.Pagination?.Total);
    }
    
    [Theory]
    [InlineData(1,10)]
    [InlineData(10,5)]
    public async Task FindAllAsync_WithPaginationAndSearch_RecordsAreSortedByNome(int page, int perPage)
    {
        var seeds = await _context.TipoDispositivos.OrderBy(x => x.Nome).ToListAsync();
        var search = Utils.RandomItem(seeds).Nome[..3];
        var pagination = new Pagination(page, perPage);
        var actualTipoDispositivos = await _tipoDispositivoDb.FindAllAsync(pagination, new(search));
        Assert.True(Utils.IsSortedBy(actualTipoDispositivos.List, x => x.Nome));
    }
    
    [Theory]
    [InlineData(1,10)]
    [InlineData(10,5)]
    public async Task FindAllAsync_WithPaginationAndSearch_FilterByNomeWorks(int page, int perPage)
    {
        var seeds = await _context.TipoDispositivos.OrderBy(x => x.Nome).ToListAsync();
        var search = Utils.RandomItem(seeds).Nome[..3];
        var pagination = new Pagination(page, perPage);
        var actualTipoDispositivos = await _tipoDispositivoDb.FindAllAsync(pagination, new(search));
        var list = actualTipoDispositivos.List;
        bool filterWorks = true;
        foreach (var tipoDispositivo in list)
        {
            filterWorks = filterWorks && tipoDispositivo.Nome.ToLower().Contains(search.ToLower());
        }
        Assert.True(filterWorks);
    }
    
    [Theory]
    [InlineData(1,10)]
    [InlineData(10,5)]
    public async Task FindAllAsync_WithPaginationAndSearch_ObjectIsComplete(int page, int perPage)
    {
        var seeds = await _context.TipoDispositivos.OrderBy(x => x.Nome).ToListAsync();
        var search = Utils.RandomItem(seeds).Nome[..3];
        var pagination = new Pagination(page, perPage);
        var actualTipoDispositivos = await _tipoDispositivoDb.FindAllAsync(pagination, new(search));
        Assert.All(actualTipoDispositivos.List, AssertObjectIntegrity);
    }

    private static void AssertObjectIntegrity(TipoDispositivoDto x)
    {
        Assert.NotEqual(x.Uuid.ToString(), Guid.Empty.ToString());
        Assert.NotNull(x.Nome);
        Assert.NotEqual(x.CriadoEm, DateTime.MinValue);
        Assert.NotNull(x.CriadoPor);
        Assert.NotEqual(x.ModificadoEm, DateTime.MinValue);
        Assert.NotNull(x.ModificadoPor);
    }
}