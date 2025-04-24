using System.Runtime.CompilerServices;
using System.Text;

namespace NexGen.Logging
{
    public static class Logger
    {

        private static log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static log4net.ILog CustomLog =
            log4net.LogManager.GetLogger("SecurityViolationFileLogger");


        static Logger()
        {
            //*************************************************************************************
            // configure the logging information provided in the log4net config
            //*************************************************************************************            
            log4net.Config.XmlConfigurator.Configure();
        }

        #region Logging Informaion

        ///********************************************************************************************
        /// <summary>
        /// A static method to log information level message if it is enabled in the config
        /// </summary>
        /// <param name="message">Message to log in the information</param>
        ///********************************************************************************************
        public static void InformationLog(string message)
        {
            if (Log.IsInfoEnabled)
            {
                string dateTime = DateTime.Now.ToString();
                Log.Info(dateTime + ":" + message);
            }
        }

        public static void SecurityViolationInfoLog(string message)
        {
            if (Log.IsInfoEnabled)
            {
                CustomLog.Info(message);
            }
        }

        public static void InformationLogMethodStarted([CallerFilePath] string memberFilePath = "", [CallerMemberName] string memberName = "")
        {
            if (Log.IsInfoEnabled)
            {
                Log.Info(String.Format("{0} : {1} ", Path.GetFileNameWithoutExtension(memberFilePath), memberName));
            }
        }

        public static void InformationLogMethodParams(Dictionary<string, string> dicParams, [CallerFilePath] string memberFilePath = "", [CallerMemberName] string memberName = "")
        {
            if (Log.IsInfoEnabled)
            {
                StringBuilder sb = null;
                try
                {
                    sb = new StringBuilder();
                    sb.AppendLine();
                    sb.AppendFormat(String.Format("{0} : {1}", Path.GetFileNameWithoutExtension(memberFilePath), memberName));
                    sb.AppendLine();
                    if (dicParams != null)
                    {
                        foreach (var item in dicParams)
                        {
                            sb.AppendFormat(item.Key, item.Value);
                            sb.AppendLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // FatalLog(ex.Message + " " + ex.Source);
                }
                finally
                {
                    if (sb != null)
                        InformationLog(sb.ToString());

                    sb = null;
                }
            }
        }

        public static void InformationLogMethodCompleted([CallerFilePath] string memberFilePath = "", [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            if (Log.IsInfoEnabled)
            {
                Log.Info(String.Format("{0} : {1}", Path.GetFileNameWithoutExtension(memberFilePath), memberName));
            }
        }

        #endregion

        #region Logging Debug

        ///********************************************************************************************
        /// <summary>
        /// A static method to log debug level message if it is enabled in the config
        /// </summary>
        /// <param name="message">message to log in the debug</param>
        ///********************************************************************************************
        public static void DebugLog(string message)
        {
            if (Log.IsDebugEnabled)
            {
                string dateTime = DateTime.Now.ToString();
                Log.Debug(dateTime + ":" + message);
            }
        }

        public static void DebugLogWithCaller(string message, [CallerFilePath] string memberFilePath = "", [CallerMemberName] string memberName = "")
        {
            if (Log.IsDebugEnabled)
            {
                Log.Debug(String.Format("{0} : {1} - {2}", Path.GetFileNameWithoutExtension(memberFilePath), memberName, message));
            }
        }
        #endregion

        #region Logging Error

        ///********************************************************************************************
        /// <summary>
        /// A static method to log the error message 
        /// </summary>
        /// <param name="message">message to log in the error</param>
        ///********************************************************************************************
        public static void ErrorLog(string message)
        {
            if (Log.IsErrorEnabled)
            {
                string dateTime = DateTime.Now.ToString();
                Log.Error(dateTime + ":" + message);
            }
        }

        ///********************************************************************************************
        /// <summary>
        /// A static method to log the error message and the exception details 
        /// in the config
        /// </summary>
        /// <param name="message">message to log in the error</param>
        /// <param name="Ex">Exception details which should be logged in the error log</param>
        ///********************************************************************************************
        public static void ErrorLog(string message, Exception Ex)
        {
            if (Log.IsErrorEnabled)
            {
                string dateTime = DateTime.Now.ToString();
                Log.Error(dateTime + ":" + message, Ex);
            }
        }
        #endregion
    }
}