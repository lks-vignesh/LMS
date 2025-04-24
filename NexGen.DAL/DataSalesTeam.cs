using NexGen.DAL.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexGen.Repository.Leads;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using NexGen.Repository.SalesTeam;

namespace NexGen.DAL
{
    public class DataSalesTeam
    {
        #region Variable Declaration

        DataBase objDB = new DataBase();
        string spName = string.Empty;
        #endregion
        public EntitySalesTeam GetSalesTeam(string EMailID)
        {
            spName = "prc_GetSalesTeam";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@EMailID", EMailID);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return ConvertEntityData(dt);
        }
        public EntitySalesTeam GetActiveSalesTeam(string EMailID)
        {
            spName = "prc_GetActiveSalesTeam";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@EMailID", EMailID);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return ConvertEntityData(dt);
        }
        public List<EntitySalesTeam> GetAssessmentCompletedSalesTeam()
        {
            spName = "prc_GetAssessmentCompletedSalesTeam";
            DataTable dt = DataBase.ExecuteDataTableProcedure(spName);
            return ConvertEntityDatalist(dt);
        }
        public List<CountrywiseSalesTeam> GetCountrywiseSalesTeam()
        {
            spName = "prc_GetCountrywiseCount";
            DataTable dt = DataBase.ExecuteDataTableProcedure(spName);
            return ConvertCountrywiseSalesTeam(dt);
        }
        public List<RegionwiseSalesTeam> GetRegionwiseSalesTeam()
        {
            spName = "prc_GetRegionwiseCount";
            DataTable dt = DataBase.ExecuteDataTableProcedure(spName);
            return ConvertRegionwiseSalesTeam(dt);
        }
        public int InsertSalesTeam(EntitySalesTeam entity)
        {
            spName = "prc_InsertSalesTeam";
            SqlParameter[] arrparameter = new SqlParameter[19];
            arrparameter[0] = new SqlParameter("@CreatedBy", 1);
            arrparameter[1] = new SqlParameter("@Title", entity.Title);
            arrparameter[2] = new SqlParameter("@Name", entity.Name);
            arrparameter[3] = new SqlParameter("@EmpanelmentNumber", entity.EmpanelmentNumber);
            arrparameter[4] = new SqlParameter("@Designation", entity.Designation);
            arrparameter[5] = new SqlParameter("@OfficialMailId", entity.OfficialMailId);
            arrparameter[6] = new SqlParameter("@PesonalMailId", entity.PesonalMailId);
            arrparameter[7] = new SqlParameter("@MobileNumber", entity.MobileNumber);
            arrparameter[8] = new SqlParameter("@EmpanelmentStatus", entity.EmpanelmentStatus);
            arrparameter[9] = new SqlParameter("@DigiSignStatus", entity.DigiSignStatus);
            arrparameter[10] = new SqlParameter("@EMailStatus", entity.EMailStatus);
            arrparameter[11] = new SqlParameter("@SimplexStatus", entity.SimplexStatus);
            arrparameter[12] = new SqlParameter("@Country", entity.Country);
            arrparameter[13] = new SqlParameter("@ReportingTo", entity.ReportingTo);
            arrparameter[14] = new SqlParameter("@EmailNotification", entity.EmailNotification);
            arrparameter[15] = new SqlParameter("@ReportingName", entity.ReportingName);
            arrparameter[16] = new SqlParameter("@ReportingMailID", entity.ReportingMailID);
            arrparameter[17] = new SqlParameter("@eBusinessCard", entity.eBusinessCard);
            arrparameter[18] = new SqlParameter("@DefaultPassword", entity.DefaultPassword);

            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return 0;
        }
        public int UpdateSalesTeam(EntitySalesTeam entity)
        {
            spName = "prc_UpdateSalesTeam";
            SqlParameter[] arrparameter = new SqlParameter[18];
            arrparameter[0] = new SqlParameter("@Title", entity.Title);
            arrparameter[1] = new SqlParameter("@Name", entity.Name);
            arrparameter[2] = new SqlParameter("@EmpanelmentNumber", entity.EmpanelmentNumber);
            arrparameter[3] = new SqlParameter("@Designation", entity.Designation);
            arrparameter[4] = new SqlParameter("@OfficialMailId", entity.OfficialMailId);
            arrparameter[5] = new SqlParameter("@PesonalMailId", entity.PesonalMailId);
            arrparameter[6] = new SqlParameter("@MobileNumber", entity.MobileNumber);
            arrparameter[7] = new SqlParameter("@EmpanelmentStatus", entity.EmpanelmentStatus);
            arrparameter[8] = new SqlParameter("@DigiSignStatus", entity.DigiSignStatus);
            arrparameter[9] = new SqlParameter("@EMailStatus", entity.EMailStatus);
            arrparameter[10] = new SqlParameter("@SimplexStatus", entity.SimplexStatus);
            arrparameter[11] = new SqlParameter("@Country", entity.Country);
            arrparameter[12] = new SqlParameter("@ReportingTo", entity.ReportingTo);
            arrparameter[13] = new SqlParameter("@EmailNotification", entity.EmailNotification);
            arrparameter[14] = new SqlParameter("@ReportingName", entity.ReportingName);
            arrparameter[15] = new SqlParameter("@ReportingMailID", entity.ReportingMailID);
            arrparameter[16] = new SqlParameter("@eBusinessCard", entity.eBusinessCard);
            arrparameter[17] = new SqlParameter("@DefaultPassword", entity.DefaultPassword);

            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return 0;
        }
        public int UpdateSalesTeamSimplexStatus(EntitySalesTeam entity)
        {
            spName = "prc_UpdateSalesTeamSimplexStatus";
            SqlParameter[] arrparameter = new SqlParameter[2];
            arrparameter[0] = new SqlParameter("@OfficialMailId", entity.OfficialMailId);
            arrparameter[1] = new SqlParameter("@SimplexStatus", entity.SimplexStatus);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return 0;
        }
        public int UpdateEmpanelmentConfirmation(EntitySalesTeam entity)
        {
            spName = "UpdateEmpanelmentConfirmation";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@OfficialMailId", entity.OfficialMailId);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return 0;
        }
        private EntitySalesTeam ConvertEntityData(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            EntitySalesTeam salesTeam = new EntitySalesTeam();
            foreach (DataRow dr in dt.Rows)
            {
                //if (!String.IsNullOrEmpty(dr["SalesTeamID"].ToString()))
                //    salesTeam.SalesTeamID = int.Parse(dr["SalesTeamID"].ToString());
                //if (!String.IsNullOrEmpty(dr["Name"].ToString()))
                //    salesTeam.Name = dr["Name"].ToString();
                //if (!String.IsNullOrEmpty(dr["Name"].ToString()))
                //    salesTeam.Name = dr["Name"].ToString();
                //if (!String.IsNullOrEmpty(dr["EmpanelmentNumber"].ToString()))
                //    salesTeam.Designation = dr["EmpanelmentNumber"].ToString();
                //if (!String.IsNullOrEmpty(dr["OfficialMailId"].ToString()))
                //    salesTeam.OfficialMailId = dr["OfficialMailId"].ToString();
                //if (!String.IsNullOrEmpty(dr["MobileNumber"].ToString()))
                //    salesTeam.MobileNumber = dr["MobileNumber"].ToString();
                //if (!String.IsNullOrEmpty(dr["EmpanelmentStatus"].ToString()))
                //    salesTeam.EmpanelmentStatus = dr["EmpanelmentStatus"].ToString();
                //if (!String.IsNullOrEmpty(dr["DigiSignStatus"].ToString()))
                //    salesTeam.DigiSignStatus = dr["DigiSignStatus"].ToString();
                //if (!String.IsNullOrEmpty(dr["EMailStatus"].ToString()))
                //    salesTeam.EMailStatus = dr["EMailStatus"].ToString();
                //if (!String.IsNullOrEmpty(dr["SimplexStatus"].ToString()))
                //    salesTeam.SimplexStatus = dr["SimplexStatus"].ToString();
                //if (!String.IsNullOrEmpty(dr["Country"].ToString()))
                //    salesTeam.Country = dr["Country"].ToString();
                //if (!String.IsNullOrEmpty(dr["PesonalMailId"].ToString()))
                //    salesTeam.PesonalMailId = dr["PesonalMailId"].ToString();

                if (!String.IsNullOrEmpty(dr["Title"].ToString()))
                    salesTeam.Title = dr["Title"].ToString();
                if (!String.IsNullOrEmpty(dr["Name"].ToString()))
                    salesTeam.Name = dr["Name"].ToString();
                if (!String.IsNullOrEmpty(dr["EmpanelmentNumber"].ToString()))
                    salesTeam.EmpanelmentNumber = dr["EmpanelmentNumber"].ToString();
                if (!String.IsNullOrEmpty(dr["Designation"].ToString()))
                    salesTeam.Designation = dr["Designation"].ToString();
                if (!String.IsNullOrEmpty(dr["OfficialMailId"].ToString()))
                    salesTeam.OfficialMailId = dr["OfficialMailId"].ToString();
                if (!String.IsNullOrEmpty(dr["PesonalMailId"].ToString()))
                    salesTeam.PesonalMailId = dr["PesonalMailId"].ToString();
                if (!String.IsNullOrEmpty(dr["MobileNumber"].ToString()))
                    salesTeam.MobileNumber = dr["MobileNumber"].ToString();
                if (!String.IsNullOrEmpty(dr["EmpanelmentStatus"].ToString()))
                    salesTeam.EmpanelmentStatus = dr["EmpanelmentStatus"].ToString();
                if (!String.IsNullOrEmpty(dr["DigiSignStatus"].ToString()))
                    salesTeam.DigiSignStatus = dr["DigiSignStatus"].ToString();
                if (!String.IsNullOrEmpty(dr["EMailStatus"].ToString()))
                    salesTeam.EMailStatus = dr["EMailStatus"].ToString();
                if (!String.IsNullOrEmpty(dr["SimplexStatus"].ToString()))
                    salesTeam.SimplexStatus = dr["SimplexStatus"].ToString();
                if (!String.IsNullOrEmpty(dr["Country"].ToString()))
                    salesTeam.Country = dr["Country"].ToString();
                //if (!String.IsNullOrEmpty(dr["ReportingTo"].ToString()))
                //    salesTeam.ReportingTo = dr["ReportingTo"].ToString();
                if (!String.IsNullOrEmpty(dr["ReportingName"].ToString()))
                    salesTeam.ReportingName = dr["ReportingName"].ToString();
                if (!String.IsNullOrEmpty(dr["ReportingMailID"].ToString()))
                    salesTeam.ReportingMailID = dr["ReportingMailID"].ToString();
                if (!String.IsNullOrEmpty(dr["eBusinessCard"].ToString()))
                    salesTeam.eBusinessCard = dr["eBusinessCard"].ToString();
                if (!String.IsNullOrEmpty(dr["DefaultPassword"].ToString()))
                    salesTeam.DefaultPassword = dr["DefaultPassword"].ToString();



            }
            return salesTeam;
        }
        private List<EntitySalesTeam> ConvertEntityDatalist(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<EntitySalesTeam> salesTeams = new List<EntitySalesTeam>();

            foreach (DataRow dr in dt.Rows)
            {
                EntitySalesTeam salesTeam = new EntitySalesTeam();
                //if (!String.IsNullOrEmpty(dr["SalesTeamID"].ToString()))
                //    salesTeam.SalesTeamID = int.Parse(dr["SalesTeamID"].ToString());
                //if (!String.IsNullOrEmpty(dr["Name"].ToString()))
                //    salesTeam.Name = dr["Name"].ToString();
                //if (!String.IsNullOrEmpty(dr["Name"].ToString()))
                //    salesTeam.Name = dr["Name"].ToString();
                //if (!String.IsNullOrEmpty(dr["EmpanelmentNumber"].ToString()))
                //    salesTeam.Designation = dr["EmpanelmentNumber"].ToString();
                //if (!String.IsNullOrEmpty(dr["OfficialMailId"].ToString()))
                //    salesTeam.OfficialMailId = dr["OfficialMailId"].ToString();
                //if (!String.IsNullOrEmpty(dr["MobileNumber"].ToString()))
                //    salesTeam.MobileNumber = dr["MobileNumber"].ToString();
                //if (!String.IsNullOrEmpty(dr["EmpanelmentStatus"].ToString()))
                //    salesTeam.EmpanelmentStatus = dr["EmpanelmentStatus"].ToString();
                //if (!String.IsNullOrEmpty(dr["DigiSignStatus"].ToString()))
                //    salesTeam.DigiSignStatus = dr["DigiSignStatus"].ToString();
                //if (!String.IsNullOrEmpty(dr["EMailStatus"].ToString()))
                //    salesTeam.EMailStatus = dr["EMailStatus"].ToString();
                //if (!String.IsNullOrEmpty(dr["SimplexStatus"].ToString()))
                //    salesTeam.SimplexStatus = dr["SimplexStatus"].ToString();
                //if (!String.IsNullOrEmpty(dr["Country"].ToString()))
                //    salesTeam.Country = dr["Country"].ToString();
                //if (!String.IsNullOrEmpty(dr["PesonalMailId"].ToString()))
                //    salesTeam.PesonalMailId = dr["PesonalMailId"].ToString();

                if (!String.IsNullOrEmpty(dr["Title"].ToString()))
                    salesTeam.Title = dr["Title"].ToString();
                if (!String.IsNullOrEmpty(dr["Name"].ToString()))
                    salesTeam.Name = dr["Name"].ToString();
                if (!String.IsNullOrEmpty(dr["EmpanelmentNumber"].ToString()))
                    salesTeam.EmpanelmentNumber = dr["EmpanelmentNumber"].ToString();
                if (!String.IsNullOrEmpty(dr["Designation"].ToString()))
                    salesTeam.Designation = dr["Designation"].ToString();
                if (!String.IsNullOrEmpty(dr["OfficialMailId"].ToString()))
                    salesTeam.OfficialMailId = dr["OfficialMailId"].ToString();
                if (!String.IsNullOrEmpty(dr["PesonalMailId"].ToString()))
                    salesTeam.PesonalMailId = dr["PesonalMailId"].ToString();
                if (!String.IsNullOrEmpty(dr["MobileNumber"].ToString()))
                    salesTeam.MobileNumber = dr["MobileNumber"].ToString();
                if (!String.IsNullOrEmpty(dr["EmpanelmentStatus"].ToString()))
                    salesTeam.EmpanelmentStatus = dr["EmpanelmentStatus"].ToString();
                if (!String.IsNullOrEmpty(dr["DigiSignStatus"].ToString()))
                    salesTeam.DigiSignStatus = dr["DigiSignStatus"].ToString();
                if (!String.IsNullOrEmpty(dr["EMailStatus"].ToString()))
                    salesTeam.EMailStatus = dr["EMailStatus"].ToString();
                if (!String.IsNullOrEmpty(dr["SimplexStatus"].ToString()))
                    salesTeam.SimplexStatus = dr["SimplexStatus"].ToString();
                if (!String.IsNullOrEmpty(dr["Country"].ToString()))
                    salesTeam.Country = dr["Country"].ToString();
                //if (!String.IsNullOrEmpty(dr["ReportingTo"].ToString()))
                //    salesTeam.ReportingTo = dr["ReportingTo"].ToString();
                if (!String.IsNullOrEmpty(dr["ReportingName"].ToString()))
                    salesTeam.ReportingName = dr["ReportingName"].ToString();
                if (!String.IsNullOrEmpty(dr["ReportingMailID"].ToString()))
                    salesTeam.ReportingMailID = dr["ReportingMailID"].ToString();
                if (!String.IsNullOrEmpty(dr["eBusinessCard"].ToString()))
                    salesTeam.eBusinessCard = dr["eBusinessCard"].ToString();
                if (!String.IsNullOrEmpty(dr["DefaultPassword"].ToString()))
                    salesTeam.DefaultPassword = dr["DefaultPassword"].ToString();


                salesTeams.Add(salesTeam);
            }
            return salesTeams;
        }
        private List<CountrywiseSalesTeam> ConvertCountrywiseSalesTeam(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<CountrywiseSalesTeam> salesTeams = new List<CountrywiseSalesTeam>();

            foreach (DataRow dr in dt.Rows)
            {
                CountrywiseSalesTeam salesTeam = new CountrywiseSalesTeam();

                if (!String.IsNullOrEmpty(dr["Country"].ToString()))
                    salesTeam.Country = dr["Country"].ToString();

                if (!String.IsNullOrEmpty(dr["Region"].ToString()))
                    salesTeam.Region = dr["Region"].ToString();

                if (!String.IsNullOrEmpty(dr["TFS"].ToString()))
                    salesTeam.TFS = int.Parse(dr["TFS"].ToString());

                if (!String.IsNullOrEmpty(dr["TFC"].ToString()))
                    salesTeam.TFC = int.Parse(dr["TFC"].ToString());

                if (!String.IsNullOrEmpty(dr["TFE"].ToString()))
                    salesTeam.TFE = int.Parse(dr["TFE"].ToString());

                if (!String.IsNullOrEmpty(dr["Total"].ToString()))
                    salesTeam.Total = int.Parse(dr["Total"].ToString());

                salesTeams.Add(salesTeam);
            }
            return salesTeams;
        }
        private List<RegionwiseSalesTeam> ConvertRegionwiseSalesTeam(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<RegionwiseSalesTeam> salesTeams = new List<RegionwiseSalesTeam>();

            foreach (DataRow dr in dt.Rows)
            {
                RegionwiseSalesTeam salesTeam = new RegionwiseSalesTeam();

                if (!String.IsNullOrEmpty(dr["Region"].ToString()))
                    salesTeam.Region = dr["Region"].ToString();

                if (!String.IsNullOrEmpty(dr["TFS"].ToString()))
                    salesTeam.TFS = int.Parse(dr["TFS"].ToString());

                if (!String.IsNullOrEmpty(dr["TFC"].ToString()))
                    salesTeam.TFC = int.Parse(dr["TFC"].ToString());

                if (!String.IsNullOrEmpty(dr["TFE"].ToString()))
                    salesTeam.TFE = int.Parse(dr["TFE"].ToString());

                if (!String.IsNullOrEmpty(dr["Total"].ToString()))
                    salesTeam.Total = int.Parse(dr["Total"].ToString());

                salesTeams.Add(salesTeam);
            }
            return salesTeams;
        }
    }
}
