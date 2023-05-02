using ComponentFactory.Krypton.Toolkit;
using System;

namespace IdeaGen
{
    public partial class Front : KryptonForm
    {
        public Front()
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Create an instance of the other form
            Sign_Up frontForm = new Sign_Up();

            // Animate the current form to slide out to the left
            WinAPI.AnimateWindow(this.Handle, 300, WinAPI.AW_SLIDE | WinAPI.AW_HOR_POSITIVE);

            // Hide the current form
            this.Hide();


            // Animate the other form to slide in from the right
            WinAPI.AnimateWindow(frontForm.Handle, 300, WinAPI.AW_SLIDE | WinAPI.AW_HOR_NEGATIVE);

            // Show the other form
            frontForm.Show();
        }


    }
}
