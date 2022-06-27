﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OPSWebServicesAPIBase.Models
{
    /// <summary>
    /// class to request parking status
    /// </summary>
    public class ParkingStatusQuery
    {
        /// <summary>
        /// (*) Contract ID
        /// </summary>
        [DisplayName("contid")]
        [Required]
        public int contractId { get; set; }
        /// <summary>
        /// (*) Plate
        /// </summary>
        [DisplayName("p")]
        [Required]
        public string plate { get; set; }
        /// <summary>
        /// (*) Mobile user id (authorization token)
        /// </summary>
        //[DisplayName("mui")]
        //[Required]
        //public string authorizationToken { get; set; }
        /// <summary>
        /// date in format hh24missddMMYY
        /// </summary>
        [DisplayName("d")]
        public string date { get; set; }
    }
}