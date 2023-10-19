using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaGen
{
    public partial class Back_up_form : KryptonForm
    {
        DAL.function_ fun = new DAL.function_();
        private int randomNumber;
        private int expectedOTP;



        public Back_up_form()
        {
            InitializeComponent();
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

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public int GenerateRandomNumber()
        {
            Random rand = new Random();
            randomNumber = rand.Next(1000, 9999);
            return randomNumber;
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

                        // Call the helper method to animate the transition between the current form and the new instance of the Front form
                        fun.AnimateFormTransition(this, new Knowdlage());

                        MessageBox.Show("Registration completed successfully!", "Success");

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

        private void send_btn_Click(object sender, EventArgs e)
        {
           
                //send OTP and Call mail function
                otp_txt.Visible = true;
                randomNumber = GenerateRandomNumber();

                var s_name = "IdeaGen_Official";
                //s_mail = "IdeaGen";
                var r_mail = "rjsathusan@gmail.com";
                var sub = "Verification Code for Your Account";
                var msg = "Dear User,\n\nPlease use the following verification code to complete your backup verification: " + randomNumber + "\n\nThank you,\nThe Team";
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

        private void back_btn_Click(object sender, EventArgs e)
        {
            // Call the helper method to animate the transition between the current form and the new instance of the Front form
            fun.AnimateFormTransition(this, new Forgot_password_form());
        }
    }
}
