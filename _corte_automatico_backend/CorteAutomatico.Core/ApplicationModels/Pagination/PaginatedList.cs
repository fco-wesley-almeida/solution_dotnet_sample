namespace CorteAutomatico.Core.ApplicationModels.Pagination;

public class PaginatedList<T>
{
   public Pagination? Pagination { get; } 
   public List<T> List { get; }
   
   public PaginatedList(IEnumerable<T> list, Pagination pagination)
   {
      Pagination = pagination ?? throw new ArgumentNullException(nameof(pagination));
      List = (List<T>) list ?? throw new ArgumentNullException(nameof(list));
   }
   
   public PaginatedList(IEnumerable<T> list)
   {
      List = (List<T>) list ?? throw new ArgumentNullException(nameof(list));
   }
}