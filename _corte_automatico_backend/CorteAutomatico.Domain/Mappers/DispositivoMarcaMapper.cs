using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Entities;
using CorteAutomatico.Core.Modules.DispositivoMarca.Dtos;

namespace CorteAutomatico.Domain.Mappers;

public static class DispositivoMarcaMapper
{
    public static DispositivoMarca MapForRegister(
        this DispositivoMarca dispositivoMarca,
        ICommand<DispositivoMarcaRequestDto> command
    )
    {
        dispositivoMarca.Nome = command.Data.Nome;
        dispositivoMarca.Ativo = true;
        dispositivoMarca.SetDefaultRegisterFields(command);
        return dispositivoMarca;
    }

    public static DispositivoMarca MapForUpdate(
        this DispositivoMarca dispositivoMarca,
        ICommand<DispositivoMarcaRequestDto> command
    )
    {
        dispositivoMarca.Nome = command.Data.Nome;
        dispositivoMarca.Ativo = command.Data.Ativo;
        dispositivoMarca.SetDefaultUpdateFields(command);
        return dispositivoMarca;
    }
    
}