using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.Entities;
using CorteAutomatico.Core.Modules.Authentication.Queries;
using CorteAutomatico.Core.Modules.Authentication.Services;
using CorteAutomatico.Core.Modules.Cryptography;
using CorteAutomatico.Core.Modules.DispositivoMarca.Queries;
using CorteAutomatico.Core.Modules.DispositivoMarca.Services;
using CorteAutomatico.Core.Modules.DispositivoModelo.Queries;
using CorteAutomatico.Core.Modules.DispositivoModelo.Services;
using CorteAutomatico.Core.Modules.Jwt.Builders;
using CorteAutomatico.Core.Modules.Jwt.Services;
using CorteAutomatico.Core.Modules.Perfil.Queries;
using CorteAutomatico.Core.Modules.Perfil.Services;
using CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;
using CorteAutomatico.Core.Modules.TipoDispositivo.Queries;
using CorteAutomatico.Core.Modules.TipoDispositivo.Services;
using CorteAutomatico.Core.Modules.Usuario.Services;
using CorteAutomatico.Core.Repositories;
using CorteAutomatico.Data.Queries;
using CorteAutomatico.Data.Repositories;
using CorteAutomatico.Domain.Builders;
using CorteAutomatico.Domain.Mappers;
using CorteAutomatico.Domain.Providers;
using CorteAutomatico.Domain.Services.Authentication;
using CorteAutomatico.Domain.Services.Cryptography;
using CorteAutomatico.Domain.Services.DispositivoMarca;
using CorteAutomatico.Domain.Services.DispositivoModelo;
using CorteAutomatico.Domain.Services.Jwt;
using CorteAutomatico.Domain.Services.Perfil;
using CorteAutomatico.Domain.Services.TipoDispositivo;
using CorteAutomatico.Domain.Services.Usuario;

namespace CorteAutomatico.Application.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IUsuarioDb, UsuarioDb>();
        services.AddScoped<ITipoDispositivoDb, TipoDispositivoDb>();
        services.AddScoped<ITipoDispositivoFinderService, TipoDispositivoFinderService>();
        services.AddScoped<ITipoDispositivoRegisterService, TipoDispositivoRegisterService>();
        services.AddScoped<ITipoDispositivoUpdateService, TipoDispositivoUpdateService>();

        services.AddScoped<IUsuarioDb, UsuarioDb>();
        services.AddScoped<IUsuarioFinderService, UsuarioFinderService>();
        services.AddScoped<IUsuarioRegisterService, UsuarioRegisterService>();
        services.AddScoped<IUsuarioUpdateService, UsuarioUpdateService>();

        services.AddScoped<IJwtTokenGeneratorService, JwtTokenGeneratorService>();
        services.AddScoped<IJwtTokenRefresherService, JwtTokenRefresherService>();
        services.AddScoped<ICryptographyService, CryptographyService>();
        services.AddTransient<IClaimsIdentityBuilder, ClaimsIdentityBuilder>();
        services.AddTransient<IJwtTokenBuilder, JwtTokenBuilder>();
        services.AddTransient<ISecurityTokenDescriptorBuilder, SecurityTokenDescriptorBuilder>();

        services.AddScoped<IPerfilDb, PerfilDb>();
        services.AddScoped<IPerfilFinderService, PerfilFinderService>();
        services.AddScoped<IPerfilRegisterService, PerfilRegisterService>();
        services.AddScoped<IPerfilUpdateService, PerfilUpdateService>();

        services.AddScoped<IDispositivoMarcaDb, DispositivoMarcaDb>();
        services.AddScoped<IDispositivoMarcaFinderService, DispositivoMarcaFinderService>();
        services.AddScoped<IDispositivoMarcaRegisterService, DispositivoMarcaRegisterService>();
        services.AddScoped<IDispositivoMarcaUpdateService, DispositivoMarcaUpdateService>();
        
        services.AddScoped<IDispositivoModeloDb, DispositivoModeloDb>();
        services.AddScoped<IDispositivoModeloFinderService, DispositivoModeloFinderService>();
        services.AddScoped<IDispositivoModeloRegisterService, DispositivoModeloRegisterService>();
        services.AddScoped<IDispositivoModeloUpdateService, DispositivoModeloUpdateService>();
        
        services.AddScoped<IRepository, Repository>();
        services.AddTransient<IRandomPasswordGenerator, RandomPasswordGenerator>();
        services.AddTransient<ITimeProvider, TimeProvider>();
        services.AddScoped<
            IEntityFactory<TipoDispositivo,TipoDispositivoRequestDto>,
            EntityFactory<TipoDispositivo,TipoDispositivoRequestDto>
        >();
    }
}