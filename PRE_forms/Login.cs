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
        DAL.function_ fun = new DAL.function_();
        public Login()
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

          

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Call the helper method to animate the transition between the current form and the new instance of the Front form
            fun.AnimateFormTransition(this, new Forgot_password_form());

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Call the helper method to animate the transition between the current form and the new instance of the Front form
            fun.AnimateFormTransition(this, new Sign_Up());
        }
      
        private  void login(object sender, EventArgs e)
        {
            // Call the helper method to animate the transition between the current form and the new instance of the Front form
            fun.AnimateFormTransition(this, new Knowdlage());
        }


    }
}
