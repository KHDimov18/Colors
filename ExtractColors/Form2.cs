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



            int br = 0;
            Color p;



            int[] rOfThePixel = new int[width * height + 1];
            int[] gOfThePixel = new int[width * height + 1];
            int[] bOfThePixel = new int[width * height + 1];




            int[] sortArrayForROfThePixel = new int[width * height + 1];
            int[] sortArrayForGOfThePixel = new int[width * height + 1];
            int[] sortArrayForBOfThePixel = new int[width * height + 1];




            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    p = img.GetPixel(i, j);
                    if ((p.R < 250 && (p.G < 200 || p.B < 200)) || (p.R < 200 && (p.G < 250 || p.B < 200)) || (p.R < 200 && (p.G < 200 || p.B < 250)))
                    {
                        sortArrayForROfThePixel[br] = p.R;
                        sortArrayForGOfThePixel[br] = p.G;
                        sortArrayForBOfThePixel[br] = p.B;



                        rOfThePixel[br] = p.R;
                        gOfThePixel[br] = p.G;
                        bOfThePixel[br] = p.B;
                    }



                    br++;
                }
            }


            Array.Sort(sortArrayForROfThePixel);
            Array.Sort(sortArrayForGOfThePixel);
            Array.Sort(sortArrayForBOfThePixel);


            int lastRedElement = sortArrayForROfThePixel[br];
            int lastGreenElement = sortArrayForGOfThePixel[br];
            int lastBlueElement = sortArrayForBOfThePixel[br];

            for (int i = 0; i < br; i++)
            {
                if (lastRedElement == lastGreenElement)
                {
                    lastRedElement = sortArrayForROfThePixel[br - 1];
                }

                if (lastBlueElement == lastGreenElement)
                {
                    lastGreenElement = sortArrayForGOfThePixel[br - 1];
                }

                if (lastRedElement == lastBlueElement)
                {
                    lastBlueElement = sortArrayForBOfThePixel[br - 1];
                }
            }



            var redColor = 0;
            var greenColor = 0;
            var blueColor = 0;


            for (int i = 0; i < br; i++)
            {
                if (lastRedElement == rOfThePixel[i])
                {
                    redColor = rOfThePixel[i];
                    greenColor = gOfThePixel[i];
                    blueColor = bOfThePixel[i];
                    break;
                }
            }

            label1.BackColor = Color.FromArgb(redColor, greenColor, blueColor);
            label1.ForeColor = Color.FromArgb(redColor, greenColor, blueColor);

            for (int i = 0; i < br; i++)
            {
                if (lastGreenElement == gOfThePixel[i])
                {
                    redColor = rOfThePixel[i];
                    greenColor = gOfThePixel[i];
                    blueColor = bOfThePixel[i];
                    break;
                }
            }

            label2.BackColor = Color.FromArgb(redColor, greenColor, blueColor);
            label2.ForeColor = Color.FromArgb(redColor, greenColor, blueColor);

            for (int i = 0; i < br; i++)
            {
                if (lastBlueElement == bOfThePixel[i])
                {
                    redColor = rOfThePixel[i];
                    greenColor = gOfThePixel[i];
                    blueColor = bOfThePixel[i];
                    break;
                }
            }
            label3.BackColor = Color.FromArgb(redColor, greenColor, blueColor);
            label3.ForeColor = Color.FromArgb(redColor, greenColor, blueColor);
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
