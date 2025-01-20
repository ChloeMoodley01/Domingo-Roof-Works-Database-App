using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DomingoApp.Models
{
    public class JobTypeDAL
    {
        //(see 3 Setting up app until Add Employee stored procedure, 2021) showed how to get the string connections
        //local connection string
        string connectionStringProd = "Data Source=LAPTOP-CR8S2VUC;Initial Catalog=DomingoDatabase;Integrated Security=True";
        //azure connection string
        

        //get all jobtype
        public IEnumerable<JobTypeInformation> GetAllJobType() //a list method
        {
            List<JobTypeInformation> jobTypeList = new List<JobTypeInformation>();   //list to store all the jobtype in the database

            // (Microsoft, 2021) and (see 3 Setting up app until Add Employee stored procedure, 2021). 
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //using local connection
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllJobType", con);  //calling the get all stored procedure from the sql database
                cmd.CommandType = CommandType.StoredProcedure;  //type of sql command
                con.Open();     //opening the connection
                SqlDataReader dr = cmd.ExecuteReader();     //reading the sql command
                while (dr.Read())       //while loop to display and read all the jobtype information
                {
                    JobTypeInformation jobTypeInfo = new JobTypeInformation();
                    jobTypeInfo.JobTypeName = dr["JobTypeName"].ToString();
                    jobTypeInfo.DailyRate = Convert.ToDecimal(dr["DailyRate"].ToString());

                    jobTypeList.Add(jobTypeInfo);     //adding all the jobtype information into the list
                }
                con.Close();        //closing the connection
            }

            return jobTypeList;        //returning the list
        }

        //get by id
        //the information below has been provided by (4. Continuation and close off, 2021) (Microsoft, 2021). 
        public JobTypeInformation GetJobTypeByID(string jobTypeID)
        {
            JobTypeInformation jobTypeInfo = new JobTypeInformation();

            using (SqlConnection con = new SqlConnection(connectionStringProd))
            {
                SqlCommand cmd = new SqlCommand("SP_GetJobTypeByID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JobTypeName", jobTypeID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    jobTypeInfo.JobTypeName = dr["JobTypeName"].ToString();
                    jobTypeInfo.DailyRate = Convert.ToDecimal(dr["DailyRate"].ToString());
                }

                con.Close();
            }
            return jobTypeInfo;
        }

        //update job type
        //the information below has been provided by (4. Continuation and close off, 2021) (Microsoft, 2021). 
        public void UpdateJobType(JobTypeInformation jobTypeInfo)        //method to update the details of a customer
        {
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //connection that is being used
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateJobType", con);      //sql command excuting stored procedure update customer
                cmd.CommandType = CommandType.StoredProcedure;      //type of command 

                //this is connecting and adding the sql variables for customer and putting it into the parameters of the local variables so it can connect to the web app

                //jobTypeInfo.setDailyRateString(jobTypeInfo.DailyRate);
                cmd.Parameters.AddWithValue("@JobTypeName", jobTypeInfo.JobTypeName);
                cmd.Parameters.AddWithValue("@DailyRateString", jobTypeInfo.DailyRateString);

                con.Open();     //opening the connection
                cmd.ExecuteNonQuery();       //this excutes queries that does not have a return value, it excutes ther command and returns the number of rows affected ()
                con.Close();        //closing the connection
            }
        }
    }
}
