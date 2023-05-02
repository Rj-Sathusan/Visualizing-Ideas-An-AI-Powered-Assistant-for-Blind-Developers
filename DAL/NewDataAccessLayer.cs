using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IdeaGen.DAL
{
    class NewDataAccessLayer : DAL.function_
    {

        public static MySqlConnection sqlconnection;
        public static DataTable comtable;
        // sqlconnection = new MySqlConnection(Config.ConnectionString);
        // public function_ fun = new function_();
        //public DataAccessLayer()
        //{
        //   //sqlconnection = new MySqlConnection(@"server=127.0.0.1;user id=root;database=hardwear");
        //   sqlconnection = new MySqlConnection(Config.ConnectionString);

        //   // sqlconnection = new MySqlConnection(@"database='hardwear'; datasource='192.168.8.15'; username='root'; password='12345'");
        //}

        public bool OpenConnection()
        {
            sqlconnection = new MySqlConnection(Configurations.Config.ConnectionString);

            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
            try
            {
                sqlconnection.Open();
            }
            catch (Exception exception)
            {
                this.ErrorMessge(exception.Message);
                sqlconnection.Close();
                return false;
            }
            return true;
        }


        public bool CloseConnection()
        {
            sqlconnection = new MySqlConnection(Configurations.Config.ConnectionString);


            try
            {
                if (sqlconnection.State == ConnectionState.Open)
                {
                    sqlconnection.Close();
                }
            }
            catch (Exception exception)
            {
                this.ErrorMessge(exception.Message);
                sqlconnection.Close();
                return false;
            }
            return true;
        }

        public DataTable dataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand sqlcmd = new MySqlCommand();
                sqlcmd.CommandTimeout = 1000;
                sqlcmd.CommandText = sql;
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Connection = sqlconnection;


                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);

                // OpenConnection();
                da.Fill(dt);
                // CloseConnection();
                return dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return dt; }


        }

        public DataTable NewdataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand sqlcmd = new MySqlCommand();
                sqlcmd.CommandTimeout = 1000;
                sqlcmd.CommandText = sql;
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Connection = sqlconnection;


                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);

                // OpenConnection();
                da.Fill(dt);
                // CloseConnection();
                return dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return dt; }




        }
        public DataTable SelectData(string stored_procedure, MySqlParameter[] para)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand sqlcmd = new MySqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandTimeout = 1000;
                sqlcmd.CommandText = stored_procedure;
                sqlcmd.Connection = sqlconnection;

                if (para != null)
                {
                    for (Int32 i = 0; i < para.Length; i++)
                    {
                        sqlcmd.Parameters.Add(para[i]);

                    }

                }

                MySqlDataAdapter da = new MySqlDataAdapter(sqlcmd);


                da.Fill(dt);

                return dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return dt; }

        }

        public bool ExecuteCommand(string stored_procedure, MySqlParameter[] para)
        {
            try
            {
                MySqlCommand sqlcmd = new MySqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = stored_procedure;
                sqlcmd.Connection = sqlconnection;

                if (para != null)
                {

                    sqlcmd.Parameters.AddRange(para);
                }
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        public void ExecuteCommand1(string stored_procedure, MySqlParameter[] para, List<string> listitem)
        {
            MySqlCommand sqlcmd = new MySqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;

            if (para != null)
            {

                sqlcmd.Parameters.AddRange(para);
                sqlcmd.Parameters.Add(new SqlParameter("@MyCodes", listitem));

            }
            sqlcmd.ExecuteNonQuery();
        }

        public void Fill_Combobox_Desplaymember_Valauemenber(string store_producer, ComboBox com, string id, string name)
        {
            com.DataSource = SelectData(store_producer, null);
            com.DisplayMember = name;
            com.ValueMember = id;
            com.Text = "";

        }

        public DataTable dt { get; set; }
    }
}
