using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DomingoApp.Models
{
    public class JobDAL
    {
        //(see 3 Setting up app until Add Employee stored procedure, 2021) showed how to get the string connections
        //local connection string
        string connectionStringProd = "Data Source=LAPTOP-CR8S2VUC;Initial Catalog=DomingoDatabase;Integrated Security=True";
        //azure connection string
        

        //get all jobs in a list
        public IEnumerable<JobInformation> GetAllJob() //a list method
        {
            List<JobInformation> jobList = new List<JobInformation>();   //list to store all the job in the database

            // (Microsoft, 2021) and (see 3 Setting up app until Add Employee stored procedure, 2021). 
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //using local connection
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllJob", con);  //calling the get all stored procedure from the sql database
                cmd.CommandType = CommandType.StoredProcedure;  //type of sql command
                con.Open();     //opening the connection
                SqlDataReader dr = cmd.ExecuteReader();     //reading the sql command
                while (dr.Read())       //while loop to display and read all the job information
                {
                    JobInformation jobInfo = new JobInformation();
                    jobInfo.JobCardNo = Convert.ToInt32(dr["JobCardNo"].ToString());
                    jobInfo.NumOfDays = Convert.ToInt32(dr["NumOfDays"].ToString());

                    jobList.Add(jobInfo);     //adding all the job information into the list
                }
                con.Close();        //closing the connection
            }

            return jobList;        //returning the list
        }

        //create job
        public void CreateJob(JobInformation jobInfo)    //method to create a new customer
        {
            //(Microsoft, 2021) and (see 3 Setting up app until Add Employee stored procedure, 2021)
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //using local connection
            {
                SqlCommand cmd = new SqlCommand("SP_InsertJob", con);      //sql command excuting stored procedure insert job
                cmd.CommandType = CommandType.StoredProcedure;      //type of command

                //this is connecting and adding the sql variables for job and putting it into the parameters of the local variables so it can connect to the web app
                cmd.Parameters.AddWithValue("@JobCardNo", jobInfo.JobCardNo);
                cmd.Parameters.AddWithValue("@NumOfDays", jobInfo.NumOfDays);

                con.Open();     //opening the connection
                cmd.ExecuteNonQuery();      //this excutes queries that does not have a return value, it excutes ther command and returns the number of rows affected ()
                con.Close();        //closing the connection
            }
        }

        //get job by ID (Details)
        //the information below has been provided by (4. Continuation and close off, 2021) (Microsoft, 2021). 
        public JobInformation GetJobByID(int? jobID)
        {
            JobInformation jobInfo = new JobInformation();

            using (SqlConnection con = new SqlConnection(connectionStringProd))
            {
                SqlCommand cmd = new SqlCommand("SP_GetJobByID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JobCardNo", jobID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    jobInfo.JobCardNo = Convert.ToInt32(dr["JobCardNo"].ToString());
                    jobInfo.NumOfDays = Convert.ToInt32(dr["NumOfDays"].ToString());
                }

                con.Close();
            }
            return jobInfo;
        }

        //update job
        //the information below has been provided by (4. Continuation and close off, 2021) (Microsoft, 2021). 
        public void UpdateJob(JobInformation jobInfo)        //method to update the details of a customer
        {
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //connection that is being used
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateJob", con);      //sql command excuting stored procedure update customer
                cmd.CommandType = CommandType.StoredProcedure;      //type of command 

                //this is connecting and adding the sql variables for customer and putting it into the parameters of the local variables so it can connect to the web app
                cmd.Parameters.AddWithValue("@JobCardNo", jobInfo.JobCardNo);
                cmd.Parameters.AddWithValue("@NumOfDays", jobInfo.NumOfDays);

                con.Open();     //opening the connection
                cmd.ExecuteNonQuery();       //this excutes queries that does not have a return value, it excutes ther command and returns the number of rows affected ()
                con.Close();        //closing the connection
            }
        }

        //delete job
        //the information below has been provided by (4. Continuation and close off, 2021) (Microsoft, 2021). 
        public void DeleteJob(int? jobID)
        {
            using (SqlConnection con = new SqlConnection(connectionStringProd))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteJob", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JobCardNo", jobID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}
