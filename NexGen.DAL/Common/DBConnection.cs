using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace NexGen.DAL.Common
{
    public class DBConnection
    {
        //public static IDbConnection GetConnection(string connectionString)
        //{
        //    // IDbConnection con = ActiveRecordMediator.GetSessionFactoryHolder().GetSessionFactory(typeof(ActiveRecordBase)).OpenSession().Connection;

        //    SqlConnection con = new SqlConnection(connectionString);
        //    //  con.Open();
        //    con.Open();
        //    return con;
        //}
        #region CommonConnection
        /// <summary>
        /// This calls used to create DB connection with database
        /// </summary>
        private readonly IConfiguration configuration;
        private string dbConn;
        /// <summary>
        /// Create and return the connection object of database
        /// </summary>
        /// <returns></returns>
        public static IDbConnection GetConnection()
        {
            string DefaultConnection;
            var configurationBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            DefaultConnection = configurationBuilder.Build().GetSection("ConnectionStrings:DefaultConnection").Value;
            //SqlConnection con = new SqlConnection("Data Source=Stage-Server\\SQLEXPRESS; Initial Catalog=NexGenV2_QA; User Id=sa; Password=tech@123");

            //SqlConnection con = new SqlConnection("Data Source=Stage-Server\\SQLEXPRESS; Initial Catalog=NexGenV2_QA; User Id=sa; Password=tech@123");
            SqlConnection con = new SqlConnection(DefaultConnection);

            //  con.Open();
            con.Open();
            return con;
        }
        public void CloseConnection(IDbConnection con)
        {
            con.Close();
        }
        public DBConnection(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DBConnection()
        {
            dbConn = configuration.GetSection("ConnectionStrings").GetSection("WebApiDatabase").Value;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to sql server with connection string from app settings
        //    options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        //    //options.UseSqlServer("Data Source=LKS; Initial Catalog=MK_Service_SNDBOX; User Id=sa; Password=tech@123");
        //}


        #endregion
    }
}
