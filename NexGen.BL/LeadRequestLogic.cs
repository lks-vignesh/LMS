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
    public class LeadRequestLogic
    {
        public IReturn InsertLeadRequest(EntityLeadRequest objInsertData)
        {
            ReturnData objReturn = new ReturnData();
            DataLeadRequest objAccess = new DataLeadRequest();
            try
            {
                //objReturn = Validate(objInsertData);
                if (objReturn.GetValidateStatus() == true)
                {
                    if (objReturn.GetValidateStatus() == true)
                    {
                        int result = objAccess.InsertLeadRequest(objInsertData);
                        objReturn.AddPrimaryId(result);

                    }
                }
            }

            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
                Logger.ErrorLog("Error Message: " + ex.Message);
                Logger.ErrorLog("Stack Trace: " + ex.StackTrace);
            }
            IReturn obj = (IReturn)objReturn;
            return obj;
        }
    }
}
