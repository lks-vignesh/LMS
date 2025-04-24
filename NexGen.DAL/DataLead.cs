using NexGen.DAL.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexGen.Repository.Leads;

namespace NexGen.DAL
{

    public class DataLead
    {
        #region Variable Declaration

        DataBase objDB = new DataBase();
        string spName = string.Empty;
        #endregion
        public int InsertLead(EntityLeads objInsert)
        {
            spName = "prc_InsertLead";
            SqlParameter[] arrparameter = new SqlParameter[23];
            arrparameter[0] = new SqlParameter("@CreatedBy", objInsert.CreatedBy);
            arrparameter[1] = new SqlParameter("@Company_Name", objInsert.Company_Name);
            arrparameter[2] = new SqlParameter("@EnquiryNumber", objInsert.EnquiryNumber);
            arrparameter[3] = new SqlParameter("@Company_Details", objInsert.Company_Details);
            arrparameter[4] = new SqlParameter("@City", objInsert.City);
            arrparameter[5] = new SqlParameter("@Country", objInsert.Country);
            arrparameter[6] = new SqlParameter("@Sector", objInsert.Sector);
            arrparameter[7] = new SqlParameter("@ContactPerson", objInsert.ContactPerson);
            arrparameter[8] = new SqlParameter("@Designation", objInsert.Designation);
            arrparameter[9] = new SqlParameter("@MobileNumber", objInsert.MobileNumber);
            arrparameter[10] = new SqlParameter("@EmailID", objInsert.EmailID);
            arrparameter[11] = new SqlParameter("@LeadSource", objInsert.LeadSource);
            arrparameter[12] = new SqlParameter("@InstrumentValue", objInsert.InstrumentValue);
            arrparameter[13] = new SqlParameter("@AssignedTo", objInsert.AssignedTo);
            arrparameter[14] = new SqlParameter("@Active", objInsert.Active);
            arrparameter[15] = new SqlParameter("@WhatsAppNumber", objInsert.WhatsAppNumber);
            arrparameter[16] = new SqlParameter("@CreationDate", objInsert.CreationDate);
            arrparameter[17] = new SqlParameter("@IntrumentType", objInsert.IntrumentType);
            arrparameter[18] = new SqlParameter("@InstrumentIssuanceTimeline", objInsert.InstrumentIssuanceTimeline);
            arrparameter[19] = new SqlParameter("@AnnualRequirement", objInsert.AnnualRequirement);
            arrparameter[20] = new SqlParameter("@AnnualTurnOver", objInsert.AnnualTurnOver);
            arrparameter[21] = new SqlParameter("@AdditionalInformation", objInsert.AdditionalInformation);
            arrparameter[22] = new SqlParameter("@LeadSourceDate", objInsert.LeadSourceDate);


            int ID = DataBase.ExecuteQuery(spName, arrparameter);
            return ID;
        }
        public EntityLeads GetMaxID(int Id)
        {
            spName = "prc_GetMaxId";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@LeadId", Id);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return ConvertEntityDataLead(dt);
        }
        public int EnableRemainderNotification(int Id)
        {
            spName = "prc_EnableRemainderNotification";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@LeadId", Id);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return 0;
        }
        public int DisableRemainderNotification(int Id)
        {
            spName = "prc_DisableRemainderNotification";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@LeadId", Id);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return 0;
        }
        public int UpdateLead(EntityLeads objInsert)
        {
            spName = "prc_UpdateLead";
            SqlParameter[] arrparameter = new SqlParameter[27];
            arrparameter[0] = new SqlParameter("@CreatedBy", objInsert.CreatedBy);
            arrparameter[1] = new SqlParameter("@Company_Name", objInsert.Company_Name);
            arrparameter[2] = new SqlParameter("@EnquiryNumber", objInsert.EnquiryNumber);
            arrparameter[3] = new SqlParameter("@Company_Details", objInsert.Company_Details);
            arrparameter[4] = new SqlParameter("@City", objInsert.City);
            arrparameter[5] = new SqlParameter("@Country", objInsert.Country);
            arrparameter[6] = new SqlParameter("@Sector", objInsert.Sector);
            arrparameter[7] = new SqlParameter("@ContactPerson", objInsert.ContactPerson);
            arrparameter[8] = new SqlParameter("@Designation", objInsert.Designation);
            arrparameter[9] = new SqlParameter("@MobileNumber", objInsert.MobileNumber);
            arrparameter[10] = new SqlParameter("@EmailID", objInsert.EmailID);
            arrparameter[11] = new SqlParameter("@LeadSource", objInsert.LeadSource);
            arrparameter[12] = new SqlParameter("@InstrumentValue", objInsert.InstrumentValue);
            arrparameter[13] = new SqlParameter("@Active", objInsert.Active);
            arrparameter[14] = new SqlParameter("@LeadId", objInsert.LeadId);
            arrparameter[15] = new SqlParameter("@WhatsAppNumber", objInsert.WhatsAppNumber);
            arrparameter[16] = new SqlParameter("@AlternativeMobileNumber", objInsert.AlternativeMobileNumber);
            arrparameter[17] = new SqlParameter("@AlternateEmail", objInsert.AlternateEmail);
            arrparameter[18] = new SqlParameter("@AlternateCompanyName", objInsert.AlternateCompanyName);
            arrparameter[19] = new SqlParameter("@IntrumentType", objInsert.IntrumentType);
            arrparameter[20] = new SqlParameter("@InstrumentIssuanceTimeline", objInsert.InstrumentIssuanceTimeline);
            arrparameter[21] = new SqlParameter("@AnnualRequirement", objInsert.AnnualRequirement);
            arrparameter[22] = new SqlParameter("@AnnualTurnOver", objInsert.AnnualTurnOver);
            arrparameter[23] = new SqlParameter("@AdditionalInformation", objInsert.AdditionalInformation);
            arrparameter[24] = new SqlParameter("@LeadSourceDate", objInsert.LeadSourceDate);
            arrparameter[25] = new SqlParameter("@LastUpdateBy", objInsert.LastUpdateBy);
            arrparameter[26] = new SqlParameter("@AssignedDate", objInsert.AssignedDate);

            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return 0;
        }
        public int UpdateLeadReAssign(EntityLeads objInsert)
        {
            spName = "prc_UpdateLeadReAssign";
            SqlParameter[] arrparameter = new SqlParameter[2];
            arrparameter[0] = new SqlParameter("@AssignedTo", objInsert.AssignedTo);
            arrparameter[1] = new SqlParameter("@LeadId", objInsert.LeadId);

            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return 0;
        }
        public EntityLeads GetLeadID(int Id)
        {
            spName = "prc_GetLeadId";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@LeadId", Id);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return ConvertEntityDataLead(dt);
        }

