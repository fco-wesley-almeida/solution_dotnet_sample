using System;
using System.Runtime.InteropServices;
using CorteAutomatico.Core.DatabaseContext;
using CorteAutomatico.Core.Modules.Jwt.Models;
using CorteAutomatico.Tests.DatabasePreConditions;
using Microsoft.EntityFrameworkCore;

// using ServiceCollectionExtensions;
namespace CorteAutomatico.Tests.Fixtures;

public class JwtContextFixture
{
    public readonly JwtContext JwtContext;

    public JwtContextFixture()
    {
        JwtContext = new()
        {
            UsuarioId = Faker.RandomNumber.Next(1,int.MaxValue),
            UsuarioUuid = Guid.NewGuid(),
            Login = Faker.Name.First() + "." + Faker.Name.Last(),
            PerfilId = Faker.RandomNumber.Next(1,int.MaxValue),
            RefreshToken = Faker.Lorem.GetFirstWord(),
            RefreshTokenExpiration = DateTime.Now.AddDays(1),
        };
    }
}