using System.Text.RegularExpressions;
using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Entities;
using CorteAutomatico.Core.Modules.Usuario.Dtos;

namespace CorteAutomatico.Domain.Mappers;

public static class UsuarioMapper
{
    public static Usuario MapForRegister(this Usuario usuario, ICommand<UsuarioRequestDto> command)
    {
        usuario.Nome = command.Data.Nome;
        usuario.Login = command.Data.Login;
        usuario.Cpf = Regex.Replace(command.Data.Cpf, @"\D", "");;
        usuario.Ativo = true;
        usuario.Email = command.Data.Email;
        usuario.EmailConfirmado = true;
        usuario.EmailConfirmacaoToken = null;
        usuario.EmailConfirmacaoExpiraEm = null;
        usuario.SetDefaultRegisterFields(command);
        return usuario;
    }
    
    public static Usuario MapForUpdate(this Usuario usuario, ICommand<UsuarioRequestDto> command)
    {
        usuario.Nome = command.Data.Nome;
        usuario.Ativo = command.Data.Ativo;
        usuario.EmailConfirmado = command.Data.EmailConfirmado;
        usuario.SetDefaultUpdateFields(command);
        return usuario;
    }
}