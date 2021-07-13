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
    public partial class Form1 : Form
    {
        public Form1(Image pic1)
        {
            InitializeComponent();
            pictureBox1.Image = pic1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpg files(*.jpg)|*.jpg|PNG files(*.png)|*.png All files(*.*)|*.*|";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form2 frm2 = new Form2(pictureBox1.Image);



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
                    if (p.R < 250 && p.G < 250 && p.B < 250)
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
            //frm2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
