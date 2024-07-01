using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEpy.Domain.Abstractions;

namespace FEpy.Domain.Shared;

public class PaginationResult<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TEntityId : class
{
    public int Count { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public IReadOnlyList<TEntity>? Data { get; set; }
    public int PageCount { get; set; }
    public int ResultByPage { get; set; }
}
