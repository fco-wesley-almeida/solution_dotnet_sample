using System;
using System.Collections.Generic;
using CorteAutomatico.Core.Entities;

namespace CorteAutomatico.Tests.DatabasePreConditions;

public class PerfilSeeder:Seeder<Perfil>
{
    public const int ActivePerfils = 50;
    public const int InactivePerfils = 22;
    public static int TotalPerfils = ActivePerfils + InactivePerfils;
    public override IEnumerable<Perfil> Seeds()
    {
        for (int i = 0; i < ActivePerfils + InactivePerfils; i++)
        {
            yield return new Perfil()
            {
                Id = i + 1,
                Uuid = Guid.NewGuid(),
                Nome = Faker.Name.FullName(),
                CriadoPor = $"{Faker.Name.First()}.{Faker.Name.Last()}",
                CriadoEm = DateTime.Now,
                ModificadoPor  = $"{Faker.Name.First()}.{Faker.Name.Last()}",
                ModificadoEm = DateTime.Now,
                Ativo = i < ActivePerfils,
            };
        }
    }
}