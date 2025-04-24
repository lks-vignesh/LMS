using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository.Onboarding
{
    public class EntityApplicant
    {
        public int ApplicantId { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string? ApplicantNo { get; set; }
        public int RequestBy { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? Constitution { get; set; }
        public string? Application_stage { get; set; }
        public string? Status { get; set; }
        public string? ApprovalStatus { get; set; }
        public bool Customer { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? ReSubmittedDate { get; set; }

        public DateTime? VerificationDate { get; set; }
        public string? VerificationStatus { get; set; }
        public string? VerificationRemarks { get; set; }
        public int VerifiedBy { get; set; }
        public DateTime? Approver1Date { get; set; }
        public string? Approver1Status { get; set; }
        public string? Approver1Remarks { get; set; }
        public int Approval1By { get; set; }


        public DateTime? Approver2Date { get; set; }
        public string? Approver2Status { get; set; }
        public string? Approver2Remarks { get; set; }
        public int Approval2By { get; set; }
        public string? Remarks { get; set; }
        public string? EmplanelmentNumber { get; set; }
        public string? SuggestedEMailID { get; set; }
        public string? SimplexFileRefNo { get; set; }
        public int SalesAgentID { get; set; }
        public int MailNotification { get; set; }
        public int NoOfRevert { get; set; }
        public string? OnboardingStatus { get; set; }
        public string? DocumentStatus { get; set; }
        public DateTime? DocumentUploadedOn { get; set; }
        public int DocumentUploadedBy { get; set; }
    }
}
