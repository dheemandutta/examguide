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

        public int DeleteChapter(int ChapterID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpDeleteChapterMasterByChapterID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", ChapterID);
            int recordAffected = cmd.ExecuteNonQuery();
            con.Close();
            return recordAffected;
        }
        
        public ChapterMasterEntity ChapterDetailsByChapterID(int chapterID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetChapterDetailsByChapterID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", chapterID);
            ChapterMasterEntity chapter = new ChapterMasterEntity();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            chapter.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"].ToString());
            chapter.ChapterName = ds.Tables[0].Rows[0]["ChapterName"].ToString();
            chapter.SubjectId = Convert.ToInt32(ds.Tables[0].Rows[0]["SubjectId"].ToString());
            chapter.SubjectName = ds.Tables[0].Rows[0]["SubjectName"].ToString();
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
            con.Open();
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
                });
                recordCount = Convert.ToInt32(cmd.Parameters["RecordCount"].Value);
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
                    Id= Convert.ToInt32(dr["Id"].ToString()),
                    ChapterName= dr["ChapterName"].ToString(),
                    SubjectId = Convert.ToInt32(dr["SubjectId"].ToString()),
                    SubjectName = dr["SubjectName"].ToString(),
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
                });
            }
            con.Close();
            return chapterList;
        }
    }
}
