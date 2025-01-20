using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace DomingoApp.Models
{
    //data access layer, this class we deal with connections and how to give access to the website
    public class CustomerDAL
    {
        //(see 3 Setting up app until Add Employee stored procedure, 2021) showed how to get the string connections
        //local connection string
        string connectionStringProd = "Data Source=LAPTOP-CR8S2VUC;Initial Catalog=DomingoDatabase;Integrated Security=True";
        //azure connection string


        //Get all the customers in a list
        public IEnumerable<CustomerInformation> GetAllCustomers() //a list method
        {
            List<CustomerInformation> customerList = new List<CustomerInformation>();   //list to store all the customers in the database

            // (Microsoft, 2021) and (see 3 Setting up app until Add Employee stored procedure, 2021). 
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //using local connection
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllCustomer", con);  //calling the get all stored procedure from the sql database
                cmd.CommandType = CommandType.StoredProcedure;  //type of sql command
                con.Open();     //opening the connection
                SqlDataReader dr = cmd.ExecuteReader();     //reading the sql command
                while (dr.Read())       //while loop to display and read all the customers information
                {
                    CustomerInformation custInfo = new CustomerInformation();
                    custInfo.CustomerID = Convert.ToInt32(dr["CustomerID"].ToString());
                    custInfo.CustomerName = dr["CustomerName"].ToString();
                    custInfo.CustomerSurname = dr["CustomerSurname"].ToString();
                    custInfo.CustomerAddress = dr["CustomerAddress"].ToString();

                    customerList.Add(custInfo);     //adding all the customers information into the list
                }
                con.Close();        //closing the connection
            }

            return customerList;        //returning the list
        }

        //creating a new customer
        public void CreateCustomer(CustomerInformation custInfo)    //method to create a new customer
        {
            //(Microsoft, 2021) and (see 3 Setting up app until Add Employee stored procedure, 2021)
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //using local connection
            {
                SqlCommand cmd = new SqlCommand("SP_InsertCustomer", con);      //sql command excuting stored procedure insert customer
                cmd.CommandType = CommandType.StoredProcedure;      //type of command

                //this is connecting and adding the sql variables for customer and putting it into the parameters of the local variables so it can connect to the web app
                cmd.Parameters.AddWithValue("@CustomerName", custInfo.CustomerName);        
                cmd.Parameters.AddWithValue("@CustomerSurname", custInfo.CustomerSurname);
                cmd.Parameters.AddWithValue("@CustomerAddress", custInfo.CustomerAddress);

                con.Open();     //opening the connection
                cmd.ExecuteNonQuery();      //this excutes queries that does not have a return value, it excutes ther command and returns the number of rows affected ()
                con.Close();        //closing the connection
            }
        }

        //get customer by id
        public CustomerInformation GetCustomerByID(int? custID)     ////method to get by id a new customer
        {
            CustomerInformation custInfo = new CustomerInformation();   //object created to call varibales from the other class

            using (SqlConnection con = new SqlConnection(connectionStringProd))      //uses connection string
            {
                SqlCommand cmd = new SqlCommand("SP_GetCustomerByID", con);     //calling sql stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerID", custID);     //passing id from sql and assigning it to local id

                con.Open();         //open connection
                SqlDataReader dr = cmd.ExecuteReader();     //sql can be read

                while (dr.Read())       //while loop to display and read all the customers information
                {
                    custInfo.CustomerID = Convert.ToInt32(dr["CustomerID"].ToString());
                    custInfo.CustomerName = dr["CustomerName"].ToString();
                    custInfo.CustomerSurname = dr["CustomerSurname"].ToString();
                    custInfo.CustomerAddress = dr["CustomerAddress"].ToString();
                }

                con.Close();        //connection closes
            }
            return custInfo;
        }

        //update a customer
        //the information below has been provided by (4. Continuation and close off, 2021) (Microsoft, 2021). 
        public void UpdateCustomer(CustomerInformation custInfo)        //method to update the details of a customer
        {
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //connection that is being used
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateCustomer", con);      //sql command excuting stored procedure update customer
                cmd.CommandType = CommandType.StoredProcedure;      //type of command 

                //this is connecting and adding the sql variables for customer and putting it into the parameters of the local variables so it can connect to the web app
                cmd.Parameters.AddWithValue("@CustomerID", custInfo.CustomerID);
                cmd.Parameters.AddWithValue("@CustomerName", custInfo.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerSurname", custInfo.CustomerSurname);
                cmd.Parameters.AddWithValue("@CustomerAddress", custInfo.CustomerAddress);

                con.Open();     //opening the connection
                cmd.ExecuteNonQuery();       //this excutes queries that does not have a return value, it excutes ther command and returns the number of rows affected ()
                con.Close();        //closing the connection
            }
        }

        //delete customer
        //the information below has been provided by (4. Continuation and close off, 2021) (Microsoft, 2021). 
        public void DeleteCustomer(int? custID)     //method to delete a new customer
        {
            using(SqlConnection con = new SqlConnection(connectionStringProd))       //uses sql conection
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteCustomer", con);      //calling the delete customer stored proecedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerID", custID);     //sql id passed through parameters

                con.Open();     //connection opens
                cmd.ExecuteNonQuery();  //non execute
                con.Close();    //closes opens

            }
        }

        //public int GetLastCustomers() //a list method
        //{
        //    List<CustomerInformation> customerList = new List<CustomerInformation>();   //list to store all the customers in the database
        //    List<int> custID = new List<int>();

        //    // (Microsoft, 2021) and (see 3 Setting up app until Add Employee stored procedure, 2021). 
        //    using (SqlConnection con = new SqlConnection(connectionStringDev))      //using local connection
        //    {
        //        SqlCommand cmd = new SqlCommand("SP_GetAllCustomer", con);  //calling the get all stored procedure from the sql database
        //        cmd.CommandType = CommandType.StoredProcedure;  //type of sql command
        //        con.Open();     //opening the connection
        //        SqlDataReader dr = cmd.ExecuteReader();     //reading the sql command
        //        while (dr.Read())       //while loop to display and read all the customers information
        //        {
        //            CustomerInformation custInfo = new CustomerInformation();
        //            custInfo.CustomerID = Convert.ToInt32(dr["CustomerID"].ToString());
        //            custInfo.CustomerName = dr["CustomerName"].ToString();
        //            custInfo.CustomerSurname = dr["CustomerSurname"].ToString();
        //            custInfo.CustomerAddress = dr["CustomerAddress"].ToString();

        //            customerList.Add(custInfo);     //adding all the customers information into the list
        //            custID.Add(custInfo.CustomerID);
        //        }
        //        con.Close();        //closing the connection
        //    }

        //    return custID[custID.Count()-1];        //returning the list
        //}
    }
}
