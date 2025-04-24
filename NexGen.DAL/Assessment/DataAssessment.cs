using NexGen.DAL.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NexGen.Repository.Assessment;
using NexGen.Repository.Leads;
using Microsoft.AspNetCore.Http;

namespace NexGen.DAL.Assessment
{

    public class DataAssessment
    {
        string spName = string.Empty;


        #region NewFuntions

        public List<EntityAssessmentQuestions> GetAssessmentQuestions()
        {
            string currentCellValue = string.Empty;
            spName = "prc_GetAssessmentQuestions";
            DataTable dt = DataBase.ExecuteDataTableProcedure(spName);
            return ConvertAssessmentQuestions(dt);
        }
        public List<EntityAssessmentResults> GetTFPAssessmentResults(string EmpanelmentNumber)
        {
           spName = "prc_GetTFPAssessmentResults";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@EmpanelmentNumber", EmpanelmentNumber);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return ConvertAssessmentResults(dt);
        }
        public void UpdateAssessmentPercentage(string EmpanelmentNumber)
        {
            spName = "prc_UpdateAssessmentPercentage";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@EmpanelmentNumber", EmpanelmentNumber);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
        }
        public List<EntityAssessmentResults> GetAssessmentResults()
        {
            spName = "prc_GetAssessmentResults";
            DataTable dt = DataBase.ExecuteDataTableProcedure(spName);
            return ConvertAssessmentResults(dt);
        }
       
        public string GetAnswer(int Key, string Value)
        {
            spName = "prc_GetAnswer";
            SqlParameter[] arrparameter = new SqlParameter[2];
            arrparameter[0] = new SqlParameter("@AssessmentQuestionId", Key);
            arrparameter[1] = new SqlParameter("@Answer", Value);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return dt.Rows[0]["RESULT"].ToString();
        }
        public int InsertAssessmentResults(EntityAssessmentResults entityQAResults)
        {
            spName = "prc_InsertAssessmentResults";
            SqlParameter[] arrparameter = new SqlParameter[8];
            arrparameter[0] = new SqlParameter("@CreatedBy", entityQAResults.CreatedBy);
            arrparameter[1] = new SqlParameter("@CreationDate", entityQAResults.CreationDate);
            arrparameter[2] = new SqlParameter("@EmpanelmentNumber", entityQAResults.EmpanelmentNumber);
            arrparameter[3] = new SqlParameter("@QuestionAttented", entityQAResults.QuestionAttented);
            arrparameter[4] = new SqlParameter("@QuestionSkipped", entityQAResults.QuestionSkipped);
            arrparameter[5] = new SqlParameter("@CorrectAnswer", entityQAResults.CorrectAnswer);
            arrparameter[6] = new SqlParameter("@IncorrectAnswer", entityQAResults.IncorrectAnswer);
            arrparameter[7] = new SqlParameter("@TimeTaken", entityQAResults.TimeTaken);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);

