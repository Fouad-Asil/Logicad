using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogiCAD
{
    public partial class Form1 : Form
    {
        int[,] b = new int[16, 6];
        int too;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            too = 0;
            pictureBox2.DoDragDrop(pictureBox2.Image, DragDropEffects.Copy);
        }

        private void pictureBox3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox3_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox3.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            b[9, 4] = too;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            too = 1;
            pictureBox1.DoDragDrop(pictureBox1.Image, DragDropEffects.Copy);
        }

        private void pictureBox4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }

        private void pictureBox4_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox4.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            b[10, 4] = too;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox3.AllowDrop = true;
            pictureBox4.AllowDrop = true;
            pictureBox5.AllowDrop = true;
            pictureBox6.AllowDrop = true;
            pictureBox7.AllowDrop = true;
            pictureBox8.AllowDrop = true;
            pictureBox9.AllowDrop = true;
        }

        private void pictureBox5_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox5.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            b[11, 4] = too;
        }

        private void pictureBox5_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }

        private void pictureBox6_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox6_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox6.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            b[12, 4] = too;
        }

        private void pictureBox7_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }

        private void pictureBox7_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox7.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            b[13, 4] = too;
        }

        private void pictureBox8_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }

        private void pictureBox8_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox8.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            b[14, 4] = too;
        }

        private void pictureBox9_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox9.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
            b[15, 4] = too;
        }

        private void pictureBox9_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // input Values 
            b[1, 5] = Convert.ToInt16(checkBox1.Checked);
            b[2, 5] = Convert.ToInt16(checkBox2.Checked);
            b[3, 5] = Convert.ToInt16(checkBox3.Checked);
            b[4, 5] = Convert.ToInt16(checkBox4.Checked);
            b[5, 5] = Convert.ToInt16(checkBox5.Checked);
            b[6, 5] = Convert.ToInt16(checkBox6.Checked);
            b[7, 5] = Convert.ToInt16(checkBox7.Checked);
            b[8, 5] = Convert.ToInt16(checkBox8.Checked);
            for (int i = 1; i <= 8; i++) // intilize last level
            {
                b[i, 0] = i; // key
                b[i, 1] = 4; // level
            }

            for (int i = 11; i <= 14; i++) // intilize 3rd level
            {
                b[i - 2, 0] = i; // key
                b[i - 2, 1] = 3; // level
                b[i - 2, 2] = b[2 * i - 21, 5]; //1st
                b[i - 2, 3] = b[2 * i - 20, 5]; //2nd
                // type in druganddrop
                if (b[i - 2, 4] == 0) //Or Opration
                {
                    int a1;
                    int c1;
                    a1 = b[i - 2, 2];
                    c1 = b[i - 2, 3];
                    if (a1 == 0 && c1 == 0)
                    {
                        b[i - 2, 5] = 0;
                    }
                    else
                    {
                        b[i - 2, 5] = 1;
                    }
                }
                if (b[i - 2, 4] == 1) //And
                {
                    int a2;
                    int c2;
                    a2 = b[i - 2, 2];
                    c2 = b[i - 2, 3];
                    if (a2 == 1 && c2 == 1)
                    {
                        b[i - 2, 5] = 1;
                    }
                    else
                    {
                        b[i - 2, 5] = 0;
                    }


                }
            }
            for (int i = 21 ; i <= 22 ; i++) //2nd level
            {
              b[i - 8, 0] = i; // key
              b[i - 8, 1] = 2; // level
              b[i - 8, 2] = b[2 * i - 33, 5]; //1st
              b[i - 8, 3] = b[2 * i - 32, 5]; //2nd
              if (b[i - 8, 4] == 0) //Or Opration
              {
                  int a1;
                  int c1;
                  a1 = b[i - 8, 2];
                  c1 = b[i - 8, 3];
                  if (a1 == 0 && c1 == 0)
                  {
                      b[i - 8, 5] = 0;
                  }
                  else
                  {
                      b[i - 8, 5] = 1;
                  }
              }
              if (b[i - 8, 4] == 1) //And
              {
                  int a2;
                  int c2;
                  a2 = b[i - 8, 2];
                  c2 = b[i - 8, 3];
                  if (a2 == 1 && c2 == 1)
                  {
                      b[i - 8, 5] = 1;
                  }
                  else
                  {
                      b[i - 8, 5] = 0;
                  }


              }
            
           }

           
            ///lstrl2
            b[15,0] = 31;
            b[15, 1] = 1;
            b[15, 2] = b[13, 5];
            b[15, 3] = b[14, 5];
            if (b[15, 4] == 0) //Or Opration
            {
                int a1;
                int c1;
                a1 = b[15, 2];
                c1 = b[15, 3];
                if (a1 == 0 && c1 == 0)
                {
                    b[15, 5] = 0;
                }
                else
                {
                    b[15, 5] = 1;
                }
            }
            if (b[15, 4] == 1) //And
            {
                int a2;
                int c2;
                a2 = b[15, 2];
                c2 = b[15, 3];
                if (a2 == 1 && c2 == 1)
                {
                    b[15, 5] = 1;
                }
                else
                {
                    b[15, 5] = 0;
                }


            }

            label1.Text = Convert.ToString(b[15, 5]);
            label2.Text = Convert.ToString(b[9, 5]);
            label3.Text = Convert.ToString(b[10, 5]);
            label4.Text = Convert.ToString(b[11, 5]);
            label5.Text = Convert.ToString(b[12, 5]);
            label6.Text = Convert.ToString(b[13, 5]);
            label7.Text = Convert.ToString(b[14, 5]);

          }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            this.Height = 770;
            var rowCount = b.GetLength(0);
            var rowLength = b.GetLength(1);

            for (int rowIndex = 0; rowIndex < rowCount; ++rowIndex)
            {
                var row = new DataGridViewRow();

                for (int columnIndex = 0; columnIndex < rowLength; ++columnIndex)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = b[rowIndex, columnIndex]
                    });
                }

                dataGridView1.Rows.Add(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        }

       
  
        
    }

   