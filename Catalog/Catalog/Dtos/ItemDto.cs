using System;

namespace Catalog.Dtos
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
