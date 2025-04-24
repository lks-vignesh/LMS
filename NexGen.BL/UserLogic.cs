using Microsoft.SqlServer.Management.Smo;
using NexGen.DAL;
using NexGen.Logging;
using NexGen.Repository;
using NexGen.Repository.Leads;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.BL
{
    public class UserLogic
    {
        public EntityUser GetLoginDetails(string username, string password)
        {
            ReturnData objReturn = new ReturnData();
            EntityUser objGetData = new EntityUser();
            try
            {

                DataUser objAccess = new DataUser();
                objGetData = objAccess.GetUserLoginDetails(username, password);

            }
            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
                Logger.ErrorLog("Error Message: " + ex.Message);
                Logger.ErrorLog("Stack Trace: " + ex.StackTrace);
            }
            return objGetData;
        }
		public EntityUser GetUserID(int UserID)
		{
			ReturnData objReturn = new ReturnData();
			EntityUser objGetData = new EntityUser();
			try
			{

				DataUser objAccess = new DataUser();
				objGetData = objAccess.GetUserID(UserID);

			}
			catch (Exception ex)
			{
				objReturn.AddErrorStatus(true);
				objReturn.AddErrorMessage(ex.Message);
				objReturn.AddErrorInfo(ex.StackTrace);
				Logger.ErrorLog("Error Message: " + ex.Message);
				Logger.ErrorLog("Stack Trace: " + ex.StackTrace);
			}
			return objGetData;
		}
		public EntityUser GetUserMailID(string MailID)
		{
			ReturnData objReturn = new ReturnData();
			EntityUser objGetData = new EntityUser();
			try
			{

				DataUser objAccess = new DataUser();
				objGetData = objAccess.GetUserMailID(MailID);

			}
			catch (Exception ex)
			{
				objReturn.AddErrorStatus(true);
				objReturn.AddErrorMessage(ex.Message);
				objReturn.AddErrorInfo(ex.StackTrace);
				Logger.ErrorLog("Error Message: " + ex.Message);
				Logger.ErrorLog("Stack Trace: " + ex.StackTrace);
			}
			return objGetData;
		}
		public EntityRoles GetRoleId(int RoleId)
		{
			ReturnData objReturn = new ReturnData();
			EntityRoles objGetData = new EntityRoles();
			try
			{

				DataUser objAccess = new DataUser();
				objGetData = objAccess.GetRoleId(RoleId);

			}
			catch (Exception ex)
			{
				objReturn.AddErrorStatus(true);
				objReturn.AddErrorMessage(ex.Message);
				objReturn.AddErrorInfo(ex.StackTrace);
				Logger.ErrorLog("Error Message: " + ex.Message);
				Logger.ErrorLog("Stack Trace: " + ex.StackTrace);
			}
			return objGetData;
		}
		public List<EntityUser> GetLoginList()
        {
            ReturnData objReturn = new ReturnData();
            List<EntityUser> objGetData = new List<EntityUser>();
            try
            {

                DataUser objAccess = new DataUser();
                objGetData = objAccess.GetUserList();

            }
            catch (Exception ex)
            {
                objReturn.AddErrorStatus(true);
                objReturn.AddErrorMessage(ex.Message);
                objReturn.AddErrorInfo(ex.StackTrace);
                Logger.ErrorLog("Error Message: " + ex.Message);
                Logger.ErrorLog("Stack Trace: " + ex.StackTrace);
            }
            return objGetData;
        }
        #region "Encrypt"
        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        #endregion

        #region "Decrypt"
        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        #endregion
    }
}
