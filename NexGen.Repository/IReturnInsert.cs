using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository
{
    public interface IReturnInsert
    {
        void AddErrorCode(int errorCode);
        void AddErrorMessage(string message);
        void AddErrorInfo(string information);
        void AddValidateMessage(string message);
        void AddRecordsCount(int recordsCount);
        void AddErrorStatus(bool status);
        void AddValidateStatus(bool status);
    }
}
