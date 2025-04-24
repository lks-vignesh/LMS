using NexGen.Repository.Assessment;
using NexGen.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexGen.DAL.Assessment;
using Microsoft.Identity.Client;
using System.Net.Mail;
using System.Net;
using Microsoft.SqlServer.Management.Smo;
using NexGen.DAL.Common;

namespace NexGen.BL.Assessment
{
    public class AssessmentLogic
    {
        #region Assessment logic functions
        public void SendAuthCode(string Name, string PersonalMailID, string AuthCode)
        {
            ReturnClass lst = new ReturnClass();
            try
            {

                string Subject = "Euro Exim Bank - Assessment Auth Code!";

                string Head = "<b>Dear " + Name + ",</b>";
                Head += "<br>";
                Head += "<br>";
                Head += "Please find the below Auth Code for Euro Exim Bank - Assessment Portal";
                Head += "<br>";
                Head += "<br/>";
                Head += "<b> " + AuthCode + " </b> ";
                lst.Body = Head;
                lst.FromName = "noreply@nexgenrecruit.com";
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
        //protected void OTP_ReSendMail(string FirstName, string LastName, String MailId, string OTP)
        //{
        //    ReturnClass lst = new ReturnClass();
        //    try
        //    {

        //        string Subject = "New Lead Assigned!";

        //        string Head = "<b>Dear " + user.Name + ",</b>";
        //        Head += "<br>";
        //        Head += "<br>";
        //        Head += "We have assigned new leads to your Lead Management Portal. Kindly login to your Lead Management Portal with your credentials and access the leads.";
        //        Head += "<br>";
        //        Head += "<br/>";
        //        Head += "<b> Lead Management Portal </b> " + "<a href=\"" + "https://leads.euroeximbank.com" + "\"> Click Here </a>" + "";
        //        Head += "<br/>";
        //        Head += "<br/>";
        //        Head += "Steps to follow for Marketing Leads,";
        //        Head += "<br/>";
        //        Head += "*\tYou have to open the Nexgen Portal (with the help of above link).";
        //        Head += "<br/>";
        //        Head += "*\tLogin with your account details.";
        //        Head += "<br/>";
        //        Head += "*\tClick The lead Activities tab in left column";
        //        Head += "<br/>";
        //        Head += "*\tClick edit button -> scroll down Update the Contact date, follow up date & Follow up stage.";
        //        Head += "<br/>";
        //        Head += "*\tUpdate your action comments in the remarks column.";
        //        Head += "<br/>";
        //        Head += "*\tClick the update button in the bottom right to save the lead status.";
        //        Head += "<br/>";
        //        Head += "*\tConnect the prospects via (email, call, WhatsApp, telegram, SMS, or social media) and guide them with their requirements.";
        //        Head += "<br/>";
        //        Head += "<br/>";
        //        Head += "<b>" + "For support regarding Lead Management Portal:</b>";
        //        Head += "<br>";
        //        Head += "<br>";
        //        Head += "" + "User related issues, write a mail to syed.a@trdfin.in & MarketingTrdfin@trdfin.in";
        //        Head += "<br>";
        //        Head += "<br>";
        //        Head += "<div style=\"background-color: yellow;\"><b>" + "Note: If there is no update on your leads for more than 72 hrs, your leads will be reallocated to another active sales representative.</b></div>";
        //        lst.Body = Head;
        //        lst.FromName = "noreply@nexgenrecruit.com";
        //        lst.Subject = Subject.Totitlecase();
        //        lst.ToList = user.EmailId;
        //        //lst.ToList = "Vigneshwaran@trdfin.in";
        //        //lst.CCList = "Vigneshwaran@trdfin.in";
        //        lst.Priority = "M";
        //        string resultResponse = MailConfig.SendMail(lst);


        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}
        public List<EntityAssessmentQuestions> GetEntityAssessmentQuestions()
        {
            ReturnData objReturn = new ReturnData();
            List<EntityAssessmentQuestions> objGetData = new List<EntityAssessmentQuestions>();
            try
            {
                DataAssessment objAccess = new DataAssessment();
                objGetData = objAccess.GetAssessmentQuestions();

            }
            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
            }
            return objGetData;
        }
        #endregion


