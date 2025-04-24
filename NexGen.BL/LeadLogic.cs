
using NexGen.DAL;
using NexGen.Logging;
using NexGen.Repository;
using NexGen.Repository.Leads;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.BL
{
    public class LeadLogic
    {
        
        public IReturn InsertLead(EntityLeads objInsertData)
        {
            ReturnData objReturn = new ReturnData();
            DataLead objAccess = new DataLead();
            try
            {
                //objReturn = Validate(objInsertData);
                if (objReturn.GetValidateStatus() == true)
                {
                    if (objReturn.GetValidateStatus() == true)
                    {
                        int result = objAccess.InsertLead(objInsertData);
                        objReturn.AddPrimaryId(result);

                         


                         //EntityLeads objLeads = objAccess.GetMaxID(result);

                        //EntityLeadActivities objLeadActivities = new EntityLeadActivities();
                        //objLeadActivities.CreatedBy = objInsertData.CreatedBy;
                        //objLeadActivities.CreationDate = objInsertData.CreationDate;
                        //objLeadActivities.LeadId = objLeads;
                        //objLeadActivities.Stage = "Lead Assigned";

                        //int results = objAccess.InsertLeadAct(objLeadActivities);
                        //objReturn.AddPrimaryId(results);
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
        public IReturn UpdateLead(EntityLeads objInsertData)
        {
            ReturnData objReturn = new ReturnData();
            DataLead objAccess = new DataLead();
            try
            {
                //objReturn = Validate(objInsertData);
                if (objReturn.GetValidateStatus() == true)
                {
                    if (objReturn.GetValidateStatus() == true)
                    {
                        int result = objAccess.UpdateLead(objInsertData);
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
        public IReturn EnableRemainderNotification(int LeadID)
        {
            ReturnData objReturn = new ReturnData();
            DataLead objAccess = new DataLead();
            try
            {
                //objReturn = Validate(objInsertData);
                if (objReturn.GetValidateStatus() == true)
                {
                    if (objReturn.GetValidateStatus() == true)
                    {
                        int result = objAccess.EnableRemainderNotification(LeadID);
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
        public IReturn DisableRemainderNotification(int LeadID)
        {
            ReturnData objReturn = new ReturnData();
            DataLead objAccess = new DataLead();
            try
            {
                //objReturn = Validate(objInsertData);
                if (objReturn.GetValidateStatus() == true)
                {
                    if (objReturn.GetValidateStatus() == true)
                    {
                        int result = objAccess.DisableRemainderNotification(LeadID);
                        objReturn.AddPrimaryId(result);
                    }
                }
            }

            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
              
            }
            IReturn obj = (IReturn)objReturn;
            return obj;
        }
        public IReturn UpdateLeadReAssign(EntityLeads objInsertData)
        {
            ReturnData objReturn = new ReturnData();
            DataLead objAccess = new DataLead();
            try
            {
                //objReturn = Validate(objInsertData);
                if (objReturn.GetValidateStatus() == true)
                {
                    if (objReturn.GetValidateStatus() == true)
                    {
                        int result = objAccess.UpdateLeadReAssign(objInsertData);
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
        public List<EntityLeads> GetLeads(int AssignedTo)
        {
            ReturnData objReturn = new ReturnData();
            List<EntityLeads> objGetData = new List<EntityLeads>();
            try
            {
                DataLead objAccess = new DataLead();
                objGetData = objAccess.GetLeads(AssignedTo);
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
        public List<EntityLeads> GetLeads_NoActivity()
        {
            ReturnData objReturn = new ReturnData();
            List<EntityLeads> objGetData = new List<EntityLeads>();
            try
            {
                DataLead objAccess = new DataLead();
                objGetData = objAccess.GetLeads_NoActivity();
            }
            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
                //Logger.ErrorLog("Error Message: " + ex.Message);
                //Logger.ErrorLog("Stack Trace: " + ex.StackTrace);
                Console.WriteLine("Er: " + ex.Message);
               
            }
            return objGetData;
        }
        public List<EntityLeads> GetLeads_Followup()
        {
            ReturnData objReturn = new ReturnData();
            List<EntityLeads> objGetData = new List<EntityLeads>();
            try
            {
                DataLead objAccess = new DataLead();
                objGetData = objAccess.GetLeads_Followup();
            }
            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
                //Logger.ErrorLog("Error Message: " + ex.Message);
                //Logger.ErrorLog("Stack Trace: " + ex.StackTrace);
                Console.WriteLine("Er: " + ex.Message);

            }
            return objGetData;
        }
        public List<EntityLeads> GetLeadsActivities(int AssignedTo)
        {
            ReturnData objReturn = new ReturnData();
            List<EntityLeads> objGetData = new List<EntityLeads>();
            try
            {
                DataLead objAccess = new DataLead();
                objGetData = objAccess.GetLeadsActivities(AssignedTo);
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

        public List<EntityLeadActivities> GetLeadStatusCount(int UserID)
		{
			ReturnData objReturn = new ReturnData();
			List<EntityLeadActivities> objGetData = new List<EntityLeadActivities>();
			try
			{
				DataLead objAccess = new DataLead();
				objGetData = objAccess.GetLeadStatusCount(UserID);
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
		public List<EntityLeadStatus> GetddlLeadStatus()
        {
            ReturnData objReturn = new ReturnData();
            List<EntityLeadStatus> objGetData = new List<EntityLeadStatus>();
            try
            {
                DataLead objAccess = new DataLead();
                objGetData = objAccess.GetddlLeadStatus();
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
        public DataTable GetLeadsActivitiesExport()
        {
            ReturnData objReturn = new ReturnData();
            DataTable objGetData = new DataTable();
            try
            {
                DataLead objAccess = new DataLead();
                objGetData = objAccess.GetLeadsActivitiesExport();
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

      
        public EntityLeads GetLead(int Id)
        {
            ReturnData objReturn = new ReturnData();
            EntityLeads objGetData = new EntityLeads();
            try
            {
                DataLead objAccess = new DataLead();
                objGetData = objAccess.GetLeadID(Id);
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
        public string GetFollowupstatus(string Followupstage)
        {
            ReturnData objReturn = new ReturnData();
            string objGetData = string.Empty;
            try
            {
                DataLead objAccess = new DataLead();
                objGetData = objAccess.GetLeadStatus(Followupstage);
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
        public IReturn InsertUploadLead(EntityLeads objInsertData)
        {
            ReturnData objReturn = new ReturnData();
            DataLead objAccess = new DataLead();
            try
            {
                //objReturn = Validate(objInsertData);
                if (objReturn.GetValidateStatus() == true)
                {
                    if (objReturn.GetValidateStatus() == true)
                    {
                        int result = objAccess.UploadLead(objInsertData);
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
        
        public List<EntityLeadActivities> GetLeadActivities(int UserID, int LeadID)
        {
            ReturnData objReturn = new ReturnData();
            List<EntityLeadActivities> objGetData = new List<EntityLeadActivities>();
            try
            {
                DataLead objAccess = new DataLead();
                objGetData = objAccess.GetLeadActivities(UserID, LeadID);
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
        public EntityLeadActivities GetLeadActivityID(int Id)
        {
            ReturnData objReturn = new ReturnData();
            EntityLeadActivities objGetData = new EntityLeadActivities();
            try
            {
                DataLead objAccess = new DataLead();
                objGetData = objAccess.GetLeadActivityID(Id);
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
        public IReturn InsertLeadActivity(EntityLeadActivities objInsertData)
        {
            ReturnData objReturn = new ReturnData();
            DataLead objAccess = new DataLead();
            try
            {
                //objReturn = Validate(objInsertData);
                if (objReturn.GetValidateStatus() == true)
                {
                    if (objReturn.GetValidateStatus() == true)
                    {
                        int result = objAccess.InsertLeadActivity(objInsertData);
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
        public Boolean CheckAssignToMail(string EmailID)
        {
            ReturnData objReturn = new ReturnData();
            DataLead objAccess = new DataLead();
            bool EmailCreated = false;
            try
            {
                //objReturn = Validate(objInsertData);
                if (objReturn.GetValidateStatus() == true)
                {
                    if (objReturn.GetValidateStatus() == true)
                    {
                        EmailCreated = objAccess.CheckAssignTo(EmailID);
                        //objReturn.AddPrimaryId(result);
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
            //IReturn obj = (IReturn)objReturn;
            return EmailCreated;
        }
        public Boolean CheckEmaiID(string EmailID)
        {
            ReturnData objReturn = new ReturnData();
            DataLead objAccess = new DataLead();
            bool EmailCreated=false;
            try
            {
                //objReturn = Validate(objInsertData);
                if (objReturn.GetValidateStatus() == true)
                {
                    if (objReturn.GetValidateStatus() == true)
                    {
                        EmailCreated = objAccess.CheckEMailID(EmailID);
                        //objReturn.AddPrimaryId(result);
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
            //IReturn obj = (IReturn)objReturn;
            return EmailCreated;
        }
    }
}
