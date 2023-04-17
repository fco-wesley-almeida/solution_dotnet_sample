namespace CorteAutomatico.Core.ApplicationModels;

public class Search
{
    private readonly string _search;
    public const int MinLength = 3;
    public const int MaxLength = 100;

    public Search(string search)
    {
        if (string.IsNullOrEmpty(search))
        {
            throw new ArgumentNullException(nameof(search));
        }
        _search = search.Length switch {
              < MinLength => throw new ArgumentOutOfRangeException(nameof(search),
                  "The search length must to be at least " + MinLength + "."),
              > MaxLength => throw new ArgumentOutOfRangeException(nameof(search),
                  "The search max length is " + MaxLength + "."),
              _ => search
          };
    }

    public override string ToString()
    {
        return $"%{_search}%";
    }
}