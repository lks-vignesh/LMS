﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NexGen.DAL.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace NexGen.BL
{
    public class DBBackupLogic
    {
        public void BackupDatabase(string databaseName, string userName, string password, string serverName, string destinationPath)

        {
            //Define a Backup object variable.
            Backup sqlBackup = new Backup();
            //Specify the type of backup, the description, the name, and the database to be backed up.
            sqlBackup.Action = BackupActionType.Database;

            sqlBackup.BackupSetDescription = "BackUp of:" + databaseName + "on" + DateTime.Now.ToShortDateString();

            sqlBackup.BackupSetName = "NexGen";

            sqlBackup.Database = databaseName;

            bool exists = System.IO.Directory.Exists(destinationPath);
            if (!exists)
                System.IO.Directory.CreateDirectory(destinationPath);

            //Declare a BackupDeviceItem
            BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath + "\\NexGen_"+DateTime.Now.ToString("yyyyMMddHHmmss") +".bak", DeviceType.File);

            //Define Server connection
            ServerConnection connection = new ServerConnection(serverName, userName, password); //To Avoid TimeOut Exception
            Server sqlServer = new Server(connection);
            sqlServer.ConnectionContext.StatementTimeout = 60 * 60;
            Database db = sqlServer.Databases[databaseName];
            // Reference Database As microsoft.sqlserver.management.smo.database, not as System.entity.database

            sqlBackup.Initialize = true;

            sqlBackup.Checksum = true;

            sqlBackup.ContinueAfterError = true;
            //Add the device to the Backup object.
            sqlBackup.Devices.Add(deviceItem);

            //Set the Incremental property to False to specify that this is a full database backup. 
            sqlBackup.Incremental = false;
            sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);

            //Specify that the log must be truncated after the backup is complete.        
            sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;
            sqlBackup.FormatMedia = false;

            //Run SqlBackup to perform the full database backup on the instance of SQL Server. 
            sqlBackup.SqlBackup(sqlServer);

            //Remove the backup device from the Backup object.           
            sqlBackup.Devices.Remove(deviceItem);

        }
    }
}
