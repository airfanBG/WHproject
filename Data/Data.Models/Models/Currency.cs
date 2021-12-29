using System;
using System.Collections.Generic;
using Utils.Infrastructure.Interfaces.Models;

namespace Data.Models
{
    /// <summary>
    /// Lookup table containing standard ISO currencies.
    /// </summary>
    public class Currency : BaseModel
    {
        public Currency()
        {
            CountryRegionCurrencies = new HashSet<CountryRegionCurrency>();
            CurrencyRateFromCurrencyCodeNavigations = new HashSet<CurrencyRate>();
            CurrencyRateToCurrencyCodeNavigations = new HashSet<CurrencyRate>();
        }

        /// <summary>
        /// The ISO code for the Currency.
        /// </summary>
        public string CurrencyCode { get; set; } = null!;
        /// <summary>
        /// Currency name.
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
      //  public DateTime ModifiedDate { get; set; }

        public ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        public ICollection<CurrencyRate> CurrencyRateFromCurrencyCodeNavigations { get; set; }
        public ICollection<CurrencyRate> CurrencyRateToCurrencyCodeNavigations { get; set; }
    }
}
