using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Lookup table containing the ISO standard codes for countries and regions.
    /// </summary>
    public class CountryRegion: BaseModel
    {
        public CountryRegion()
        {
            CountryRegionCurrencies = new HashSet<CountryRegionCurrency>();
            SalesTerritories = new HashSet<SalesTerritory>();
            StateProvinces = new HashSet<StateProvince>();
        }

        /// <summary>
        /// ISO standard code for countries and regions.
        /// </summary>
        public string CountryRegionCode { get; set; } = null!;
        /// <summary>
        /// Country or region name.
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
      //  public DateTime ModifiedDate { get; set; }

        public ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        public ICollection<SalesTerritory> SalesTerritories { get; set; }
        public ICollection<StateProvince> StateProvinces { get; set; }
    }
}
