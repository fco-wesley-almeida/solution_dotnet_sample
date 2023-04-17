namespace CorteAutomatico.Core.ApplicationModels.Pagination;

public interface IPaginationBuilder: IBuilder<Pagination?>
{
    public IPaginationBuilder SetPage(int? page);
    public IPaginationBuilder SetPerPage(int? perPage);
    public new Pagination? Build();
}