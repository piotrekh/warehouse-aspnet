using System.Collections.Generic;

namespace Warehouse.Domain.Common.Models
{
    public class ItemsResult<T>
    {
        public List<T> Items { get; set; }
    }
}