        public List<EntityAssessmentResults> GetAssessmentResults()
        {
            ReturnData objReturn = new ReturnData();
            List<EntityAssessmentResults> objGetData = new List<EntityAssessmentResults>();
            try
            {
                DataAssessment objAccess = new DataAssessment();
                objGetData = objAccess.GetAssessmentResults();

            }
            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
            }
            return objGetData;
        }
        public List<EntityAssessmentResults> GetTFPAssessmentResults(string EmpanelmentNumber)
        {
            ReturnData objReturn = new ReturnData();
            List<EntityAssessmentResults> objGetData = new List<EntityAssessmentResults>();
            try
            {
                DataAssessment objAccess = new DataAssessment();
                objGetData = objAccess.GetTFPAssessmentResults(EmpanelmentNumber);

            }
            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
            }
            return objGetData;
        }
        public void UpdateAssessmentPercentage(string EmpanelmentNumber)
        {
            ReturnData objReturn = new ReturnData();
            try
            {
                DataAssessment objAccess = new DataAssessment();
                objAccess.UpdateAssessmentPercentage(EmpanelmentNumber);

            }
            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
            }
            
        }
        public string GetAnswerLogic(int Key, string Value)
        {
            string result = string.Empty;

            try
            {
                DataAssessment objAccess = new DataAssessment();
                result = objAccess.GetAnswer(Key, Value);
            }
            catch (Exception ex)
            {

            }

            return result;
        }
        public IReturn InsertResultLogic(EntityAssessmentResults entityQAResults)
        {
            ReturnData objReturn = new ReturnData();
            DataAssessment objAccess = new DataAssessment();
            try
            {
                //objReturn = Validate(objInsertData);
                if (objReturn.GetValidateStatus() == true)
                {
                    if (objReturn.GetValidateStatus() == true)
                    {
                        int result = objAccess.InsertAssessmentResults(entityQAResults);
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
        public void InsertAssessmentHistoryLogic(EntityAssessmentHistory entity)
        {
            ReturnData objReturn = new ReturnData();

            try
            {
                DataAssessment objAccess = new DataAssessment();
                objAccess.InsertAssessmentHistory(entity);
            }
            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
                //Logger.ErrorLog("Error Message: " + ex.Message);
                //Logger.ErrorLog("Stack Trace: " + ex.StackTrace);
            }
        }
        public EntityAssessmentResults GetAssessmentResults(int Id)
        {
            ReturnData objReturn = new ReturnData();
            EntityAssessmentResults objGetData = new EntityAssessmentResults();
            try
            {
                DataAssessment objAccess = new DataAssessment();
                objGetData = objAccess.GetAssessmentResultId(Id);
            }
            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
                //Logger.ErrorLog("Error Message: " + ex.Message);
                //Logger.ErrorLog("Stack Trace: " + ex.StackTrace);
            }
            return objGetData;
        }
        public EntityAssessmentResults GetLatestAssessmentResult(string EmpanelmentNumber)
        {
            ReturnData objReturn = new ReturnData();
            EntityAssessmentResults objGetData = new EntityAssessmentResults();
            try
            {
                DataAssessment objAccess = new DataAssessment();
                objGetData = objAccess.GetLatestAssessmentResult(EmpanelmentNumber);
            }
            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
                //Logger.ErrorLog("Error Message: " + ex.Message);
                //Logger.ErrorLog("Stack Trace: " + ex.StackTrace);
            }
            return objGetData;
        }
        public List<EntityAssessmentHistory> GetAssessmentHistory(int Id)
        {
            ReturnData objReturn = new ReturnData();
            List<EntityAssessmentHistory> objGetData = new List<EntityAssessmentHistory>();
            try
            {
                DataAssessment objAccess = new DataAssessment();
                objGetData = objAccess.GetAssessmentHistory(Id);
            }
            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
                //Logger.ErrorLog("Error Message: " + ex.Message);
                //Logger.ErrorLog("Stack Trace: " + ex.StackTrace);
            }
            return objGetData;
        }
    }
}
