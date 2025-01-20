using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DomingoApp.Models
{
    public class MaterialsDAL
    {
        //(see 3 Setting up app until Add Employee stored procedure, 2021) showed how to get the string connections
        //local connection string
        string connectionStringProd = "Data Source=LAPTOP-CR8S2VUC;Initial Catalog=DomingoDatabase;Integrated Security=True";
        //azure connection string
       

        //get all materials
        public IEnumerable<MaterialsInformation> GetAllMaterials() //a list method
        {
            List<MaterialsInformation> materialsList = new List<MaterialsInformation>();   //list to store all the materials in the database

            // (Microsoft, 2021) and (see 3 Setting up app until Add Employee stored procedure, 2021). 
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //using local connection
            {

                SqlCommand cmd = new SqlCommand("SP_GetAllMaterials", con);  //calling the get all stored procedure from the sql database
                cmd.CommandType = CommandType.StoredProcedure;  //type of sql command
                con.Open();     //opening the connection
                SqlDataReader dr = cmd.ExecuteReader();     //reading the sql command
                while (dr.Read())       //while loop to display and read all the materials information
                {
                    MaterialsInformation matInfo = new MaterialsInformation();
                    matInfo.MaterialsID = Convert.ToInt32(dr["MaterialsID"].ToString());
                    matInfo.MaterialsUsed = dr["MaterialsUsed"].ToString();
                    matInfo.JobTypeName = dr["JobTypeName"].ToString();

                    materialsList.Add(matInfo);     //adding all the materials information into the list
                }
                con.Close();        //closing the connection
            }

            return materialsList;        //returning the list
        }

        //create materials
        public void CreateMaterials(MaterialsInformation matInfo)    //method to create a new customer
        {
            //(Microsoft, 2021) and (see 3 Setting up app until Add Employee stored procedure, 2021)
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //using local connection
            {
                SqlCommand cmd = new SqlCommand("SP_InsertMaterials", con);      //sql command excuting stored procedure insert materials
                cmd.CommandType = CommandType.StoredProcedure;      //type of command

                //this is connecting and adding the sql variables for materials and putting it into the parameters of the local variables so it can connect to the web app
                cmd.Parameters.AddWithValue("@MaterialsUsed", matInfo.MaterialsUsed);
                cmd.Parameters.AddWithValue("@JobTypeName", matInfo.JobTypeName);

                con.Open();     //opening the connection
                cmd.ExecuteNonQuery();      //this excutes queries that does not have a return value, it excutes ther command and returns the number of rows affected ()
                con.Close();        //closing the connection
            }
        }

        //get materials by id
        //the information below has been provided by (4. Continuation and close off, 2021) (Microsoft, 2021). 
        public MaterialsInformation GetMaterialsByID(int? matID)
        {
            MaterialsInformation matInfo = new MaterialsInformation();

            using (SqlConnection con = new SqlConnection(connectionStringProd))
            {
                SqlCommand cmd = new SqlCommand("SP_GetMaterialsByID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaterialsID", matID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    matInfo.MaterialsID = Convert.ToInt32(dr["MaterialsID"].ToString());
                    matInfo.MaterialsUsed = dr["MaterialsUsed"].ToString();
                    matInfo.JobTypeName = dr["JobTypeName"].ToString();
                }

                con.Close();
            }
            return matInfo;
        }

        //update materials
        //the information below has been provided by (4. Continuation and close off, 2021) (Microsoft, 2021). 
        public void UpdateMaterials(MaterialsInformation matInfo)        //method to update the details of a customer
        {
            using (SqlConnection con = new SqlConnection(connectionStringProd))      //connection that is being used
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateMaterials", con);      //sql command excuting stored procedure update customer
                cmd.CommandType = CommandType.StoredProcedure;      //type of command 

                //this is connecting and adding the sql variables for customer and putting it into the parameters of the local variables so it can connect to the web app
                cmd.Parameters.AddWithValue("@MaterialsID", matInfo.MaterialsID);
                cmd.Parameters.AddWithValue("@MaterialsUsed", matInfo.MaterialsUsed);
                cmd.Parameters.AddWithValue("@JobTypeName", matInfo.JobTypeName);

                con.Open();     //opening the connection
                cmd.ExecuteNonQuery();       //this excutes queries that does not have a return value, it excutes ther command and returns the number of rows affected ()
                con.Close();        //closing the connection
            }
        }

        //delete materials
        //the information below has been provided by (4. Continuation and close off, 2021) (Microsoft, 2021). 
        public void DeleteMaterials(int? matID)
        {
            using (SqlConnection con = new SqlConnection(connectionStringProd))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteMaterials", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaterialsID", matID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}
