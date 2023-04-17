using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Pagination;
using CorteAutomatico.Core.DatabaseContext;
using CorteAutomatico.Core.Modules.Perfil.Dtos;
using CorteAutomatico.Core.Modules.Perfil.Queries;
using CorteAutomatico.Data.Queries;
using CorteAutomatico.Tests.DatabasePreConditions;
using CorteAutomatico.Tests.Fixtures;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CorteAutomatico.Tests.Queries;

public class PerfilDbTests: IClassFixture<TestDatabaseFixture>
{
    private readonly IPerfilDb _perfilDb;
    private readonly CorteAutomaticoContext _context;
    public PerfilDbTests()
    {
        _perfilDb = new PerfilDb(Utils.Connection());
        _context = new();
    }

    [Fact]
    public async Task FindAllAsync_WhenCalled_ReturnsAllRecordsIncludingInactives()
    {
        var actualPerfils = await _perfilDb.FindAllAsync();
        Assert.Equal(
            expected: PerfilSeeder.TotalPerfils, 
            actual: actualPerfils.Count()
        );
    }
    
    [Fact]
    public async Task FindAllAsync_WhenCalled_ReturnsAllRecordsSortedByNome()
    {
        var actualPerfils = await _perfilDb.FindAllAsync() as List<PerfilDto>;
        Assert.True(Utils.IsSortedBy(actualPerfils!, x => x.Nome));
    }
    
    [Fact]
    public async Task FindAllAsync_WhenCalled_ObjectIsComplete()
    {
        var actualPerfils = await _perfilDb.FindAllAsync() as List<PerfilDto>;
        Assert.True(actualPerfils!.Exists(x => x.Ativo));
        Assert.All(actualPerfils, AssertObjectIntegrity);
    }
    
    [Fact]
    public async Task FindAllAsync_WithSearch_ReturnsAllRecordsFilteringBySearchCaseInsensitiveIncludingInactives()
    {
        var seeds = await _context.Perfils.ToListAsync();
        var search = Utils.RandomItem(seeds).Nome[..3];
        var actualPerfils = await _perfilDb.FindAllAsync(new Search(search)) as List<PerfilDto>;
        bool filterWorks = true;
        for (int i = 0; i < seeds.Count(x => x.Nome.ToLower().Contains(search.ToLower())); i++)
        {
            filterWorks = filterWorks && actualPerfils![i].Nome.ToLower().Contains(search.ToLower());
        }
        Assert.True(filterWorks);
    }
    
    [Fact]
    public async Task FindAllAsync_WithSearch_RecordsAreSortedByNome()
    {
        var seeds = await _context.Perfils.ToListAsync();
        var search = new Search(Utils.RandomItem(seeds).Nome[..3]);
        var actualPerfils = await _perfilDb.FindAllAsync(search) as List<PerfilDto>;
        Assert.True(Utils.IsSortedBy(actualPerfils!, x => x.Nome));
    }
    
    [Fact]
    public async Task FindAllAsync_WithSearch_AllFieldsMustToBeReturned()
    {
        var seeds = await _context.Perfils.ToListAsync();
        var search = new Search(Utils.RandomItem(seeds).Nome[..3]);
        var actualPerfils = await _perfilDb.FindAllAsync(search) as List<PerfilDto>;
        Assert.All(actualPerfils!, AssertObjectIntegrity);
    }
    
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task FindByUuidAsync_WhenRecordExists_ReturnsARecordFilteringByUuidIncludingInactives(bool ativo)
    {
        var expectedPerfil = await _context.Perfils.FirstAsync(x => x.Ativo == ativo);
        var actualPerfil = await _perfilDb.FindByUuidAsync(expectedPerfil.Uuid);
        Assert.Equal(expectedPerfil.Uuid.ToString(), actualPerfil!.Uuid.ToString());
    }
    
    [Fact]
    public async Task FindByUuidAsync_WhenRecordDoesNotExists_ReturnsNull()
    {
        var actualPerfil = await _perfilDb.FindByUuidAsync(Guid.NewGuid());
        Assert.Null(actualPerfil);
    }
    
    [Fact]
    public async Task FindByUuidAsync_WhenRecordDoesNotExists_ObjectIsComplete()
    {
        var expectedPerfil = await _context.Perfils.FirstAsync(x => x.Ativo);
        var actualPerfil = await _perfilDb.FindByUuidAsync(expectedPerfil.Uuid);
        AssertObjectIntegrity(actualPerfil!);
    }
    
    
    [Theory]
    [InlineData(1,10)]
    [InlineData(10,5)]
    [InlineData(PerfilSeeder.ActivePerfils + 1, 1)]
    [InlineData(PerfilSeeder.ActivePerfils + PerfilSeeder.ActivePerfils,1)]
    [InlineData(int.MaxValue,1)]
    public async Task FindAllAsync_WithPagination_ReturnsPaginatedIncludeInactives(int page, int perPage)
    {
        var pagination = new Pagination(page, perPage);
        var seeds = await _context.Perfils.OrderBy(x => x.Nome).ToListAsync();
        var expectedPaginatedList = seeds.Skip((page - 1) * perPage)
            .Take(perPage)
            .ToList();
        var actualPerfils = await _perfilDb.FindAllAsync(pagination);
        Assert.Equal(
            expected: expectedPaginatedList.Select(x=>x.Uuid),
            actual: actualPerfils.List.Select(x=>x.Uuid)
        );
        Assert.Equal(seeds.Count, actualPerfils.Pagination?.Total);
    }
    
