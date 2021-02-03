using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CummingsAssessment.Models
{
    public class BondTransfer
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        [Required]
        [MaxLength(20)]
        public string SerialNumber { get; set; }
    }
}