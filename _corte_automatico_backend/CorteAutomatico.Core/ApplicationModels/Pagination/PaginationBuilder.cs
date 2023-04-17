namespace CorteAutomatico.Core.ApplicationModels.Pagination;

public class PaginationBuilder: IPaginationBuilder
{
    private int? _page = null;
    private int? _perPage = null;
    public IPaginationBuilder SetPage(int? page)
    {
        _page = page;
        return this;
    }

    public IPaginationBuilder SetPerPage(int? perPage)
    {
        _perPage = perPage;
        return this;
    }
    
    public Pagination? Build()
    {
        if (_page is null || _perPage is null)
        {
            return null;
        }
        return new Pagination(_page ?? 0, _perPage ?? 0);
    }
}