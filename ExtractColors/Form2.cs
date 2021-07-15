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

            IOrderedEnumerable<List<Color>> orderedGroups = groups.OrderBy(x => x.Count);



            int primeArgR = 0;
            int primeSumR = 0;
            foreach (Color color in filteredColors)
            {
                primeSumR += color.R;
            }
            primeArgR = primeSumR / filteredColors.Count();


            int primeArgG = 0;
            int primeSumG = 0;
            foreach (Color color in filteredColors)
            {
                primeSumG += color.G;
            }
            primeArgG = primeSumG / filteredColors.Count();


            int primeArgB = 0;
            int primeSumB = 0;
            foreach (Color color in filteredColors)
            {
                primeSumB += color.B;
            }
            primeArgB = primeSumB / filteredColors.Count();

            Color prime = Color.FromArgb(primeArgR, primeArgG, primeArgB);

            
            pictureBox2.BackColor = Color.FromArgb(primeArgR, primeArgG, primeArgB);


            
            int[] oldRGB = new int[3];
            oldRGB[0] = primeArgR;
            oldRGB[1] = primeArgG;
            oldRGB[2] = primeArgB;


            int[] newRGB = new int[3];

            int counter = 0;
            for (int x = 0; x < 3; x++)
            {
                newRGB[x] = 255 - oldRGB[x];
                if ((newRGB[x] - oldRGB[x] < 10 && newRGB[x] - oldRGB[x] > 0) || (oldRGB[x] - newRGB[x] < 10 && oldRGB[x] - newRGB[x] > 0))
                {
                    if (oldRGB[x] <= 128)
                    {
                        counter++;
                    }
                    else
                    {
                        counter--;
                    }
                }
            }
            if (counter == 3)
            {
                pictureBox3.BackColor = Color.FromArgb(250, 250, 250);
            }
            else if (counter == -3)
            {
                pictureBox3.BackColor = Color.FromArgb(5, 5, 5);
            }
            else
            {
                
                pictureBox3.BackColor = Color.FromArgb(newRGB[0], newRGB[1], newRGB[2]);
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
