﻿using System;
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
        public static string l1;
        public static string l2;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(pictureBox1.Image);
                for(int i=0;i<Width;i++)
            {
                for(int j=0;j<Height;j++)
                {
                    Color colorOfPixel = img.GetPixel(i, j);
                }
            }
        }
    }
}