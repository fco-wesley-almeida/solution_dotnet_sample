namespace CorteAutomatico.Core.ApplicationModels;

public interface IBuilder<out T>
{
    public T Build();
}