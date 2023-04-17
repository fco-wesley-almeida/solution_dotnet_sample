using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorteAutomatico.Core.Modules.Authentication.Queries;
using CorteAutomatico.Core.Modules.Usuario.Dtos;
using CorteAutomatico.Data.Queries;
using CorteAutomatico.Tests.DatabasePreConditions;
using CorteAutomatico.Tests.Fixtures;
using Xunit;

namespace CorteAutomatico.Tests.Queries;

public class UsuarioDbTests: IClassFixture<TestDatabaseFixture>
{
    private readonly IUsuarioDb _usuarioDb;
    private readonly UsuarioSeeder _usuarioSeeder;
    public UsuarioDbTests()
    {
        _usuarioDb = new UsuarioDb(Utils.Connection());
        _usuarioSeeder = new UsuarioSeeder();
    }

    [Fact]
    public async Task FindAllAsync_WhenCalled_ReturnsAllRecordsIncludingInactives()
    {
        var usuarios = await _usuarioDb.FindAllAsync();
        Assert.Equal(UsuarioSeeder.TotalUsuarios, usuarios.Count());
    }
    
    [Fact]
    public async Task FindAllAsync_WhenCalled_ReturnsAllRecordsSortedByName()
    {
        List<UsuarioDto> usuarios = (await _usuarioDb.FindAllAsync() as List<UsuarioDto>)!;
        bool isSortedByNameAsc = true;
        for (int i = 1; i < usuarios.Count; i++)
        {
            if (string.Compare(usuarios[i - 1].Nome, usuarios[i].Nome, StringComparison.Ordinal) == 1)
            {
                isSortedByNameAsc = false;
                break;
            }
        }
        Assert.True(isSortedByNameAsc);
    }
}