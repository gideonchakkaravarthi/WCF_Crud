using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Crud
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        public string InsertEmpDetails(EmpDetails eDetails) //For Insert Purpose  
        {
            string Status;
            SqlCommand cmd = new SqlCommand("USP_Emp_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", eDetails.Name);
            cmd.Parameters.AddWithValue("@Salary", eDetails.Salary);
            cmd.Parameters.AddWithValue("@DeptId", eDetails.DeptId);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Status = eDetails.Name + " " + eDetails.Salary + " Is Registered Successfully";
            }
            else
            {
                Status = eDetails.Name + " " + eDetails.Salary + " could not be registered";
            }
            con.Close();
            return Status;
        }
        public DataSet GetEmpDetails(EmpDetails eDetails) //For Details Purpose  
        {
            SqlCommand cmd = new SqlCommand("Get_AllEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", eDetails.Id);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
        public DataSet FetchUpdatedRecords(EmpDetails eDetails) //For update details Purpose  
        {
            SqlCommand cmd = new SqlCommand("Get_AllEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", eDetails.Id);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
        public string UpdateEmpDetails(EmpDetails eDetails) //For Update Purpose  
        {
            string Status;
            SqlCommand cmd = new SqlCommand("USP_Emp_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", eDetails.Id);
            cmd.Parameters.AddWithValue("@Name", eDetails.Name);
            cmd.Parameters.AddWithValue("@Salary", eDetails.Salary);
            cmd.Parameters.AddWithValue("@DeptId", eDetails.DeptId);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Status = "Record Is Updated successfully";
            }
            else
            {
                Status = "Record could not be updated";
            }
            con.Close();
            return Status;
        }
        public bool DeleteEmpDetails(EmpDetails eDetails) //For Delete Purpose  
        {
            SqlCommand cmd = new SqlCommand("USP_Emp_Delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", eDetails.Id);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
    }
}
