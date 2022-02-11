using SqlTest_CSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindoFood_Ordering_System_Project
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

               //  dataGridView1.DataSource = Connection.Select("Select * from Customer");
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        string custID = "";
        private void button5_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(ID.Text))
            {
                MessageBox.Show("Please enter ID");
                return;
            }
            string cmd = "insert into Customer (CUSTOMER_ID,CUSTOMER_NAME,CUST_CITY,CUST_STREET,CUST_FLOOR,CUST_APARTMENT)" +
                "values('" + ID.Text.ToString() + "','" + Name.Text.ToString() + "','" + City.Text.ToString() + "','" + Street.Text.ToString() + "','" + Floor.Text.ToString() + "','" + Apartment.Text.ToString() + "')";
            custID = ID.Text.ToString();
            Connection.RunCommand(cmd);
            MessageBox.Show("Registered Successfully");
            //dataGridView2.DataSource = Connection.Select("Select * from Customer ");
           dataGridView2.DataSource = Connection.Select("Select * from Customer where CUSTOMER_ID = "+ custID);


            //empty controls
            ID.Text = "";
            Name.Text = "";
            City.Text = "";
            Street.Text = "";
            Floor.Text = "";
            Apartment.Text = "";



        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
           // dataGridView2.DataSource = Connection.Select("Select * from Customer ");
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
            }
            else
            {
                string newValue = ((System.Data.DataTable)dataGridView2.DataSource).Rows[e.RowIndex][e.ColumnIndex].ToString();
                string id = ((System.Data.DataTable)dataGridView2.DataSource).Rows[e.RowIndex][0].ToString();

                string columnName = ((System.Data.DataTable)dataGridView2.DataSource).Columns[e.ColumnIndex].ColumnName;


                Connection.RunCommand("Update Customer set " + columnName + " = '" + newValue + "' Where Customer_ID = " + id);
            }

            //dataGridView2.DataSource = Connection.Select("Select * from Customer");

        }


        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                string id = ((System.Data.DataTable)dataGridView2.DataSource).Rows[e.Row.Index][0].ToString();
                Connection.RunCommand("Delete from Customer Where Customer_ID = " + id);
                MessageBox.Show("Deleted Successfully");

            }
            catch (Exception)
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //add new meal
            string cmd = "Select * from Menu";
            /*MessageBox.Show(" Searching !!!");
            string where1 = " RESID == '" + txtResID.Text + "'"; ;
            string Res_ID = txtResID.Text.ToString();
            
            if (!string.Equals(txtResID.ToString(),where1.ToString()))
            {
                dataGridView3.DataSource = Connection.Select("Select * from Menu");
            }
            */
            string where4 = "1=1";
            if (!string.IsNullOrEmpty(txtResID.Text))
            {
                where4 = "RESID ='" + txtResID.Text + "'";
            }

            if ( where4 != null)
            {
                cmd += " Where " + where4;

            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
            }
            else
            {
                string newValue = ((System.Data.DataTable)dataGridView3.DataSource).Rows[e.RowIndex][e.ColumnIndex].ToString();
                string id = ((System.Data.DataTable)dataGridView3.DataSource).Rows[e.RowIndex][0].ToString();

                string columnName = ((System.Data.DataTable)dataGridView3.DataSource).Columns[e.ColumnIndex].ColumnName;


                Connection.RunCommand("Update Menu set " + columnName + " = '" + newValue + "' Where M_ID = " + id);
            }

            dataGridView3.DataSource = Connection.Select("Select * from Menu");

        }
        private void dataGridView3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                string id = ((System.Data.DataTable)dataGridView3.DataSource).Rows[e.Row.Index][0].ToString();
                Connection.RunCommand("Delete from MENU Where M_ID = " + id);
                MessageBox.Show("Deleted Meal Successfully");

            }
            catch (Exception)
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string cmd = "Select * from Menu ";
            string where1, where2, where3,where4; where1 = where2 = where3=where4 = " 1 = 1 ";
            if (!string.IsNullOrEmpty(txtMealNameSearch.Text))
            {
                where1 = " M_Name like '%" + txtMealNameSearch.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtMealPriceSearch.Text))
            {
                where2 = " M_Price = '" + txtMealPriceSearch.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtCategorySearch.Text))
            {
                where3 = " Category like '%" + txtCategorySearch.Text + "%'";
            }
            if(!string.IsNullOrEmpty(txtResID.Text))
            {
                where4 = "RESID ='" + txtResID.Text + "'";
            }

            if (where1 != null || where2 != null || where3 != null||where4!=null )
            {
                cmd += " Where ";
                cmd += string.Join(" AND ", new string[] { where1, where2, where3,where4 });

            }


            //txtMealPriceSearch
            //txtCategorySearch

           dataGridView3.DataSource = Connection.Select(cmd);
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            dataGridView3.DataSource = Connection.Select("Select * from Menu");

        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            combo_Customers.DataSource = Connection.Select("Select * from Customer");
            D_combo.DataSource = Connection.Select("Select * from DRIVER");
            OrderBooked_combo.DataSource = Connection.Select("Select * from Orders");
           // dataGridView4.DataSource = Connection.Select("Select * from Orders");

        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string orderid = "";
        string meal = "";
       


        private void button8_Click(object sender, EventArgs e)
        {
            
            string cmd2= "insert into [CONTAINS] (ORDER_ID,M_ID)" +
                "values('" + txtOrderID.Text.ToString() + "','" + txtmealNUMBER.Text.ToString() + "')";
            meal = "'" + txtmealNUMBER.Text.ToString() + "'";
            string price = "select M_PRICE FROM MENU ,ORDERS ,[CONTAINS] where ORDERS.ORDER_ID=[CONTAINS].ORDER_ID and MENU.M_ID =[CONTAINS].M_ID and MENU.M_ID= " + meal;
            var priceconn = Connection.Select(price);
            orderid = txtOrderID.Text.ToString();
            string cmd = "insert into Orders (ORDER_ID,CUSTOMER_ID,D_ID,DATE,PAYMENT)" +
                "values('" + txtOrderID.Text.ToString() + "','" + combo_Customers.SelectedValue.ToString() + "','" + D_combo.SelectedValue.ToString() + "','" + txtDate.Value.ToString("MM/dd/yyyy HH:mm") + "',to int32(priceconn))";

            Connection.RunCommand(cmd);
            Connection.RunCommand(cmd2);
            MessageBox.Show("Order Booked");
            dataGridView4.DataSource = Connection.Select("select  MENU.M_NAME ,MENU.M_PRICE from MENU where M_ID="+meal);
        }
       
        private void combo_Customers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void D_combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*private void dataGridView4_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                string id = ((System.Data.DataTable)dataGridView4.DataSource).Rows[e.Row.Index][0].ToString();
                Connection.RunCommand("Delete from ORDERS Where M_ID = " + id);
                MessageBox.Show(" Orders Canceld");

            }
            catch (Exception)
            {

            }
        }*/
        private void button9_Click(object sender, EventArgs e)
        {
            string cmd = OrderBooked_combo.SelectedValue.ToString();
            Connection.RunCommand("Delete from ORDERS Where Order_ID = " + cmd);
            MessageBox.Show("Order Canceled");
            dataGridView4.DataSource = Connection.Select("Select * from Orders");
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string cmd = "update Customer set C_FEEDBACK = '" + txt_feed.Text.ToString() + "' ";
            string where = "where CUSTOMER_ID = '"+ID.Text+"'";
            cmd += where;
            Connection.RunCommand(cmd);
            MessageBox.Show("Thanks For Your Feedback");
            dataGridView2.DataSource = Connection.Select("Select CUSTOMER_NAME,C_FEEDBACK from Customer WHERE CUSTOMER_ID = "+ custID);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            /*string cmd = "select CUSTOMER.CUSTOMER_NAME,sum(ORDERS.PAYMENT)from CUSTOMER, MENU, ORDERS,[CONTAINS]";

            string where = "where CUSTOMER.CUSTOMER_ID=ORDERS.CUSTOMER_ID ";
            string where1 = " ORDERS.ORDER_ID=[CONTAINS].ORDER_ID ";
            string where2 = " [CONTAINS].M_ID=MENU.M_ID ";
            string where3 = " CUSTOMER.CUSTOMER_ID = "+ custID;
            string group = " group by CUSTOMER_NAME";
            cmd += where + " and " + where1 + " and " + where2 +"and"+where3+ group;*/
            /*var total = Connection.Select("select CUSTOMER.CUSTOMER_NAME,sum(ORDERS.PAYMENT)" +
                " from CUSTOMER, MENU, ORDERS,[CONTAINS] where CUSTOMER.CUSTOMER_ID = ORDERS.CUSTOMER_ID " +
                "and ORDERS.ORDER_ID =[CONTAINS].ORDER_ID and[CONTAINS].M_ID = MENU.M_ID " +
                "and CUSTOMER.CUSTOMER_ID = "+ 2 +" and ORDERS.ORDER_ID = "+3+                 "group by CUSTOMER_NAME");
            MessageBox.Show("Total = " + total);*/

            string totalP = "";
            totalP = Connection.NewCommand();
            MessageBox.Show("your bill is " + totalP);
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        /*private void button10_Click(object sender, EventArgs e)
        {
            //txtfeedback
            string cmd = "insert into Customer (C_FEEDBACK)" +
                "values('" + txtfeedback.Text.ToString() + "')";
            MessageBox.Show("Thanks For Your Feedback");
            Connection.RunCommand(cmd);
            Feedback.Text = "";
        }*/
    }
    }

