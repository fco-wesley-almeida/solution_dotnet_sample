namespace CorteAutomatico.Core.Modules.DispositivoModelo.Dtos;

public class DispositivoModeloDto
{
    public DispositivoModeloDto()
    {
    }

    public DispositivoModeloDto(Entities.DispositivoModelo dispositivoModelo)
    {
        Uuid = dispositivoModelo.Uuid;
        Nome = dispositivoModelo.Nome;
        DispositivoMarcaUuid = dispositivoModelo.DispositivoMarca.Uuid;
        DispositivoMarcaNome = dispositivoModelo.DispositivoMarca.Nome;
        DispositivoTipoUuid = dispositivoModelo.DispositivoMarca.TipoDispositivo.Uuid;
        DispositivoTipoNome = dispositivoModelo.DispositivoMarca.TipoDispositivo.Nome;
        Compativel = dispositivoModelo.Compativel;
        QuantidadeFases = dispositivoModelo.QuantidadeFases;
        CriadoPor = dispositivoModelo.CriadoPor;
        CriadoEm = dispositivoModelo.CriadoEm;
        ModificadoPor = dispositivoModelo.ModificadoPor;
        ModificadoEm = dispositivoModelo.ModificadoEm;
        Ativo = dispositivoModelo.Ativo;
    }

    public Guid Uuid { get; set; }
    public string Nome { get; set; } = null!;
    public Guid DispositivoMarcaUuid { get; set; }
    public string DispositivoMarcaNome { get; set; } = null!;
    public Guid DispositivoTipoUuid { get; set; }
    public string DispositivoTipoNome { get; set; } = null!;
    public bool Compativel { get; set; }
    public int QuantidadeFases { get; set; }
    public string CriadoPor { get; set; } = null!;
    public DateTime CriadoEm { get; set; }
    public string ModificadoPor { get; set; } = null!;
    public DateTime ModificadoEm { get; set; }
    public bool Ativo { get; set; }
}