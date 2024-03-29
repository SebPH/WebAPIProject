﻿using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public class CreateItemDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 1000)]
        public decimal Price { get; set; }
    }
}
