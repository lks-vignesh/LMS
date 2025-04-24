using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository.Leads
{
    public class EntitySalesTeam
    {
        //public int SalesTeamID { get; set; }
        //public int CreatedBy { get; set; }
        //public DateTime CreationDate { get; set; }
        //public int? LastUpdateBy { get; set; }
        //public DateTime? LastUpdateDate { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? EmpanelmentNumber { get; set; }
        public string? Designation { get; set; }
        public string? OfficialMailId { get; set; }
        public string? PesonalMailId { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmpanelmentStatus { get; set; }
        public string? DigiSignStatus { get; set; }
        public string? EMailStatus { get; set; }
        public string? SimplexStatus { get; set; }
        public string? Country { get; set; }
        public int? ReportingTo { get; set; }
        public string? ReportingName { get; set; }
        public string? ReportingMailID { get; set; }
        public string? eBusinessCard { get; set; }
        public string? DefaultPassword { get; set; }
        public bool? EmailNotification { get; set; }
        public bool? Active { get; set; }
    }
}
