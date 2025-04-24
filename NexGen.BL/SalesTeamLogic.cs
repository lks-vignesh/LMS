using Microsoft.SqlServer.Management.Smo;
using NexGen.BL.Assessment;
using NexGen.DAL;
using NexGen.DAL.Common;
using NexGen.Logging;
using NexGen.Repository;
using NexGen.Repository.Leads;
using NexGen.Repository.SalesTeam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.BL
{
    public class SalesTeamLogic
    {
        public EntitySalesTeam GetSalesTeamTeam(string EMailID)
        {
            ReturnData objReturn = new ReturnData();
            EntitySalesTeam objGetData = new EntitySalesTeam();
            try
            {
                DataSalesTeam objAccess = new DataSalesTeam();
                objGetData = objAccess.GetSalesTeam(EMailID);
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
        public EntitySalesTeam GetActiveSalesTeamTeam(string EMailID)
        {
            ReturnData objReturn = new ReturnData();
            EntitySalesTeam objGetData = new EntitySalesTeam();
            try
            {
                DataSalesTeam objAccess = new DataSalesTeam();
                objGetData = objAccess.GetActiveSalesTeam(EMailID);
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
        public List<EntitySalesTeam> GetAssessmentCompletedSalesTeam()
        {
            ReturnData objReturn = new ReturnData();
            List<EntitySalesTeam> objGetData = new List<EntitySalesTeam>();
            try
            {
                DataSalesTeam objAccess = new DataSalesTeam();
                objGetData = objAccess.GetAssessmentCompletedSalesTeam();
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
        public List<CountrywiseSalesTeam> GetCountrywiseSalesTeam()
        {
            ReturnData objReturn = new ReturnData();
            List<CountrywiseSalesTeam> objGetData = new List<CountrywiseSalesTeam>();
            try
            {
                DataSalesTeam objAccess = new DataSalesTeam();
                objGetData = objAccess.GetCountrywiseSalesTeam();
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
        public List<RegionwiseSalesTeam> GetRegionwiseSalesTeam()
        {
            ReturnData objReturn = new ReturnData();
            List<RegionwiseSalesTeam> objGetData = new List<RegionwiseSalesTeam>();
            try
            {
                DataSalesTeam objAccess = new DataSalesTeam();
                objGetData = objAccess.GetRegionwiseSalesTeam();
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
        public int InsertSalesTeamTeam(EntitySalesTeam entity)
        {
            ReturnData objReturn = new ReturnData();
            int objGetData = 0;
            try
            {
                DataSalesTeam objAccess = new DataSalesTeam();
                objGetData = objAccess.InsertSalesTeam(entity);
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
        public int UpdateSalesTeam(EntitySalesTeam entity)
        {
            ReturnData objReturn = new ReturnData();
            int objGetData = 0;
            try
            {
                DataSalesTeam objAccess = new DataSalesTeam();
                objGetData = objAccess.UpdateSalesTeam(entity);
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
        public int UpdateSalesTeamSimplexStatus(EntitySalesTeam entity)
        {
            ReturnData objReturn = new ReturnData();
            int objGetData = 0;
            try
            {
                DataSalesTeam objAccess = new DataSalesTeam();
                objGetData = objAccess.UpdateSalesTeamSimplexStatus(entity);
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
        public int UpdateEmpanelmentConfirmation(EntitySalesTeam entity)
        {
            ReturnData objReturn = new ReturnData();
            int objGetData = 0;
            try
            {
                DataSalesTeam objAccess = new DataSalesTeam();
                objGetData = objAccess.UpdateEmpanelmentConfirmation(entity);
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
        public string GenerateAuthCode()
        {
            Random random = new Random();
            string combination = "0123456789";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);

            return captcha.ToString();
        }
        public void SendAuthCode(string Name, string PersonalMailID, string AuthCode)
        {
            ReturnClass lst = new ReturnClass();
            try
            {

                string Subject = "Euro Exim Bank - Auth Code!";

                string Head = "<b>Dear " + Name + ",</b>";
                Head += "<br>";
                Head += "<br>";
                Head += "Please find the below Auth Code for Euro Exim Bank - Helpdesk Portal";
                Head += "<br>";
                Head += "<br/>";
                Head += "<b> " + AuthCode + " </b> ";
                lst.Body = Head;
                lst.FromName = "no-reply@euroeximbank-sales.com";
                lst.Subject = Subject.Totitlecase();
                lst.ToList = PersonalMailID;
                //lst.ToList = "Vigneshwaran@trdfin.in";
                //lst.CCList = "Vigneshwaran@trdfin.in";
                lst.Priority = "M";
                string resultResponse = MailConfig.SendEEBMail(lst);

            }
            catch (Exception ex)
            {

            }

        }
    }
}
