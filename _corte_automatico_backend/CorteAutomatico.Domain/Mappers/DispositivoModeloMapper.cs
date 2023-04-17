using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Entities;
using CorteAutomatico.Core.Modules.DispositivoModelo.Dtos;

namespace CorteAutomatico.Domain.Mappers;

public static class DispositivoModeloMapper
{
    public static DispositivoModelo MapForRegister(
        this DispositivoModelo dispositivoModelo,
        ICommand<DispositivoModeloRequestDto> command
    )
    {
        dispositivoModelo.Nome = command.Data.Nome;
        dispositivoModelo.Compativel = command.Data.Compativel;
        dispositivoModelo.QuantidadeFases = command.Data.QuantidadeFases;
        dispositivoModelo.Ativo = true;
        dispositivoModelo.SetDefaultRegisterFields(command);
        return dispositivoModelo;
    }

    public static DispositivoModelo MapForUpdate(
        this DispositivoModelo dispositivoModelo,
        ICommand<DispositivoModeloRequestDto> command
    )
    {
        dispositivoModelo.Nome = command.Data.Nome;
        dispositivoModelo.Compativel = command.Data.Compativel;
        dispositivoModelo.QuantidadeFases = command.Data.QuantidadeFases;
        dispositivoModelo.Ativo = command.Data.Ativo;
        dispositivoModelo.SetDefaultUpdateFields(command);
        return dispositivoModelo;
    }
}