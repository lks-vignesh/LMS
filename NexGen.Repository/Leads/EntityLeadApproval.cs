using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository.Leads
{
    public class EntityLeadApproval
    {
        public int LeadApprovalId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string Company_Name { get; set; }
        public string EnquiryNumber { get; set; }
        public string Company_Details { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Sector { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public string LeadSource { get; set; }
        public string InstrumentValue { get; set; }
        public string AssingedTo { get; set; }
        public string CallCenterComments { get; set; }
        public bool Active { get; set; }
    }
}
