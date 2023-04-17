

using CorteAutomatico.Core.ApplicationModels;
using CorteAutomatico.Core.ApplicationModels.Command;
using CorteAutomatico.Core.Modules.Jwt.Models;

namespace CorteAutomatico.Core.Entities;
using System.Security.Claims;
public static class EntityExtensions
{
    public static void SetDefaultRegisterFields<T>(this IEntity entity, ICommand<T> command)
    {
        entity.Id = 0;
        entity.Uuid = Guid.NewGuid();
        entity.CriadoPor = command.JwtContext.Login;
        entity.CriadoEm = DateTime.Now;
        entity.ModificadoPor = command.JwtContext.Login;
        entity.ModificadoEm = DateTime.Now;
        entity.Ativo = true;
    }
    
    public static void SetDefaultUpdateFields<T>(this IEntity entity, ICommand<T> command)
    {
        entity.ModificadoPor = command.JwtContext.Login;
        entity.ModificadoEm = DateTime.Now;
    }
}