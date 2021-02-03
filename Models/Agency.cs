using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CummingsAssessment.Models
{
    public class Agency
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string AgentName { get; set; }

        [Required]
        [MaxLength(100)]
        public string AgencyName { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Phone]
        public string MobileNumber { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string State { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }
    }
}