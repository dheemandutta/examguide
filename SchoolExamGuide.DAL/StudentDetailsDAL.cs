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
    public class StudentDetailsDAL
    {
        public int SaveUpdateStudentDetails(StudentDetailsEntity studentDetails)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpSaveUpdateStudentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (String.IsNullOrEmpty(studentDetails.ID.ToString()) || (studentDetails.ID == 0))
            {
                cmd.Parameters.AddWithValue("@ID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ID", studentDetails.ID);
            }
            cmd.Parameters.AddWithValue("@StudentId", studentDetails.StudentId);
            cmd.Parameters.AddWithValue("@StateId", studentDetails.StateId);
            cmd.Parameters.AddWithValue("@DistrictId", studentDetails.DistrictId);
            cmd.Parameters.AddWithValue("@ClassId", studentDetails.ClassId);
            cmd.Parameters.AddWithValue("@GuardiansName", studentDetails.GuardiansName);
            cmd.Parameters.AddWithValue("@GuardiansMob", studentDetails.GuardiansMob);

            int recordAffected = cmd.ExecuteNonQuery();
            con.Close();
            return recordAffected;
        }

        public int DeleteStudentDetails(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpDeleteStudentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            int recordAffected = cmd.ExecuteNonQuery();
            con.Close();
            return recordAffected;
        }

        public StudentDetailsEntity GetStudentDetailsByID(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetStudentDetailsByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            StudentDetailsEntity studentDetails = new StudentDetailsEntity();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            studentDetails.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
            studentDetails.StudentId = Convert.ToInt32(ds.Tables[0].Rows[0]["StudentId"].ToString());
            studentDetails.StateId = Convert.ToInt32(ds.Tables[0].Rows[0]["StateId"].ToString());
            studentDetails.DistrictId = Convert.ToInt32(ds.Tables[0].Rows[0]["DistrictId"].ToString());
            studentDetails.ClassId = Convert.ToInt32(ds.Tables[0].Rows[0]["ClassId"].ToString());
            studentDetails.GuardiansName = ds.Tables[0].Rows[0]["GuardiansName"].ToString();
            studentDetails.GuardiansMob = ds.Tables[0].Rows[0]["GuardiansMob"].ToString();
      
            return studentDetails;
        }

        public List<StudentDetailsEntity> GetStudentDetailsPagewise(int pageIndex, ref int recordCount, int length) ////////////////////////////////
        {
            List<StudentDetailsEntity> studentDetailsEntity = new List<StudentDetailsEntity>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("stpGetClassMasterPageWise", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@PageSize", length);
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                    cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                    con.Open();

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        studentDetailsEntity.Add(new StudentDetailsEntity
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                          //  ClassName = Convert.ToString(dr["ClassName"])
                        });
                    }
                    recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                    con.Close();
                }
            }
            return studentDetailsEntity;
        }

    }
}
