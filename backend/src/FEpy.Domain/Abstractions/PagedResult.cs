namespace FEpy.Domain.Abstractions;
/// <summary>
/// Esta clase que debuelve un dato pagina usa la paginacion con metodo genericos, no es lo mismo que 
/// <see cref="PaginationResult"/> que es una clase que se usa para devolver datos paginados
/// usando el patron Specification
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TEntityId"></typeparam>
public class PagedResults<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TEntityId : class
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalNumberOfPages { get; set; }
    public int TotalNumberOfRecords { get; set; }
    public List<TEntity> Results { get; set; } = new List<TEntity>();
}