        //public EntityLeads GetLeadStatus(string Followupstage)
        //{
        //    spName = "prc_GetFollowup";
        //    SqlParameter[] arrparameter = new SqlParameter[1];
        //    arrparameter[0] = new SqlParameter("@LeadStatus", Followupstage);
        //    DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
        //    return ConvertEntityDataLead(dt);
        //}
        public EntityLeadActivities GetLeadActivityID(int ActivityId)
        {
            spName = "prc_GetLeadActivityId";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@LeadActivityId", ActivityId);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return ConvertEntityDataLeadActivity(dt);
        }
        public List<EntityLeadStatus> GetddlLeadStatus()
        {
            spName = "prc_GetddlLeadStatus";
            DataTable dt = DataBase.ExecuteDataTableProcedure(spName);
            return ConvertEntityDataLeadStatus(dt);
        }


        public DataTable GetLeadsActivitiesExport()
        {
            spName = "prc_GetLeadActivitiesExport";
            //SqlParameter[] arrparameter = new SqlParameter[1];
            //arrparameter[0] = new SqlParameter("@LeadId", LeadId);
            DataTable dt = DataBase.ExecuteDataTableProcedure(spName);
            return dt;
        }
        public List<EntityLeads> GetLeads_NoActivity()
        {

            spName = "prc_GetLeads_NoActivity";
            //SqlParameter[] arrparameter = new SqlParameter[1];
            //arrparameter[0] = new SqlParameter("@LeadId", LeadId);
            DataTable dt = DataBase.ExecuteDataTableProcedure(spName);
            return ConvertEntityDataLeads(dt);
        }
        public List<EntityLeads> GetLeads_Followup()
        {

            spName = "prc_GetLeads_Followup";
            //SqlParameter[] arrparameter = new SqlParameter[1];
            //arrparameter[0] = new SqlParameter("@LeadId", LeadId);
            DataTable dt = DataBase.ExecuteDataTableProcedure(spName);
            return ConvertEntityDataLeads(dt);
        }
        public List<EntityLeads> GetLeads(int AssignedTo)
        {
            spName = "prc_GetLeads";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@AssignedTo", AssignedTo);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return ConvertEntityDataLeads(dt);
        }
        public List<EntityLeads> GetLeadsActivities(int AssignedTo)
        {
            spName = "prc_GetLeadActivitiesList";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@AssignedTo", AssignedTo);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return ConvertEntityActivitiesDataLeads(dt);
        }

