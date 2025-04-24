using NexGen.Repository.Leads;

namespace NexGen.CRM.ViewModel
{
    public class LeadActivityVM
    {
        public EntityLeads entityLeads { get; set; } = new EntityLeads();
        public EntityLeadActivities entityLeadActivities { get; set; } = new EntityLeadActivities();
        //public List<ManufacturingDetails> manufacturingdetailslist { get; set; }
    }
}
