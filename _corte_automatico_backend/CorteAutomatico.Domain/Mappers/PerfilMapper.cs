using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Entities;
using CorteAutomatico.Core.Modules.Perfil.Dtos;

namespace CorteAutomatico.Domain.Mappers;

public static class PerfilMapper
{
    public static Perfil MapForRegister(this Perfil perfil, ICommand<PerfilRequestDto> command)
    {
        perfil.Nome = command.Data.Nome;
        perfil.Ativo = true;
        perfil.SetDefaultRegisterFields(command);
        return perfil;
    }
    
    public static Perfil MapForUpdate(this Perfil perfil, ICommand<PerfilRequestDto> command)
    {
        perfil.Nome = command.Data.Nome;
        perfil.Ativo = command.Data.Ativo;
        perfil.SetDefaultUpdateFields(command);
        return perfil;
    }
}