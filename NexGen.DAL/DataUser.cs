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
    public class DataUser
    {
        #region Variable Declaration

        DataBase objDB = new DataBase();
        string spName = string.Empty;
        #endregion

        public EntityUser GetUserLoginDetails(string username, string password)
        {
            spName = "prc_GetLoginDetails";
            SqlParameter[] arrparameter = new SqlParameter[2];
            arrparameter[0] = new SqlParameter("@username", username);
            arrparameter[1] = new SqlParameter("@password", password);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return convertEntityUser(dt);
        }
		public EntityUser GetUserID(int UserID)
		{
			spName = "prc_GetUserID";
			SqlParameter[] arrparameter = new SqlParameter[1];
			arrparameter[0] = new SqlParameter("@UserID", UserID);
			DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
			return convertEntityUser(dt);
		}
		public EntityUser GetUserMailID(string MailID)
		{
			spName = "prc_GetUserMailID";
			SqlParameter[] arrparameter = new SqlParameter[1];
			arrparameter[0] = new SqlParameter("@MailID", MailID);
			DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
			return convertEntityUser(dt);
		}
		public EntityRoles GetRoleId(int RoleId)
		{
			spName = "prc_GetRoleId";
			SqlParameter[] arrparameter = new SqlParameter[1];
			arrparameter[0] = new SqlParameter("@RoleId", RoleId);
			DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
			return convertEntityDataRole(dt);
		}
		public List<EntityUser> GetUserList()
        {
            spName = "prc_GetLoginList";
            SqlParameter[] arrparameter = new SqlParameter[0];
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return convertEntityUserlist(dt);
        }
		private EntityRoles convertEntityDataRole(DataTable dt)
		{
			if (dt == null)
				return null;
			if (dt.Rows.Count == 0)
				return null;
			EntityRoles objEMD = new EntityRoles();
			foreach (DataRow dr in dt.Rows)
			{

				if (!String.IsNullOrEmpty(dr[0].ToString()))
					objEMD.RoleId = int.Parse(dr["RoleId"].ToString());
				objEMD.Name = dr["Name"].ToString();
				objEMD.Description = dr["Description"].ToString();


			}
			return objEMD;
		}
		private EntityUser convertEntityUser(DataTable dt)
        {
            EntityUser objUserData = new EntityUser();
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return objUserData;

            foreach (DataRow dr in dt.Rows)
            {
                if (!String.IsNullOrEmpty(dr[0].ToString()))
                objUserData.UserId = int.Parse(dr["UserId"].ToString());
                objUserData.Name = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
                objUserData.Password = dr["Password"].ToString();
                objUserData.Password = dr["Password"].ToString();
                objUserData.EmailId = dr["EmailId"].ToString();
                objUserData.RoleId = int.Parse(dr["RoleId"].ToString());
                objUserData.EmailNotification = bool.Parse(dr["EmailNotification"].ToString());
                objUserData.Active = bool.Parse(dr["Active"].ToString());
            }
            return objUserData;
        }
        private List<EntityUser> convertEntityUserlist(DataTable dt)
        {
            List<EntityUser> objUserDataList = new List<EntityUser>();
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return objUserDataList;

            foreach (DataRow dr in dt.Rows)
            {
                EntityUser objUserData = new EntityUser();
                if (!String.IsNullOrEmpty(dr[0].ToString()))
                    objUserData.UserId = int.Parse(dr["UserId"].ToString());
                objUserData.Name = dr["FirstName"].ToString() + "" + dr["LastName"].ToString();
                objUserData.Password = dr["Password"].ToString();
                 objUserData.Password = dr["Password"].ToString();
                objUserData.EmailId = dr["EmailId"].ToString();
                objUserData.RoleId = int.Parse(dr["RoleId"].ToString());
                objUserData.EmailNotification = bool.Parse(dr["EmailNotification"].ToString());
                objUserData.Active = bool.Parse(dr["Active"].ToString());
                objUserDataList.Add(objUserData);
            }
            return objUserDataList;
        }
    }
}
