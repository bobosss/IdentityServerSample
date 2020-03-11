using System;
using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// City Business Model
    /// </summary>
    /// <remarks>
    /// regarding geonames.org City data (with population over 1000 [most we could get])
    /// </remarks>
    public class City : EntityWithError
    {

        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// GeoNameId 
        /// </summary>
        /// <remarks>
        /// id in geonames.org db
        /// </remarks>
        public int GeoNameId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ascii Name
        /// </summary>
        public string AsciiName { get; set; }

        /// <summary>
        /// Alternate Names
        /// </summary>
        public string AlternateNames { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// Feature Class Code
        /// </summary>
        public string FeatureClassCode { get; set; }

        /// <summary>
        /// Feature Code
        /// </summary>
        public string FeatureCode { get; set; }

        /// <summary>
        /// Country Code (ISO-3166-2)
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Country Codes Alternate
        /// </summary>
        public string CountryCodesAlternate { get; set; }

        /// <summary>
        /// Geographical Division 1 Code
        /// </summary>
        /// <remarks>
        /// provided by geonames.org
        /// </remarks>
        public string GeoDivision1Code { get; set; }

        /// <summary>
        /// Geographical Division 2 Code
        /// </summary>
        /// <remarks>
        /// provided by geonames.org
        /// </remarks>
        public string GeoDivision2Code { get; set; }

        /// <summary>
        /// Geographical Division 3 Code
        /// </summary>
        /// <remarks>
        /// not provided by geonames.org (perhaps not needed at this point)
        /// </remarks>
        public string GeoDivision3Code { get; set; }

        /// <summary>
        /// Geographical Division 4 Code
        /// </summary>
        /// <remarks>
        /// not provided by geonames.org (perhaps not needed at this point)
        /// </remarks>
        public string GeoDivision4Code { get; set; }

        /// <summary>
        /// Population
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// Elevation
        /// </summary>
        public int? Elevation { get; set; }

        /// <summary>
        /// Digital Elevation Model
        /// </summary>
        public int DigitalElevationModel { get; set; }

        /// <summary>
        /// Timezone
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// geonames.org Modification Date
        /// </summary>
        public DateTime GeoModificationDate { get; set; }
    }
}
