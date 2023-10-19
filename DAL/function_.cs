using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Net;




namespace IdeaGen.DAL
{
    class function_
    {
        string i = Configurations.Config.ConnectionString;// @"server=127.0.0.1;user id=root;database=hardwear;default command timeout=1000";//arifpos


        //  string i = @"database='hardwear'; datasource='192.168.8.15'; username='root'; password='12345';default command timeout=1000";

        // Define the WinAPI class
        class WinAPI
        {
            public const int AW_HOR_POSITIVE = 0x00000001;
            public const int AW_HOR_NEGATIVE = 0x00000002;
            public const int AW_SLIDE = 0x00040000;

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        }

        public void AnimateFormTransition(Form currentForm, Form nextForm)
        {
            const int animationDuration = 300;
            const int slideFlags = WinAPI.AW_SLIDE | WinAPI.AW_HOR_POSITIVE;

            // Animate the current form to slide out to the left
            WinAPI.AnimateWindow(currentForm.Handle, animationDuration, slideFlags);

            // Hide the current form
            currentForm.Hide();

            // Animate the next form to slide in from the right
            WinAPI.AnimateWindow(nextForm.Handle, animationDuration, slideFlags | WinAPI.AW_HOR_NEGATIVE);

            // Show the next form
            nextForm.Show();
        }



       public void ErrorMessge(string validate) 
       { 
           MessageBox.Show(validate, "Warnig Message", MessageBoxButtons.OK, MessageBoxIcon.Error); 
       }


      public bool ShowMessage(string message, string Con)
        {
            if (Con != "Confirm")
            {
                if (Con == "Warning")
                {
                    MessageBox.Show(message, Configurations.Config.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Con == "Information")
                {
                    MessageBox.Show(message, Configurations.Config.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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



        public void SendEmail(string recipientEmail, string subject, string body)
        {
            string email = "www.rjsathusan@gmail.com";
            string appPassword = "vimapnlymjmeveww";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(email);
            mail.To.Add(recipientEmail);
            mail.Subject = subject;
            mail.Body = body;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(email, appPassword);
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mail);
                //Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

     



  

    

       





        
     

       

      
        
    
      
       


   
        }








    }



