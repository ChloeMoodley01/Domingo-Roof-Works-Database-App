using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DomingoApp.Models
{
    public class EmployeeDAL
    {
        //(see 3 Setting up app until Add Employee stored procedure, 2021) showed how to get the string connections
        //local connection string
        string connectionStringProd = "Data Source=LAPTOP-CR8S2VUC;Initial Catalog=DomingoDatabase;Integrated Security=True";
        //azure connection string
        //string connectionStringProd = "Server=tcp:domingodatabaseserver.database.windows.net,1433;Initial Catalog=DomingoDatabase;Persist Security Info=False;User ID=ChloeMoodley;Password=Harrypotter1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public IEnumerable<EmployeeInformation> GetAllEmployee() //a list method
        {
            List<EmployeeInformation> employeeList = new List<EmployeeInformation>();   //list to store all the employees in the database

            // (Microsoft, 2021) and (see 3 Setting up app until Add Employee stored procedure, 2021). 
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //using local connection
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmployee", con);  //calling the get all stored procedure from the sql database
                cmd.CommandType = CommandType.StoredProcedure;  //type of sql command
                con.Open();     //opening the connection
                SqlDataReader dr = cmd.ExecuteReader();     //reading the sql command
                while (dr.Read())       //while loop to display and read all the employee information
                {
                    EmployeeInformation empInfo = new EmployeeInformation();
                    empInfo.EmployeeID = dr["EmployeeID"].ToString();
                    empInfo.EmployeeName = dr["EmployeeName"].ToString();
                    empInfo.EmployeeSurname = dr["EmployeeSurname"].ToString();

                    employeeList.Add(empInfo);     //adding all the employees information into the list
                }
                con.Close();        //closing the connection
            }

            return employeeList;        //returning the list
        }

        //create employee
        public void CreateEmployee(EmployeeInformation empInfo)    //method to create a new employee
        {
            //(Microsoft, 2021) and (see 3 Setting up app until Add Employee stored procedure, 2021)
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //using local connection
            {
                SqlCommand cmd = new SqlCommand("SP_InsertEmployee", con);      //sql command excuting stored procedure insert employee
                cmd.CommandType = CommandType.StoredProcedure;      //type of command

                //this is connecting and adding the sql variables for employee and putting it into the parameters of the local variables so it can connect to the web app
                cmd.Parameters.AddWithValue("@EmployeeID", empInfo.EmployeeID);
                cmd.Parameters.AddWithValue("@EmployeeName", empInfo.EmployeeName);
                cmd.Parameters.AddWithValue("@EmployeeSurname", empInfo.EmployeeSurname);

                con.Open();     //opening the connection
                cmd.ExecuteNonQuery();      //this excutes queries that does not have a return value, it excutes ther command and returns the number of rows affected ()
                con.Close();        //closing the connection
            }
        }

        //get by id
        //the information below has been provided by (4. Continuation and close off, 2021) (Microsoft, 2021). 
        public EmployeeInformation GetEmployeeByID(string empID)    //method to create a new employee
        {
            EmployeeInformation empInfo = new EmployeeInformation();        //object to call vairables from the employees class

            using (SqlConnection con = new SqlConnection(connectionStringProd))      //uses connection string
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmployeeByID", con); //sql command excuting stored procedure update employee
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", empID);      // passing id from sql and assigning it to local id

                con.Open();     //connection opening 
                SqlDataReader dr = cmd.ExecuteReader();     //sql reader

                while (dr.Read())       //while loop to display and read all the employee information
                {
                    empInfo.EmployeeID = dr["EmployeeID"].ToString();
                    empInfo.EmployeeName = dr["EmployeeName"].ToString();
                    empInfo.EmployeeSurname = dr["EmployeeSurname"].ToString();
                }

                con.Close();        //connetion closed
            }
            return empInfo;     //returns information
        }

        //update employee
        //the information below has been provided by (4. Continuation and close off, 2021) (Microsoft, 2021). 
        public void UpdateEmployee(EmployeeInformation empInfo)        //method to update the details of a employee
        {
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //connection that is being used
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateEmployee", con);      //sql command excuting stored procedure update employee
                cmd.CommandType = CommandType.StoredProcedure;      //type of command 

                //this is connecting and adding the sql variables for employee and putting it into the parameters of the local variables so it can connect to the web app
                cmd.Parameters.AddWithValue("@EmployeeID", empInfo.EmployeeID);
                cmd.Parameters.AddWithValue("@EmployeeName", empInfo.EmployeeName);
                cmd.Parameters.AddWithValue("@EmployeeSurname", empInfo.EmployeeSurname);

                con.Open();     //opening the connection
                cmd.ExecuteNonQuery();       //this excutes queries that does not have a return value, it excutes ther command and returns the number of rows affected ()
                con.Close();        //closing the connection
            }
        }

        //delete employee
        //the information below has been provided by (4. Continuation and close off, 2021) (Microsoft, 2021). 
        public void DeleteEmployee(string empID)        //delete method 
        {
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //using sql connection
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteEmployee", con);      //stored procedure being called
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", empID);      

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}
