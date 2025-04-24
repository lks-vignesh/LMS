using NexGen.DAL.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NexGen.Repository.Leads;

namespace NexGen.DAL
{

    public class DataRecruitmentTeam
    {
        #region Variable Declaration

        DataBase objDB = new DataBase();
        string spName = string.Empty;
        #endregion
        public EntityRecruitmentTeam GetRecruitmentTeam(string EMailID)
        {
            spName = "prc_GetRecruitmentTeam";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@EMailID", EMailID);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return ConvertEntityData(dt);
        }
        private EntityRecruitmentTeam ConvertEntityData(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            EntityRecruitmentTeam lead = new EntityRecruitmentTeam();
            foreach (DataRow dr in dt.Rows)
            {
                if (!String.IsNullOrEmpty(dr[0].ToString()))
                    lead.ID = int.Parse(dr["ID"].ToString());
                lead.Name = dr["Name"].ToString();
                lead.Designation = dr["Designation"].ToString();
                lead.EMailID = dr["EMailID"].ToString();
                lead.MobileNumber = dr["MobileNumber"].ToString();

            }
            return lead;
        }
    }
}
