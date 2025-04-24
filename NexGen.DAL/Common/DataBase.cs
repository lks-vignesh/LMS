using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NexGen.DAL.Common
{
    public class DataBase
    {
        public static int ExecuteQuery(string spName, SqlParameter[] parameters)
        {
            using (IDbCommand cmdA = DBConnection.GetConnection().CreateCommand())
            {
                cmdA.CommandText = spName;
                cmdA.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Length > 0)
                {
                    for (Int32 i = 0; i < parameters.Length; i++)
                    {
                        cmdA.Parameters.Add(parameters.GetValue(i));
                    }
                }
                return cmdA.ExecuteNonQuery();
            }
        }
       
        public static int ExecuteQuerys(string spName)
        {
            using (IDbCommand cmdA = DBConnection.GetConnection().CreateCommand())
            {
                cmdA.CommandText = spName;
                cmdA.CommandType = CommandType.StoredProcedure;
                return cmdA.ExecuteNonQuery();
                //cmdA.Connection.Close();
            }
        }
        //Data Table Databind Using Execute Procedure with Parameters
        public static DataTable ExecuteDataTableprocedure(string spName, SqlParameter[] parameters)
        {
            using (IDbCommand cmdA = DBConnection.GetConnection().CreateCommand())
            {
                cmdA.CommandText = spName;
                cmdA.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Length > 0)
                {
                    for (Int32 i = 0; i < parameters.Length; i++)
                    {
                        cmdA.Parameters.Add(parameters.GetValue(i));
                    }
                }
                DataTable dt = new DataTable();
                dt.Load(cmdA.ExecuteReader(), LoadOption.OverwriteChanges);
                cmdA.Connection.Close();
                return dt;
            }
        }
        //Data Table Data Bind Using ExecuteProcedure With out Parameters
        public static DataTable ExecuteDataTableProcedure(string spName)
        {
            using (IDbCommand cmdA = DBConnection.GetConnection().CreateCommand())
            {
                cmdA.CommandText = spName;
                cmdA.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                dt.Load(cmdA.ExecuteReader(), LoadOption.OverwriteChanges);
                cmdA.Connection.Close();
                return dt;
            }
        }
    }
}
