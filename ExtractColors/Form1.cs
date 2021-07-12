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
            this.Hide();
            Form2 frm2 = new Form2(pictureBox1.Image);
            Bitmap img = new Bitmap(pictureBox1.Image);
            Color[,] arrayOfColors = new Color[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    arrayOfColors[i, j] = img.GetPixel(i, j);
                }
            }
            frm2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
