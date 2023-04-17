using System;
using System.Collections;
using System.Collections.Generic;
using Bogus.Extensions.Brazil;
using CorteAutomatico.Core.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace CorteAutomatico.Tests.DatabasePreConditions;

public class UsuarioSeeder: Seeder<Usuario>
{
    public const int  ActiveUsuarios = 1000;
    public const int  InactiveUsuarios = 500;
    public static int TotalUsuarios => ActiveUsuarios + InactiveUsuarios;

    public override IEnumerable<Usuario> Seeds()
    {
        for (int i = 0; i < TotalUsuarios; i++)
        {
            yield return new Usuario()
            {
                Id = i + 1,
                Uuid = Guid.NewGuid(),
                Nome = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                Login = $"{Faker.Name.First()}.{Faker.Name.Last()}",
                PerfilId = Faker.RandomNumber.Next(1, PerfilSeeder.ActivePerfils),
                Cpf  = BogusFaker.Person.Cpf(),
                EmailConfirmado = Faker.Boolean.Random(),
                EmailConfirmacaoToken = Guid.NewGuid().ToString(),
                EmailConfirmacaoExpiraEm = BogusFaker.Date.Future(),
                CriadoPor = $"{Faker.Name.First()}.{Faker.Name.Last()}",
                CriadoEm = DateTime.Now,
                ModificadoPor  = $"{Faker.Name.First()}.{Faker.Name.Last()}",
                ModificadoEm = DateTime.Now,
                Ativo = i < ActiveUsuarios,
            };
        }
    }
}