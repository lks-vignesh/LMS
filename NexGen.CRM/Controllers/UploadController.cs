using AspNetCoreHero.ToastNotification.Abstractions;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml.Office;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Management.Smo;
using NexGen.BL;
using NexGen.Repository;
using NexGen.Repository.Leads;
using OpenXmlPowerTools;
using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace NexGen.CRM.Controllers
{
    public class UploadController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _notyf;
        private IConfiguration Configuration;

        public UploadController(ILogger<HomeController> logger, INotyfService notyf, IConfiguration _configuration)
        {
            _logger = logger;
            _notyf = notyf;
            Configuration = _configuration;
        }
        public IActionResult LeadUpload()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            ViewBag.LeadUptag = 07;
            return View();
        }
        public IActionResult ReAssignUpload()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            ViewBag.LeadRUptag = 08;
            return View();
        }


        public async Task<IActionResult> ImportReassigncsvFile(object sender, IFormFile FormFile, string ddlDocType, EventArgs e)
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            LeadLogic leadlogic = new LeadLogic();
            if (FormFile == null)
            {
                _notyf.Error("Kindly upload a proper CSV File");
                return RedirectToAction("ReAssignUpload", "Upload");
            }
            else
            {

                var supportedTypes = new[] { "csv" };
                var fileExt = System.IO.Path.GetExtension(FormFile.FileName).Substring(1);


                if (!supportedTypes.Contains(fileExt))
                {
                    _notyf.Error("File Extension Is InValid - Only Upload CSV File");
                    return RedirectToAction("ReAssignUpload", "Upload");
                }
                else
                {
                    var MainPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");

                    //create directory "Uploads" if it doesn't exists
                    if (!Directory.Exists(MainPath))
                    {
                        Directory.CreateDirectory(MainPath);
                    }

                    var filename = ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim();

                    //get file path 
                    var filePath = Path.Combine(MainPath, FormFile.FileName);
                    using (System.IO.Stream stream = new FileStream(filePath, FileMode.Create))
                    {
                        await FormFile.CopyToAsync(stream);
                    }
                    DataTable dtr = new DataTable();
                    using (StreamReader sr = new StreamReader(filePath))
                    {

                        string[] headers = sr.ReadLine().Split(',');
                        foreach (string header in headers)
                        {
                            dtr.Columns.Add(header);

                        }
                        while (!sr.EndOfStream)
                        {
                            string[] rows = sr.ReadLine().Split(',');
                            DataRow dr = dtr.NewRow();
                            for (int i = 0; i < headers.Length; i++)
                            {
                                dr[i] = rows[i];
                            }
                            dtr.Rows.Add(dr);
                        }
                        if ((dtr.Columns.Contains("LeadID")) && (dtr.Columns.Contains("AssignTo")))
                        {
                            foreach (DataRow dtrows in dtr.Rows)
                            {
                                string LeadId = dtrows["LeadID"].ToString();
                                string taskname = dtrows["AssignTo"].ToString();
                                if ((LeadId == null) || (LeadId == "") && (taskname == null) || (taskname == ""))
                                {
                                    _notyf.Error("All fields is mandatory");
                                    return RedirectToAction("ReassignUpload", "Upload");
                                }
                                else if ((taskname == null) || (taskname == ""))
                                {
                                    _notyf.Error("AssignTo field is mandatory");
                                    return RedirectToAction("ReassignUpload", "Upload");
                                }
                                else
                                {
                                    string leadID = dtrows["LeadID"].ToString().Replace("L", "");

                                    bool successfullyParsed = int.TryParse(leadID, out _);

                                    if (successfullyParsed)
                                    {
                                        int ID = int.Parse(leadID);
                                        if (leadlogic.GetLead(ID) == null)
                                        {
                                            _notyf.Error("Lead ID " + LeadId + " is Incorrect ");
                                            return RedirectToAction("ReAssignUpload", "Upload");
                                        }
                                        else if (leadlogic.CheckAssignToMail(taskname) == null)
                                        {
                                            _notyf.Error("Email ID " + taskname + " is not valid");
                                            return RedirectToAction("ReAssignUpload", "Upload");
                                        }
                                    }
                                    else
                                    {
                                        _notyf.Error("Lead ID " + LeadId + " is Incorrect ");
                                        return RedirectToAction("ReAssignUpload", "Upload");
                                    }


                                    //else if (leadLogic.GetLead(ID) != null)
                                    // {
                                    // _notyf.Error("Lead ID " + LeadId + " is already registered ");
                                    // return RedirectToAction("ReAssignUpload", "Upload");
                                    //}

                                }

                            }


                            foreach (DataRow dtrows in dtr.Rows)
                            {
                                string leadID = dtrows["LeadID"].ToString().Replace("L", "");
                                int ID = int.Parse(leadID);
                                EntityLeads entityLeads = leadlogic.GetLead(ID);



                                if (entityLeads.AssignedTo_MailID != "")
                                {
                                    UserLogic userLogic = new UserLogic();
                                    EntityUser user = userLogic.GetUserMailID(dtrows["AssignTo"].ToString());
                                    if (user.EmailId != null)
                                    {
                                        EntityLeads Entity = leadlogic.GetLead(ID);
                                        entityLeads.AssignedTo = user.UserId;
                                        entityLeads.AssignedDate = DateTime.Now;
                                        leadlogic.UpdateLeadReAssign(entityLeads);
                                        EntityLeadActivities leadActivities = new EntityLeadActivities();
                                        leadActivities.LeadId = Entity;
                                        leadActivities.CreationDate = DateTime.Now;
                                        leadActivities.ContactDate = DateTime.Now;
                                        leadActivities.Remarks = "Lead ReAssigned To " + user.Name;
                                        leadActivities.LeadStatus = "ReAssigned";
                                        leadActivities.FollowUpStage = "Lead ReAssigned";
                                        int ActivityUser = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
                                        leadActivities.CreatedBy = ActivityUser;
                                        leadActivities.LastUpdateBy = ActivityUser;
                                        IReturn objReturn = leadlogic.InsertLeadActivity(leadActivities);
                                        leadlogic.EnableRemainderNotification(Entity.LeadId);

                                    }
                                    else
                                    {
                                        _notyf.Error("The Assigned To is invalid or not in our system");
                                        return RedirectToAction("ReAssignUpload", "Upload");
                                    }

                                }




                                if (entityLeads.AssignedTo != 0)
                                {
                                    MailLogic mailLogic = new MailLogic();
                                    mailLogic.SendAssignedMail(entityLeads.AssignedTo);
                                }
                                //IReturn objReturn = leadlogic.InsertUploadLead(Entity);
                            }
                        }
                        else
                        {
                            _notyf.Error("Please upload a valid excel sheet");
                            return RedirectToAction("ReAssignUpload", "Upload");
                        }


                    }
                }


                //DataTable transposedTable = GenerateTransposedTable(dtr);
                _notyf.Success("File Imported and CSV data saved into database");

                return RedirectToAction("LeadUpload", "Upload");
            }
        }
        public async Task<IActionResult> ImportcsvFile(object sender, IFormFile FormFile, string ddlDocType, EventArgs e)
        {

            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            LeadLogic leadlogic = new LeadLogic();
            if (FormFile == null)
            {
                _notyf.Error("Kindly upload a proper CSV File");
                return RedirectToAction("LeadUpload", "Upload");
            }
            else
            {
                var supportedTypes = new[] { "csv" };
                var fileExt = System.IO.Path.GetExtension(FormFile.FileName).Substring(1);


                if (!supportedTypes.Contains(fileExt))
                {
                    _notyf.Error("File Extension Is InValid - Only Upload CSV File");
                    return RedirectToAction("ReAssignUpload", "Upload");
                }
                else
                {
                    var MainPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads");

                    //create directory "Uploads" if it doesn't exists
                    if (!Directory.Exists(MainPath))
                    {
                        Directory.CreateDirectory(MainPath);
                    }

                    var filename = ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim();

                    //get file path 
                    var filePath = Path.Combine(MainPath, FormFile.FileName);
                    using (System.IO.Stream stream = new FileStream(filePath, FileMode.Create))
                    {
                        await FormFile.CopyToAsync(stream);
                    }
                    DataTable dtr = new DataTable();
                    using (StreamReader sr = new StreamReader(filePath))
                    {

                        string[] headers = sr.ReadLine().Split(',');
                        foreach (string header in headers)
                        {
                            dtr.Columns.Add(header);

                        }
                        while (!sr.EndOfStream)
                        {
                            string[] rows = sr.ReadLine().Split(',');
                            DataRow dr = dtr.NewRow();
                            for (int i = 0; i < headers.Length; i++)
                            {
                                dr[i] = rows[i];
                            }
                            dtr.Rows.Add(dr);
                        }

                        if ((dtr.Columns.Contains("Source")) && (dtr.Columns.Contains("Date")) && (dtr.Columns.Contains("Name")) && (dtr.Columns.Contains("Job Title")) && (dtr.Columns.Contains("Work Phone Number")) && (dtr.Columns.Contains("Whatsapp Number")) && (dtr.Columns.Contains("work_email")) && (dtr.Columns.Contains("Company Name")) && (dtr.Columns.Contains("Timeline for Instrument Issuance")) && (dtr.Columns.Contains("Annual Requirement of Such Instruments")) && (dtr.Columns.Contains("Annual Turnover of Your Company(USD)")) && (dtr.Columns.Contains("under_which_category_you_wants_us_to_recognize")) && (dtr.Columns.Contains("which_instruments_you_are_looking")) && (dtr.Columns.Contains("value_of_the_instrument_you_are_looking")) && (dtr.Columns.Contains("Additional Information You'd Like to Share")) && (dtr.Columns.Contains("city")) && (dtr.Columns.Contains("Country")) && (dtr.Columns.Contains("Assigned person")) && (dtr.Columns.Contains("Assigned date")) && (dtr.Columns.Contains("Sales Email Id")) && (dtr.Columns.Contains("Reporting Name")) && (dtr.Columns.Contains("Reporting TFS")))
                        {
                            foreach (DataRow datarow in dtr.Rows)
                            {
                                string taskname = datarow["Name"].ToString();
                                string Number = datarow["Work Phone Number"].ToString();
                                string Email = datarow["work_email"].ToString();
                                string CompanyName = datarow["Company Name"].ToString();
                                string Country = datarow["Country"].ToString();
                                string Instrument = datarow["value_of_the_instrument_you_are_looking"].ToString();


                                //DateTime.ParseExact(SourceDate, "dd/MM/yyyy", null);

                                DateTime LeadSourceDate;
                                DateTime AssignedDate;


                                string[] formats = { "d/MM/yyyy", "dd/MM/yyyy" };
                                var isValidFormat_SourceDate = DateTime.TryParseExact(datarow["Date"].ToString(), formats, new CultureInfo("en-US"), DateTimeStyles.None, out LeadSourceDate);
                                var isValidFormat_AssignedDate = DateTime.TryParseExact(datarow["Assigned date"].ToString(), formats, new CultureInfo("en-US"), DateTimeStyles.None, out AssignedDate);

                                if (!isValidFormat_SourceDate)
                                {
                                    _notyf.Error("Invalid Source Date");
                                    return RedirectToAction("LeadUpload", "Upload");
                                }
                                if (!isValidFormat_AssignedDate)
                                {
                                    _notyf.Error("Invalid Assigned Date");
                                    return RedirectToAction("LeadUpload", "Upload");
                                }
                                if (LeadSourceDate > AssignedDate)
                                {
                                    _notyf.Error("Assign Date is Greater Than Lead SourceDate ");
                                    return RedirectToAction("LeadUpload", "Upload");
                                }
                                else if ((Email == null) || (Email == ""))
                                {
                                    _notyf.Error("Fill all the fields of Work Email and try again");
                                    return RedirectToAction("LeadUpload", "Upload");
                                }
                                else if (leadlogic.CheckEmaiID(Email))
                                {
                                    _notyf.Error("Email ID " + Email + " is already Exist ");
                                    return RedirectToAction("LeadUpload", "Upload");
                                }
                                else if ((taskname == null) || (taskname == ""))
                                {
                                    _notyf.Error("Fill all the fields of Name and try again");
                                    return RedirectToAction("LeadUpload", "Upload");
                                }
                                else if ((Number == null) || (Number == ""))
                                {
                                    _notyf.Error("Fill all the fields of Work Phone Number and try again");
                                    return RedirectToAction("LeadUpload", "Upload");
                                }
                                else if ((CompanyName == null) || (CompanyName == ""))
                                {
                                    _notyf.Error("Fill the field of Company name and try again");
                                    return RedirectToAction("LeadUpload", "Upload");
                                }
                                else if ((Country == null) || (Country == ""))
                                {
                                    _notyf.Error("Fill the field of Country and try again");
                                    return RedirectToAction("LeadUpload", "Upload");
                                }
                                else if ((Instrument == null) || (Instrument == ""))
                                {
                                    _notyf.Error("Fill the field of value_of_the_instrument_you_are_looking and try again");
                                    return RedirectToAction("LeadUpload", "Upload");
                                }



                                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                                Regex re = new Regex(emailRegex);
                                if (!re.IsMatch(Email))
                                {
                                    _notyf.Error("Email is not Valid");
                                    return RedirectToAction("LeadUpload", "Upload");
                                }


                            }


                            foreach (DataRow datarow in dtr.Rows)
                            {
                                // int LeadId = 0;
                                EntityLeads Entity = new EntityLeads();
                                Entity.CreatedBy = 1;
                                Entity.CreationDate = DateTime.Now;
                                string source = datarow["Source"].ToString();
                                Entity.ContactPerson = datarow["Name"].ToString();
                                Entity.Designation = datarow["Job Title"].ToString();
                                Entity.MobileNumber = datarow["Work Phone Number"].ToString();
                                Entity.WhatsAppNumber = datarow["Whatsapp Number"].ToString();
                                Entity.EmailID = datarow["work_email"].ToString();
                                Entity.Company_Name = datarow["Company Name"].ToString();
                                Entity.InstrumentIssuanceTimeline = datarow["Timeline for Instrument Issuance"].ToString();
                                Entity.AnnualRequirement = datarow["Annual Requirement of Such Instruments"].ToString();
                                Entity.AnnualTurnOver = datarow["Annual Turnover of Your Company(USD)"].ToString();
                                Entity.Sector = datarow["under_which_category_you_wants_us_to_recognize"].ToString();
                                Entity.IntrumentType = datarow["which_instruments_you_are_looking"].ToString();
                                Entity.InstrumentValue = datarow["value_of_the_instrument_you_are_looking"].ToString();
                                Entity.AdditionalInformation = datarow["Additional Information You'd Like to Share"].ToString();
                                Entity.City = datarow["city"].ToString();
                                Entity.Country = datarow["Country"].ToString();
                                string SourceDate = datarow["Date"].ToString();
                                Entity.LeadSourceDate = DateTime.ParseExact(SourceDate, "dd/MM/yyyy", null);
                                string AssignDate = datarow["Assigned date"].ToString();
                                Entity.AssignedDate = DateTime.ParseExact(AssignDate, "dd/MM/yyyy", null).AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);


                                int ActivityUser = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;
                                Entity.CreatedBy = ActivityUser;

                                Entity.Active = true;
                                if (datarow["Sales Email Id"].ToString() != "")
                                {
                                    UserLogic userLogic = new UserLogic();
                                    EntityUser user = userLogic.GetUserMailID(datarow["Sales Email Id"].ToString());
                                    if (user != null)
                                    {
                                        Entity.AssignedTo = user.UserId;
                                    }
                                }
                                //Entity.AssignedTo = dtr["Assigned person"].ToString();
                                //Entity.AssignedTo = dtr["Sales Email Id"].ToString();
                                //Entity.AssignedTo = dtr["Reporting Name"].ToString();
                                //Entity.AssignedTo = dtr["Reporting TFS"].ToString();

                                //Entity.CreationDate = DateTime.Now;
                                //Entity.AssignedDate = DateTime.Now;

                                if (source.Contains("LinkedIn"))
                                {
                                    Entity.LeadSource = datarow["Source"].ToString();
                                }

                                else if (source.Contains("Website"))
                                {
                                    Entity.LeadSource = datarow["Source"].ToString();
                                }


                                else if (source.Contains("Facebook Ads"))
                                {
                                    Entity.LeadSource = datarow["Source"].ToString();
                                }

                                else if (source.Contains("Google Ads"))
                                {
                                    Entity.LeadSource = datarow["Source"].ToString();
                                }

                                else if (source.Contains("Website Chat"))
                                {
                                    Entity.LeadSource = datarow["Source"].ToString();
                                }

                                else if (source.Contains("Website Form"))
                                {
                                    Entity.LeadSource = datarow["Source"].ToString();
                                }

                                else if (source.Contains("Validation Lead"))
                                {
                                    Entity.LeadSource = datarow["Source"].ToString();
                                }

                                else if (source.Contains("Calendly"))
                                {
                                    Entity.LeadSource = datarow["Source"].ToString();
                                }

                                else if (source.Contains("Scrapping Lead"))
                                {
                                    Entity.LeadSource = datarow["Source"].ToString();
                                }

                                else if (source.Contains("Email Marketing Lead"))
                                {
                                    Entity.LeadSource = datarow["Source"].ToString();
                                }
                                else
                                {
                                    _notyf.Error("Please Check Source Column in CSV sheet");
                                    return RedirectToAction("LeadUpload", "Upload");
                                }
                                if (leadlogic.CheckEmaiID(Entity.EmailID))
                                {
                                    _notyf.Error("Email ID " + Entity.EmailID + " is already Exist ");
                                    //  return RedirectToAction("LeadUpload", "Upload");
                                }
                                else
                                {
                                    IReturn objReturn = leadlogic.InsertUploadLead(Entity);
                                    Entity.LeadId = objReturn.GetPrimaryId();
                                }
                                if (Entity.AssignedTo != 0)
                                {
                                    UserLogic userLogic = new UserLogic();
                                    EntityUser user = userLogic.GetUserMailID(datarow["Sales Email Id"].ToString());

                                    EntityLeadActivities leadActivities = new EntityLeadActivities();
                                    leadActivities.LeadId = Entity;
                                    leadActivities.CreationDate = DateTime.Now;
                                    leadActivities.ContactDate = Entity.AssignedDate;
                                    leadActivities.Remarks = "Lead Assigned To " + user.Name;
                                    leadActivities.LeadStatus = "Assigned";
                                    leadActivities.FollowUpStage = "Lead Assigned";
                                    leadActivities.CreatedBy = ActivityUser;
                                    IReturn objReturn = leadlogic.InsertLeadActivity(leadActivities);
                                    leadlogic.EnableRemainderNotification(Entity.LeadId);

                                    MailLogic mailLogic = new MailLogic();
                                    mailLogic.SendAssignedMail(Entity.AssignedTo);
                                }
                            }
                        }
                        else
                        {
                            _notyf.Error("Please enter valid CSV sheet");
                            return RedirectToAction("LeadUpload", "Upload");
                        }

                    }

                }




                //DataTable transposedTable = GenerateTransposedTable(dtr);
                _notyf.Success("File Imported and CSV data saved into database");

                return RedirectToAction("LeadUpload", "Upload");
            }
        }

    }
}