// See https://aka.ms/new-console-template for more information
using NexGen.BL;
using System.IO;

Console.WriteLine("Hello, World!");
string path = System.IO.Directory.GetCurrentDirectory()+"\\DB";

DBBackupLogic backupLogic = new DBBackupLogic();
backupLogic.BackupDatabase("NexGen", "sa", "tech@123", "LKS", path);
