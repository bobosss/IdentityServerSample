using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Country Business Model
    /// </summary>
    /// <remarks>
    /// regarding geonames.org Country data
    /// </remarks>
    [DataContract]
    public class Country : EntityWithError
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Country Code (ISO-3166-2)
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Country Code as in ISO-3166-3
        /// </summary>
        [DataMember]
        public string CodeISO3 { get; set; }

        /// <summary>
        /// Country Code as in ISO-3166-1 (numeric)
        /// </summary>
        [DataMember]
        public int CodeISONum { get; set; }

        /// <summary>
        /// Country FIPS Code
        /// </summary>
        [DataMember]
        public string FipsCode { get; set; }
        
        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Capital
        /// </summary>
        [DataMember]
        public string Capital { get; set; }

        /// <summary>
        /// Area
        /// </summary>
        [DataMember]
        public decimal Area { get; set; }

        /// <summary>
        /// Population
        /// </summary>
        [DataMember]
        public int Population { get; set; }

        /// <summary>
        /// Continent Code
        /// </summary>
        [DataMember]
        public string ContinentCode { get; set; }

        /// <summary>
        /// Country Top-level domain Code
        /// </summary>
        [DataMember]
        public string TldCode { get; set; }

        /// <summary>
        /// Currency Code
        /// </summary>
        [DataMember]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Currency Name
        /// </summary>
        [DataMember]
        public string CurrencyName { get; set; }

        /// <summary>
        /// Phone Prefix
        /// </summary>
        [DataMember]
        public string PhonePrefix { get; set; }

        /// <summary>
        /// Postal Code Format
        /// </summary>
        [DataMember]
        public string PostalCodeFormat { get; set; }

        /// <summary>
        /// Postal Code Regex
        /// </summary>
        [DataMember]
        public string PostalCodeRegex { get; set; }

        /// <summary>
        /// Languages
        /// </summary>
        /// <remarks>
        /// as comma-separated language codes
        /// </remarks>
        [DataMember]
        public string Languages { get; set; }

        /// <summary>
        /// GeoNameId in geonames.org db
        /// </summary>
        [DataMember]
        public int GeoNameId { get; set; }

        /// <summary>
        /// Neighbours
        /// </summary>
        /// <remarks>
        /// as comma-separated country codes
        /// </remarks>
        [DataMember]
        public string Neighbours { get; set; }

        /// <summary>
        /// Equivalent FIPS Code
        /// </summary>
        [DataMember]
        public string EquivalentFipsCode { get; set; }

        /// <summary>
        /// Nationality
        /// </summary>
        /// <remarks>
        /// added later (see AUD-65, originally not in geonames.org data)
        /// </remarks>
        [DataMember]
        public string Nationality { get; set; }
    }
}
