using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository.Assessment
{
    public class EntityAssessmentResults
    {
        public int AssessmentResultId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int LastUpdateBy { get; set; }   
        public DateTime LastUpdateDate { get; set; }
        public DateTime AssessmentDate { get; set; }
        public int SalesTeamID { get; set; }
        public string EmpanelmentNumber { get; set; }
        public int QuestionAttented { get; set; }
        public int QuestionSkipped { get; set; }
        public int CorrectAnswer { get; set; }
        public int IncorrectAnswer { get; set; }
        public string TimeTaken { get; set; }
        public int AssessmentPercentage { get; set; }
    }
}
