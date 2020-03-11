using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Stores address data for which ever entity needs it
    /// </summary>
    /// <remarks>
    /// Proper Datacontract Namespace is located in AssemblyInfo.cs file. Namespace is equal to relative Client Side Model
    /// </remarks>
    public class Address : EntityWithError
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Address Type
        /// </summary>
        /// <remarks>
        /// from lookup
        /// </remarks>
        public string AddressType { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Street number
        /// </summary>
        public string StreetNo { get; set; }
        /// <summary>
        /// Postal Code
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// Area
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        /// <remarks>
        /// from geodata
        /// </remarks>
        public string Country { get; set; }
        /// <summary>
        /// GeoDivision1
        /// </summary>
        /// <remarks>
        /// from geodata
        /// </remarks>
        public string GeoDivision1 { get; set; }
        /// <summary>
        /// GeoDivision2
        /// </summary>
        /// <remarks>
        /// from geodata
        /// </remarks>
        public string GeoDivision2 { get; set; }
        /// <summary>
        /// City
        /// </summary>
        /// <remarks>
        /// from geodata
        /// </remarks>
        public string City { get; set; }
    }
}