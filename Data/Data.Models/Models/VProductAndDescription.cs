using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Product names and descriptions. Product descriptions are provided in multiple languages.
    /// </summary>
    public class VProductAndDescription : IBaseModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string ProductModel { get; set; } = null!;
        public string CultureId { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
