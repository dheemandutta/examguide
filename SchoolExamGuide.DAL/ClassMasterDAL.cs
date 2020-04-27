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
    public class ClassMasterDAL
    {
        public int SaveUpdateClassMaster(ClassMasterEntity classMaster)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpSaveClassMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (String.IsNullOrEmpty(classMaster.ID.ToString()) || (classMaster.ID == 0))
            {
                cmd.Parameters.AddWithValue("@ID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ID", classMaster.ID);
            }
            cmd.Parameters.AddWithValue("@ClassName", classMaster.ClassName);

            int recordAffected = cmd.ExecuteNonQuery();
            con.Close();
            return recordAffected;
        }

        public int DeleteClassMaster(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpDeleteClassMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            int recordAffected = cmd.ExecuteNonQuery();
            con.Close();
            return recordAffected;
        }

        public ClassMasterEntity GetClassMasterDetailsByID(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolExamConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("stpGetClassMasterByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            ClassMasterEntity classMaster = new ClassMasterEntity();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            classMaster.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
            classMaster.ClassName = ds.Tables[0].Rows[0]["ClassName"].ToString();
            return classMaster;
        }

        public List<ClassMasterEntity> GetClassMasterDetailsPagewise(int pageIndex, ref int recordCount, int length)
        {
            List<ClassMasterEntity> classMasterEntity = new List<ClassMasterEntity>();

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
                        classMasterEntity.Add(new ClassMasterEntity
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            ClassName = Convert.ToString(dr["ClassName"])
                        });
                    }
                    recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                    con.Close();
                }
            }
            return classMasterEntity;
        }
    }
}
