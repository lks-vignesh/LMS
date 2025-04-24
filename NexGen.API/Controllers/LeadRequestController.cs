using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NexGen.BL;
using NexGen.Repository.Leads;

namespace NexGen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadRequestController : ControllerBase
    {
        private readonly ILogger<LeadRequestController> _logger;

        public LeadRequestController(ILogger<LeadRequestController> logger)
        {
            _logger = logger;
        }
        [HttpPost(Name = "InsertLeadRequest")]
        //[Route("/RecruitmentTeam/GetRecruitmentTeam/")]
        public IActionResult Put([FromBody] EntityLeadRequest value)
        {
            LeadRequestLogic logic = new LeadRequestLogic();
            logic.InsertLeadRequest(value);

            return Ok(1);
        }

    }
}
