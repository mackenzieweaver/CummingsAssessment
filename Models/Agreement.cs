using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CummingsAssessment.Models;

namespace CummingsAssessment.Models
{
    public class Agreement
    {
        public int Id { get; set; }

        public int ProvidingAgencyId { get; set; }
        public int JailId { get; set; }
        public int BondTransferId { get; set; }
        public int RequestingAgencyId { get; set; }
        public int DefendantId { get; set; }
        public int IndemnitorId { get; set; }

        public ProvidingAgency ProvidingAgency { get; set; }
        public Jail Jail { get; set; }
        public BondTransfer BondTransfer { get; set; }
        public RequestingAgency RequestingAgency { get; set; }
        public Defendant Defendant { get; set; }
        public Indemnitor Indemnitor { get; set; }

        [MaxLength(1000)]
        public string AdditionalInformation { get; set; }
    }
}