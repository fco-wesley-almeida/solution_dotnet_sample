namespace CorteAutomatico.Core.Modules.DispositivoMarca.Dtos;

public class DispositivoMarcaFilter
{
    public Guid TipoDispositivoUuid { get; }
    
    public DispositivoMarcaFilter(Guid tipoDispositivoUuid)
    {
        TipoDispositivoUuid = tipoDispositivoUuid;
    }

}