        public List<EntityLeadActivities> GetLeadStatusCount(int userID)
        {
            spName = "prc_GetLeadStatusCount";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@UserId", userID);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return ConvertLeadStatusCount(dt);
        }
        public Boolean CheckEMailID(string MailID)
        {
            spName = "prc_chkEMailID";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@EmailID", MailID);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            if (dt.Rows.Count != 0)
                return true;
            else
                return false;
        }
        public string GetLeadStatus(string FollowUpStage)
        {
            spName = "prc_GetLeadStatus";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@FollowUpStage", FollowUpStage);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            string LeadStatus = string.Empty;
            if (dt.Rows.Count > 0)
                LeadStatus = dt.Rows[0][0].ToString();
            return LeadStatus;
        }
        public Boolean CheckAssignTo(string AssignedTo)
        {
            spName = "prc_chkAssignTo";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@EmailId", AssignedTo);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public List<EntityLeadActivities> GetLeadActivities(int UserID, int LeadID)
        {
            spName = "prc_GetLeadActivities";
            SqlParameter[] arrparameter = new SqlParameter[2];
            arrparameter[0] = new SqlParameter("@CreatedBy", UserID);
            arrparameter[1] = new SqlParameter("@LeadId", LeadID);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return ConvertEntityDataLeadActivities(dt);
        }
        public int InsertLeadActivity(EntityLeadActivities objInsert)
        {
            spName = "prc_InsertLeadActivities";
            SqlParameter[] arrparameter = new SqlParameter[8];
            arrparameter[0] = new SqlParameter("@LeadId", objInsert.LeadId.LeadId);
            arrparameter[1] = new SqlParameter("@ContactDate", objInsert.ContactDate);
            arrparameter[2] = new SqlParameter("@FollowUpDate", objInsert.FollowUpDate);
            arrparameter[3] = new SqlParameter("@FollowUpStage", objInsert.FollowUpStage);
            arrparameter[4] = new SqlParameter("@Remarks", objInsert.Remarks);
            arrparameter[5] = new SqlParameter("@CreatedBy", objInsert.CreatedBy);
            arrparameter[6] = new SqlParameter("@Active", objInsert.Active);
            arrparameter[7] = new SqlParameter("@LeadStatus", objInsert.LeadStatus);

            int ID = DataBase.ExecuteQuery(spName, arrparameter);
            return ID;
        }
        public int UploadLead(EntityLeads objInsert)
        {
            spName = "prc_UploadLead";
            SqlParameter[] arrparameter = new SqlParameter[24];
            arrparameter[0] = new SqlParameter("@CreatedBy", objInsert.CreatedBy);
            arrparameter[1] = new SqlParameter("@Company_Name", objInsert.Company_Name);
            arrparameter[2] = new SqlParameter("@City", objInsert.City);
            arrparameter[3] = new SqlParameter("@Country", objInsert.Country);
            arrparameter[4] = new SqlParameter("@Sector", objInsert.Sector);
            arrparameter[5] = new SqlParameter("@ContactPerson", objInsert.ContactPerson);
            arrparameter[6] = new SqlParameter("@Designation", objInsert.Designation);
            arrparameter[7] = new SqlParameter("@MobileNumber", objInsert.MobileNumber);
            arrparameter[8] = new SqlParameter("@EmailID", objInsert.EmailID);
            arrparameter[9] = new SqlParameter("@LeadSource", objInsert.LeadSource);
            arrparameter[10] = new SqlParameter("@InstrumentValue", objInsert.InstrumentValue);
            arrparameter[11] = new SqlParameter("@AssignedTo", objInsert.AssignedTo);
            arrparameter[12] = new SqlParameter("@AdditionalInformation", objInsert.AdditionalInformation);
            arrparameter[13] = new SqlParameter("@WhatsAppNumber", objInsert.WhatsAppNumber);
            arrparameter[14] = new SqlParameter("@InstrumentIssuanceTimeline", objInsert.InstrumentIssuanceTimeline);
            arrparameter[15] = new SqlParameter("@AnnualRequirement", objInsert.AnnualRequirement);
            arrparameter[16] = new SqlParameter("@AnnualTurnOver", objInsert.AnnualTurnOver);
            arrparameter[17] = new SqlParameter("@IntrumentType", objInsert.IntrumentType);
            arrparameter[18] = new SqlParameter("@AssignedDate", objInsert.AssignedDate);
            arrparameter[19] = new SqlParameter("@Active", objInsert.Active);
            arrparameter[20] = new SqlParameter("@CreationDate", objInsert.CreationDate);
            arrparameter[21] = new SqlParameter("@LeadSourceDate", objInsert.LeadSourceDate);
            arrparameter[22] = new SqlParameter("@Company_Details", objInsert.Company_Details);
            arrparameter[23] = new SqlParameter("@AssignedTo_MailID", objInsert.AssignedTo_MailID);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);

            int id = 0;
            if (dt.Rows.Count > 0)
                id = int.Parse(dt.Rows[0][0].ToString());
            return id;
        }
        private EntityLeads ConvertEntityDataLead(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            EntityLeads lead = new EntityLeads();
            foreach (DataRow dr in dt.Rows)
            {
                if (!String.IsNullOrEmpty(dr[0].ToString()))
                    lead.LeadId = int.Parse(dr["LeadId"].ToString());
                lead.Company_Name = dr["Company_Name"].ToString();
                lead.EnquiryNumber = dr["EnquiryNumber"].ToString();
                lead.Company_Details = dr["Company_Details"].ToString();
                lead.City = dr["City"].ToString();
                lead.Country = dr["Country"].ToString();
                lead.Sector = dr["Sector"].ToString();
                lead.ContactPerson = dr["ContactPerson"].ToString();
                lead.Designation = dr["Designation"].ToString();
                lead.MobileNumber = dr["MobileNumber"].ToString();
                lead.EmailID = dr["EmailID"].ToString();
                lead.LeadSource = dr["LeadSource"].ToString();
                lead.InstrumentValue = dr["InstrumentValue"].ToString();
                lead.WhatsAppNumber = dr["WhatsAppNumber"].ToString();
                lead.IntrumentType = dr["IntrumentType"].ToString();
                lead.InstrumentIssuanceTimeline = dr["InstrumentIssuanceTimeline"].ToString();
                lead.AnnualRequirement = dr["AnnualRequirement"].ToString();
                lead.AnnualTurnOver = dr["AnnualTurnOver"].ToString();
                lead.AdditionalInformation = dr["AdditionalInformation"].ToString();
                lead.AlternativeMobileNumber = dr["AlternativeMobileNumber"].ToString();
                lead.AlternateEmail = dr["AlternateEmail"].ToString();
                lead.AlternateCompanyName = dr["AlternateCompanyName"].ToString();
                var date = dr["LeadSourceDate"].ToString();
                var assignDate = dr["AssignedDate"].ToString();
                lead.AssignedDate = DateTime.Parse(assignDate);
                lead.LeadSourceDate = DateTime.Parse(date);
                if (dr["AssignedTo"] != null && dr["AssignedTo"] != "")
                {
                    string AssignedTo = dr["AssignedTo"].ToString();
                    if (AssignedTo != "")
                    {

                        lead.AssignedTo = int.Parse(dr["AssignedTo"].ToString());
                        DataUser dataUser = new DataUser();
                        EntityUser user = dataUser.GetUserID(lead.AssignedTo);
                        if (user != null)
                        {
                            lead.AssignedTo_MailID = user.EmailId;
                        }
                    }
                }
            }
            return lead;
        }
        private EntityLeadActivities ConvertEntityDataLeadActivity(DataTable dt)
        {
            DataLead dataLead = new DataLead();

            EntityLeadActivities LeadActivity = new EntityLeadActivities();
            foreach (DataRow dr in dt.Rows)
            {
                if (!String.IsNullOrEmpty(dr["LeadActivityId"].ToString()))
                    LeadActivity.LeadActivityId = int.Parse(dr["LeadActivityId"].ToString());
                if (!String.IsNullOrEmpty(dr["LeadId"].ToString()))
                {
                    int CompanyId = int.Parse(dr["LeadId"].ToString());
                    LeadActivity.LeadId = dataLead.GetLeadID(CompanyId);
                }

                LeadActivity.ContactDate = DateTime.Parse(dr["ContactDate"].ToString());
                LeadActivity.FollowUpDate = DateTime.Parse(dr["FollowUpDate"].ToString());
                LeadActivity.FollowUpStage = dr["FollowUpStage"].ToString();
                LeadActivity.Remarks = dr["Remarks"].ToString();
                LeadActivity.LeadStatus = dr["LeadStatus"].ToString();

            }
            return LeadActivity;
        }
        private List<EntityLeadStatus> ConvertEntityDataLeadStatus(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<EntityLeadStatus> entityLeadStatus = new List<EntityLeadStatus>();
            foreach (DataRow dr in dt.Rows)
            {
                EntityLeadStatus entity = new EntityLeadStatus();

                if (!String.IsNullOrEmpty(dr[0].ToString()))
                    entity.Followup_Stage = dr["FollowupStage"].ToString();
                entity.Lead_status = dr["LeadStatus"].ToString();
                entityLeadStatus.Add(entity);
            }
            return entityLeadStatus;
        }

