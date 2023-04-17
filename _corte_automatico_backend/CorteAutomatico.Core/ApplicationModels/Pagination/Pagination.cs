namespace CorteAutomatico.Core.ApplicationModels.Pagination;

public class Pagination
{
    public int Page { get; }
    public int PerPage { get; }
    public int? Total { get; set; }
    public const int MaxPerPage = 1000;

    public Pagination(int page, int perPage)
    {
        if (page <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(page), "Page must to be positive.");
        }
        switch (perPage)
        {
            case <= 0:
                throw new ArgumentOutOfRangeException(nameof(perPage), "PerPage must to be positive.");
            case >= MaxPerPage:
                throw new ArgumentOutOfRangeException(nameof(perPage), $"PerPage must to lesser than {MaxPerPage}.");
        }
        Page = page;
        PerPage = perPage;
        Total = null;
    }

    public static IPaginationBuilder Builder()
    {
        return new PaginationBuilder();
    }

    public Pagination SetTotal(int total)
    {
        if (Total is not null)
        {
            throw new InvalidOperationException();
        }
        Total = total;
        return this;
    }

    public int Limit() => PerPage;
    public int Offset() => (Page - 1) * PerPage;
}