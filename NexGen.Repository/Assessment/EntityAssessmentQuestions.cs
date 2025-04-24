using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexGen.Repository.Assessment
{
    public class EntityAssessmentQuestions
    {
        public int AssessmentQuestionId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Question { get; set; }
        public string QuestionType { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Answer { get; set; }
    }
}
