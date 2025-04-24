using NexGen.DAL.Common;
using NexGen.Repository.Leads;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NexGen.DAL
{
    public class DataLeadRequest
    {
        #region Variable Declaration

        DataBase objDB = new DataBase();
        string spName = string.Empty;
        #endregion
        public int InsertLeadRequest(EntityLeadRequest objInsert)
        {
            spName = "prc_InsertLeadRequest";
            SqlParameter[] arrparameter = new SqlParameter[2];
            arrparameter[0] = new SqlParameter("@RequestedMailID", objInsert.RequestedMailID);
            arrparameter[1] = new SqlParameter("@Country", objInsert.Country);
            int ID = DataBase.ExecuteQuery(spName, arrparameter);
            return ID;
        }
    }
}
