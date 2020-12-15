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
        bool tb1, tb2, tb1c, tb2c;
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
            if (e.Button == MouseButtons.Left )
            {
                if (Control.ModifierKeys == Keys.Control) tb1c = true;
                if (Control.ModifierKeys == Keys.None) tb1 = true;
                DoDragDrop(textBox1.Text, DragDropEffects.Copy);
                

            }
            if (e.Button == MouseButtons.Right) 
            {
                if (Control.ModifierKeys == Keys.Control) tb2c = true;
                if (Control.ModifierKeys == Keys.None) tb2 = true;
                DoDragDrop(textBox1.Text, DragDropEffects.Copy);
                
            }
            
        }


        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            ListBox l = (ListBox)sender;


            if ((l!=listBox1 && lb1)||(l != listBox2 && lb2)||tb1||tb2||tb1c||tb2c)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else e.Effect = DragDropEffects.None;

        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            ListBox l = (ListBox)sender;
            string[] lst;
            if (e.Data.GetDataPresent(typeof(object[])) && (lb1 || lb2))
            {
                object [] a = (object[])e.Data.GetData(typeof(object[]));
                if (lb1 && l != listBox1)
                {
                    for (int i = 0; i < a.Length; i++) 
                    {
                        listBox1.Items.Remove((string)a[i]);
                        l.Items.Add((string)a[i]);
                    }
                   
                    label4.Text = "Вы скопировали элементы из 1 списка во 2 список";
                    lb1 = false;
                }
                if (lb2 && l != listBox2)
                {

                    for (int i = 0; i < a.Length; i++)
                    {
                        listBox2.Items.Remove((string)a[i]);
                        l.Items.Add((string)a[i]);
                    }

                    label4.Text = "Вы скопировали элементы из 2 списка во 1 список";
                    lb2 = false;
                }
            }
            if (e.Data.GetDataPresent(DataFormats.Text) && (lb1||lb2)) 
            {
                if (lb1 && l != listBox1)
                {   
                    listBox1.Items.Remove(e.Data.GetData(DataFormats.Text));
                    l.Items.Add(e.Data.GetData(DataFormats.Text));

                    label4.Text = "Вы скопировали элемент из 1 списка во 2 список";
                    lb1 = false;
                }
                if (lb2 && l != listBox2)
                {
                    listBox2.Items.Remove(e.Data.GetData(DataFormats.Text));
                    l.Items.Add(e.Data.GetData(DataFormats.Text));

                    label4.Text = "Вы скопировали элемент из 2 списка во 1 список";
                    lb2 = false;
                }
            }
            if (tb1) 
            { 
                lst = new string[l.Items.Count];
                for(int i = 0; i < l.Items.Count; i++) 
                {
                    lst[i] = l.Items[i].ToString();
                }
                l.Items.Clear();
                l.Items.Add(e.Data.GetData(DataFormats.Text));
                l.Items.AddRange(lst);
                textBox1.Text = "";
                label4.Text = "Вы перенесли текст из TextBox-a в начало списка";
                tb1 = false;
            }
            if (tb2) 
            {
                l.Items.Add(e.Data.GetData(DataFormats.Text));
                textBox1.Text = "";
                label4.Text = "Вы перенесли текст из TextBox-a во конец списка";
                tb2 = false;
            }
            if (tb1c)
            {
                lst = new string[l.Items.Count];
                for (int i = 0; i < l.Items.Count; i++)
                {
                    lst[i] = l.Items[i].ToString();
                }
                l.Items.Clear();
                l.Items.Add(e.Data.GetData(DataFormats.Text));
                l.Items.AddRange(lst);
                label4.Text = "Вы скопировали текст из TextBox-a в начало списка";
                tb1c = false;
            }
            if (tb2c)
            {
                l.Items.Add(e.Data.GetData(DataFormats.Text));
                label4.Text = "Вы скопировали текст из TextBox-a в конец списка";
                tb2 = false;
            }
        }
        private void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox l = (ListBox)sender;
            if (e.Button == MouseButtons.Left && l.SelectedIndex != -1)
            {   

                if (l == listBox1) lb1 = true;
                if (l == listBox2) lb2 = true;
                if (l.SelectedItems.Count > 1)
                {
                    
                    object[] o = new object [l.SelectedItems.Count];
                    for (int i = 0;i < l.SelectedItems.Count; i++) { o[i] = l.SelectedItems[i]; }
                    DoDragDrop(o, DragDropEffects.Copy);
                }
                else 
                {
                    DoDragDrop(l.SelectedItem, DragDropEffects.Copy);
                }

            }

        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (lb1||lb2)
            { 
                e.Effect = DragDropEffects.Copy;
            }
            else e.Effect = DragDropEffects.None;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lb1 = false;
            lb2 = false;
            tb1 = false;
            tb2 = false;
            tb1c = false;
            tb2c = false;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
        
            if (e.Data.GetDataPresent(typeof(object[])) && (lb1 || lb2))
            {
                object[] a = (object[])e.Data.GetData(typeof(object[]));
                if (lb1)
                {
                    if (e.Data.GetDataPresent(typeof(object[])))
                    {
                        

                        for (int i = 0; i < a.Length; i++)
                        {
                            listBox1.Items.Add((string)a[i]);
                        }

                        label4.Text = "Вы продублировали в конец 1 списка выделенные строки";
                        lb1 = false;
                    }
                }
                if (lb2)
                {
                    if (e.Data.GetDataPresent(typeof(object[])))
                    {


                        for (int i = 0; i < a.Length; i++)
                        {
                            listBox2.Items.Remove((string)a[i]);
                        }

                        label4.Text = "Вы удалили выделенные элементы из 2 списка";
                        lb2 = false;
                    }
                }
            }
            if (e.Data.GetDataPresent(DataFormats.Text) && (lb1 || lb2))
            {
                if (lb1)
                {
                   
                    listBox1.Items.Add(e.Data.GetData(DataFormats.Text));
                    label4.Text = "Вы скопировали выделенный элемент в конец 1 списка";
                    lb1 = false;
                    
                   
                }
                if (lb2)
                {

                    listBox2.Items.Remove(e.Data.GetData(DataFormats.Text));
                    label4.Text = "Вы удалили выделенный элемент из 2 списка";
                    lb2 = false;


                }

            }
        }
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (lb1 || lb2)
            {
                string t;
                if (lb1) 
                {
                    t = textBox1.Text;
                    textBox1.Text = listBox1.Items[0].ToString();
                    listBox1.Items[0] = t;
                    label4.Text = "Вы обменяли первый элемент 1 списка на текст из TextBox-а";
                    lb1 = false;
                }
                if (lb2)
                {
                    t = textBox1.Text;
                    textBox1.Text = listBox2.Items[0].ToString();
                    listBox2.Items[0] = t;
                    label4.Text = "Вы обменяли первый элемент 2 списка на текст из TextBox-а";
                    lb2 = false;
                }

            }
        }

        private void listBox2_MouseUp(object sender, MouseEventArgs e)
        {
            lb1 = false;
            lb2 = false;
            tb1 = false;
            tb2 = false;
            tb1c = false;
            tb2c = false;
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if ((lb1 || lb2) && textBox1.TextLength != 0)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else e.Effect = DragDropEffects.None;
        }
    }
}
