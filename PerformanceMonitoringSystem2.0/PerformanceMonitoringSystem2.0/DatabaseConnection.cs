using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceMonitoringSystem2._0
{
    internal class DatabaseConnection
    {
        private string sql_string; // This variable holds the SQL string "SELECT * FROM tbl_students"
        private string strCon; // This field holds the location of the database

        System.Data.SqlClient.SqlDataAdapter da_1;// This is called a DataAdapter and it is used to open up a table in a database

        //Write-only property. This means that it has no get part
        public string Sql
        {
            set
            {
                sql_string = value; // the value, which is the SQL, is assigned to "sql_string"
            }
        }

        //This is the connection string, the one that was set up on the Settings page. This is a write-only property as well.
        public string connection_string
        {
            set { strCon = value; }
        }

        //DataSet is a grid that holds the data from our table. 
        //Table data is loaded into a DataSet, rather than changing the table in the database
        public System.Data.DataSet GetConnection
        {
            get { return MyDataSet(); }
        }
        // This method connects to the database and fills the Dataset
        private System.Data.DataSet MyDataSet()
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(strCon);
            con.Open(); //Opens a connection to the database
            da_1 = new System.Data.SqlClient.SqlDataAdapter(sql_string, con); //This is used to tell C# which records we want from the table and it is a variable created from the DataAdapter class
            System.Data.DataSet dat_set = new System.Data.DataSet();//This sets up a DataSet object. The variable that was created is called dat_set. The whole method is going to be returning this DataSet, which will hold all the records from the table.

            da_1.Fill(dat_set, "Table_Data_1");//Fills a DataSet

            con.Close();//Closes the connection object

            return dat_set;//Returns the DataSet
        }

        //Method for updating the database
        public void UpdateDatabase(System.Data.DataSet ds)
        {
            System.Data.SqlClient.SqlCommandBuilder cb = new System.Data.SqlClient.SqlCommandBuilder(da_1);

            cb.DataAdapter.Update(ds.Tables[0]);
        }
    }
}
