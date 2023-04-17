using System.Collections;
using System.Collections.Generic;
using CorteAutomatico.Core.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace CorteAutomatico.Tests.DatabasePreConditions;

public abstract class Seeder<T> where T: IEntity
{
    protected Bogus.Faker BogusFaker = new("pt_BR");
    public abstract IEnumerable<T> Seeds();

}