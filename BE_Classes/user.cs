using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace IdeaGen.BE
{
    class User : IdeaGen.DAL.NewDataAccessLayer
    {
        private int id;
        private string User_name;
        private string Your_name;
        private string Gmail;
        private string password;
        private long shift_id;

        //Start---------------Getter/setter-----------------------------


        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string USER_NAME
        {
            get { return this.User_name; }
            set { this.User_name = value; }
        }
        public string YOUR_NAME
        {
            get { return this.Your_name; }
            set { this.Your_name = value; }
        }
        public string GMAIL
        {
            get { return this.Gmail; }
            set { this.Gmail = value; }
        }
        public string PASSWORD
        {
            get { return this.password; }
            set { this.password = value; }
        }
        public long SHIFT_ID
        {
            get { return this.shift_id; }
            set { this.shift_id = value; }
        }

        //END---------------Getter/setter-----------------------------

        //Start---------------------SAVE------------------Proceture---------------

        public bool SaveUser()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[5];
                param[0] = new MySqlParameter("@id0", MySqlDbType.Int32);
                param[0].Value = id;
                param[1] = new MySqlParameter("@User_name0", MySqlDbType.VarChar, 60);
                param[1].Value = User_name;
                param[2] = new MySqlParameter("@Your_name0", MySqlDbType.VarChar, 60);
                param[2].Value = Your_name;
                param[3] = new MySqlParameter("@Gmail0", MySqlDbType.VarChar, 60);
                param[3].Value = Gmail;
                param[4] = new MySqlParameter("@password0", MySqlDbType.VarChar, 60);
                param[4].Value = password;

                if (OpenConnection())
                {
                    if (ExecuteCommand("User_Save", param))
                    {
                        CloseConnection();
                        param = null;

                        return true;
                    }
                    else
                    {

                        ShowMessage("This gmail ID alreadey Registerd", "Error");
                        param = null;
                        return false;
                    }

                }
                else
                {
                    ShowMessage("Server Not Connected", "Error");

                    param = null;
                    return false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }


        //END-------------------------------SAVE------------------Proceture----------------------


        //Start---------------------------EDIT----------------Proceture-----------------------

        public bool EditUser()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[7];
                param[0] = new MySqlParameter("@id0", MySqlDbType.Int32);
                param[0].Value = id;
                param[1] = new MySqlParameter("@id0", MySqlDbType.Int32);
                param[1].Value = id;
                param[2] = new MySqlParameter("@User_name0", MySqlDbType.VarChar, 60);
                param[2].Value = User_name;
                param[3] = new MySqlParameter("@Your_name0", MySqlDbType.VarChar, 60);
                param[3].Value = Your_name;
                param[4] = new MySqlParameter("@Gmail0", MySqlDbType.VarChar, 60);
                param[4].Value = Gmail;
                param[5] = new MySqlParameter("@password0", MySqlDbType.VarChar, 60);
                param[5].Value = password;
                param[6] = new MySqlParameter("@shift_id0", MySqlDbType.Int64);
                param[6].Value = shift_id;
                if (OpenConnection())
                {
                    if (ExecuteCommand(" User_Edit", param))
                    {

                        ShowMessage("Data Edited Successfully", "Warning");
                        CloseConnection();
                        param = null;

                        return true;
                    }
                    else
                    {

                        ShowMessage("Duplicate entry", "Error");
                        param = null;
                        return false;
                    }

                }
                else
                {
                    ShowMessage("Server Not Connected", "Error");

                    param = null;
                    return false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }


        //END----------------------------------------------EDIT-------------------------Proceture------------


        //Start-------------------------DELETE----------------------Proceture------------------

        public bool DeleteUser()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@id0", MySqlDbType.Int32);
                param[0].Value = id;
                if (OpenConnection())
                {
                    if (ExecuteCommand(" Delete_User ", param))
                    {

                        ShowMessage("Data Deleted Successfully", "Warning");
                        CloseConnection();
                        param = null;

                        return true;
                    }
                    else
                    {

                        ShowMessage("Duplicate entry", "Error");
                        param = null;
                        return false;
                    }

                }
                else
                {
                    ShowMessage("Server Not Connected", "Error");

                    param = null;
                    return false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }


        //END------------------------------------DELETE--------------------Proceture-------------------

        // ============================================ Get all details in Shop ==============================//////

        public DataTable GetUser()
        {
            comtable = null;


            if (OpenConnection())
            {
                comtable = SelectData("User_Select", null);
                sqlconnection.Close();
            }

            return comtable;
        }
        public void BindUserDetails(DataGridView dgv)
        {

            BindGrid(dgv, GetUser());
        }

        //Start-----------------constructer-------------------------------


        //End-----------------------constructer-------------------------------

        public User()
        {
        }

        public string GetPassword(string email)
        {
            string password = "";

            MySqlParameter[] param = new MySqlParameter[2];

            param[0] = new MySqlParameter("@Email", MySqlDbType.VarChar, 60);
            param[0].Value = email;

            param[1] = new MySqlParameter("@Password", MySqlDbType.VarChar, 60);
            param[1].Direction = ParameterDirection.Output;

            if (OpenConnection())
            {
                ExecuteCommand("forgot_pass", param);
                password = param[1].Value.ToString();
                CloseConnection();
            }

            return password;
        }


        //Start-----------------constructer-------------------------------

        public User(int id, string User_name, string Your_name, string Gmail, string password, long shift_id)
        {

            this.id = id;
            this.User_name = User_name;
            this.Your_name = Your_name;
            this.Gmail = Gmail;
            this.password = password;
            this.shift_id = shift_id;


            //End-----------------------constructer-------------------------------        
        }

    }
}