﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OPSWebServicesAPIBase.Models
{
    /// <summary>
    /// class to request place
    /// </summary>
    public class PlaceQuery
    {
        /// <summary>
        /// (*) Contract ID
        /// </summary>
        [DisplayName("contid")]
        [Required]
        public int contractId { get; set; }
        /// <summary>
        /// (*) Street name
        /// </summary>
        [DisplayName("streetname")]
        [Required]
        public string streetname { get; set; }
        /// <summary>
        /// Street number
        /// </summary>
        [DisplayName("streetno")]
        public string streetno { get; set; }
    }
}