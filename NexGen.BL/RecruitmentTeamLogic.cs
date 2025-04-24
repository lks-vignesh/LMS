using NexGen.DAL;
using NexGen.Logging;
using NexGen.Repository;
using NexGen.Repository.Leads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.BL
{
    public class RecruitmentTeamLogic
    {
        public EntityRecruitmentTeam GetRecruitmentTeam(string EMailID)
        {
            ReturnData objReturn = new ReturnData();
            EntityRecruitmentTeam objGetData = new EntityRecruitmentTeam();
            try
            {
                DataRecruitmentTeam objAccess = new DataRecruitmentTeam();
                objGetData = objAccess.GetRecruitmentTeam(EMailID);
            }
            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
                Logger.ErrorLog("Error Message: " + ex.Message);
                Logger.ErrorLog("Stack Trace: " + ex.StackTrace);
            }
            return objGetData;
        }
    }
}
