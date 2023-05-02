using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaGen
{
    public partial class Login : KryptonForm
    {
        public Login()
        {
            InitializeComponent();
        }
        //private void Front_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    // Animate the current form to slide out to the right
        //    WinAPI.AnimateWindow(this.Handle, 500, WinAPI.AW_SLIDE | WinAPI.AW_HOR_POSITIVE);

        //    // Hide the current form
        //    this.Hide();

        //    // Animate the other form to slide in from the left
        //    WinAPI.AnimateWindow(Form1.ActiveForm.Handle, 500, WinAPI.AW_SLIDE | WinAPI.AW_HOR_NEGATIVE);

        //    // Show the other form
        //    Form1.ActiveForm.Show();
        //}



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

        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            string s_name = "Krypton_Toolkit_Demo_Official";
            string s_mail = "Krypton_Toolkit_Demo";
            string r_mail = "www.rjsathusan@gmail.com";
            string sub = "Verification Mail";
            string msg = "Test";

            await Mail(s_name, s_mail, r_mail, sub, msg);

            // Create an instance of the other form
            Knowdlage frontForm = new Knowdlage();

            // Animate the current form to slide out to the left
            WinAPI.AnimateWindow(this.Handle, 300, WinAPI.AW_SLIDE | WinAPI.AW_HOR_NEGATIVE);

            // Hide the current form
            this.Hide();


            // Animate the other form to slide in from the right
            WinAPI.AnimateWindow(frontForm.Handle, 300, WinAPI.AW_SLIDE | WinAPI.AW_HOR_POSITIVE);

            // Show the other form
            frontForm.Show(); ;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string userInput = Microsoft.VisualBasic.Interaction.InputBox("Please enter your name:", "User Name", "");

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


    }
}
