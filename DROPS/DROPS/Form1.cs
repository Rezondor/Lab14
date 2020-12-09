using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DROPS
{
    public partial class Form1 : Form
    {
        bool tb;
        bool lb1, lb2;
        bool pn;
        public Form1()
        {
            InitializeComponent();
        }
        string []str = {"Информатика","Программирование", "Геометрия", "Матанализ", "Статистика", "Функанализ", "ТФКП" };

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(str);
        }

       
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(textBox1.Text, DragDropEffects.Copy);

            }
            if (e.Button == MouseButtons.Right) { 
                DoDragDrop(textBox1, DragDropEffects.All); 
            
            }
        }
        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            listBox1.Items.Add(e.Data.GetData(DataFormats.Text));
            listBox2.Items.Remove(e.Data.GetData(DataFormats.Text));
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && listBox1.SelectedIndex != -1)
            {
                DoDragDrop(listBox1.SelectedItem, DragDropEffects.Copy);
                lb1 = true;
            }

        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text)) 
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            listBox2.Items.Add(e.Data.GetData(DataFormats.Text));
            listBox1.Items.Remove(e.Data.GetData(DataFormats.Text));
            textBox1.Text = "";
        }
        private void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && listBox2.SelectedIndex != -1)
            {
                DoDragDrop(listBox2.SelectedItem, DragDropEffects.Copy);

            }

        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text) && lb1) 
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (lb1) 
            {
                listBox1.Items.Add(e.Data.GetData(DataFormats.Text));
                lb1 = false;
            }
        }

        
    }
}
