using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NexGen.API.ViewModels;
using NexGen.BL;
using NexGen.Repository.Leads;
using System.Data;

namespace NexGen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentTeamController : ControllerBase
    {
        private readonly ILogger<RecruitmentTeamController> _logger;

        public RecruitmentTeamController(ILogger<RecruitmentTeamController> logger)
        {
            _logger = logger;
        }
        [HttpPost(Name = "GetRecruitmentTeam")]
        //[Route("/RecruitmentTeam/GetRecruitmentTeam/")]
        public IActionResult Get(string EMailID)
        {
            EntityRecruitmentTeam recruitmentTeam = new EntityRecruitmentTeam();

            RecruitmentTeamLogic logic = new RecruitmentTeamLogic();
            recruitmentTeam=logic.GetRecruitmentTeam(EMailID);

            JsonSerializer ser = new JsonSerializer();
            string jsonresp = JsonConvert.SerializeObject(recruitmentTeam);

            return Ok(jsonresp);
        }
    }
}
