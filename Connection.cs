using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTest_CSharp
{
    public class Connection
    {
        public static DataTable Select(string commandText)
        {
            // Create the connection to the resource!  
            // This is the connection, that is established and  
            // will be available throughout this block.  
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data Source=.;Initial Catalog=FoodOrderingSystemProjectDB;Integrated Security=SSPI;";
                conn.Open();
                SqlCommand command = new SqlCommand(commandText, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    conn.Dispose();

                    return dataTable;
                }

            }
        }

        public static void RunCommand(string commandText)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data Source=.;Initial Catalog=FoodOrderingSystemProjectDB;Integrated Security=SSPI;";
                    conn.Open();
                    // SqlCommand command = new SqlCommand(commandText, conn);

                    SqlCommand insertCommand = new SqlCommand(commandText, conn);
                    insertCommand.ExecuteNonQuery();

                    conn.Dispose();
                }



            }
            catch (Exception ex)
            {

            }
        }
        public static string NewCommand ()
        {
            try
            {
                using(SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = "Data Source=.;Initial Catalog=FoodOrderingSystemProjectDB;Integrated Security=SSPI;";
                    con.Open();
                    // SqlCommand command = new SqlCommand(commandText, conn);
                    SqlCommand c = new SqlCommand();
                    c.CommandText = "select CUSTOMER.CUSTOMER_NAME,sum(ORDERS.PAYMENT) from CUSTOMER, MENU, ORDERS,[CONTAINS] where CUSTOMER.CUSTOMER_ID = ORDERS.CUSTOMER_ID and ORDERS.ORDER_ID =[CONTAINS].ORDER_ID and[CONTAINS].M_ID = MENU.M_ID and CUSTOMER.CUSTOMER_ID = 2 group by CUSTOMER_NAME "; ;
                    c.Connection = con;
                    c.CommandType = CommandType.Text;

                    SqlDataReader read = c.ExecuteReader();
                    string totalP = "";
                    while (read.Read())
                    {
                        totalP += read[1];
                    }
                    return totalP;
                    con.Dispose();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}