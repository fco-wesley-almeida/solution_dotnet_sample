using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorteAutomatico.Core.Modules.DispositivoMarca.Dtos;

public class DispositivoMarcaDto
{
    public DispositivoMarcaDto()
    {
    }

    public DispositivoMarcaDto(Entities.DispositivoMarca dispositivoMarca)
    {
        Uuid = dispositivoMarca.Uuid;
        Nome = dispositivoMarca.Nome;
        TipoDispositivoUuid = dispositivoMarca.TipoDispositivo.Uuid;
        TipoDispositivoNome = dispositivoMarca.TipoDispositivo.Nome;
        CriadoPor = dispositivoMarca.CriadoPor;
        CriadoEm = dispositivoMarca.CriadoEm;
        ModificadoPor = dispositivoMarca.ModificadoPor;
        ModificadoEm = dispositivoMarca.ModificadoEm;
        Ativo = dispositivoMarca.Ativo;
    }
    
    public Guid Uuid { get; set; }
    public string Nome { get; set; } = null!;
    public Guid TipoDispositivoUuid { get; set; }
    public string TipoDispositivoNome { get; set; } = null!;
    public string CriadoPor { get; set; } = null!;
    public DateTime CriadoEm { get; set; }
    public string ModificadoPor { get; set; } = null!;
    public DateTime ModificadoEm { get; set; }
    public bool Ativo { get; set; }

}