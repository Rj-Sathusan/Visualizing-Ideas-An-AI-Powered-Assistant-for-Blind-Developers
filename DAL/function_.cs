using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.IO;
using System.Dynamic;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Globalization;



namespace Krypton_Toolkit_Demo.DAL
{
    class function_
    {
         public double  totalamount { get; set; }
         string i = Configurations.Config.ConnectionString;// @"server=127.0.0.1;user id=root;database=hardwear;default command timeout=1000";//arifpos
        
     
      //  string i = @"database='hardwear'; datasource='192.168.8.15'; username='root'; password='12345';default command timeout=1000";
        public string caranceformat(double amount)
        {
            return String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N2}", amount);

        }
        public double doubleformat(string amount)
        {
            return double.Parse(amount, System.Globalization.NumberStyles.Currency);
        }


        public void BindGridButton(DataGridView dgv, DataTable table)
        {
            dgv.Rows.Clear();
            // GetValue(x)
            dgv.RowCount = table.Rows.Count;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int x = 0; x < dgv.ColumnCount - 1; x++)
                {
                    dgv[x, i].Value = table.Rows[i].ItemArray[x].ToString().Trim();
                }
            }



        }

        public void BindGridButton2(DataGridView dgv, DataTable table)
        {
            // GetValue(x)
            dgv.RowCount = table.Rows.Count;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int x = 0; x < dgv.ColumnCount - 2; x++)
                {
                    dgv[x, i].Value = table.Rows[i].ItemArray[x].ToString().Trim();
                }
            }



        }


        public void BindGridButton3(DataGridView dgv, DataTable table)
        {
            // GetValue(x)
            dgv.RowCount = table.Rows.Count;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int x = 0; x < dgv.ColumnCount - 3; x++)
                {
                    dgv[x, i].Value = table.Rows[i].ItemArray[x].ToString().Trim();
                }
            }



        }

        public double CalculateAmountByUsingDatagridview(DataGridView dgv, int columindes)
        {
            totalamount = 0;
            for (int a = 0; dgv.Rows.Count > a; a++)
            {
                totalamount += doubleformat(dgv.Rows[a].Cells[columindes].Value.ToString());
            }
            return totalamount;
        }

        public void godFocusOnButton(Button but)
        {
            but.BackColor = Color.LightGreen;

        }

        public void lostFocusOnButton(Button but)
        {
            but.BackColor = SystemColors.Control;

        }

        public void CalculateAmountByUsingDatagridviewithCondi(DataGridView dgv, int columindes,Label laselesitem,Label laselseqty)
        {
            totalamount = 0; double saqty = 0;
            for (int a = 0; dgv.Rows.Count > a; a++)
            {
                if (Convert.ToDouble(dgv.Rows[a].Cells[columindes].Value.ToString()) > 0)
                {
                    saqty += doubleformat(dgv.Rows[a].Cells[columindes].Value.ToString());
                    totalamount += 1;
                }
            }
            laselesitem.Text = totalamount.ToString(); laselseqty.Text = saqty.ToString();

        }
        public double CalculateAmountByUsingDatagridviewithCondiWithCount(DataGridView dgv, int columindes)
        {
            totalamount = 0;
            for (int a = 0; dgv.Rows.Count > a; a++)
            {
                if (Convert.ToDouble(dgv.Rows[a].Cells[columindes].Value.ToString()) > 0)
                {
                    totalamount += 1;
                }
            }
            return totalamount;
        }


        public void GetReturnQtyAndItems(DataGridView dgv, int columindes,Label reitem,Label reqty)
        {
            totalamount = 0; double rtqty = 0;
            for (int a = 0; dgv.Rows.Count > a; a++)
            {
                if (Convert.ToDouble(dgv.Rows[a].Cells[columindes].Value.ToString()) < 0)
                {
                    rtqty += Convert.ToDouble(Convert.ToDouble(dgv.Rows[a].Cells[columindes].Value.ToString())) * -1;
                    totalamount += 1;
                }
            }
            reitem.Text = totalamount.ToString();
            reqty.Text = rtqty.ToString();
        }

        public double CalculateGrossAmount(DataGridView dgv, int saleuntipriceindex,int retunenettotalintex,int qtyintex)
        {
            totalamount = 0; double retunamount = 0;
            for (int a = 0; dgv.Rows.Count > a; a++)
            {
                if (Convert.ToDouble(dgv.Rows[a].Cells[qtyintex].Value.ToString()) >= 0)
                {
                    totalamount += Convert.ToDouble(dgv.Rows[a].Cells[saleuntipriceindex].Value.ToString());
                }
                else
                {
                    totalamount += Convert.ToDouble(dgv.Rows[a].Cells[retunenettotalintex].Value.ToString());
               
                }

            }
            return totalamount;
        }

        public double CalculateAmountByUsingDatagridviewithCondiWithCountOtherColum(DataGridView dgv, int columindes,int columother)
        {
            totalamount = 0;
            for (int a = 0; dgv.Rows.Count > a; a++)
            {
                if (Convert.ToDouble(dgv.Rows[a].Cells[columother].Value.ToString()) > 0)
                {
                    totalamount += Convert.ToDouble(dgv.Rows[a].Cells[columindes].Value.ToString());
                }
            }
            return totalamount;
        }
        public string fill_combo_value(string query, ComboBox combobox, string display_member_column_name, string value_member_column_name)
        {

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(query, i);
            da.Fill(ds);
            combobox.DataSource = ds.Tables[0].DefaultView;
            combobox.DisplayMember = display_member_column_name;
            combobox.ValueMember = value_member_column_name;
            return combobox.SelectedValue.ToString();
        }

        public void datagridviewcolor(DataGridView dgv) { dgv.DefaultCellStyle.BackColor = Color.LightGray; dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White; }



        public void FistLeterCapita(TextBox tb)
        {
            try {
               
                // Creates a TextInfo based on the "en-US" culture.
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

                // Changes a string to titlecase.
                tb.Text = textInfo.ToTitleCase(tb.Text.Trim());
                
            }
            catch { }
        
        }
        public void DataHandel(string sql)
        {

            MySqlConnection con = new MySqlConnection(i);
            MySqlCommand cmd = new MySqlCommand(sql, con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();



        }

        public void FillComboBox(ComboBox combo, string sql)
        {
            combo.Items.Clear();
            MySqlConnection con = new MySqlConnection(i);
            MySqlCommand command = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) { combo.Items.Add(reader[0].ToString().Trim()); }

                con.Close();
            }
            catch  { }

        }


        public void TextClear(TextBox[] Boxes)
        {
            try
            {
                for (int i = 0; i < Boxes.Length; i++)
                {
                    Boxes[i].Text = string.Empty;
                }
            }
            catch (Exception) { }
        }

        public void FillTextBox(TextBox text, string sql)
        {//text.Text=""; write this code form load to clear data textbox1
            try
            {
                MySqlConnection con = new MySqlConnection(i);
                MySqlDataAdapter cmd = new MySqlDataAdapter(sql, con);
                DataTable dt = new DataTable();

                con.Open();
                cmd.Fill(dt);
                con.Close();

                string data = dt.Rows[0].ItemArray[0].ToString();
                text.Text = data;

            }
            catch (Exception) { }

        }

        public void BindGrid(DataGridView dgv, DataTable table)
        {
            dgv.Rows.Clear();
            dgv.RowCount = table.Rows.Count;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int x = 0; x < dgv.ColumnCount; x++)
                {
                    dgv[x, i].Value = table.Rows[i].ItemArray[x].ToString().Trim();
                }
            }



        }


        public DataTable dataTable(string sql)
        {

                 DataTable table = new DataTable();
           
                MySqlConnection con = new MySqlConnection(i);
                MySqlDataAdapter cmd = new MySqlDataAdapter(sql, con);

                con.Open();
                cmd.Fill(table);
                con.Close();

                return table;
           


        }

        
        public double GetSingleValue(string sql)
        {
            //you shoud use try,catch block combobox selected index
            double x;
            MySqlConnection con = new MySqlConnection(i);
            MySqlDataAdapter cmd = new MySqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            con.Open();
            cmd.Fill(dt);
            con.Close();


            x = double.Parse(dt.Rows[0].ItemArray[0].ToString()); return x;



        }

        public string GetSingleValueString(string sql)
        {
            //you shoud use try,catch block combobox selected index
            string x;
            MySqlConnection con = new MySqlConnection(i);
            MySqlDataAdapter cmd = new MySqlDataAdapter(sql, con);
            DataTable dt = new DataTable();

            con.Open();
            cmd.Fill(dt);
            con.Close();


            x = dt.Rows[0].ItemArray[0].ToString(); return x;



        }
       
     

        public void LableTransferant(Label[] lebel, PictureBox picBox)
        {
            for (int i = 0; i < lebel.Length; i++)
            {
                lebel[i].Parent = picBox;
                lebel[i].BackColor = Color.Transparent;
            }
        }

        public void timeDisplay(Label lab)
        {
            string s, m;
            int x = DateTime.Now.Second;
            int y = DateTime.Now.Minute;
            int w = DateTime.Now.Hour;

            if (x < 10)
            {
                s = "0" + x;

            }
            else { s = x.ToString(); }

            if (y < 10)
            {
                m = "0" + y;

            }
            else
            {
                m = y.ToString();

                lab.Text = w.ToString() + ":" + m + ":" + s;


            }


        }


        public void askmessage(string sql)
        {

            DialogResult dialog = MessageBox.Show( " \t Do You Want To Delete ?","Conform Message", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                function_ fun = new function_();
                fun.DataHandel(sql);
                fun.DeleteMessge();
            }
            else if (dialog == DialogResult.No)
            {
               
            }





        }
        public void InputNumberWithSub(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'  || e.KeyChar==45) )
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
            else
            {
                if (txtDecimal.Text.Contains("-") && e.KeyChar == 45)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
        }
        public void InputNumberOnley(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
        public void checkString(KeyPressEventArgs e, TextBox txt) {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 46 || e.KeyChar == 8 )//true or false
            {
                if (txt.Text.Contains(".") && e.KeyChar == 46 )
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
            else
            {
                
                    e.Handled = true;
             
            }
        }

        public void checkStringWithOutPoint(KeyPressEventArgs e, TextBox txt)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57  || e.KeyChar == 8)//true or false
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }


        public void checkStringwithsub(KeyPressEventArgs e, TextBox txt)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 46 || e.KeyChar == 8 ||e.KeyChar==45)//true or false
            {
                if (txt.Text.Contains(".") && e.KeyChar == 46)
                {
                    e.Handled = true;
                }
                else
                {                    

                    if (txt.Text.Contains("-") && e.KeyChar == 45)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
              
               
               
            }
            else
            {
                e.Handled = true;
            }
        }
        public void checknumber(KeyPressEventArgs e, TextBox txt)
        {

            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 46 || e.KeyChar == 8 || e.KeyChar == 42)//true or false
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        
        
        }
        public void AddMessage() { MessageBox.Show("Data Saved Successfuly !!!","Add Message",MessageBoxButtons.OK,MessageBoxIcon.Information); }
        public void EditMessge() { MessageBox.Show("Data Updated Successfuly !!!", "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        public void DeleteMessge() { MessageBox.Show("Data Deleted Successfuly !!!", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        public void validationMessge(string validate) { MessageBox.Show(validate, "Warnig Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        public void ErrorMessge(string validate) { MessageBox.Show(validate, "Warnig Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        public void WwarningMessge(string validate) { MessageBox.Show(validate, "Warnig Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); }
     
        public void listboxclear(ListBox listname) {
            for (int i = 0; i < listname.Items.Count; i++) { listname.Items.RemoveAt(i); i--; }
        }
        public void comboboxclear(ComboBox comname) { for (int i = 0; i < comname.Items.Count; i++) { comname.Items.RemoveAt(i); i--; } }

        public void getStock(string sql, TextBox currentbox, TextBox currentpieces, int pie,TextBox total_pie)
        {
            function_ fun = new function_();
            int curentbox, currentpies;
            int current_stock = int.Parse(fun.dataTable(sql).Rows[0].ItemArray[0].ToString());

            curentbox = current_stock / pie; currentpies = current_stock % pie;
            currentbox.Text = curentbox.ToString();
            currentpieces.Text = currentpies.ToString();
            total_pie.Text = current_stock.ToString();


        }

        public void auto_fill_text_box(TextBox text_box, string sql)
        {
            try
            {
                text_box.AutoCompleteMode = AutoCompleteMode.Suggest;
                text_box.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                getData(DataCollection, sql);
                text_box.AutoCompleteCustomSource = DataCollection;
            }
            catch { }
        }

        public bool ShowMessage(string message, string Con)
        {
            if (Con != "Confirm")
            {
                if (Con == "Warning")
                {
                    MessageBox.Show(message,Configurations. Config.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Con == "Information")
                {
                    MessageBox.Show(message,Configurations. Config.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (Con == "Error")
                {
                    MessageBox.Show(message, Configurations.Config.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else if (MessageBox.Show(message, Configurations.Config.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
        public void getData(AutoCompleteStringCollection dataCollection, string sql)
        {
            try{
           
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet ds = new DataSet();

         
            MySqlConnection connection = new MySqlConnection(Configurations.Config.ConnectionString);
          
                connection.Open();
                command = new MySqlCommand(sql,connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataCollection.Add(row[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
                
        
        
        
        
        
    
    }

    
}
