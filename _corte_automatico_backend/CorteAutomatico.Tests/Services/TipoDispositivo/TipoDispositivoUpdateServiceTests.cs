using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;
using CorteAutomatico.Core.Modules.TipoDispositivo.Queries;
using CorteAutomatico.Core.Repositories;
using CorteAutomatico.Domain.Services.TipoDispositivo;
using CorteAutomatico.Tests.Fixtures;
using Moq;
using Xunit;

namespace CorteAutomatico.Tests.Services.TipoDispositivo;

public class TipoDispositivoUpdateServiceTests: IClassFixture<JwtContextFixture>
{
    private readonly Mock<IRepository> _repositoryMock;
    private readonly Mock<IEntityFactory<Core.Entities.TipoDispositivo, TipoDispositivoRequestDto>> _factoryMock;
    private readonly Mock<ITipoDispositivoDb> _tipoDispositivoDbMock;
    private readonly TipoDispositivoUpdateService _sut;
    private readonly JwtContext _jwtContext;
    
    public TipoDispositivoUpdateServiceTests(JwtContextFixture jwtContextFixture)
    {
        _jwtContext = jwtContextFixture.JwtContext;
        _repositoryMock = new Mock<IRepository>();
        _factoryMock = new Mock<IEntityFactory<Core.Entities.TipoDispositivo, TipoDispositivoRequestDto>>();
        _tipoDispositivoDbMock = new Mock<ITipoDispositivoDb>();
        _sut = new TipoDispositivoUpdateService(_repositoryMock.Object, _factoryMock.Object, _tipoDispositivoDbMock.Object);
    }
    
    [Fact]
    public async Task UpdateAsync_WhenUuidNotFound_ThrowsNotFoundException()
    {
        // Arrange
        var uuid = Guid.NewGuid();
        _repositoryMock
            .Setup(x => x.FindByUuidAsync<Core.Entities.TipoDispositivo>(uuid, true))
            .ReturnsAsync((Core.Entities.TipoDispositivo) null!);

        var command = Command<TipoDispositivoRequestDto>.Builder()
            .SetData(Utils.FakeObj<TipoDispositivoRequestDto>())
            .SetJwtContext(_jwtContext)
            .Build();
        
        // Act and Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _sut.UpdateAsync(uuid, command));
    }
    
    [Fact]
    public async Task UpdateAsync_WhenUuidIsFound_UpdateAndReturnsUpdatedEntity()
    {
        // Arrange
        var uuid = Guid.NewGuid();
        var tipoDispositivo = new Core.Entities.TipoDispositivo
        {
            Id = Faker.RandomNumber.Next(),
            Uuid = uuid,
            Ativo = Faker.Boolean.Random(),
            CriadoEm = DateTime.Now,
            CriadoPor = Utils.RandomString(1,100),
            ModificadoEm = DateTime.Now,
            ModificadoPor = Utils.RandomString(1,100),
            Nome = Utils.RandomString(1,100)
        };
        var tipoDispositivoDto = Utils.FakeObj<TipoDispositivoDto>();
        var request = Utils.FakeObj<TipoDispositivoRequestDto>();
        
        _repositoryMock
            .Setup(x => x.FindByUuidAsync<Core.Entities.TipoDispositivo>(uuid, true))
            .ReturnsAsync(tipoDispositivo);

        _factoryMock
            .Setup(x => x.CreateForUpdate(
                It.IsAny<Core.Entities.TipoDispositivo>(),
                It.IsAny<Command<TipoDispositivoRequestDto>>()
            ))
            .Returns(tipoDispositivo);

        _repositoryMock
            .Setup(x => x.UpdateAsync<Core.Entities.TipoDispositivo>(It.IsAny<Core.Entities.TipoDispositivo>()))
            .Callback<Core.Entities.TipoDispositivo>(x =>
            {
                Assert.Equal(tipoDispositivo.CriadoEm.ToString("yy-MM-dd hh:mm:ss"), x.CriadoEm.ToString("yy-MM-dd hh:mm:ss"));
                Assert.Equal(tipoDispositivo.ModificadoEm.ToString("yy-MM-dd hh:mm:ss"), x.ModificadoEm.ToString("yy-MM-dd hh:mm:ss"));
                Assert.Equal(tipoDispositivo.ModificadoEm.ToString("yy-MM-dd hh:mm:ss"), x.ModificadoEm.ToString("yy-MM-dd hh:mm:ss"));
                Assert.Equal(tipoDispositivo.CriadoPor, x.CriadoPor);
                Assert.Equal(tipoDispositivo.ModificadoPor, x.ModificadoPor);
                Assert.Equal(request.Nome, x.Nome);
                Assert.Equal(request.Ativo, x.Ativo);
            });

        _tipoDispositivoDbMock
            .Setup(x => x.FindByUuidAsync(uuid))
            .ReturnsAsync(tipoDispositivoDto);

        var command = Command<TipoDispositivoRequestDto>.Builder()
            .SetData(request)
            .SetJwtContext(_jwtContext)
            .Build();
        
        // Act
        var result = await _sut.UpdateAsync(uuid, command);
        
        // Assert
        Assert.Equal(
            expected: JsonSerializer.Serialize(tipoDispositivoDto),
            actual: JsonSerializer.Serialize(result)
        );
        _tipoDispositivoDbMock
            .Verify(x => x.FindByUuidAsync(It.IsAny<Guid>()), Times.Once());
        _repositoryMock
            .Verify(x => x.UpdateAsync(It.IsAny<Core.Entities.TipoDispositivo>()), Times.Once());
    }
}