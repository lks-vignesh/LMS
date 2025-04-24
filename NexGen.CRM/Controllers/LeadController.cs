using AspNetCoreHero.ToastNotification.Abstractions;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using NexGen.BL;
using NexGen.Repository;
using ClosedXML.Excel;
using System.Data;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.SqlServer.Management.Smo;
using NexGen.Repository.Leads;

namespace NexGen.CRM.Controllers
{
    public class LeadController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _notyf;
        private IConfiguration Configuration;
        private int UserID = 0;

        public LeadController(ILogger<HomeController> logger, INotyfService notyf, IConfiguration _configuration)
        {
            _logger = logger;
            _notyf = notyf;
            Configuration = _configuration;
            //UserID = _session.GetInt32("UserID") != null ? _session.GetInt32("UserID").Value : 0;
            //UserID = (int)HttpContext.Session.GetInt32("UserID");
            //int RoleID = HttpContext.Session.GetInt32("RoleId") != null ? HttpContext.Session.GetInt32("RoleId").Value : 0;
        }
        public IActionResult Leads()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            ViewBag.Leadtag = 01;
            int RoleID = HttpContext.Session.GetInt32("RoleId") != null ? HttpContext.Session.GetInt32("RoleId").Value : 0;
            ViewBag.RoleID = RoleID;
            return View();
        }

        public IActionResult LeadActivities()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            int RoleID = HttpContext.Session.GetInt32("RoleId") != null ? HttpContext.Session.GetInt32("RoleId").Value : 0;
            ViewBag.RoleID = RoleID;
            ViewBag.LeadActtag = 05;
            return View();
        }
        public IActionResult LeadReAssign()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            int RoleID = HttpContext.Session.GetInt32("RoleId") != null ? HttpContext.Session.GetInt32("RoleId").Value : 0;
            ViewBag.RoleID = RoleID;
            ViewBag.LeadAsgtag = 06;
            return View();
        }
        public IActionResult LeadList()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            int UserID = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
            int RoleID = HttpContext.Session.GetInt32("RoleId") != null ? HttpContext.Session.GetInt32("RoleId").Value : 0;

            LeadLogic objLogic = new LeadLogic();
            List<EntityLeads> leadlist = new List<EntityLeads>();
            leadlist = objLogic.GetLeads(UserID);
            var jsonData = new { data = leadlist };
            return Ok(jsonData);
        }
        public IActionResult GetLeadlist(string data)
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            int UserID = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
            int RoleID = HttpContext.Session.GetInt32("RoleId") != null ? HttpContext.Session.GetInt32("RoleId").Value : 0;

            LeadLogic objLogic = new LeadLogic();
            List<EntityLeads> leadlist = new List<EntityLeads>();

            leadlist = objLogic.GetLeads(UserID);
            var jsonData = new { data = leadlist };
            return Ok(jsonData);
        }

        public IActionResult LeadActivityList()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            int UserID = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
            int RoleID = HttpContext.Session.GetInt32("RoleId") != null ? HttpContext.Session.GetInt32("RoleId").Value : 0;

            LeadLogic objLogic = new LeadLogic();
            List<EntityLeads> leadlist = new List<EntityLeads>();
            leadlist = objLogic.GetLeadsActivities(UserID);
            var jsonData = new { data = leadlist };
            return Ok(jsonData);
        }
        public IActionResult LeadReAssignList()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            int UserID = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
            int RoleID = HttpContext.Session.GetInt32("RoleId") != null ? HttpContext.Session.GetInt32("RoleId").Value : 0;

            LeadLogic objLogic = new LeadLogic();
            List<EntityLeads> leadlist = new List<EntityLeads>();

            leadlist = objLogic.GetLeads(UserID);
            var jsonData = new { data = leadlist };
            return Ok(jsonData);
        }
        public IActionResult AddNewLead()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            ViewBag.Leadtag = 01;
            return View();
        }
        public IActionResult EditLead(int Id)
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            ViewBag.Leadtag = 01;
            int RoleID = HttpContext.Session.GetInt32("RoleId") != null ? HttpContext.Session.GetInt32("RoleId").Value : 0;

            HttpContext.Session.SetInt32("LeadID", Id);
            LeadLogic objLogic = new LeadLogic();
            EntityLeads entity = new EntityLeads();
            entity = objLogic.GetLead(Id);
            HttpContext.Session.SetString("EMailID", entity.AssignedTo_MailID != null ? entity.AssignedTo_MailID : "");
            if (RoleID == 1)
                return View(entity);
            else
                return RedirectToAction("ViewLead", entity);
        }
        public IActionResult ViewLead(EntityLeads entity)
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            ViewBag.Leadtag = 01;
            //HttpContext.Session.SetInt32("LeadID", Id);
            //LeadLogic objLogic = new LeadLogic();
            //EntityLeads entity = new EntityLeads();
            //entity = objLogic.GetLead(Id);
            return View(entity);
        }

        public IActionResult EditLeadReAssign(int Id)
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            ViewBag.Reassigntag = 09;
            HttpContext.Session.SetInt32("LeadID", Id);
            LeadLogic objLogic = new LeadLogic();
            EntityLeads entity = new EntityLeads();
            entity = objLogic.GetLead(Id);
            HttpContext.Session.SetString("AssignEMailID", entity.AssignedTo_MailID != null ? entity.AssignedTo_MailID : "");
            return View(entity);
        }
        public IActionResult LeadSubmit(EntityLeads objuser)
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            LeadLogic leadlogic = new LeadLogic();

            EntityLeads entityLead = new EntityLeads();
            int UserID = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;

            entityLead.CreatedBy = UserID;
            entityLead.CreationDate = DateTime.Now;
            entityLead.Company_Name = objuser.Company_Name;
            entityLead.EnquiryNumber = objuser.EnquiryNumber;
            entityLead.Company_Details = objuser.Company_Details;
            entityLead.City = objuser.City;
            entityLead.Country = objuser.Country;
            entityLead.Sector = objuser.Sector;
            entityLead.ContactPerson = objuser.ContactPerson;
            entityLead.Designation = objuser.Designation;
            entityLead.MobileNumber = objuser.MobileNumber;
            entityLead.EmailID = objuser.EmailID;
            entityLead.LeadSource = objuser.LeadSource;
            entityLead.InstrumentValue = objuser.InstrumentValue;
            entityLead.WhatsAppNumber = objuser.WhatsAppNumber;
            entityLead.AssignedDate = objuser.AssignedDate;
            entityLead.IntrumentType = objuser.IntrumentType;
            entityLead.InstrumentIssuanceTimeline = objuser.InstrumentIssuanceTimeline;
            entityLead.AnnualRequirement = objuser.AnnualRequirement;
            entityLead.AnnualTurnOver = objuser.AnnualTurnOver;
            entityLead.ContactPerson = objuser.ContactPerson;
            entityLead.LeadSourceDate = objuser.LeadSourceDate;
            entityLead.AdditionalInformation = objuser.AdditionalInformation;
            entityLead.AssignedTo_MailID = objuser.AssignedTo_MailID;

            string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                              @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                 @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(emailRegex);
            if (!re.IsMatch(entityLead.EmailID))
            {
                _notyf.Error("Email is not Valid");
                return RedirectToAction("Leads", "Lead");
            }
            if (leadlogic.CheckEmaiID(entityLead.EmailID))
            {
                _notyf.Error("Email ID " + entityLead.EmailID + " is already Exist ");
                return RedirectToAction("Leads", "Lead");
            }

            if (objuser.AssignedTo_MailID != "" || objuser.AssignedTo_MailID != null)
            {
                UserLogic userLogic = new UserLogic();
                EntityUser user = userLogic.GetUserMailID(objuser.AssignedTo_MailID);
                if (user.UserId != 0)
                {
                    entityLead.AssignedTo = user.UserId;
                }
                else
                {
                    _notyf.Error("Assigned To is invalid or not available in our system");
                    return RedirectToAction("Leads", "Lead");
                }
            }

            entityLead.Active = true;
            IReturn objReturn = leadlogic.InsertUploadLead(entityLead);
            MailLogic mailLogic = new MailLogic();
            mailLogic.SendAssignedMail(entityLead.AssignedTo);
            entityLead.LeadId = objReturn.GetPrimaryId();
            EntityLeadActivities leadActivities = new EntityLeadActivities();
            UserLogic userLogics = new UserLogic();
            EntityUser users = userLogics.GetUserMailID(objuser.AssignedTo_MailID);
            leadActivities.LeadId = entityLead;
            int ActivityUser = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
            leadActivities.CreatedBy = ActivityUser;
            leadActivities.CreationDate = DateTime.Now;
            leadActivities.ContactDate = DateTime.Now;
            leadActivities.Remarks = "Lead Assigned To " + users.Name;
            leadActivities.LeadStatus = "Assigned";
            leadActivities.FollowUpStage = "Lead Assigned";
            leadActivities.Active = true;
            IReturn objReturns = leadlogic.InsertLeadActivity(leadActivities);
            leadlogic.EnableRemainderNotification(entityLead.LeadId);

            _notyf.Success("Lead Saved Successfully");
            return RedirectToAction("Leads", "Lead");
        }
        public IActionResult UpdateLead(EntityLeads objuser)
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            int Lead_Id = HttpContext.Session.GetInt32("LeadID").Value;

            LeadLogic leadlogic = new LeadLogic();

            EntityLeads entityLead = leadlogic.GetLead(Lead_Id);

            int RoleID = HttpContext.Session.GetInt32("RoleId") != null ? HttpContext.Session.GetInt32("RoleId").Value : 0;
            int UserID = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
            string AssignMailID = HttpContext.Session.GetString("EMailID");

            if (RoleID == 1)
            {


                entityLead.CreatedBy = 1;
                entityLead.LeadId = Lead_Id;
                entityLead.Company_Name = objuser.Company_Name;
                entityLead.EnquiryNumber = objuser.EnquiryNumber;
                entityLead.Company_Details = objuser.Company_Details;
                entityLead.City = objuser.City;
                entityLead.Country = objuser.Country;
                entityLead.Sector = objuser.Sector;
                entityLead.ContactPerson = objuser.ContactPerson;
                entityLead.Designation = objuser.Designation;
                entityLead.MobileNumber = objuser.MobileNumber;
                entityLead.WhatsAppNumber = objuser.WhatsAppNumber;
                entityLead.EmailID = objuser.EmailID;
                entityLead.LeadSource = objuser.LeadSource;
                entityLead.LeadSourceDate = objuser.LeadSourceDate;
                entityLead.InstrumentValue = objuser.InstrumentValue;
                entityLead.Active = true;
                entityLead.IntrumentType = objuser.IntrumentType;
                entityLead.InstrumentIssuanceTimeline = objuser.InstrumentIssuanceTimeline;
                entityLead.AnnualRequirement = objuser.AnnualRequirement;
                entityLead.AnnualTurnOver = objuser.AnnualTurnOver;
                entityLead.AdditionalInformation = objuser.AdditionalInformation;
                entityLead.AlternativeMobileNumber = objuser.AlternativeMobileNumber;
                entityLead.AlternateEmail = objuser.AlternateEmail;
                entityLead.AlternateCompanyName = objuser.AlternateCompanyName;
                entityLead.AssignedDate = objuser.AssignedDate;
                entityLead.LastUpdateBy = UserID;

                if (objuser.AssignedTo_MailID != null)
                {
                    if (objuser.AssignedTo_MailID != "" || objuser.AssignedTo_MailID != null)
                    {
                        if (AssignMailID != objuser.AssignedTo_MailID)
                        {
                            UserLogic userLogic = new UserLogic();
                            EntityUser user = userLogic.GetUserMailID(objuser.AssignedTo_MailID);
                            if (user.UserId != 0)
                            {
                                entityLead.AssignedTo = user.UserId;
                            }
                            else
                            {
                                _notyf.Error("Assigned To is invalid or not available in our system");
                                return RedirectToAction("LeadReAssign", "Lead");
                            }
                            IReturn objReturn = leadlogic.UpdateLeadReAssign(entityLead);
                            MailLogic mailLogic = new MailLogic();
                            mailLogic.SendAssignedMail(entityLead.AssignedTo);
                            entityLead.LeadId = Lead_Id;
                            EntityLeadActivities leadActivities = new EntityLeadActivities();
                            UserLogic userLogics = new UserLogic();
                            EntityUser users = userLogics.GetUserMailID(objuser.AssignedTo_MailID);
                            leadActivities.LeadId = entityLead;
                            leadActivities.CreationDate = DateTime.Now;
                            leadActivities.ContactDate = DateTime.Now;
                            leadActivities.Remarks = "Lead Assigned To " + users.Name;
                            leadActivities.LeadStatus = "Assigned";
                            leadActivities.FollowUpStage = "Lead Assigned";
                            leadActivities.Active = true;
                            int ActivityUser = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
                            leadActivities.CreatedBy = ActivityUser;
                            IReturn objReturns = leadlogic.InsertLeadActivity(leadActivities);
                            leadlogic.EnableRemainderNotification(entityLead.LeadId);

                        }
                        else
                        {

                        }


                    }
                }
                else
                {
                    _notyf.Error("Assigned To field is mandatory");
                    return RedirectToAction("Leads", "Lead");
                }
            }
            else
            {
                entityLead.AlternativeMobileNumber = objuser.AlternativeMobileNumber;
                entityLead.AlternateEmail = objuser.AlternateEmail;
                entityLead.AlternateCompanyName = objuser.AlternateCompanyName;
                entityLead.LastUpdateBy = UserID;
            }
            leadlogic.UpdateLead(entityLead);
            _notyf.Success("Lead Updated Successfully");
            return RedirectToAction("Leads", "Lead");
        }
        public IActionResult UpdateLeadReAssign(EntityLeads objuser)
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            int Lead_Id = HttpContext.Session.GetInt32("LeadID").Value;
            string AssignMailID = HttpContext.Session.GetString("AssignEMailID");

            if (AssignMailID != objuser.AssignedTo_MailID)
            {
                LeadLogic leadlogic = new LeadLogic();

                EntityLeads entityLead = new EntityLeads();
                entityLead.LeadId = Lead_Id;
                if (objuser.AssignedTo_MailID != null)
                {
                    if (objuser.AssignedTo_MailID != "" || objuser.AssignedTo_MailID != null)
                    {
                        UserLogic userLogic = new UserLogic();
                        EntityUser user = userLogic.GetUserMailID(objuser.AssignedTo_MailID);
                        if (user.UserId != 0)
                        {
                            entityLead.AssignedTo = user.UserId;
                            entityLead.AssignedDate=DateTime.Now;
                        }
                        else
                        {
                            _notyf.Error("Assigned To is invalid or not available in our system");
                            return RedirectToAction("LeadReAssign", "Lead");
                        }
                    }
                    //leadlogic.UpdateLeadReAssign(entityLead);
                    IReturn objReturn = leadlogic.UpdateLeadReAssign(entityLead);
                    MailLogic mailLogic = new MailLogic();
                    mailLogic.SendAssignedMail(entityLead.AssignedTo);
                    entityLead.LeadId = Lead_Id;

                    EntityLeadActivities leadActivities = new EntityLeadActivities();
                    UserLogic userLogics = new UserLogic();
                    EntityUser users = userLogics.GetUserMailID(objuser.AssignedTo_MailID);
                    int ActivityUser = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
                    leadActivities.CreatedBy = ActivityUser;
                    leadActivities.LeadId = entityLead;
                    leadActivities.CreationDate = DateTime.Now;
                    leadActivities.ContactDate = DateTime.Now;
                    leadActivities.Remarks = "Lead Assigned To " + users.Name;
                    leadActivities.LeadStatus = "Assigned";
                    leadActivities.FollowUpStage = "Lead Assigned";
                    leadActivities.Active = true;
                    IReturn objReturns = leadlogic.InsertLeadActivity(leadActivities);
                    leadlogic.EnableRemainderNotification(entityLead.LeadId);

                }
                else
                {
                    _notyf.Error("Assigned To field is mandatory");
                    return RedirectToAction("LeadReAssign", "Lead");
                }
                _notyf.Success("Assigned To updated Successfully");
                return RedirectToAction("LeadReAssign", "Lead");
            }
            else
            {
                // _notyf.Error("Assigned To is invalid or not available in our system");
                return RedirectToAction("LeadReAssign", "Lead");
            }

        }

        public IActionResult AddLeadActivity(EntityLeads objleads)
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            LeadLogic leadlogic = new LeadLogic();

            EntityLeadActivities entityLeadActivities = new EntityLeadActivities();

            int Lead_Id = HttpContext.Session.GetInt32("LeadActivityID").Value;

            EntityLeads entityLeads = leadlogic.GetLead(Lead_Id);
            entityLeads.AlternativeMobileNumber = objleads.AlternativeMobileNumber;
            entityLeads.AlternateEmail = objleads.AlternateEmail;
            entityLeads.AlternateCompanyName = objleads.AlternateCompanyName;
            leadlogic.UpdateLead(entityLeads);
            int ActivityUser = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
            entityLeadActivities.CreatedBy = ActivityUser;
            entityLeadActivities.LeadId = entityLeads;
            entityLeadActivities.ContactDate = objleads.ContactDate;
            entityLeadActivities.FollowUpDate = objleads.Follow_upDate;
            entityLeadActivities.FollowUpStage = objleads.FollowUpStage;
            entityLeadActivities.Remarks = objleads.Remarks;
            entityLeadActivities.LeadStatus = leadlogic.GetFollowupstatus(objleads.FollowUpStage);
            entityLeadActivities.Active = true;

            IReturn objReturn = leadlogic.InsertLeadActivity(entityLeadActivities);
            _notyf.Success("Lead Activity Updated Successfully");
            return RedirectToAction("LeadActivities", "Lead");
        }

        public IActionResult EditLeadActivity(int Id)
        {
            LeadLogic objLogic = new LeadLogic();
            ViewBag.FSlist = objLogic.GetddlLeadStatus();

            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            ViewBag.LeadActtag = 05;
            HttpContext.Session.SetInt32("LeadActivityID", Id);
            //LeadLogic objLogic = new LeadLogic();
            EntityLeads entity = new EntityLeads();
            entity = objLogic.GetLead(Id);
            int UserID = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
            HttpContext.Session.SetInt32("UserID", UserID);
            HttpContext.Session.SetInt32("Lead", entity.LeadId);
            return View(entity);
        }
        public IActionResult GetLeadActivities()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            int UserID = HttpContext.Session.GetInt32("UserID").Value;
            int LeadID = HttpContext.Session.GetInt32("Lead").Value;

            LeadLogic objLogic = new LeadLogic();
            List<EntityLeadActivities> leadlist = new List<EntityLeadActivities>();

            leadlist = objLogic.GetLeadActivities(UserID, LeadID);
            var jsonData = new { data = leadlist };
            return Ok(jsonData);
        }

        public ActionResult Export()
        {

            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            LeadLogic objLogic = new LeadLogic();
            List<EntityLeads> leadlist = new List<EntityLeads>();
            int UserID = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
            leadlist = objLogic.GetLeads(UserID);

            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[23] {
                                            new DataColumn("LeadID"),
                                            new DataColumn("Company_Name"),
                                            new DataColumn("Company_Details"),
                                            new DataColumn("City"),
                                            new DataColumn("Country"),
                                            new DataColumn("Sector"),
                                            new DataColumn("ContactPerson"),
                                            new DataColumn("Designation"),
                                            new DataColumn("MobileNumber"),
                                            new DataColumn("EmailID"),
                                            new DataColumn("LeadSource"),
                                            new DataColumn("InstrumentValue"),
                                            new DataColumn("AssignedTo_MailID"),
                                            new DataColumn("WhatsAppNumber"),
                                            new DataColumn("InstrumentIssuanceTimeline"),
                                            new DataColumn("AnnualRequirement"),
                                            new DataColumn("AnnualTurnOver"),
                                            new DataColumn("IntrumentType"),
                                            new DataColumn("AssignedDate"),
                                            new DataColumn("AdditionalInformation"),
                                            new DataColumn("AlternativeMobileNumber"),
                                            new DataColumn("AlternateEmail"),
                                            new DataColumn("AlternateCompanyName") });

            if (leadlist.Count > 0)
            {
                foreach (var lead in leadlist)
                {
                    // if (lead.AssignedTo == 0)
                    // {
                    // }
                    // else { }
                    dt.Rows.Add(lead.EnquiryNumber, lead.Company_Name, lead.Company_Details, lead.City, lead.Country, lead.Sector, lead.ContactPerson, lead.Designation, lead.MobileNumber, lead.EmailID, lead.LeadSource, lead.InstrumentValue, lead.AssignedTo_MailID, lead.WhatsAppNumber, lead.InstrumentIssuanceTimeline, lead.AnnualRequirement, lead.AnnualTurnOver, lead.IntrumentType, lead.AssignedDate, lead.AdditionalInformation, lead.AlternativeMobileNumber, lead.AlternateEmail, lead.AlternateCompanyName);

                }
                //Name of File  
                string fileName = "LeadList.xlsx";

                using (XLWorkbook wb = new XLWorkbook())
                {
                    //Add DataTable in worksheet  
                    wb.Worksheets.Add(dt);
                    using (var stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                    }
                }
            }
            else
            {
                _notyf.Error("Data is Empty");
                return RedirectToAction("LeadReAssign", "Lead");
            }
        }

        public ActionResult LeadExport()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            LeadLogic objLogic = new LeadLogic();
            List<EntityLeads> leadlist = new List<EntityLeads>();
            int UserID = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
            leadlist = objLogic.GetLeads(UserID);


            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("LeadID"),
                                            new DataColumn("Company_Name"),
                                            new DataColumn("Sector"),
                                            new DataColumn("ContactPerson"),
                                            new DataColumn("AssignTo") });

            if (leadlist.Count > 0)
            {
                foreach (var lead in leadlist)
                {

                    dt.Rows.Add(lead.EnquiryNumber, lead.Company_Name, lead.Sector, lead.ContactPerson, lead.AssignedTo);

                }
                //Name of File  
                string fileName = "LeadList.xlsx";

                using (XLWorkbook wb = new XLWorkbook())
                {
                    //Add DataTable in worksheet  
                    wb.Worksheets.Add(dt);
                    using (var stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                    }
                }
            }
            else
            {
                _notyf.Error("Data is Empty");
                return RedirectToAction("LeadReAssign", "Lead");
            }


        }

        public ActionResult LeadActivitiesExport()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            LeadLogic objLogic = new LeadLogic();
            DataTable dataTable = objLogic.GetLeadsActivitiesExport();


            if (dataTable.Rows.Count > 0)
            {
                string fileName = "Lead Activities.xlsx";
                dataTable.TableName = "Lead Details";
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dataTable);
                    using (var stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                    }
                }
            }
            else
            {
                _notyf.Error("Data is Empty");
                return RedirectToAction("LeadReAssign", "Lead");
            }
        }
        public ActionResult LeadReassignExport()
        {

            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            LeadLogic objLogic = new LeadLogic();
            List<EntityLeads> leadlist = new List<EntityLeads>();
            int UserID = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
            leadlist = objLogic.GetLeads(UserID);

            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[23] {
                                            new DataColumn("LeadID"),
                                            new DataColumn("Company_Name"),
                                            new DataColumn("Company_Details"),
                                            new DataColumn("City"),
                                            new DataColumn("Country"),
                                            new DataColumn("Sector"),
                                            new DataColumn("ContactPerson"),
                                            new DataColumn("Designation"),
                                            new DataColumn("MobileNumber"),
                                            new DataColumn("EmailID"),
                                            new DataColumn("LeadSource"),
                                            new DataColumn("InstrumentValue"),
                                            new DataColumn("AssignedTo_MailID"),
                                            new DataColumn("WhatsAppNumber"),
                                            new DataColumn("InstrumentIssuanceTimeline"),
                                            new DataColumn("AnnualRequirement"),
                                            new DataColumn("AnnualTurnOver"),
                                            new DataColumn("IntrumentType"),
                                            new DataColumn("AssignedDate"),
                                            new DataColumn("AdditionalInformation"),
                                            new DataColumn("AlternativeMobileNumber"),
                                            new DataColumn("AlternateEmail"),
                                            new DataColumn("AlternateCompanyName") });

            if (leadlist.Count > 0)
            {
                foreach (var lead in leadlist)
                {
                    // if (lead.AssignedTo == 0)
                    // {
                    // }
                    // else { }
                    dt.Rows.Add(lead.EnquiryNumber, lead.Company_Name, lead.Company_Details, lead.City, lead.Country, lead.Sector, lead.ContactPerson, lead.Designation, lead.MobileNumber, lead.EmailID, lead.LeadSource, lead.InstrumentValue, lead.AssignedTo_MailID, lead.WhatsAppNumber, lead.InstrumentIssuanceTimeline, lead.AnnualRequirement, lead.AnnualTurnOver, lead.IntrumentType, lead.AssignedDate, lead.AdditionalInformation, lead.AlternativeMobileNumber, lead.AlternateEmail, lead.AlternateCompanyName);

                }
                //Name of File  
                string fileName = "LeadReassign.xlsx";

                using (XLWorkbook wb = new XLWorkbook())
                {
                    //Add DataTable in worksheet  
                    wb.Worksheets.Add(dt);
                    using (var stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                    }
                }
            }
            else
            {
                _notyf.Error("Data is Empty");
                return RedirectToAction("LeadReAssign", "Lead");
            }


        }


    }
}
