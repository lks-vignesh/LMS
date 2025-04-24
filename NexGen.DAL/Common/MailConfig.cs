using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.DAL.Common
{
    public class ReturnClass
    {
        public String Subject;
        public String Body;
        public List<String> AttachmentPath;
        public List<String> AttachmentName;
        public List<AttachmentList> AttachmentList;
        public String ToList;
        public String CCList;
        public String BCCList;
        public String From;
        public String FromName;
        public String ReplyTo;
        public String Priority;
    }
    public class AttachmentList
    {
        public String AttachmentPath;
        public String AttachmentName;
    }
    public static class MailConfig
    {
        public static MailPriority ReturnPriority(this string lst)
        {
            MailPriority mp = new MailPriority();
            switch (lst)
            {
                case "H":
                    mp = MailPriority.High;
                    break;
                case "M":
                    mp = MailPriority.Normal;
                    break;
                case "L":
                    mp = MailPriority.Low;
                    break;
                default:
                    mp = MailPriority.Normal;
                    break;
            }
            return mp;
        }
        public enum StatusCode
        {
            Success = 'S',
            Warning = 'W',
            Pending = 'P',
            Failure = 'F',
            Exception = 'E'
        }
        public static DateTime NextDateCalculate(string nextrundate, string onceevery)
        {
            DateTime date = Convert.ToDateTime(nextrundate);
            switch (onceevery)
            {
                case "D": date = date.AddDays(1); break;
                case "W": date = date.AddDays(7); break;
                case "M": date = date.AddMonths(1); break;
                case "Y": date = date.AddYears(1); break;
            }
            return date;
        }
        public static string Totitlecase(this string text)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            return myTI.ToTitleCase(text);
        }
        public static string ToHTMLConvert(this string text)
        {
            return text.ToString().Replace("|~", "<").Replace("|`", ">").Replace("&nbsp", " ").Replace("&Amp;", " ");
        }
        public static string ToDateFormat(this string text)
        {
            return Convert.ToDateTime(text).ToString("dd/MM/yyyy").ToString();
        }
        public static string SendMail(ReturnClass lst)
        {
            string MailId = "noreply-eeb@nexgenrecruit.com";
            string Password = "gxhrjkswxgjymwlf";

            string returnresult = "S";
            try
            {
                SmtpClient mySmtpClient = new SmtpClient();
                mySmtpClient.Host = "smtp.office365.com";
                mySmtpClient.Port = 587;
                mySmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mySmtpClient.EnableSsl = true;
                mySmtpClient.UseDefaultCredentials = false;
                NetworkCredential basicAuthenticationInfo = new NetworkCredential(MailId, Password);
                mySmtpClient.Credentials = basicAuthenticationInfo;

                //Console.WriteLine("Mail From");
                //Console.WriteLine(lst.From);
                MailAddress from = new MailAddress(MailId, "NexGen Notification");
                MailMessage myMail = new System.Net.Mail.MailMessage();

                //Console.WriteLine("Mail From");
                //Console.WriteLine(from);
                myMail.From = from;

                string[] ToList = lst.ToList.Split(',');
                foreach (string to in ToList)
                {
                    //Console.WriteLine("Mail To");
                    //Console.WriteLine(to);
                    MailAddress toitm = new MailAddress(to);
                    myMail.To.Add(toitm);
                }
                if (lst.CCList != null)
                {
                    string[] CCList = lst.CCList.Split(',');
                    foreach (string to in CCList)
                    {
                        //Console.WriteLine("Mail To");
                        //Console.WriteLine(to);
                        MailAddress toitm = new MailAddress(to);
                        myMail.CC.Add(toitm);
                    }
                }

                //Console.WriteLine("Add ReplyTo");
                //Console.WriteLine(lst.CCList);

                MailAddress replyTo = new MailAddress(MailId);
                myMail.ReplyToList.Add(replyTo);

                //Console.WriteLine("Priority");
                //Console.WriteLine(lst.Priority.ReturnPriority());
                myMail.Priority = lst.Priority.ReturnPriority();

                //Console.WriteLine("subject");
                //Console.WriteLine(lst.Subject);
                myMail.Subject = lst.Subject;


                //Console.WriteLine("Body");
                //Console.WriteLine(lst.Body);
                //string Body = "<img alt=\"\" hspace=0 src=\"cid:imageId\" align=baseline border=0 >";
                //Body+= style = "background-image:url(cid:linkedResourceMenuBackground);"
                //Body += lst.Body;
                //string Body = "<b> Welcome to Embed image!</b><br><BR>Online resource for .net articles.<BR><img alt=\"\" hspace=0 src=\"cid:imageId\" align=baseline border=0 >";
                //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(lst.Body, null, "text/html");

                //LinkedResource imagelink = new LinkedResource(AppDomain.CurrentDomain.BaseDirectory + @"\Images\bg2.png", "image/jpg");

                //imagelink.ContentId = "imageId";

                //imagelink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;

                //htmlView.LinkedResources.Add(imagelink);

                //myMail.AlternateViews.Add(htmlView);
                //string path = AppDomain.CurrentDomain.BaseDirectory + @"\\Images\bg2.png";
                //string Body= "style=\"background-image:url("+ path + ");\"";
                //Body += lst.Body;

                myMail.Body = lst.Body;
                myMail.Body += "<br/>";
                myMail.Body += "<br/>";
                myMail.Body += "Regards,";
                myMail.Body += "<br/>";
                myMail.Body += "Marketing Team.";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                myMail.IsBodyHtml = true;
                if (lst.AttachmentList != null)
                {
                    foreach (AttachmentList ls in lst.AttachmentList)
                    {
                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(ls.AttachmentPath);
                        attachment.Name = ls.AttachmentName;
                        myMail.Attachments.Add(attachment);
                    }
                }

                Console.WriteLine(myMail.Subject + " - " + "Sending email...");
                mySmtpClient.Send(myMail);
                Console.WriteLine("Email send successfully...");
            }
            catch (SmtpException ex)
            {
                returnresult = ex.ToString();
                //throw new ApplicationException
                //  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                returnresult = ex.ToString();
                //throw ex;
            }
            return returnresult;
        }
        public static string SendEEBMail(ReturnClass lst)
        {
            string MailId = "no-reply@euroeximbank-sales.com";
            string Password = "vqbzqfvkzqsrbprn";

            string returnresult = "S";
            try
            {
                SmtpClient mySmtpClient = new SmtpClient();
                mySmtpClient.Host = "smtp.office365.com";
                mySmtpClient.Port = 587;
                mySmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mySmtpClient.EnableSsl = true;
                mySmtpClient.UseDefaultCredentials = false;
                NetworkCredential basicAuthenticationInfo = new NetworkCredential(MailId, Password);
                mySmtpClient.Credentials = basicAuthenticationInfo;

                //Console.WriteLine("Mail From");
                //Console.WriteLine(lst.From);
                MailAddress from = new MailAddress(MailId, "Euro Exim Bank Notification");
                MailMessage myMail = new System.Net.Mail.MailMessage();

                //Console.WriteLine("Mail From");
                //Console.WriteLine(from);
                myMail.From = from;

                string[] ToList = lst.ToList.Split(',');
                foreach (string to in ToList)
                {
                    //Console.WriteLine("Mail To");
                    //Console.WriteLine(to);
                    MailAddress toitm = new MailAddress(to);
                    myMail.To.Add(toitm);
                }
                if (lst.CCList != null)
                {
                    string[] CCList = lst.CCList.Split(',');
                    foreach (string to in CCList)
                    {
                        //Console.WriteLine("Mail To");
                        //Console.WriteLine(to);
                        MailAddress toitm = new MailAddress(to);
                        myMail.CC.Add(toitm);
                    }
                }

                //Console.WriteLine("Add ReplyTo");
                //Console.WriteLine(lst.CCList);

                MailAddress replyTo = new MailAddress(MailId);
                myMail.ReplyToList.Add(replyTo);

                //Console.WriteLine("Priority");
                //Console.WriteLine(lst.Priority.ReturnPriority());
                myMail.Priority = lst.Priority.ReturnPriority();

                //Console.WriteLine("subject");
                //Console.WriteLine(lst.Subject);
                myMail.Subject = lst.Subject;


                //Console.WriteLine("Body");
                //Console.WriteLine(lst.Body);
                //string Body = "<img alt=\"\" hspace=0 src=\"cid:imageId\" align=baseline border=0 >";
                //Body+= style = "background-image:url(cid:linkedResourceMenuBackground);"
                //Body += lst.Body;
                //string Body = "<b> Welcome to Embed image!</b><br><BR>Online resource for .net articles.<BR><img alt=\"\" hspace=0 src=\"cid:imageId\" align=baseline border=0 >";
                //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(lst.Body, null, "text/html");

                //LinkedResource imagelink = new LinkedResource(AppDomain.CurrentDomain.BaseDirectory + @"\Images\bg2.png", "image/jpg");

                //imagelink.ContentId = "imageId";

                //imagelink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;

                //htmlView.LinkedResources.Add(imagelink);

                //myMail.AlternateViews.Add(htmlView);
                //string path = AppDomain.CurrentDomain.BaseDirectory + @"\\Images\bg2.png";
                //string Body= "style=\"background-image:url("+ path + ");\"";
                //Body += lst.Body;

                myMail.Body = lst.Body;
                myMail.Body += "<br/>";
                myMail.Body += "<br/>";
                myMail.Body += "<b>**This is an automated message please do not reply**</b>";
                myMail.Body += "<br/>";
                myMail.Body += "<br/>";
                myMail.Body += "<br/>";
                myMail.Body += "<br/>";
                myMail.Body += "Regards,";
                myMail.Body += "<br/>";
                myMail.Body += "HR Team.";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                myMail.IsBodyHtml = true;
                if (lst.AttachmentList != null)
                {
                    foreach (AttachmentList ls in lst.AttachmentList)
                    {
                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(ls.AttachmentPath);
                        attachment.Name = ls.AttachmentName;
                        myMail.Attachments.Add(attachment);
                    }
                }

                Console.WriteLine(myMail.Subject + " - " + "Sending email...");
                mySmtpClient.Send(myMail);
                Console.WriteLine("Email send successfully...");
            }
            catch (SmtpException ex)
            {
                returnresult = ex.ToString();
                //throw new ApplicationException
                //  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                returnresult = ex.ToString();
                //throw ex;
            }
            return returnresult;
        }
        public static string SendMailHRTeam(ReturnClass lst)
        {
            string MailId = ConfigurationManager.AppSettings["HRMailId"];
            string Password = ConfigurationManager.AppSettings["HRPassword"];

            string returnresult = "S";
            try
            {
                SmtpClient mySmtpClient = new SmtpClient();
                mySmtpClient.Host = "smtp.office365.com";
                mySmtpClient.Port = 587;
                mySmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mySmtpClient.EnableSsl = true;
                mySmtpClient.UseDefaultCredentials = false;
                NetworkCredential basicAuthenticationInfo = new NetworkCredential(MailId, Password);
                mySmtpClient.Credentials = basicAuthenticationInfo;

                //Console.WriteLine("Mail From");
                //Console.WriteLine(lst.From);
                MailAddress from = new MailAddress(MailId, "NexGen Notification");
                MailMessage myMail = new System.Net.Mail.MailMessage();

                //Console.WriteLine("Mail From");
                //Console.WriteLine(from);
                myMail.From = from;

                string[] ToList = lst.ToList.Split(',');
                foreach (string to in ToList)
                {
                    //Console.WriteLine("Mail To");
                    //Console.WriteLine(to);
                    MailAddress toitm = new MailAddress(to);
                    myMail.To.Add(toitm);
                }
                if (lst.CCList != null)
                {
                    string[] CCList = lst.CCList.Split(',');
                    foreach (string to in CCList)
                    {
                        //Console.WriteLine("Mail To");
                        //Console.WriteLine(to);
                        MailAddress toitm = new MailAddress(to);
                        myMail.CC.Add(toitm);
                    }
                }
                if (lst.BCCList != null)
                {
                    string[] BCCList = lst.BCCList.Split(',');
                    foreach (string to in BCCList)
                    {
                        //Console.WriteLine("Mail To");
                        //Console.WriteLine(to);
                        MailAddress toitm = new MailAddress(to);
                        myMail.Bcc.Add(toitm);
                    }
                }
                //Console.WriteLine("Add ReplyTo");
                //Console.WriteLine(lst.CCList);

                MailAddress replyTo = new MailAddress(MailId);
                myMail.ReplyToList.Add(replyTo);

                //Console.WriteLine("Priority");
                //Console.WriteLine(lst.Priority.ReturnPriority());
                myMail.Priority = lst.Priority.ReturnPriority();

                //Console.WriteLine("subject");
                //Console.WriteLine(lst.Subject);
                myMail.Subject = lst.Subject;


                //Console.WriteLine("Body");
                //Console.WriteLine(lst.Body);
                //string Body = "<img alt=\"\" hspace=0 src=\"cid:imageId\" align=baseline border=0 >";
                //Body+= style = "background-image:url(cid:linkedResourceMenuBackground);"
                //Body += lst.Body;
                //string Body = "<b> Welcome to Embed image!</b><br><BR>Online resource for .net articles.<BR><img alt=\"\" hspace=0 src=\"cid:imageId\" align=baseline border=0 >";
                //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(lst.Body, null, "text/html");

                //LinkedResource imagelink = new LinkedResource(AppDomain.CurrentDomain.BaseDirectory + @"\Images\bg2.png", "image/jpg");

                //imagelink.ContentId = "imageId";

                //imagelink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;

                //htmlView.LinkedResources.Add(imagelink);

                //myMail.AlternateViews.Add(htmlView);
                //string path = AppDomain.CurrentDomain.BaseDirectory + @"\\Images\bg2.png";
                //string Body= "style=\"background-image:url("+ path + ");\"";
                //Body += lst.Body;




                myMail.Body = lst.Body;
                myMail.Body += "<br/>";
                myMail.Body += "<br/>";
                myMail.Body += "Regards,";
                myMail.Body += "<br/>";
                myMail.Body += "HR Team.";
                myMail.Body += "<br/>";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                myMail.IsBodyHtml = true;
                if (lst.AttachmentList != null)
                {
                    foreach (AttachmentList ls in lst.AttachmentList)
                    {
                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(ls.AttachmentPath);
                        attachment.Name = ls.AttachmentName;
                        myMail.Attachments.Add(attachment);
                    }
                }

                Console.WriteLine("Sending email...");
                mySmtpClient.Send(myMail);
                Console.WriteLine("Email send successfully...");


            }
            catch (SmtpException ex)
            {
                returnresult = ex.ToString();
                //throw new ApplicationException
                //  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                returnresult = ex.ToString();
                //throw ex;
            }
            return returnresult;
        }
        public static string SendMailITSupport(ReturnClass lst)
        {
            string MailId = ConfigurationManager.AppSettings["ITMailId"];
            string Password = ConfigurationManager.AppSettings["ITPassword"];

            string returnresult = "S";
            try
            {
                SmtpClient mySmtpClient = new SmtpClient();
                mySmtpClient.Host = "smtp.office365.com";
                mySmtpClient.Port = 587;
                mySmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mySmtpClient.EnableSsl = true;
                mySmtpClient.UseDefaultCredentials = false;
                NetworkCredential basicAuthenticationInfo = new NetworkCredential(MailId, Password);
                mySmtpClient.Credentials = basicAuthenticationInfo;

                //Console.WriteLine("Mail From");
                //Console.WriteLine(lst.From);
                MailAddress from = new MailAddress(MailId, "NexGen Notification");
                MailMessage myMail = new System.Net.Mail.MailMessage();

                //Console.WriteLine("Mail From");
                //Console.WriteLine(from);
                myMail.From = from;

                string[] ToList = lst.ToList.Split(',');
                foreach (string to in ToList)
                {
                    //Console.WriteLine("Mail To");
                    //Console.WriteLine(to);
                    MailAddress toitm = new MailAddress(to);
                    myMail.To.Add(toitm);
                }
                if (lst.CCList != null)
                {
                    string[] CCList = lst.CCList.Split(',');
                    foreach (string to in CCList)
                    {
                        //Console.WriteLine("Mail To");
                        //Console.WriteLine(to);
                        MailAddress toitm = new MailAddress(to);
                        myMail.CC.Add(toitm);
                    }
                }

                //Console.WriteLine("Add ReplyTo");
                //Console.WriteLine(lst.CCList);

                MailAddress replyTo = new MailAddress(MailId);
                myMail.ReplyToList.Add(replyTo);

                //Console.WriteLine("Priority");
                //Console.WriteLine(lst.Priority.ReturnPriority());
                myMail.Priority = lst.Priority.ReturnPriority();

                //Console.WriteLine("subject");
                //Console.WriteLine(lst.Subject);
                myMail.Subject = lst.Subject;


                //Console.WriteLine("Body");
                //Console.WriteLine(lst.Body);
                //string Body = "<img alt=\"\" hspace=0 src=\"cid:imageId\" align=baseline border=0 >";
                //Body+= style = "background-image:url(cid:linkedResourceMenuBackground);"
                //Body += lst.Body;
                //string Body = "<b> Welcome to Embed image!</b><br><BR>Online resource for .net articles.<BR><img alt=\"\" hspace=0 src=\"cid:imageId\" align=baseline border=0 >";
                //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(lst.Body, null, "text/html");

                //LinkedResource imagelink = new LinkedResource(AppDomain.CurrentDomain.BaseDirectory + @"\Images\bg2.png", "image/jpg");

                //imagelink.ContentId = "imageId";

                //imagelink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;

                //htmlView.LinkedResources.Add(imagelink);

                //myMail.AlternateViews.Add(htmlView);
                //string path = AppDomain.CurrentDomain.BaseDirectory + @"\\Images\bg2.png";
                //string Body= "style=\"background-image:url("+ path + ");\"";
                //Body += lst.Body;




                myMail.Body = lst.Body;
                myMail.Body += "<br/>";
                myMail.Body += "<br/>";
                myMail.Body += "Regards,";
                myMail.Body += "<br/>";
                myMail.Body += "HR Team.";
                myMail.Body += "<br/>";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                myMail.IsBodyHtml = true;
                if (lst.AttachmentList != null)
                {
                    foreach (AttachmentList ls in lst.AttachmentList)
                    {
                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(ls.AttachmentPath);
                        attachment.Name = ls.AttachmentName;
                        myMail.Attachments.Add(attachment);
                    }
                }

                Console.WriteLine("Sending email...");
                mySmtpClient.Send(myMail);
                Console.WriteLine("Email send successfully...");


            }
            catch (SmtpException ex)
            {
                returnresult = ex.ToString();
                //throw new ApplicationException
                //  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                returnresult = ex.ToString();
                //throw ex;
            }
            return returnresult;
        }
    }
}
