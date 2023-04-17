namespace CorteAutomatico.Core.Modules.Perfil.Dtos;

public class PerfilDto
{
    public PerfilDto()
    {
    }
    public PerfilDto(Core.Entities.Perfil perfil)
    {
        Uuid = perfil.Uuid;
        Nome = perfil.Nome;
        CriadoPor = perfil.CriadoPor;
        CriadoEm = perfil.CriadoEm;
        ModificadoPor = perfil.ModificadoPor;
        ModificadoEm = perfil.ModificadoEm;
        Ativo = perfil.Ativo;
    }

    public Guid Uuid { get; set; }

    public string Nome { get; set; } = null!;

    public string CriadoPor { get; set; } = null!;

    public DateTime CriadoEm { get; set; }

    public string ModificadoPor { get; set; } = null!;

    public DateTime ModificadoEm { get; set; }

    public bool Ativo { get; set; }
}