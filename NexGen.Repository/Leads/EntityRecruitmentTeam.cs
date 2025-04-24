using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository.Leads
{
    public class EntityRecruitmentTeam
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string EMailID { get; set; }
        public string Designation { get; set; }
        public string MobileNumber { get; set; }
        public bool Active { get; set; }
    }
}
