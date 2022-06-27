using System.ComponentModel;

namespace OPSWebServicesAPIBase.Models
{
    /// <summary>
    /// Streets full information
    /// </summary>
    public class StreetFullInfo
    {
        /// <summary>
        /// street identification number
        /// </summary>
        [DisplayName("streetId")]
        public int streetId { get; set; }
        /// <summary>
        /// street name
        /// </summary>
        [DisplayName("street")]
        public string street { get; set; }
    }
}