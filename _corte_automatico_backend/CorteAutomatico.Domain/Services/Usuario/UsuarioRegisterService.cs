using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Entities;
using CorteAutomatico.Core.Exceptions;
using CorteAutomatico.Core.Modules.Authentication.Queries;
using CorteAutomatico.Core.Modules.Authentication.Services;
using CorteAutomatico.Core.Modules.Usuario.Dtos;
using CorteAutomatico.Core.Modules.Usuario.Services;
using CorteAutomatico.Core.Repositories;
using CorteAutomatico.Domain.Mappers;

namespace CorteAutomatico.Domain.Services.Usuario;

public class UsuarioRegisterService: IUsuarioRegisterService
{
    private readonly IRepository _repository;
    private readonly IUsuarioDb _usuarioDb;
    private readonly IRandomPasswordGenerator _randomPasswordGenerator;

    private const int RandomPasswordExpirationTimeInMinutes = 60;
    private Command<UsuarioRequestDto> _command = null!;
    public UsuarioRegisterService(IRepository repository, IUsuarioDb usuarioDb, IRandomPasswordGenerator randomPasswordGenerator, IUsuarioFinderService usuarioFinderService)
    {
        _repository = repository;
        _usuarioDb = usuarioDb;
        _randomPasswordGenerator = randomPasswordGenerator;
    }

    public async Task<UsuarioDto> RegisterAsync(Command<UsuarioRequestDto> command)
    {
        _command = command;
        var usuario = Usuario();
        await Validate(usuario);
        usuario.UsuarioSenhas.Add(UsuarioSenha());
        var perfil = await Perfil();
        usuario.PerfilId = perfil.Id;
        await _repository.InsertAsync(usuario);
        return (await _usuarioDb.FindByUuid(usuario.Uuid))!;
    }
    
    private async Task Validate(Core.Entities.Usuario usuario)
    {
        if (await _usuarioDb.ExistsWithSameEmailAsync(usuario.Email))
        {
            throw new BadRequestException("Já existe um usuário ativo com esse mesmo email.");
        }
        if (await _usuarioDb.ExistsWithSameLoginAsync(usuario.Login))
        {
            throw new BadRequestException("Já existe um usuário ativo com esse mesmo login.");
        }
        if (await _usuarioDb.ExistsWithSameCpfAsync(usuario.Cpf))
        {
            throw new BadRequestException("Já existe um usuário ativo com esse mesmo CPF.");
        }       
    }

    private Core.Entities.Usuario Usuario()
    {
        return new Core.Entities.Usuario().MapForRegister(_command);
    }

    private async Task<Core.Entities.Perfil> Perfil()
    {
        return await _repository.FindByUuidAsync<Core.Entities.Perfil>(_command.Data.PerfilUuid)
                     ?? throw new BadRequestException("Esse perfil não existe.");
    }

    private UsuarioSenha UsuarioSenha()
    {
         UsuarioSenha usuarioSenha = new()
         {
             Senha = _randomPasswordGenerator.Generate(),
             DataExpiracao = DateTime.Now.AddMinutes(RandomPasswordExpirationTimeInMinutes),
         };
         usuarioSenha.SetDefaultRegisterFields(_command);
         return usuarioSenha;
    }
}