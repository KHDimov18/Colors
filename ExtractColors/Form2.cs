using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtractColors
{
    public partial class Form2 : Form
    {
        public Form2(Image pic1)
        {
            InitializeComponent();




            pictureBox1.Image = pic1;



            Bitmap img = new Bitmap(pictureBox1.Image);



            int width = img.Width;
            int height = img.Height;

            List<Color> allImageColors = new List<Color>();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color pixel = img.GetPixel(x, y);
                    allImageColors.Add(pixel);

                }
            }

            float avgSaturation = allImageColors.Average(x => x.GetSaturation());

            List<Color> filteredColors = allImageColors.Where(x => x.GetSaturation() > avgSaturation).ToList();



            List<List<Color>> groups = new List<List<Color>>();

            foreach (Color pixel in filteredColors)
            {
                List<Color> group = new List<Color>();
                group.Add(pixel);

                List<Color> similarColors = filteredColors.Where(newPixel => checking(pixel, newPixel)).ToList();
                group.AddRange(similarColors);

                groups.Add(group);

            }



        }


        private static bool checking(Color pixel, Color newPixel)
        {
            if ((10 < (pixel.R - newPixel.R) && 10 < (pixel.G + newPixel.G) && 10 < (pixel.B + newPixel.B)) || (10 < (newPixel.R - pixel.R) && 10 < (newPixel.G - pixel.G) && 10 < (newPixel.B - pixel.B)))
            {
                return true;
            }
            return false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Form1 frm1 = new Form1(pictureBox1.Image);
            frm1.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
