using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kefron
{
    public partial class _Default : Page
    {
        private static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
            }
        }

        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file, using the 
            // System.Configuration.ConfigurationSettings.AppSettings property 
            return "Data Source=(local);Initial Catalog=AdventureWorks;"
                + "Integrated Security=SSPI;";
        }

        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyfFrstDataBaseConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            myConnection.Open();

            string query = "select * from [dbo].[Menu]";

            // use a SqlAdapter to execute the query
            using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Menu", myConnection))
            {
                // fill a data table
                var t = new DataTable();
                a.Fill(t);

                // Bind the table to the list box
                listMenu.DataTextField = "name";
                listMenu.DataValueField = "id";
                listMenu.DataSource = t;
                listMenu.DataBind();
            }

            myConnection.Close();

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            string name = txtName.Text;
            string address = txtAddress.Text;
            string dateOfBirth = txtDateOfBirth.Text;
            string email = txtEmail.Text;

            myConnection.Open();

            // Customer
            string query = "Insert into [dbo].[Customer] (name, address, date_of_birth, email) Values (@name, @address, @date_of_birth, @email)";
            SqlCommand insertCommand = new SqlCommand(query, myConnection);
            insertCommand.Parameters.AddWithValue("@name", name);
            insertCommand.Parameters.AddWithValue("@address", address);
            insertCommand.Parameters.AddWithValue("@date_of_birth", dateOfBirth);
            insertCommand.Parameters.AddWithValue("@email", email);
            insertCommand.Parameters.Add("@id", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
            int id_customer = insertCommand.ExecuteNonQuery();

            // Customer X Menu
            foreach (int i in listMenu.GetSelectedIndices())
            {

                int id_menu = int.Parse(listMenu.Items[i].Value);

                query = "Insert into [dbo].[Customer_X_Menu] (id_menu, id_customer) Values (@id_menu, @id_customer)";
                insertCommand = new SqlCommand(query, myConnection);
                insertCommand.Parameters.AddWithValue("@id_menu", id_menu);
                insertCommand.Parameters.AddWithValue("@id_customer", id_customer);
                insertCommand.ExecuteNonQuery();

            }

            myConnection.Close();


        }
    }
}