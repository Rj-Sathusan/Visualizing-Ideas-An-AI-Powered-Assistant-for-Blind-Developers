using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.RegularExpressions;


namespace Krypton_Toolkit_Demo
{
    public partial class Sign_Up : KryptonForm
    {
       
        private int expectedOTP;

        BE.User User;

        DAL.function_ fun = new DAL.function_();
        DAL.NewDataAccessLayer Ndal = new DAL.NewDataAccessLayer();



        public Sign_Up()
        {
            InitializeComponent();
        }
       

        public int GenerateRandomNumber()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1000, 9999);
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

        public static async Task Mail(string s_name, string s_mail, string r_mail, string sub, string msg)
        {
            string url = "https://cntreon.000webhostapp.com/";
            var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("sender_name", s_name),
            new KeyValuePair<string, string>("sender_email", s_mail + "@gmail.com"),
            new KeyValuePair<string, string>("receiver_email", r_mail),
            new KeyValuePair<string, string>("subject", sub),
            new KeyValuePair<string, string>("message", msg)
        });

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, content);

                Console.WriteLine(response.StatusCode);
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }



        

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Create an instance of the other form
            Front frontForm = new Front();

            // Animate the current form to slide out to the left
            WinAPI.AnimateWindow(this.Handle, 300, WinAPI.AW_SLIDE | WinAPI.AW_HOR_POSITIVE);

            // Hide the current form
            this.Hide();


            // Animate the other form to slide in from the right
            WinAPI.AnimateWindow(frontForm.Handle, 300, WinAPI.AW_SLIDE | WinAPI.AW_HOR_NEGATIVE);

            // Show the other form
            frontForm.Show();
        }

        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {

                otp_txt.Visible = true;
                int randomNumber = GenerateRandomNumber();

                string s_name = "IdeaGen_Official";
                string s_mail = "IdeaGen";
                string r_mail = gmail_txt.Text;
                string sub = "Verification Code for Your Account";
                string msg = "Dear User,\n\nPlease use the following verification code to complete your account registration: " + randomNumber + "\n\nThank you,\nThe Team";
                await Mail(s_name, s_mail, r_mail, sub, msg);

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

                    // Create a new instance of the User class
                    BE.User user = new BE.User();

                    // Set the properties of the user object using the values entered in the form
                    user.ID = 0;
                    user.USER_NAME = user_name_txt.Text;
                    user.YOUR_NAME = your_name_txt.Text;
                    user.GMAIL = gmail_txt.Text;
                    user.PASSWORD = password_txt.Text;

                    // Call the SaveUser method to save the user data to the database
                    bool result = user.SaveUser();

                    // Display a message to the user based on the result of the SaveUser method
                    if (result)
                    {
                        // Animate the current form to slide out to the left
                        WinAPI.AnimateWindow(this.Handle, 300, WinAPI.AW_SLIDE | WinAPI.AW_HOR_NEGATIVE);

                        // Hide the current form
                        this.Hide();

                        // Animate the other form to slide in from the right
                        WinAPI.AnimateWindow(frontForm.Handle, 300, WinAPI.AW_SLIDE | WinAPI.AW_HOR_POSITIVE);

                        // Show the other form
                        frontForm.Show();

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



       
    }
}
