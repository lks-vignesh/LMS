using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository.Leads
{
    public class EntityLeads
    {
        public int LeadId { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
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
        public int AssignedTo { get; set; }
        public string AssignedTo_MailID { get; set; }
        public string AdditionalInformation { get; set; }
        public string WhatsAppNumber { get; set; }
        public string InstrumentIssuanceTimeline { get; set; }
        public string AnnualRequirement { get; set; }
        public string AnnualTurnOver { get; set; }
        public string IntrumentType { get; set; }
        public string AlternativeMobileNumber { get; set; }
        public string AlternateEmail { get; set; }
        public string AlternateCompanyName { get; set; }
        public DateTime? LeadSourceDate { get; set; }
        public DateTime? AssignedDate { get; set; }
        public bool Active { get; set; }


        #region Lead Activities

        public List<EntityLeadActivities> leadActivities { get; set; }

        public DateTime? ContactDate { get; set; }
        public DateTime? Follow_upDate { get; set; }
        public string FollowUpStage { get; set; }
        public string Remarks { get; set; }
        public string LeadStatus { get; set; }

        public string SourceDate
        {
            get
            {
                return LeadSourceDate != null ? LeadSourceDate.Value.ToShortDateString() : "";
            }
        }

        public string AssignDate
        {
            get
            {
                return AssignedDate != null ? AssignedDate.Value.ToShortDateString() : "";
            }
        }

        #endregion
    }
}
