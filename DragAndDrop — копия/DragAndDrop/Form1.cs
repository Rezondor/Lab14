
using System;
using System.IO;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace DragAndDrop
{
    public partial class Form1 : Form

    {
       
        public Form1()
        {
            InitializeComponent();
           
        }

       

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.DoDragDrop(sender, DragDropEffects.Move);
            
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.Label", false))
            {
                var label = (Label)e.Data.GetData("System.Windows.Forms.Label");
                textBox1.Text=label.Text;
                label.Text = "";
            }
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (textBox1.Text != "")
            {
                e.Effect = DragDropEffects.None;

            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {

            label2.DoDragDrop(sender, DragDropEffects.Move);
            
        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            if (textBox2.Text != "")
            {
                e.Effect = DragDropEffects.None;
                
            }
            else
            {
                if (e.Data.GetDataPresent("System.Windows.Forms.Label", false))
                {
                    var label = (Label)e.Data.GetData("System.Windows.Forms.Label");
                    textBox2.Text = label.Text;
                    label.Text = "";

                }
            }
        }

        private void textBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (textBox2.Text != "")
            {
                e.Effect = DragDropEffects.None;
                
            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void textBox3_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.Label", false))
            {
                var label = (Label)e.Data.GetData("System.Windows.Forms.Label");
                textBox3.Text = label.Text;
                label.Text = "";
            }
            if (e.Data.GetDataPresent("System.Windows.Forms.TextBox", false))
            {
                var TextBox = (TextBox)e.Data.GetData("System.Windows.Forms.TextBox");
                textBox3.Text = TextBox.Text;
                TextBox.Text = "";
            }

        }

        private void textBox3_DragEnter(object sender, DragEventArgs e)
        {
            if (textBox3.Text != "")
            {
                e.Effect = DragDropEffects.None;

            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void textBox4_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.Label", false))
            {
                var label = (Label)e.Data.GetData("System.Windows.Forms.Label");
                textBox4.Text = label.Text;
                label.Text = "";
            }
        }

        private void textBox4_DragEnter(object sender, DragEventArgs e)
        {
            if (textBox4.Text != "")
            {
                e.Effect = DragDropEffects.None;

            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            label3.DoDragDrop(sender, DragDropEffects.Move);
            
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            label4.DoDragDrop(sender, DragDropEffects.Move);
            
        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent("System.Windows.Forms.Label", false))
            {

                var label = (Label)e.Data.GetData("System.Windows.Forms.Label");
                
                label.Location = new Point(e.X, e.Y);

            }
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