        private List<EntityLeadActivities> ConvertLeadStatusCount(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<EntityLeadActivities> entityLeadStatus = new List<EntityLeadActivities>();
            foreach (DataRow dr in dt.Rows)
            {
                EntityLeadActivities entity = new EntityLeadActivities();

                if (!String.IsNullOrEmpty(dr[0].ToString()))
                    entity.FollowUpStage = dr["FollowUpStage"].ToString();
                entity.LeadStatus = dr["LeadStatus"].ToString();
                entity.NoOfLeads = dr["NoOfLeads"].ToString();

                entityLeadStatus.Add(entity);
            }
            return entityLeadStatus;
        }


        private List<EntityLeads> ConvertEntityActivitiesDataLeads(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<EntityLeads> entityLeads = new List<EntityLeads>();
            foreach (DataRow dr in dt.Rows)
            {
                EntityLeads lead = new EntityLeads();
                lead = GetLeadID(int.Parse(dr["LeadId"].ToString()));
                lead.FollowUpStage = dr["FollowUpStage"].ToString();
                lead.AssignedDate = DateTime.Parse(dr["AssignedDate"].ToString());
                lead.LeadStatus = dr["LeadStatus"].ToString();
                entityLeads.Add(lead);
            }
            return entityLeads;
        }
        private List<EntityLeads> ConvertEntityDataLeads(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<EntityLeads> entityLeads = new List<EntityLeads>();
            foreach (DataRow dr in dt.Rows)
            {
                EntityLeads entity = new EntityLeads();
                if (!String.IsNullOrEmpty(dr[0].ToString()))
                    entity.LeadId = int.Parse(dr["LeadId"].ToString());
                entity.Company_Name = dr["Company_Name"].ToString();
                entity.EnquiryNumber = dr["EnquiryNumber"].ToString();
                entity.Company_Details = dr["Company_Details"].ToString();
                entity.City = dr["City"].ToString();
                entity.Country = dr["Country"].ToString();
                entity.Sector = dr["Sector"].ToString();
                entity.ContactPerson = dr["ContactPerson"].ToString();
                entity.Designation = dr["Designation"].ToString();
                entity.MobileNumber = dr["MobileNumber"].ToString();
                entity.EmailID = dr["EmailID"].ToString();
                entity.LeadSource = dr["LeadSource"].ToString();
                entity.InstrumentValue = dr["InstrumentValue"].ToString();
                entity.AssignedDate = DateTime.Parse(dr["AssignedDate"].ToString());
                entity.LeadSourceDate = DateTime.Parse(dr["LeadSourceDate"].ToString());
                if (dr["AssignedTo"] != null && dr["AssignedTo"] != "")
                {
                    string AssignedTo = dr["AssignedTo"].ToString();
                    if (AssignedTo != "")
                    {

                        entity.AssignedTo = int.Parse(dr["AssignedTo"].ToString());
                        DataUser dataUser = new DataUser();
                        EntityUser user = dataUser.GetUserID(entity.AssignedTo);
                        if (user != null)
                        {
                            entity.AssignedTo_MailID = user.EmailId;
                        }
                    }
                }

                entityLeads.Add(entity);
            }
            return entityLeads;
        }
        private List<EntityLeadActivities> ConvertEntityDataLeadActivities(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<EntityLeadActivities> entityLeadActivities = new List<EntityLeadActivities>();
            foreach (DataRow dr in dt.Rows)
            {
                EntityLeadActivities entity = new EntityLeadActivities();

                if (!String.IsNullOrEmpty(dr[0].ToString()))
                    entity.LeadActivityId = int.Parse(dr["LeadActivityId"].ToString());
                entity.LeadId = GetLeadID(int.Parse(dr["LeadId"].ToString()));

                entity.ContactDate = DateTime.Parse(dr["ContactDate"].ToString());

                string followupDate = dr["FollowUpDate"].ToString();
                if (followupDate == null || followupDate == "")
                {
                    entity.FollowUpDate = null;
                }
                else
                {
                    entity.FollowUpDate = DateTime.Parse(followupDate);
                }


                //entity.FollowUpDate = DateTime.Now;
                entity.FollowUpStage = dr["FollowUpStage"].ToString();
                entity.Remarks = dr["Remarks"].ToString();
                entity.LeadStatus = dr["LeadStatus"].ToString();
                entityLeadActivities.Add(entity);
            }
            return entityLeadActivities;
        }
    }
}
