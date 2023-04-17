using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;
using CorteAutomatico.Core.Modules.TipoDispositivo.Queries;
using CorteAutomatico.Core.Modules.TipoDispositivo.Services;
using CorteAutomatico.Core.Repositories;
using CorteAutomatico.Domain.Mappers;
using CorteAutomatico.Domain.Services.TipoDispositivo;
using CorteAutomatico.Tests.Fixtures;
using Moq;
using Xunit;

namespace CorteAutomatico.Tests.Services.TipoDispositivo;

public class TipoDispositivoRegisterServiceTests: IClassFixture<JwtContextFixture>
{
    private readonly Mock<ITipoDispositivoDb> _tipoDispositivoDbMock;
    private readonly Mock<IRepository> _repositoryMock;
    private readonly Mock<IEntityFactory<Core.Entities.TipoDispositivo, TipoDispositivoRequestDto>> _factoryMock;    
    private readonly JwtContext _jwtContext;
    private readonly ITipoDispositivoRegisterService _sut;
    
    public TipoDispositivoRegisterServiceTests(JwtContextFixture jwtContextFixture)
    {
        _tipoDispositivoDbMock = new Mock<ITipoDispositivoDb>();
        _repositoryMock = new Mock<IRepository>();
        _factoryMock = new Mock<IEntityFactory<Core.Entities.TipoDispositivo, TipoDispositivoRequestDto>>();
        _jwtContext = jwtContextFixture.JwtContext;
        _sut = new TipoDispositivoRegisterService(_repositoryMock.Object, _tipoDispositivoDbMock.Object, _factoryMock.Object);
    }
    
    [Fact]
    public async Task RegisterAsync_WithValidArguments_ShouldRegisterAndReturn()
    {
        // Arrange
        var request = Utils.FakeObj<TipoDispositivoRequestDto>();
        var tipoDispositivo = new Core.Entities.TipoDispositivo()
        {
            Id = Faker.RandomNumber.Next(),
            Ativo = false,
            CriadoEm = DateTime.Now,
            ModificadoEm = DateTime.Now,
            CriadoPor = _jwtContext.Login,
            ModificadoPor = _jwtContext.Login
        };
        var tipoDispositivoDto = Utils.FakeObj<TipoDispositivoDto>();
        
        _factoryMock
            .Setup(x => x.CreateForRegister(
                It.IsAny<ICommand<TipoDispositivoRequestDto>>()
            ))
            .Returns(tipoDispositivo);

        _repositoryMock
            .Setup(x => x.InsertAsync(It.IsAny<Core.Entities.TipoDispositivo>()))
            .Callback<Core.Entities.TipoDispositivo>(x =>
            {
                Assert.Equal(tipoDispositivo.CriadoEm.ToString("yy-MM-dd hh:mm:ss"), x.CriadoEm.ToString("yy-MM-dd hh:mm:ss"));
                Assert.Equal(tipoDispositivo.ModificadoEm.ToString("yy-MM-dd hh:mm:ss"), x.ModificadoEm.ToString("yy-MM-dd hh:mm:ss"));
                Assert.Equal(tipoDispositivo.ModificadoEm.ToString("yy-MM-dd hh:mm:ss"), x.ModificadoEm.ToString("yy-MM-dd hh:mm:ss"));
                Assert.Equal(tipoDispositivo.CriadoPor, x.CriadoPor);
                Assert.Equal(tipoDispositivo.ModificadoPor, x.ModificadoPor);
                Assert.Equal(request.Nome, x.Nome);
                Assert.True(x.Ativo);
            })
        ;
        
        _tipoDispositivoDbMock
            .Setup(x => x.FindByUuidAsync(tipoDispositivo.Uuid))
            .ReturnsAsync(tipoDispositivoDto);
        
        // Act
        var result = await _sut.RegisterAsync(
            Command<TipoDispositivoRequestDto>.Builder()
                .SetData(request)
                .SetJwtContext(_jwtContext)
                .Build()
        );
        
        //Assert
        Assert.Equal(
            expected: JsonSerializer.Serialize(tipoDispositivoDto),
            actual: JsonSerializer.Serialize(result)
        );
        _tipoDispositivoDbMock
            .Verify(x => x.FindByUuidAsync(It.IsAny<Guid>()), Times.Once());
        _repositoryMock
            .Verify(x => x.InsertAsync(It.IsAny<Core.Entities.TipoDispositivo>()), Times.Once());
    }
}