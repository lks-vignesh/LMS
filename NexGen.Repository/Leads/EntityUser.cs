using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository.Leads
{
    public class EntityUser
    {
        public int UserId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool EmailNotification { get; set; }
        public bool Active { get; set; }
    }
}
