using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SchoolExamGuide.Entities;
using System.Collections;

namespace SchoolExamGuide.DAL
{
    public class SubjectMasterDAL
    {
        public int SaveUpdateSubjectMaster(SubjectMasterEntity subject)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpSaveUpdateSubjectMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;

            if (String.IsNullOrEmpty(subject.ID.ToString()) || (subject.ID == 0))
            {
                cmd.Parameters.AddWithValue("@ID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ID", subject.ID);
            }

            cmd.Parameters.AddWithValue("@SubjectName", subject.SubjectName);
            cmd.Parameters.AddWithValue("@ClassId", subject.ClassID);

            int recrodAffected = cmd.ExecuteNonQuery();
            con.Close();
            return recrodAffected;
        }

        public int DeleteSubjectByID(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpDeleteSubjectMasterBySubjectID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            int recordAffected = cmd.ExecuteNonQuery();
            con.Close();
            return recordAffected;
        }
   
        public SubjectMasterEntity GetSubjectDetailsBySubjectID(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetSubjectDetailsBySubjectID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            SubjectMasterEntity subject = new SubjectMasterEntity();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            subject.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
            subject.SubjectName = ds.Tables[0].Rows[0]["SubjectName"].ToString();
            subject.ClassID = Convert.ToInt32(ds.Tables[0].Rows[0]["ClassID"].ToString());
            subject.ClassName = ds.Tables[0].Rows[0]["ClassName"].ToString();
            return subject;
        }
        
        public List<SubjectMasterEntity> GetSubjectDetailsPagewise(int pageIndex, ref int recordCount, int length)
        {
            List<SubjectMasterEntity> subjectList = new List<SubjectMasterEntity>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetSubjectDetailsPageWise", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            cmd.Parameters.AddWithValue("@PageSize", length);
            cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
            cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                subjectList.Add(new SubjectMasterEntity
                {
                    ID = Convert.ToInt32(dr["ID"].ToString()),
                    SubjectName = dr["SubjectName"].ToString(),
                    ClassID = Convert.ToInt32(dr["ClassID"].ToString()),
                    ClassName = dr["ClassName"].ToString(),
                });
                recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            }
            con.Close();
            return subjectList;
        }

        public List<SubjectMasterEntity> GetSubjectDetailsByClassID(int classID)
        {
            List<SubjectMasterEntity> subjectList = new List<SubjectMasterEntity>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetSubjectDetailsByClassID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClassID", classID);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                subjectList.Add(new SubjectMasterEntity
                {
                    ID = Convert.ToInt32(dr["ID"].ToString()),
                    SubjectName = dr["SubjectName"].ToString(),
                    ClassID = Convert.ToInt32(dr["ClassID"].ToString()),
                    ClassName = dr["ClassName"].ToString(),
                });
            }
            con.Close();
            return subjectList;
        }

        public List<SubjectMasterEntity> GetSubjectDetailsAll()
        {
            List<SubjectMasterEntity> subjectList = new List<SubjectMasterEntity>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetSubjectDetailsAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                subjectList.Add(new SubjectMasterEntity
                {
                    ID = Convert.ToInt32(dr["ID"].ToString()),
                    SubjectName = dr["SubjectName"].ToString(),
                    ClassID = Convert.ToInt32(dr["ClassID"].ToString()),
                    ClassName = dr["ClassName"].ToString(),
                });
            }
            con.Close();
            return subjectList;
        }

        public List<SubjectMasterEntity> GetClassDetailsAll()
        {
            List<SubjectMasterEntity> classList = new List<SubjectMasterEntity>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetClassDetailsAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                classList.Add(new SubjectMasterEntity
                {
                    ClassID = Convert.ToInt32(dr["ID"].ToString()),
                    ClassName = dr["ClassName"].ToString(),
                });
            }
            con.Close();
            return classList;
        }
    }
}