﻿using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Uses PIVOT to return aggregated sales information for each sales representative.
    /// </summary>
    public class VSalesPersonSalesByFiscalYear : BaseModel
    {
        public int? SalesPersonId { get; set; }
        public string? FullName { get; set; }
        public string JobTitle { get; set; } = null!;
        public string SalesTerritory { get; set; } = null!;
        public decimal? _2002 { get; set; }
        public decimal? _2003 { get; set; }
        public decimal? _2004 { get; set; }
    }
}