            int id = 0;
            if (dt.Rows.Count > 0)
                id = int.Parse(dt.Rows[0][0].ToString());
            return id;
        }
        public void InsertAssessmentHistory(EntityAssessmentHistory entity)
        {
            spName = "prc_InsertAssessmentHistory";
            SqlParameter[] arrparameter = new SqlParameter[7];
            arrparameter[0] = new SqlParameter("@SalesTeamId", entity.SalesTeamID);
            arrparameter[1] = new SqlParameter("@EmpanelmentNumber", entity.EmpanelmentNumber);
            arrparameter[2] = new SqlParameter("@AssessmentQuestionId", entity.AssessmentQuestionId);
            arrparameter[3] = new SqlParameter("@Question", entity.Question);
            arrparameter[4] = new SqlParameter("@Answer", entity.Answer);
            arrparameter[5] = new SqlParameter("@Result", entity.Result);
            arrparameter[6] = new SqlParameter("@AssessmentResultId", entity.AssessmentResultId);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
        }
        public EntityAssessmentResults GetAssessmentResultId(int Id)
        {
            spName = "prc_GetAssessmentResultId";
            SqlParameter[] arrparameter = new SqlParameter[1];      
            arrparameter[0] = new SqlParameter("@AssessmentResultId", Id);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return ConvertAssessmentResult(dt);
        }
        public EntityAssessmentResults GetLatestAssessmentResult(string EmpanelmentNumber)
        {
            spName = "prc_GetLatestAssessmentResult";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@EmpanelmentNumber", EmpanelmentNumber);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return ConvertAssessmentResult(dt);
        }
        //public EntityAssessmentResults GetAssessmentHistory(int Id)
        //{
        //    spName = "prc_GetAssessmentResultId";
        //    SqlParameter[] arrparameter = new SqlParameter[1];
        //    arrparameter[0] = new SqlParameter("@AssessmentResultId", Id);
        //    DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
        //    return ConvertAssessmentResult(dt);
        //}
        public List<EntityAssessmentHistory> GetAssessmentHistory(int Id)
        {
            spName = "prc_GetAssessmentHistory";
            SqlParameter[] arrparameter = new SqlParameter[1];
            arrparameter[0] = new SqlParameter("@AssessmentResultId", Id);
            DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
            return ConvertAssessmentHistory(dt);
        }
        private EntityAssessmentResults ConvertAssessmentResult(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            EntityAssessmentResults entityQAResults = new EntityAssessmentResults();
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(dr[0].ToString()))
                    entityQAResults.AssessmentResultId = int.Parse(dr["AssessmentResultId"].ToString());
                entityQAResults.CreationDate = DateTime.Parse(dr["CreationDate"].ToString());
                entityQAResults.QuestionAttented = int.Parse(dr["QuestionAttented"].ToString());
                entityQAResults.QuestionSkipped = int.Parse(dr["QuestionSkipped"].ToString());
                entityQAResults.CorrectAnswer = int.Parse(dr["CorrectAnswer"].ToString());
                entityQAResults.IncorrectAnswer = int.Parse(dr["IncorrectAnswer"].ToString());
                entityQAResults.EmpanelmentNumber = dr["EmpanelmentNumber"].ToString();
                entityQAResults.AssessmentPercentage = int.Parse(dr["AssessmentPercentage"].ToString());
            }
            return entityQAResults;
        }
        //private List<EntityAssessmentQuestions> ConvertQuestionList(DataTable dt)
        //{
        //    if (dt == null)
        //        return null;
        //    if (dt.Rows.Count == 0)
        //        return null;
        //    List<EntityAssessmentQuestions> QuesList = new List<EntityAssessmentQuestions>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        EntityAssessmentQuestions objAbb = new EntityAssessmentQuestions();
        //        if (dr[0] != DBNull.Value && dr[0] != null)
        //        {
        //            objAbb.QAId = int.Parse(dr[0].ToString());
        //        }
        //        objAbb.Question = dr[1].ToString();
        //        QuesList.Add(objAbb);
        //    }
        //    return QuesList;
        //}

        #endregion
        #region Conversions

        private List<EntityAssessmentQuestions> ConvertAssessmentQuestions(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<EntityAssessmentQuestions> assessmentQuestions = new List<EntityAssessmentQuestions>();
            foreach (DataRow dr in dt.Rows)
            {
                EntityAssessmentQuestions objQuestion = new EntityAssessmentQuestions();
                if (dr["AssessmentQuestionId"] != DBNull.Value && dr["AssessmentQuestionId"] != null)
                {
                    objQuestion.AssessmentQuestionId = int.Parse(dr["AssessmentQuestionId"].ToString());
                }
                objQuestion.Question = dr["Question"].ToString();
                objQuestion.QuestionType = dr["QuestionType"].ToString();
                objQuestion.Option1 = dr["Option1"].ToString();
                objQuestion.Option2 = dr["Option2"].ToString();
                objQuestion.Option3 = dr["Option3"].ToString();
                objQuestion.Option4 = dr["Option4"].ToString();
                objQuestion.Answer = dr["Answer"].ToString();
                assessmentQuestions.Add(objQuestion);
            }
            return assessmentQuestions;
        }
        private List<EntityAssessmentResults> ConvertAssessmentResults(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<EntityAssessmentResults> assessmentResults = new List<EntityAssessmentResults>();
            foreach (DataRow dr in dt.Rows)
            {
                EntityAssessmentResults results = new EntityAssessmentResults();
                if (dr["AssessmentResultId"] != DBNull.Value && dr["AssessmentResultId"] != null)
                {
                    results.AssessmentResultId = int.Parse(dr["AssessmentResultId"].ToString());
                }
                if (dr["SalesTeamId"] != DBNull.Value && dr["SalesTeamId"] != null)
                {
                    results.SalesTeamID = int.Parse(dr["SalesTeamId"].ToString());
                }
                results.CreationDate = DateTime.Parse(dr["CreationDate"].ToString());
                results.EmpanelmentNumber = dr["EmpanelmentNumber"].ToString();
                results.QuestionAttented = int.Parse(dr["QuestionAttented"].ToString());
                results.QuestionSkipped = int.Parse(dr["QuestionSkipped"].ToString());
                results.CorrectAnswer = int.Parse(dr["CorrectAnswer"].ToString());
                results.IncorrectAnswer = int.Parse(dr["IncorrectAnswer"].ToString());
                results.TimeTaken = dr["TimeTaken"].ToString();
                results.AssessmentPercentage = int.Parse(dr["AssessmentPercentage"].ToString());
                assessmentResults.Add(results);
            }
            return assessmentResults;
        }
        private List<EntityAssessmentHistory> ConvertAssessmentHistory(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<EntityAssessmentHistory> assessmentResults = new List<EntityAssessmentHistory>();
            foreach (DataRow dr in dt.Rows)
            {
                EntityAssessmentHistory results = new EntityAssessmentHistory();
                if (dr["AssessmentHistoryId"] != DBNull.Value && dr["AssessmentHistoryId"] != null)
                {
                    results.AssessmentHistoryId = int.Parse(dr["AssessmentHistoryId"].ToString());
                }
                if (dr["SalesTeamId"] != DBNull.Value && dr["SalesTeamId"] != null)
                {
                    results.SalesTeamID = int.Parse(dr["SalesTeamId"].ToString());
                }
                if (dr["AssessmentResultId"] != DBNull.Value && dr["AssessmentResultId"] != null)
                {
                    results.AssessmentResultId = int.Parse(dr["AssessmentResultId"].ToString());
                }
                results.CreationDate = DateTime.Parse(dr["CreationDate"].ToString());
                results.EmpanelmentNumber = dr["EmpanelmentNumber"].ToString();
                results.AssessmentQuestionId = int.Parse(dr["AssessmentQuestionId"].ToString());
                results.Question = int.Parse(dr["Question"].ToString());
                results.QuestionDetail = dr["QuestionDetail"].ToString();
                results.CorrectAnswer = dr["CorrectAnswer"].ToString();
                results.Answer = dr["Answer"].ToString();
                results.Result = dr["Result"].ToString();
                assessmentResults.Add(results);
            }
            return assessmentResults;
        }

        #endregion
        //#region OldFunctions
        //public DataTable GetQuestionListdt()
        //{
        //    string currentCellValue = string.Empty;
        //    spName = "prc_GetQA";
        //    DataTable dt = DataBase.ExecuteDataTableProcedure(spName);
        //    int i = 1;
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        currentCellValue = row["Question"].ToString();
        //        row["Question"] = "Question-" + i + " " + currentCellValue;
        //        i++;
        //    }
        //    return dt;
        //}
        //public DataTable GetClientListdt()
        //{
        //    string emp_num = "EMP21398713";
        //    spName = "prc_GetClientReport";
        //    SqlParameter[] arrparameter = new SqlParameter[1];
        //    arrparameter[0] = new SqlParameter("@Emp_Number", emp_num);
        //    DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
        //    return dt;
        //}
        //public string CheckAnswerList(int Key, string Value)
        //{
        //    spName = "prc_CheckResults";
        //    SqlParameter[] arrparameter = new SqlParameter[2];
        //    arrparameter[0] = new SqlParameter("@QuestionId", Key);
        //    arrparameter[1] = new SqlParameter("@Answer", Value);
        //    DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
        //    return dt.Rows[0]["RESULT"].ToString();
        //}
        //public int InsertResult(EntityAssessmentResults entityQAResults)
        //{
        //    spName = "prc_InsertAssessmentResults";
        //    SqlParameter[] arrparameter = new SqlParameter[8];
        //    arrparameter[0] = new SqlParameter("@CreatedBy", entityQAResults.CreatedBy);
        //    arrparameter[1] = new SqlParameter("@CreationDate", entityQAResults.CreationDate);
        //    arrparameter[2] = new SqlParameter("@Emp_Number", entityQAResults.Emp_Number);
        //    arrparameter[3] = new SqlParameter("@QuestionAttented", entityQAResults.QuestionAttented);
        //    arrparameter[4] = new SqlParameter("@QuestionSkipped", entityQAResults.QuestionSkipped);
        //    arrparameter[5] = new SqlParameter("@CorrectAnswer", entityQAResults.CorrectAnswer);
        //    arrparameter[6] = new SqlParameter("@IncorrectAnswer", entityQAResults.IncorrectAnswer);
        //    arrparameter[7] = new SqlParameter("@TimeTaken", entityQAResults.TimeTaken);
        //    DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);

        //    int id = 0;
        //    if (dt.Rows.Count > 0)
        //        id = int.Parse(dt.Rows[0][0].ToString());
        //    return id;
        //}
        //public void InsertHistory(int Key, string Value, string Emp_Number, string TimeTaken)
        //{
        //    spName = "prc_InsertAssessmentHistory";
        //    SqlParameter[] arrparameter = new SqlParameter[4];
        //    arrparameter[0] = new SqlParameter("@Emp_Number", Emp_Number);
        //    arrparameter[1] = new SqlParameter("@Question", Key);
        //    arrparameter[2] = new SqlParameter("@Answer", Value);
        //    arrparameter[3] = new SqlParameter("@TimeTaken", TimeTaken);
        //    DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
        //}
        //public EntityAssessmentResults GetResultID(int Id)
        //{
        //    spName = "prc_GetResultsId";
        //    SqlParameter[] arrparameter = new SqlParameter[1];
        //    arrparameter[0] = new SqlParameter("@ResultsId", Id);
        //    DataTable dt = DataBase.ExecuteDataTableprocedure(spName, arrparameter);
        //    return ConvertEntityDataLead(dt);
        //}
        //private EntityAssessmentResults ConvertEntityDataLead(DataTable dt)
        //{
        //    if (dt == null)
        //        return null;
        //    if (dt.Rows.Count == 0)
        //        return null;
        //    EntityAssessmentResults entityQAResults = new EntityAssessmentResults();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        if (!string.IsNullOrEmpty(dr[0].ToString()))
        //            entityQAResults.AssessmentResultId = int.Parse(dr["ResultsId"].ToString());
        //        entityQAResults.QuestionAttented = int.Parse(dr["QuestionAttented"].ToString());
        //        entityQAResults.QuestionSkipped = int.Parse(dr["QuestionSkipped"].ToString());
        //        entityQAResults.CorrectAnswer = int.Parse(dr["CorrectAnswer"].ToString());
        //        entityQAResults.IncorrectAnswer = int.Parse(dr["IncorrectAnswer"].ToString());

        //    }
        //    return entityQAResults;
        //}
        //private List<EntityAssessmentQuestions> ConvertQuestionList(DataTable dt)
        //{
        //    if (dt == null)
        //        return null;
        //    if (dt.Rows.Count == 0)
        //        return null;
        //    List<EntityAssessmentQuestions> QuesList = new List<EntityAssessmentQuestions>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        EntityAssessmentQuestions objAbb = new EntityAssessmentQuestions();
        //        if (dr[0] != DBNull.Value && dr[0] != null)
        //        {
        //            objAbb.QAId = int.Parse(dr[0].ToString());
        //        }
        //        objAbb.Question = dr[1].ToString();
        //        QuesList.Add(objAbb);
        //    }
        //    return QuesList;
        //}
        //#endregion


    }
}
