using System;
using System.Collections.Generic;
using CorteAutomatico.Core.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace CorteAutomatico.Tests.DatabasePreConditions;

public class TipoDispositivoSeeder: Seeder<TipoDispositivo>
{
    public const int ActiveTipoDispositivos = 1000;
    public const int InactiveTipoDispositivos = 500;
    public static int TotalTipoDispositivos => ActiveTipoDispositivos + InactiveTipoDispositivos;
    public override IEnumerable<TipoDispositivo> Seeds()
    {
        for (int i = 0; i < TotalTipoDispositivos; i++)
        {
            yield return new TipoDispositivo()
            {
                Id = i + 1,
                Uuid = Guid.NewGuid(),
                Nome = Faker.Name.FullName(),
                CriadoPor = $"{Faker.Name.First()}.{Faker.Name.Last()}",
                CriadoEm = DateTime.Now,
                ModificadoPor  = $"{Faker.Name.First()}.{Faker.Name.Last()}",
                ModificadoEm = DateTime.Now,
                Ativo = i < ActiveTipoDispositivos
            };
        }
    }
}