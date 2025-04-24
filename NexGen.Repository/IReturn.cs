using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository
{
    public interface IReturn
    {
        int GetErrorCode();
        string GetErrorMessage();
        string GetErrorInfo();
        List<string> GetValidateMessage();
        bool GetValidateStatus();
        bool GetErrorStatus();
        ErrorDetails GetError();
        int GetRecordsCount();
        int GetPrimaryId();
    }
}
