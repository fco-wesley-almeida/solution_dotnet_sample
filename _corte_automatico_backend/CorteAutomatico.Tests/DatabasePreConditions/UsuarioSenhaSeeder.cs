using System;
using System.Collections.Generic;
using CorteAutomatico.Core.Entities;

namespace CorteAutomatico.Tests.DatabasePreConditions;

public class UsuarioSenhaSeeder: Seeder<UsuarioSenha>
{
    public const int ActiveUsuarioSenhas = 1000;
    public const int InactiveUsuarioSenhas = 500;
    public override IEnumerable<UsuarioSenha> Seeds()
    {
        for (int i = 0; i < ActiveUsuarioSenhas + InactiveUsuarioSenhas; i++)
        {
            yield return new UsuarioSenha()
            {
                Id = i + 1,
                Uuid = Guid.NewGuid(),
                DataExpiracao = BogusFaker.Date.Future(),
                UsuarioId = i + 1,
                Senha = Guid.NewGuid().ToString(),
                CriadoPor = $"{Faker.Name.First()}.{Faker.Name.Last()}",
                CriadoEm = DateTime.Now,
                ModificadoPor  = $"{Faker.Name.First()}.{Faker.Name.Last()}",
                ModificadoEm = DateTime.Now,
                Ativo = i < ActiveUsuarioSenhas,
            };
        }
    }
}