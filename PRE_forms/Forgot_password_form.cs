using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;

namespace IdeaGen
{
    public partial class Forgot_password_form : KryptonForm
    {
        BE.User user = new BE.User();
        DAL.function_ fun = new DAL.function_();

        public Forgot_password_form()
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

        private void kryptonButton3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            var Forgot_password = user.GetPassword(gmail_txt.Text);
            MessageBox.Show(Forgot_password);
            var s_name = "IdeaGen_Official";
            //s_mail = "IdeaGen";
            var r_mail = "rjsathusan@gmail.com";
            var sub = "Verification Code for Your Account";
            var msg = "Dear User,\n\nPlease use the following password  to complete your login \n Your password : " + Forgot_password + "\n\nThank you,\nThe Team";
            //await fun.Mail (s_name, s_mail, r_mail, sub, msg);
            fun.SendEmail(r_mail, sub, msg);



            MessageBox.Show("Please enter the verification code we sent to your email address to complete your account registration.", "Verification");

        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            // Call the helper method to animate the transition between the current form and the new instance of the Front form
            fun.AnimateFormTransition(this, new Front());
        }
    }
}
