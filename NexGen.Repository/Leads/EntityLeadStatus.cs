using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository.Leads
{
    public class EntityLeadStatus
    {
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string Lead_status { get; set; }
        public string Followup_Stage { get; set; }
    }
}
