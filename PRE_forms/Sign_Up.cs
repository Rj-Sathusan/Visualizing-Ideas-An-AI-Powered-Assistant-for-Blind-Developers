using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IdeaGen
{
    public partial class Sign_Up : KryptonForm
    {
        private int id;
        private string User_name;
        private string Your_name;
        private string Gmail;
        private string password;
        private int expectedOTP;
        private string s_name;
        private string s_mail;
        private string r_mail;
        private string sub;
        private string msg;
        private int randomNumber;


        // Create a new instance of the User class
        BE.User user = new BE.User();
        DAL.function_ fun = new DAL.function_();
        DAL.NewDataAccessLayer Ndal = new DAL.NewDataAccessLayer();



        public Sign_Up()
        {
            InitializeComponent();
        }


        public int GenerateRandomNumber()
        {
            Random rand = new Random();
            randomNumber = rand.Next(1000, 9999);
            return randomNumber;
        }


        private bool ValidateInputs()
        {
            // Validate user name
            if (string.IsNullOrWhiteSpace(user_name_txt.Text) || !Regex.IsMatch(user_name_txt.Text, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter a valid user name. Only letters are allowed.", "Invalid User Name");
                user_name_txt.Focus(); // Set focus to the user name text box
                return false;
            }

            // Validate your name
            if (string.IsNullOrWhiteSpace(your_name_txt.Text) || !Regex.IsMatch(your_name_txt.Text, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter your name. Only letters are allowed.", "Invalid Name");
                your_name_txt.Focus(); // Set focus to the your name text box
                return false;
            }

            // Validate password
            if (string.IsNullOrWhiteSpace(password_txt.Text))
            {
                MessageBox.Show("Please enter a password.", "Invalid Password");
                password_txt.Focus(); // Set focus to the password text box
                return false;
            }

            // Validate gmail
            if (string.IsNullOrWhiteSpace(gmail_txt.Text) || !Regex.IsMatch(gmail_txt.Text, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
            {
                MessageBox.Show("Please enter a valid gmail address.", "Invalid Gmail Address");
                gmail_txt.Focus();
                return false;
            }

            return true;
        }





        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Message");
        }

      


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Call the helper method to animate the transition between the current form and the new instance of the Front form
            fun.AnimateFormTransition(this, new Front());
        }

        private async void pictureBox4_Click(object sender, EventArgs e)
        {
             if (ValidateInputs())
            {
                //send OTP and Call mail function
                 otp_txt.Visible = true;
                 randomNumber = GenerateRandomNumber();

                 s_name = "IdeaGen_Official";
                 //s_mail = "IdeaGen";
                 r_mail = gmail_txt.Text;
                 sub = "Verification Code for Your Account";
                 msg = "Dear User,\n\nPlease use the following verification code to complete your account registration: " + randomNumber + "\n\nThank you,\nThe Team";
                //await fun.Mail (s_name, s_mail, r_mail, sub, msg);
                fun.SendEmail(r_mail, sub, msg);


                // Set the expected OTP value
                expectedOTP = randomNumber;

                MessageBox.Show("Please enter the verification code we sent to your email address to complete your account registration.", "Verification");

                // Clear any existing text in the otp_txt textbox
                otp_txt.Text = "";

                // Enable the otp_txt textbox to receive input
                otp_txt.Enabled = true;

                // Focus on the otp_txt textbox to allow for immediate input
                otp_txt.Focus();
            }
        }

        private void otp_txt_TextChanged(object sender, EventArgs e)
        {
            if (otp_txt.Text.Length >= 4)
            {

                // Retrieve the entered OTP value
                string enteredOTP = otp_txt.Text;

                // Create an instance of the other form
                Knowdlage frontForm = new Knowdlage();


                if (enteredOTP == Convert.ToString(expectedOTP))
                {

                    // Set the properties of the user object using the values entered in the form
                    id = 0; //Id auto increament
                    User_name = user_name_txt.Text;
                    Your_name = your_name_txt.Text;
                    Gmail = gmail_txt.Text;
                    password = password_txt.Text;

                    //Set values user class
                    BE.User newUser = new BE.User(id, User_name, Your_name, Gmail, password);

                    // Call the SaveUser method to save the user data to the database
                    bool result = user.SaveUser();

                    // Display a message to the user based on the result of the SaveUser method
                    if (result)
                    {
                        // Call the helper method to animate the transition between the current form and the new instance of the Front form
                        fun.AnimateFormTransition(this, new Knowdlage());

                        MessageBox.Show("Registration completed successfully!", "Success");

                    }
                    else
                    {
                        MessageBox.Show("Error saving data.");
                    }

                }
                else
                {
                    MessageBox.Show("The OTP entered is incorrect. Please try again.", "Incorrect OTP");

                    // Focus on the otp_txt textbox to allow for immediate input
                    otp_txt.Focus();

                    // Clear any existing text in the otp_txt textbox
                    otp_txt.Text = "";

                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Call the helper method to animate the transition between the current form and the new instance of the Front form
            fun.AnimateFormTransition(this, new Login());
        }




    }
}
