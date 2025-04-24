using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using NexGen.BL;
using NexGen.CRM.Models;
using NexGen.Repository.Leads;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NexGen.CRM.Controllers
{
    public class HomeController : Controller
    {
        internal UserLogic logic = new UserLogic();
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _notyf;
        private IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, INotyfService notyf, IConfiguration _configuration)
        {
            _logger = logger;
            _notyf = notyf;
            Configuration = _configuration;

        }

        public IActionResult Index()
        {

            //string path = System.IO.Directory.GetCurrentDirectory() + "\\DB";
            //DBBackupLogic backupLogic = new DBBackupLogic();
            //backupLogic.BackupDatabase("NexGen", "sa", "tech@123", "TRD0002\\SQLEXPRESS03", path);
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            return View();
        }
        public IActionResult SignIn()
        {

            return View();
        }
        public IActionResult LogIn()
        {
           
            //MailLogic mailLogic = new MailLogic();
            //mailLogic.SendAssignedmail(1);
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult LeadActivitiesCount()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Home");
            int UserID = HttpContext.Session.GetInt32("UserID") != null ? HttpContext.Session.GetInt32("UserID").Value : 0;

            LeadLogic objLogic = new LeadLogic();
            List<EntityLeadActivities> leadlist = new List<EntityLeadActivities>();
            leadlist = objLogic.GetLeadStatusCount(UserID);
            var jsonData = new { data = leadlist };
            return Ok(jsonData);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(EntityUser model, string name)
        {
            try
            {
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                               @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(emailRegex);

                if (model.EmailId == "" || model.EmailId == null)
                {
                    _notyf.Error("Please Enter Email Id");
                    return RedirectToAction("LogIn", "Home");
                }
                else if (!re.IsMatch(model.EmailId))
                {
                    _notyf.Error("Email is not Valid");
                    return RedirectToAction("LogIn", "Home");
                }
                else if ((model.Password == "") || (model.Password == null))
                {
                    _notyf.Error("Please Enter  Password");
                    return RedirectToAction("LogIn", "Home");
                }
                else
                {
                    string StrUsername = model.EmailId.ToString();
                    //string strpassword = logic.Encrypt(model.Password);
                    string StrPassword = model.Password.ToString();

                    EntityUser objlogin = new EntityUser();
                    objlogin = logic.GetLoginDetails(StrUsername, StrPassword);
                    int StrRoleID = objlogin.RoleId;

                    if (objlogin.Active == true)
                    {
                        HttpContext.Session.SetInt32("RoleId", objlogin.RoleId);
                        HttpContext.Session.SetString("EMailID", objlogin.EmailId);
                        HttpContext.Session.SetInt32("UserID", objlogin.UserId);
                        _notyf.Success("Login Successful!.");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        _notyf.Error("Invalid Credentials!.");
                        return (RedirectToAction("LogIn", "Home"));
                    }
                }
                //return Task.FromResult<IActionResult>(RedirectToAction("Index", "Home"));
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
                return (RedirectToAction("LogIn", "Home"));
            }

        }
    }
}