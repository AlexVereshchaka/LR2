using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB22
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		Bitmap b;
		private void button3_Click(object sender, EventArgs e)
		{
			Color c, newC;
			int newR, newG, newB;
			double r = Convert.ToDouble(textBox3.Text);
			double u = Convert.ToDouble(textBox4.Text);

			for (int x = 0; x < b.Width; x++)
			{
				for (int y = 0; y < b.Height; y++)
				{
					c = b.GetPixel(x, y);
					newR = (int)(r * Math.Pow(c.R, u));
					newG = (int)(r * Math.Pow(c.G, u));
					newB = (int)(r * Math.Pow(c.B, u));
					if (newR > 255) newR = 255;
					if (newR<0) newR = 0;
					if (newG >255) newG = 255;
					if (newG<0) newG = 0;
					if (newB > 255) newB = 255;
					if (newB<0) newB = 0;
					newC = Color.FromArgb(255, newR, newG, newB);
					b.SetPixel(x, y, newC);
				}
			}
			pictureBox1.Image = b;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			// Устанавливаем свойства для OpenFileDialog
			openFileDialog1.InitialDirectory = "C:\\";
			openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 2;
			openFileDialog1.RestoreDirectory = true;

			// Отображаем диалоговое окно выбора файла
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				// Получаем выбранный путь к файлу
				string filePath = openFileDialog1.FileName;

				// Выводим путь к файлу в текстовое поле на форме
				textBox1.Text = filePath;
				b = new Bitmap(Image.FromFile(textBox1.Text));
				pictureBox1.Image = b;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Color c, newC;
			double I;
			double n = 0, procent;
			int newR, newG, newB;
			double k = Convert.ToDouble(textBox2.Text);
			for (int x = 0; x < b.Width - 0; x++)
			{
				for (int y = 0; y < b.Height - 0; y++)
				{
					c = b.GetPixel(x, y);
					I = (c.R + c.G + c.B) / 3;
					I = I * k;
					if (I > 255)
					{
						I = 255;
						n++;
					}
					if (I < 0)
					{
						I = 0;
						n++;
					}
					newC = Color.FromArgb(255, (int)I, (int)I, (int)I);
					b.SetPixel(x, y, newC);
				}
			}
			procent = n / (double)(b.Width * b.Height);
			MessageBox.Show(" Витратили " + n.ToString() + " пікселів, це " + procent + " % ");
			pictureBox1.Image = b;
		}
	}
	}

