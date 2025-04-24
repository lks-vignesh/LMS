using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository.Leads
{
    public class EntityLeadRequest
    {
        public int LeadRequestId { get; set; }
        public int? CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreationDate { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string? RequestNumber { get; set; }
        public string RequestedMailID { get; set; }
        public string Country { get; set; }
        public string? Status { get; set; }
    }
}
