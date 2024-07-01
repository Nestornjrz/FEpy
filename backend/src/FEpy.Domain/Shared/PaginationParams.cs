﻿
namespace FEpy.Domain.Shared
{
    /// <summary>
    /// Es casi lo mismo que <see cref="SpecificationEntry"/> pero este solo se usa para paginacion
    /// usando metodos genericos y no el patron specification
    /// </summary>
    public record PaginationParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 2;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string? OrderBy { get; set; }
        public bool OrderAsc { get; set; } = true;  
        public string? Search { get; set; }

    }
}
