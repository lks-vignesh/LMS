using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository.Leads
{
    public class EntityLeadActivities
    {
        public int LeadActivityId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public EntityLeads LeadId { get; set; }

        public DateTime? ContactDate { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string FollowUpStage { get; set; }
        public string NoOfLeads { get; set; }
        public string LeadStatus { get; set; }
        public string Remarks { get; set; }
        public bool Active { get; set; }
    }
}
