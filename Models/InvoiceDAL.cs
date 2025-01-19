using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DomingoApp.Models
{
    public class InvoiceDAL
    {

        //(see 3 Setting up app until Add Employee stored procedure, 2021) showed how to get the string connections
        //local connection string
        string connectionStringProd = "Data Source=LAPTOP-CR8S2VUC;Initial Catalog=DomingoDatabase;Integrated Security=True";
        //azure connection string
        //string connectionStringProd = "Server=tcp:domingodatabaseserver.database.windows.net,1433;Initial Catalog=DomingoDatabase;Persist Security Info=False;User ID=ChloeMoodley;Password=Harrypotter1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //get all invoices in a list
        public IEnumerable<InvoiceInformation> GetAllInvoice() //a list method
        {
            List<InvoiceInformation> invoiceList = new List<InvoiceInformation>();   //list to store all the invoice in the database

            // (Microsoft, 2021) and (see 3 Setting up app until Add Employee stored procedure, 2021). 
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //using local connection
            {
                SqlCommand cmd = new SqlCommand("SP_GetInvoice", con);  //calling the get all stored procedure from the sql database
                cmd.CommandType = CommandType.StoredProcedure;  //type of sql command
                con.Open();     //opening the connection
                SqlDataReader dr = cmd.ExecuteReader();     //reading the sql command
                while (dr.Read())       //while loop to display and read all the invoice information
                {
                    InvoiceInformation inInfo = new InvoiceInformation();
                    inInfo.JobTypeName = dr["JobTypeName"].ToString();
                    inInfo.DailyRate = Convert.ToDecimal(dr["DailyRate"].ToString());
                    inInfo.CustomerName = dr["CustomerName"].ToString();
                    inInfo.CustomerSurname = dr["CustomerSurname"].ToString();
                    inInfo.CustomerAddress = dr["CustomerAddress"].ToString();
                    //inInfo.EmployeeID = dr["EmployeeID"].ToString();
                    inInfo.JobCardNo = Convert.ToInt32(dr["JobCardNo"].ToString());
                    inInfo.NumOfDays = Convert.ToInt32(dr["NumOfDays"].ToString());
                    inInfo.MaterialsUsed = dr["MaterialsUsed"].ToString();
                    inInfo.Subtotal = Convert.ToDecimal(dr["Subtotal"].ToString());
                    inInfo.VAT = Convert.ToDecimal(dr["VAT"].ToString());
                    inInfo.Total = Convert.ToDecimal(dr["Total"].ToString());


                    invoiceList.Add(inInfo);     //adding all the customers information into the list
                }
                con.Close();        //closing the connection
            }

            return invoiceList;        //returning the list
        }

        //create
        public void CreateInvoice(InvoiceInformation inInfo)    //method to create a new customer
        {
            CustomerDAL custDAL = new CustomerDAL();

            //(Microsoft, 2021) and (see 3 Setting up app until Add Employee stored procedure, 2021)
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //using local connection
            {
                SqlCommand cmd = new SqlCommand("SP_InsertInvoice", con);      //sql command excuting stored procedure insert invoice
                cmd.CommandType = CommandType.StoredProcedure;      //type of command

                //this is connecting and adding the sql variables for invoice and putting it into the parameters of the local variables so it can connect to the web app
                cmd.Parameters.AddWithValue("@CustomerID", inInfo.CustomerID);
                cmd.Parameters.AddWithValue("@EmployeeID", inInfo.EmployeeID);
                cmd.Parameters.AddWithValue("@JobCardNo", inInfo.JobCardNo);
                cmd.Parameters.AddWithValue("@MaterialsID", inInfo.MaterialsID);

                //custDAL.GetLastCustomers()



                con.Open();     //opening the connection
                cmd.ExecuteNonQuery();      //this excutes queries that does not have a return value, it excutes ther command and returns the number of rows affected ()
                con.Close();        //closing the connection
            }
        }

        //get by id
        //the information below has been provided by (4. Continuation and close off, 2021) (Microsoft, 2021). 
        public IEnumerable<InvoiceInformation> GetInvoiceByID(int? invID)
        {
            InvoiceInformation inInfo = new InvoiceInformation();
            List<InvoiceInformation> invoiceList = new List<InvoiceInformation>();

            using (SqlConnection con = new SqlConnection(connectionStringProd))
            {
                SqlCommand cmd = new SqlCommand("SP_GetInvoiceByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@JobCardNo", invID);

                SqlCommand cmd2 = new SqlCommand("SP_JobCardEmployee", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@JobCardNo", invID);

                List<string> EmployeeID = new List<string>();
                List<string> EmployeeName = new List<string>();
                List<string> EmployeeSurname = new List<string>();

                con.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    inInfo.EmployeeID = dr2["EmployeeID"].ToString();
                    inInfo.EmployeeName = dr2["EmployeeName"].ToString();
                    inInfo.EmployeeSurname = dr2["EmployeeSurname"].ToString();

                    EmployeeID.Add(inInfo.EmployeeID);
                    EmployeeName.Add(inInfo.EmployeeName);
                    EmployeeSurname.Add(inInfo.EmployeeSurname);
                }
                string empID = "";
                string empName = "";
                string empSurname = "";

                for (int i = 0; i < EmployeeID.Count; i++)
                {
                    empID = empID + EmployeeID[i] + " ,";
                    empName = empName  + EmployeeName[i] + " ,";
                    empSurname = empSurname + EmployeeSurname[i] + " ,";
                }
                con.Close();
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    inInfo.JobTypeName = dr["JobTypeName"].ToString();
                    inInfo.DailyRate = Convert.ToDecimal(dr["DailyRate"].ToString());
                    inInfo.CustomerName = dr["CustomerName"].ToString();
                    inInfo.CustomerSurname = dr["CustomerSurname"].ToString();
                    inInfo.CustomerAddress = dr["CustomerAddress"].ToString();
                    inInfo.EmployeeID = empID;
                    inInfo.EmployeeName = empName;
                    inInfo.EmployeeSurname = empSurname;
                    inInfo.JobCardNo = Convert.ToInt32(dr["JobCardNo"].ToString());
                    inInfo.NumOfDays = Convert.ToInt32(dr["NumOfDays"].ToString());
                    inInfo.MaterialsUsed = dr["MaterialsUsed"].ToString();
                    inInfo.Subtotal = Convert.ToDecimal(dr["Subtotal"].ToString());
                    inInfo.VAT = Convert.ToDecimal(dr["VAT"].ToString());
                    inInfo.Total = Convert.ToDecimal(dr["Total"].ToString());

                    invoiceList.Add(inInfo);
                }

                con.Close();
            }
            return invoiceList;
        }

        
    }
}
