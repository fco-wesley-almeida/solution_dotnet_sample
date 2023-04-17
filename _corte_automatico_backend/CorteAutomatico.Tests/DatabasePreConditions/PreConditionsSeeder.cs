using CorteAutomatico.Core.DatabaseContext;
using CorteAutomatico.Core.Entities;

namespace CorteAutomatico.Tests.DatabasePreConditions;

public class PreConditionsSeeder
{
    public static void CreatePreConditions(CorteAutomaticoContext context)
    {
        context.Perfils.AddRange(new PerfilSeeder().Seeds());
        context.Usuarios.AddRange(new UsuarioSeeder().Seeds());
        context.UsuarioSenhas.AddRange(new UsuarioSenhaSeeder().Seeds());
        context.TipoDispositivos.AddRange(new TipoDispositivoSeeder().Seeds());
    }
}