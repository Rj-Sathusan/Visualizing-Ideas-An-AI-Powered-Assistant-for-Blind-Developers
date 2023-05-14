using ComponentFactory.Krypton.Toolkit;
using System;

namespace IdeaGen
{
    public partial class Front : KryptonForm  
    {
        DAL.function_ fun = new DAL.function_();

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
            

            // Call the helper method to animate the transition between the current form and the new instance of the Front form
            fun.AnimateFormTransition(this, new Sign_Up());
        }


    }
}
