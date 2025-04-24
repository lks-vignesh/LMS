using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository.Assessment
{
    public class EntityAssessmentHistory
    {
        public int AssessmentHistoryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int AssessmentResultId { get; set; }
        public DateTime AssessmentDate { get; set; }
        public int SalesTeamID { get; set; }
        public string EmpanelmentNumber { get; set; }
        public int AssessmentQuestionId { get; set; }
        public int Question { get; set; }
        public string QuestionDetail { get; set; }
        public string CorrectAnswer { get; set; }
        public string Answer  { get; set; }
        public string Result { get; set; }
    }
}
