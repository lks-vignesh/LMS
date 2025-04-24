using Microsoft.SqlServer.Management.Smo;
using NexGen.DAL.Common;
using NexGen.Repository.Leads;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.BL
{
    public class MailLogic
    {
        public void SendAssignedMail(int UserID)
        {
            ReturnClass lst = new ReturnClass();
            try
            {
                UserLogic userLogic = new UserLogic();

                EntityUser user = userLogic.GetUserID(UserID);

                string Subject = "New Lead Assigned!";

                string Head = "<b>Dear " + user.Name + ",</b>";
                Head += "<br>";
                Head += "<br>";
                Head += "We have assigned new leads to your Lead Management Portal. Kindly login to your Lead Management Portal with your credentials and access the leads.";
                Head += "<br>";
                Head += "<br/>";
                Head += "<b> Lead Management Portal </b> " + "<a href=\"" + "https://leads.euroeximbank.com" + "\"> Click Here </a>" + "";
                Head += "<br/>";
                Head += "<br/>";
                Head += "Steps to follow for Marketing Leads,";
                Head += "<br/>";
                Head += "*\tYou have to open the Nexgen Portal (with the help of above link).";
                Head += "<br/>";
                Head += "*\tLogin with your account details.";
                Head += "<br/>";
                Head += "*\tClick The lead Activities tab in left column";
                Head += "<br/>";
                Head += "*\tClick edit button -> scroll down Update the Contact date, follow up date & Follow up stage.";
                Head += "<br/>";
                Head += "*\tUpdate your action comments in the remarks column.";
                Head += "<br/>";
                Head += "*\tClick the update button in the bottom right to save the lead status.";
                Head += "<br/>";
                Head += "*\tConnect the prospects via (email, call, WhatsApp, telegram, SMS, or social media) and guide them with their requirements.";
                Head += "<br/>";
                Head += "<br/>";
                Head += "<b>" + "For support regarding Lead Management Portal:</b>";
                Head += "<br>";
                Head += "<br>";
                Head += "" + "User related issues, write a mail to syed.a@trdfin.in & MarketingTrdfin@trdfin.in";
                Head += "<br>";
                Head += "<br>";
                Head += "<div style=\"background-color: yellow;\"><b>" + "Note: If there is no update on your leads for more than 72 hrs, your leads will be reallocated to another active sales representative.</b></div>";
                lst.Body = Head;
                lst.FromName = "noreply@nexgenrecruit.com";
                lst.Subject = Subject.Totitlecase();
                lst.ToList = user.EmailId;
                //lst.ToList = "Vigneshwaran@trdfin.in";
                //lst.CCList = "Vigneshwaran@trdfin.in";
                lst.Priority = "M";
                string resultResponse = MailConfig.SendMail(lst);
                if (resultResponse == "S")
                {
                    //subtaskEmail.status = ((char)Mail.StatusCode.Success).ToString();
                    //subtaskEmail.responsemessage = ((char)Mail.StatusCode.Success).ToString();
                    //var result = _dbContext.SaveChanges();
                }
                else
                {
                    //subtaskEmail.status = ((char)Mail.StatusCode.Failure).ToString();
                    //subtaskEmail.responsemessage = resultResponse;
                    //var result = _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            Console.WriteLine("End SubTaskCreateEmailNotification");
            Console.WriteLine("******************************");
        }
        public void SendFollowupMail(int UserID)
        {
            ReturnClass lst = new ReturnClass();
            try
            {
                UserLogic userLogic = new UserLogic();

                EntityUser user = userLogic.GetUserID(UserID);

                string Subject = "Lead Followup!";

                string Head = "<b>Dear " + user.Name + ",</b>";
                Head += "<br>";
                Head += "<br>";
                Head += "Please update your lead follow up status for the leads. Kindly login to your Lead Management Portal with your credentials and access the leads.";
                Head += "<br>";
                Head += "<br/>";
                Head += "<b> Lead Management Portal </b> " + "<a href=\"" + "https://leads.euroeximbank.com" + "\"> Click Here </a>" + "";
                Head += "<br/>";
                Head += "<br/>";
                Head += "Please note this is the follow-up reminder, no action on follow-ups with in 72hrs will be consider as untouched leads and we will reallocate those leads to other active sales member.";
                Head += "<br/>";
                Head += "<br/>";
                Head += "Please contact the customer and update the follow-ups ASAP. If you have any challenges in updating the follow-ups in Lead Management Portal, please do let us know.";
                //Head += "<br/>";
                //Head += "<br/>";
                //Head += "<b>" + "For support regarding Lead Management Portal:</b>";
                //Head += "<br>";
                //Head += "<br>";
                //Head += "" + "User related issues, write a mail to helpdesk@nexgenrecruit.com , syed.a@trdfin.in & MarketingTrdfin@trdfin.in";
                //Head += "<br>";
                //Head += "<br>";
                //Head += "<div style=\"background-color: yellow;\"><b>" + "Note: If there is no update on your leads for more than (48)  72 hrs, your leads will be reallocated to another active sales representative.</b></div>";
                lst.Body = Head;
                lst.FromName = "noreply@nexgenrecruit.com";
                lst.Subject = Subject.Totitlecase();
                lst.ToList = user.EmailId;
                //lst.ToList = "Vigneshwaran@trdfin.in";
                //lst.CCList = "Vigneshwaran@trdfin.in";
                lst.Priority = "M";
                string resultResponse = MailConfig.SendMail(lst);
                if (resultResponse == "S")
                {
                    //subtaskEmail.status = ((char)Mail.StatusCode.Success).ToString();
                    //subtaskEmail.responsemessage = ((char)Mail.StatusCode.Success).ToString();
                    //var result = _dbContext.SaveChanges();
                }
                else
                {
                    //subtaskEmail.status = ((char)Mail.StatusCode.Failure).ToString();
                    //subtaskEmail.responsemessage = resultResponse;
                    //var result = _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            Console.WriteLine("End SubTaskCreateEmailNotification");
            Console.WriteLine("******************************");
        }
        public void TestMail(string data)
        {
            ReturnClass lst = new ReturnClass();
            try
            {
                Console.WriteLine("Start EMail Notification");
                Console.WriteLine("******************************");

                string Subject = "Test Mail!" + data;

                string Head = "<b>Dear " + "User" + ",</b>";
                Head += "<br>";
                Head += "<br>";
                Head += "We have unassigned leads which are not attened for More than 48 Hours in your Lead Management Portal. Kindly login to your Lead Management Portal with your credentials and access the portal.";
                Head += "<br>";
                Head += "<br/>";
                Head += "<b> Lead Management Portal </b> " + "<a href=\"" + "https://leads.euroeximbank.com" + "\"> Click Here </a>" + "";
                Head += "<br/>";
                Head += "<br/>";
                Head += "<b>" + "For support regarding Lead Management Portal:</b>";
                Head += "<br>";
                Head += "<br>";
                Head += "" + "User related issues, write a mail to helpdesk@nexgenrecruit.com";
                Head += "<br>";
                Head += "<br>";
                Head += "<div style=\"background-color: yellow;\"><b>" + "Note: If there is no update on your leads for more than 48 hrs, your leads will be reallocated to another active sales representative.</b></div>";
                lst.Body = Head;
                lst.FromName = "noreply@nexgenrecruit.com";
                lst.Subject = Subject.Totitlecase();
                lst.ToList = "Vigneshwaran@trdfin.in";
                //lst.CCList = "Vigneshwaran@trdfin.in";
                lst.Priority = "M";
                string resultResponse = MailConfig.SendMail(lst);
                if (resultResponse == "S")
                {
                    //subtaskEmail.status = ((char)Mail.StatusCode.Success).ToString();
                    //subtaskEmail.responsemessage = ((char)Mail.StatusCode.Success).ToString();
                    //var result = _dbContext.SaveChanges();
                }
                else
                {
                    //subtaskEmail.status = ((char)Mail.StatusCode.Failure).ToString();
                    //subtaskEmail.responsemessage = resultResponse;
                    //var result = _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            Console.WriteLine("End SubTaskCreateEmailNotification");
            Console.WriteLine("******************************");
        }
        public void SendUnAssignedMail(int LeadID, int UserID)
        {
            ReturnClass lst = new ReturnClass();
            try
            {
                UserLogic userLogic = new UserLogic();

                EntityUser user = userLogic.GetUserID(UserID);

                string Subject = "Lead Reallocation Intimation!";

                string Head = "<b>Dear " + user.Name + ",</b>";
                Head += "<br>";
                Head += "<br>";
                Head += "This is to inform you that as instructed in our Wednesday internal training session, we are removing your leads and reallocating the leads which we have not received any follow-ups from your side.";
                Head += "<br>";
                Head += "<br/>";
                Head += "Please note if there is no update on your leads more than 72 hrs your leads will be reallocated to another active sales members. We regret to inform that we stop sharing leads to you until you are active once again.";
                Head += "<br/>";
                Head += "<br/>";
                Head += "Please if you have any concerns about updating the follow-ups or need any assistance kindly do let us know.";
                Head += "<br>";
                Head += "<br>";
                lst.Body = Head;
                lst.FromName = "noreply@nexgenrecruit.com";
                lst.Subject = Subject.Totitlecase();
                lst.ToList = user.EmailId;
                //lst.ToList = "Vigneshwaran@trdfin.in";
                //lst.CCList = "Vigneshwaran@trdfin.in";
                lst.Priority = "M";
                string resultResponse = MailConfig.SendMail(lst);
                if (resultResponse == "S")
                {
                    //subtaskEmail.status = ((char)Mail.StatusCode.Success).ToString();
                    //subtaskEmail.responsemessage = ((char)Mail.StatusCode.Success).ToString();
                    //var result = _dbContext.SaveChanges();
                }
                else
                {
                    //subtaskEmail.status = ((char)Mail.StatusCode.Failure).ToString();
                    //subtaskEmail.responsemessage = resultResponse;
                    //var result = _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            Console.WriteLine("End SubTaskCreateEmailNotification");
            Console.WriteLine("******************************");
        }
        public void SendAuthCode(int SalesTeamID)
        {
            ReturnClass lst = new ReturnClass();
            try
            {
                UserLogic userLogic = new UserLogic();

                EntityUser user = userLogic.GetUserID(SalesTeamID);

                string Subject = "NexGen Assessment Auth Code!";

                string Head = "<b>Dear " + user.Name + ",</b>";
                Head += "<br>";
                Head += "<br>";
                Head += "We have assigned new leads to your Lead Management Portal. Kindly login to your Lead Management Portal with your credentials and access the leads.";
                Head += "<br>";
                Head += "<br/>";
                Head += "<b> Lead Management Portal </b> " + "<a href=\"" + "https://leads.euroeximbank.com" + "\"> Click Here </a>" + "";
                Head += "<br/>";
                Head += "<br/>";
                Head += "Steps to follow for Marketing Leads,";
                Head += "<br/>";
                Head += "*\tYou have to open the Nexgen Portal (with the help of above link).";
                Head += "<br/>";
                Head += "*\tLogin with your account details.";
                Head += "<br/>";
                Head += "*\tClick The lead Activities tab in left column";
                Head += "<br/>";
                Head += "*\tClick edit button -> scroll down Update the Contact date, follow up date & Follow up stage.";
                Head += "<br/>";
                Head += "*\tUpdate your action comments in the remarks column.";
                Head += "<br/>";
                Head += "*\tClick the update button in the bottom right to save the lead status.";
                Head += "<br/>";
                Head += "*\tConnect the prospects via (email, call, WhatsApp, telegram, SMS, or social media) and guide them with their requirements.";
                Head += "<br/>";
                Head += "<br/>";
                Head += "<b>" + "For support regarding Lead Management Portal:</b>";
                Head += "<br>";
                Head += "<br>";
                Head += "" + "User related issues, write a mail to syed.a@trdfin.in & MarketingTrdfin@trdfin.in";
                Head += "<br>";
                Head += "<br>";
                Head += "<div style=\"background-color: yellow;\"><b>" + "Note: If there is no update on your leads for more than 72 hrs, your leads will be reallocated to another active sales representative.</b></div>";
                lst.Body = Head;
                lst.FromName = "noreply@nexgenrecruit.com";
                lst.Subject = Subject.Totitlecase();
                lst.ToList = user.EmailId;
                //lst.ToList = "Vigneshwaran@trdfin.in";
                //lst.CCList = "Vigneshwaran@trdfin.in";
                lst.Priority = "M";
                string resultResponse = MailConfig.SendMail(lst);
                if (resultResponse == "S")
                {
                    //subtaskEmail.status = ((char)Mail.StatusCode.Success).ToString();
                    //subtaskEmail.responsemessage = ((char)Mail.StatusCode.Success).ToString();
                    //var result = _dbContext.SaveChanges();
                }
                else
                {
                    //subtaskEmail.status = ((char)Mail.StatusCode.Failure).ToString();
                    //subtaskEmail.responsemessage = resultResponse;
                    //var result = _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            Console.WriteLine("End SubTaskCreateEmailNotification");
            Console.WriteLine("******************************");

        }
    }
}
