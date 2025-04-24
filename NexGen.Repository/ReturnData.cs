using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository
{
    public class ReturnData : IReturnInsert, IReturn
    {
        bool IsValid { get; set; }
        bool IsError { get; set; }
        int RecordsCount { get; set; }
        int PrimaryId { get; set; }
        List<string> ValidateMessage = new List<string>();
        ErrorDetails objError = new ErrorDetails();
        public ReturnData()
        {
            IsValid = true;
            IsError = false;
        }
        public void AddErrorStatus(bool status)
        {
            IsError = status;
        }

        public void AddValidateStatus(bool status)
        {
            IsValid = status;
        }
        public void AddErrorCode(int errorCode)
        {
            objError.ErrorCode = errorCode;
        }

        public void AddErrorMessage(string message)
        {
            objError.ErrorMessage = message;

        }

        public void AddErrorInfo(string information)
        {
            objError.ErrorInfo = information;
        }

        public void AddValidateMessage(string message)
        {
            ValidateMessage.Add(message);
        }
        public void AddRecordsCount(int recordsCount)
        {
            RecordsCount = recordsCount;
        }
        public void AddPrimaryId(int primaryId)
        {
            PrimaryId = primaryId;
        }
        public int GetErrorCode()
        {
            return objError.ErrorCode;
        }

        public string GetErrorMessage()
        {
            return objError.ErrorMessage;
        }

        public string GetErrorInfo()
        {
            return objError.ErrorInfo;
        }

        public List<string> GetValidateMessage()
        {
            return ValidateMessage;
        }

        public bool GetValidateStatus()
        {
            return IsValid;
        }

        public bool GetErrorStatus()
        {
            return IsError;
        }

        public ErrorDetails GetError()
        {
            return objError;
        }

        public int GetRecordsCount()
        {
            return RecordsCount;
        }
        public int GetPrimaryId()
        {
            return PrimaryId;
        }
    }
}