    [Theory]
    [InlineData(1,10)]
    [InlineData(10,5)]
    public async Task FindAllAsync_WithPagination_RecordsAreSortedByNome(int page, int perPage)
    {
        var pagination = new Pagination(page, perPage);
        var actualPerfils = await _perfilDb.FindAllAsync(pagination);
        Assert.True(Utils.IsSortedBy(actualPerfils.List, x => x.Nome));
    }
    
    [Theory]
    [InlineData(1,10)]
    public async Task FindAllAsync_WithPagination_ObjectIsComplete(int page, int perPage)
    {
        var pagination = new Pagination(page, perPage);
        var actualPerfils = await _perfilDb.FindAllAsync(pagination);
        Assert.All(actualPerfils.List,AssertObjectIntegrity);
    }
    [Theory]
    [InlineData(1,10)]
    [InlineData(10,5)]
    [InlineData(PerfilSeeder.ActivePerfils + 1, 1)]
    [InlineData(PerfilSeeder.ActivePerfils + PerfilSeeder.ActivePerfils,1)]
    [InlineData(int.MaxValue,1)]
    public async Task FindAllAsync_WithPaginationAndSearch_ReturnsPaginatedIncludeInactives(int page, int perPage)
    {
        var pagination = new Pagination(page, perPage);
        var seeds = await _context.Perfils.ToListAsync();
        var search = Utils.RandomItem(seeds).Nome[..3];
        seeds = seeds
            .Where(x=> x.Nome.ToLower().Contains(search.ToLower()))
            .OrderBy(x => x.Nome).ToList();
        var expectedPaginatedList = seeds.Skip((page - 1) * perPage)
            .Take(perPage)
            .ToList();
        var actualPerfils = await _perfilDb.FindAllAsync(pagination, new(search));
        Assert.Equal(
            expected: expectedPaginatedList.Select(x=>x.Uuid),
            actual: actualPerfils.List.Select(x=>x.Uuid)
        );
        Assert.Equal(seeds.Count, actualPerfils.Pagination?.Total);
    }
    
    [Theory]
    [InlineData(1,10)]
    [InlineData(10,5)]
    public async Task FindAllAsync_WithPaginationAndSearch_RecordsAreSortedByNome(int page, int perPage)
    {
        var seeds = await _context.Perfils.OrderBy(x => x.Nome).ToListAsync();
        var search = Utils.RandomItem(seeds).Nome[..3];
        var pagination = new Pagination(page, perPage);
        var actualPerfils = await _perfilDb.FindAllAsync(pagination, new(search));
        Assert.True(Utils.IsSortedBy(actualPerfils.List, x => x.Nome));
    }
    
    [Theory]
    [InlineData(1,10)]
    [InlineData(10,5)]
    public async Task FindAllAsync_WithPaginationAndSearch_FilterByNomeWorks(int page, int perPage)
    {
        var seeds = await _context.Perfils.OrderBy(x => x.Nome).ToListAsync();
        var search = Utils.RandomItem(seeds).Nome[..3];
        var pagination = new Pagination(page, perPage);
        var actualPerfils = await _perfilDb.FindAllAsync(pagination, new(search));
        var list = actualPerfils.List;
        bool filterWorks = true;
        foreach (var perfil in list)
        {
            filterWorks = filterWorks && perfil.Nome.ToLower().Contains(search.ToLower());
        }
        Assert.True(filterWorks);
    }
    
    [Theory]
    [InlineData(1,10)]
    [InlineData(10,5)]
    public async Task FindAllAsync_WithPaginationAndSearch_ObjectIsComplete(int page, int perPage)
    {
        var seeds = await _context.Perfils.OrderBy(x => x.Nome).ToListAsync();
        var search = Utils.RandomItem(seeds).Nome[..3];
        var pagination = new Pagination(page, perPage);
        var actualPerfils = await _perfilDb.FindAllAsync(pagination, new(search));
        Assert.All(actualPerfils.List, AssertObjectIntegrity);
    }

    private static void AssertObjectIntegrity(PerfilDto x)
    {
        Assert.NotEqual(x.Uuid.ToString(), Guid.Empty.ToString());
        Assert.NotNull(x.Nome);
        Assert.NotEqual(x.CriadoEm, DateTime.MinValue);
        Assert.NotNull(x.CriadoPor);
        Assert.NotEqual(x.ModificadoEm, DateTime.MinValue);
        Assert.NotNull(x.ModificadoPor);
    }
}