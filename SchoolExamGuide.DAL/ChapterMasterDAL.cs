using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SchoolExamGuide.Entities;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace SchoolExamGuide.DAL
{
    public class ChapterMasterDAL
    {
        public int SaveUpdateChapter(ChapterMasterEntity chapter)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpSaveUpdateChapterMaster",con);
            cmd.CommandType = CommandType.StoredProcedure;
            if(String.IsNullOrEmpty(chapter.Id.ToString())||(chapter.Id == 0))
            {
                cmd.Parameters.AddWithValue("@Id", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Id", chapter.Id);
            }
            cmd.Parameters.AddWithValue("@ChapterName", chapter.ChapterName);
            cmd.Parameters.AddWithValue("@SubjectId", chapter.SubjectId);

            int recordAffected = cmd.ExecuteNonQuery();
            con.Close();
            return recordAffected;
        }

        public int DeleteChapter(int Id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpDeleteChapterMasterByChapterID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            int recordAffected = cmd.ExecuteNonQuery();
            con.Close();
            return recordAffected;
        }
        
        public ChapterMasterEntity ChapterDetailsByChapterID(int Id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetChapterDetailsByChapterID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            ChapterMasterEntity chapter = new ChapterMasterEntity();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            chapter.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"].ToString());
            chapter.ChapterName = ds.Tables[0].Rows[0]["ChapterName"].ToString();
            chapter.SubjectId = Convert.ToInt32(ds.Tables[0].Rows[0]["SubjectId"].ToString());
            chapter.SubjectName = ds.Tables[0].Rows[0]["SubjectName"].ToString();
            chapter.ClassID = Convert.ToInt32(ds.Tables[0].Rows[0]["ClassID"].ToString());
            chapter.ClassName= ds.Tables[0].Rows[0]["ClassName"].ToString();
            return chapter;
        }

        public List<ChapterMasterEntity> GetChaptertDetailsPagewise(int pageIndex, ref int recordCount, int length)
        {
            List<ChapterMasterEntity> chapterList = new List<ChapterMasterEntity>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetChapterDetailsPageWise", con);
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
                chapterList.Add(new ChapterMasterEntity
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    ChapterName = dr["ChapterName"].ToString(),
                    SubjectId = Convert.ToInt32(dr["SubjectId"].ToString()),
                    SubjectName = dr["SubjectName"].ToString(),
                    ClassID=Convert.ToInt32(dr["ClassID"].ToString()),
                    ClassName=dr["ClassName"].ToString(),
                });
                recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            }
            con.Close();
            return chapterList;
        }

        public List<ChapterMasterEntity> GetChapterDetailsBySubjectID(int subjectID)
        {
            List<ChapterMasterEntity> chapterList = new List<ChapterMasterEntity>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetChapterDetailsBySubjectID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SubjectID", subjectID);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                chapterList.Add(new ChapterMasterEntity
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    ChapterName= dr["ChapterName"].ToString(),
                    SubjectId = Convert.ToInt32(dr["SubjectId"].ToString()),
                    SubjectName = dr["SubjectName"].ToString(),
                    ClassID=Convert.ToInt32(dr["ClassID"].ToString()),
                    ClassName=dr["ClassName"].ToString(),
                });
            }
            con.Close();
            return chapterList;
        }

        public List<ChapterMasterEntity> GetChapterDetailsAll()
        {
            List<ChapterMasterEntity> chapterList = new List<ChapterMasterEntity>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetChapterDetailsAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                chapterList.Add(new ChapterMasterEntity
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    ChapterName = dr["ChapterName"].ToString(),
                    SubjectId = Convert.ToInt32(dr["SubjectId"].ToString()),
                    SubjectName = dr["SubjectName"].ToString(),
                    ClassID=Convert.ToInt32(dr["ClassID"].ToString()),
                    ClassName=dr["ClassName"].ToString(),
                });
            }
            con.Close();
            return chapterList;
        }

        public List<ChapterMasterEntity> GetClassDetailsAll()
        {
            List<ChapterMasterEntity> chapterList = new List<ChapterMasterEntity>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetClassDetailsAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                chapterList.Add(new ChapterMasterEntity
                {
                    ClassID = Convert.ToInt32(dr["ID"].ToString()),
                    ClassName = dr["ClassName"].ToString(),
                });
            }
            con.Close();
            return chapterList;
        }

        public List<ChapterMasterEntity> GetSubjectDetailsAll()
        {
            List<ChapterMasterEntity> subjectList = new List<ChapterMasterEntity>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetSubjectDetailsAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                subjectList.Add(new ChapterMasterEntity
                {
                    SubjectId = Convert.ToInt32(dr["ID"].ToString()),
                    SubjectName = dr["SubjectName"].ToString(),                
                });
            }
            con.Close();
            return subjectList;
        }

        public List<ChapterMasterEntity> GetSubjectDetailsByClassID(int classID)
        {
            List<ChapterMasterEntity> chapterList = new List<ChapterMasterEntity>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetSubjectDetailsByClassID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ClassID", classID);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                chapterList.Add(new ChapterMasterEntity
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    SubjectName = dr["SubjectName"].ToString(),
                    ClassID = Convert.ToInt32(dr["ClassID"].ToString()),
                    ClassName = dr["ClassName"].ToString(),
                });
            }
            con.Close();
            return chapterList;
        }

        public List<ChapterMasterEntity> GetChaptertDetailsSubjectAndPagewise(int pageIndex, ref int recordCount, int length, int SubjectId)
        {
            List<ChapterMasterEntity> chapterList = new List<ChapterMasterEntity>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetChapterDetailsSubjectPageWise", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            cmd.Parameters.AddWithValue("@PageSize", length);
            cmd.Parameters.AddWithValue("@SubjectId", SubjectId);
            cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
            cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                chapterList.Add(new ChapterMasterEntity
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    ChapterName = dr["ChapterName"].ToString(),
                    SubjectId = Convert.ToInt32(dr["SubjectId"].ToString()),
                    SubjectName = dr["SubjectName"].ToString(),
                    ClassID = Convert.ToInt32(dr["ClassID"].ToString()),
                    ClassName = dr["ClassName"].ToString(),
                });
                recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
            }
            con.Close();
            return chapterList;
        }

    }
}
