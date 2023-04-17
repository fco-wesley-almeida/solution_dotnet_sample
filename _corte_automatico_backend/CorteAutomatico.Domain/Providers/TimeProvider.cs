using CorteAutomatico.Core.ApplicationModels;

namespace CorteAutomatico.Domain.Providers;

public class TimeProvider: ITimeProvider
{
    public DateTime Now() => DateTime.Now;
}