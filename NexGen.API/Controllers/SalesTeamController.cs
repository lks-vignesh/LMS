using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NexGen.BL;
using NexGen.Repository.Leads;

namespace NexGen.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Produces("application/json")]
    public class SalesTeamController : ControllerBase
    {
        private readonly ILogger<RecruitmentTeamController> _logger;
        public SalesTeamController(ILogger<RecruitmentTeamController> logger)
        {
            _logger = logger;
        }
        [HttpPost(Name = "GetSalesTeam")]
        
        //[Route("/SalesTeam/GetSalesTeam/")]
        public IActionResult GetSalesTeam([FromBody] EntitySalesTeam value)
        {
            EntitySalesTeam salesTeam = new EntitySalesTeam();

            SalesTeamLogic logic = new SalesTeamLogic();
            if (value != null)
                salesTeam = logic.GetSalesTeamTeam(value.OfficialMailId);

            //JsonSerializer ser = new JsonSerializer();
            //var jsonresp = JsonConvert.SerializeObject(salesTeam);

            return new JsonResult(salesTeam);
        }
        [HttpPost(Name = "GetAssessmentCompletedSalesTeam")]

        //[Route("/SalesTeam/GetSalesTeam/")]
        public IActionResult GetAssessmentCompletedSalesTeam()
        {
            List<EntitySalesTeam> salesTeam = new List<EntitySalesTeam>();

            SalesTeamLogic logic = new SalesTeamLogic();
            salesTeam = logic.GetAssessmentCompletedSalesTeam();
            JsonSerializer ser = new JsonSerializer();
            var jsonresp = JsonConvert.SerializeObject(salesTeam);

            return new JsonResult(salesTeam);
        }
        [HttpPost(Name = "InsertSalesTeam")]
        //[Route("/SalesTeam/InsertSalesTeam/")]
        public IActionResult InsertSalesTeam([FromBody] EntitySalesTeam value)
        {
            EntitySalesTeam salesTeam = new EntitySalesTeam();
            int i = 0;
            SalesTeamLogic logic = new SalesTeamLogic();
            if (value != null)
            {
                EntitySalesTeam entitySalesTeam = logic.GetSalesTeamTeam(value.OfficialMailId);
                if(entitySalesTeam==null)
                    i = logic.InsertSalesTeamTeam(value);
                else
                    i = logic.UpdateSalesTeam(value);
            }

            //JsonSerializer ser = new JsonSerializer();
            //var jsonresp = JsonConvert.SerializeObject(salesTeam);

            return new JsonResult("Data Updated Successfully!");
        }
        [HttpPost(Name = "UpdateSalesTeam")]
        //[Route("/SalesTeam/InsertSalesTeam/")]
        public IActionResult UpdateSalesTeam([FromBody] EntitySalesTeam value)
        {
            EntitySalesTeam salesTeam = new EntitySalesTeam();
            int i = 0;
            SalesTeamLogic logic = new SalesTeamLogic();
            if (value != null)
                i = logic.UpdateSalesTeam(value);

            //JsonSerializer ser = new JsonSerializer();
            //var jsonresp = JsonConvert.SerializeObject(salesTeam);

            return new JsonResult("Data Updated Successfully!");
        }
        [HttpPost(Name = "UpdateSalesTeamSimplexStatus")]
        //[Route("/SalesTeam/InsertSalesTeam/")]
        public IActionResult UpdateSalesTeamSimplexStatus([FromBody] EntitySalesTeam value)
        {
            EntitySalesTeam salesTeam = new EntitySalesTeam();
            int i = 0;
            SalesTeamLogic logic = new SalesTeamLogic();
            if (value != null)
                i = logic.UpdateSalesTeamSimplexStatus(value);

            //JsonSerializer ser = new JsonSerializer();
            //var jsonresp = JsonConvert.SerializeObject(salesTeam);

            return new JsonResult("Data Updated Successfully!");
        }
        [HttpPost(Name = "UpdateEmpanelmentConfirmation")]
        //[Route("/SalesTeam/InsertSalesTeam/")]
        public IActionResult UpdateEmpanelmentConfirmation([FromBody] EntitySalesTeam value)
        {
            EntitySalesTeam salesTeam = new EntitySalesTeam();
            int i = 0;
            SalesTeamLogic logic = new SalesTeamLogic();
            if (value != null)
                i = logic.UpdateEmpanelmentConfirmation(value);
            return new JsonResult("Data Updated Successfully!");
        }
    }
}
