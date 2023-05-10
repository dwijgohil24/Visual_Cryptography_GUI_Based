using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_cp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // I will write something over here.
            //now when this button will be clicked the xorImage function will be called which will take two images do xor of them and display as third image.

            Bitmap copyBitmap1 = new Bitmap((Bitmap)pictureBox1.Image);
            Bitmap copyBitmap2 = new Bitmap((Bitmap)pictureBox2.Image);
            Bitmap xorImg = new Bitmap(copyBitmap1.Width, copyBitmap1.Height);

            xorImage(copyBitmap1, copyBitmap2, xorImg);

            pictureBox3.Image = xorImg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFile.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(openFile.FileName);
            }
        }

        public bool xorImage(Bitmap bmp1, Bitmap bmp2, Bitmap xorImg)
        {
            for (int i = 0; i < bmp1.Width; i++)
            {
                for (int j = 0; j < bmp1.Height; j++)
                {
                    //the pixel that we got store it into color variable both for image -1 and image - 2.
                    Color bmpcolor1 = bmp1.GetPixel(i, j);
                    Color bmpcolor2 = bmp2.GetPixel(i, j);

                    //now extract all the colors from image1.
                    int red1 = bmpcolor1.R;
                    int green1 = bmpcolor1.G;
                    int blue1 = bmpcolor1.B;

                    //now extract all the colors from image2.
                    int red2 = bmpcolor2.R;
                    int green2 = bmpcolor2.G;
                    int blue2 = bmpcolor2.B;

                    //now make xor of all the color values of pixel.
                    int red = red1 ^ red2;
                    int green = green1 ^ green2;
                    int blue = blue1 ^ blue2;

                    //now set the pixel in resultant image with xored values.

                    xorImg.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap1 = new Bitmap((Bitmap)pictureBox1.Image);
            Bitmap xorImg = new Bitmap((Bitmap)pictureBox3.Image);
            Bitmap orgImg = new Bitmap(copyBitmap1.Width, copyBitmap1.Height);

            xorImage(copyBitmap1, xorImg, orgImg);

            pictureBox4.Image = orgImg;
        }
    }
}
