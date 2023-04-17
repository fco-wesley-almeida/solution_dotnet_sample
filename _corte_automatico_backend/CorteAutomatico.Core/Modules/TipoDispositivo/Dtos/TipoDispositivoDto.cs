namespace CorteAutomatico.Core.Modules.TipoDispositivo.Dtos;

public class TipoDispositivoDto
{
    public Guid Uuid { get; set; }
    public string Nome { get; set; } = null!;
    public string CriadoPor { get; set; } = null!;
    public DateTime CriadoEm { get; set; }
    public string ModificadoPor { get; set; } = null!;
    public DateTime ModificadoEm { get; set; }
    public bool Ativo { get; set; }

    public TipoDispositivoDto()
    {
        
    }

    public TipoDispositivoDto(Core.Entities.TipoDispositivo tipoDispositivo)
    {
        Uuid = tipoDispositivo.Uuid;
        Nome = tipoDispositivo.Nome;
        CriadoPor = tipoDispositivo.CriadoPor;
        CriadoEm = tipoDispositivo.CriadoEm;
        ModificadoPor = tipoDispositivo.ModificadoPor;
        ModificadoEm = tipoDispositivo.ModificadoEm;
        Ativo = tipoDispositivo.Ativo;
    }
}