﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OPSWebServicesAPIBase.Models
{
    /// <summary>
    /// class to request streets
    /// </summary>
    public class StreetsQuery
    {
        /// <summary>
        /// (*) Contract ID
        /// </summary>
        [DisplayName("contid")]
        [Required]
        public int contractId { get; set; }
    }
}