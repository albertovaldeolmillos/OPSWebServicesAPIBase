﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OPSWebServicesAPIBase.Models
{
    /// <summary>
    /// class to request User recharge credit
    /// </summary>
    public class UserRechargeQuery
    {
        /// <summary>
        /// (*) id del municipio
        /// </summary>
        [DisplayName("contid")]
        [Required]
        public int contractId { get; set; }
        /// <summary>
        /// (*) Cloud token
        /// </summary>
        [DisplayName("cid")]
        [Required]
        public string cloudToken { get; set; }
        /// <summary>
        /// (*) Authentication token
        /// </summary>
        //[DisplayName("mui")]
        //[Required]
        //public string authorizationToken { get; set; }
        /// <summary>
        /// (*) OS --> 1- Android 2- iOS 3- web
        /// </summary>
        [DisplayName("os")]
        [Required]
        public int operatingSystem { get; set; }
        /// <summary>
        /// (*) Amount (expressed in Euro cents)
        /// </summary>
        [DisplayName("am")]
        [Required]
        public int amount { get; set; }
        /// <summary>
        /// Simulate Sermepa response (0 = false, 1 = true) --- Optional and only for testing
        /// </summary>
        [DisplayName("sim")]
        public int simulate { get; set; }
        /// <summary>
        /// hash
        /// </summary>
        [DisplayName("ah")]
        public string authenticationHash { get; set; }
        /// <summary>
        /// (*) tipo de operación: 1: tarjeta nueva, 109: tarjeta anterior
        /// </summary>
        [DisplayName("op")]
        [Required]
        public int operation { get; set; }
    }
}