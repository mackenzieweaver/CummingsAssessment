using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CummingsAssessment.Models
{
    public class AgreementViewModel
    {
        public ProvidingAgency ProvidingAgency { get; set; }
        public Jail Jail { get; set; }
        public BondTransfer BondTransfer { get; set; }
        public RequestingAgency RequestingAgency { get; set; }
        public Defendant Defendant { get; set; }
        public Indemnitor Indemnitor { get; set; }
        [MaxLength(100)]
        public string AdditionalInformation { get; set; }
    }
}