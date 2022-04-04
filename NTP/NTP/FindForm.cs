using System;
using System.ComponentModel;
using System.Windows.Forms;
using Model;

namespace NTP
{
    public partial class FindForm : Form
    {
        public BindingList<Fitness> lst;

        public FindForm(BindingList<Fitness> lst)
        {
            InitializeComponent();
            this.lst = lst;
        }

        //поиск
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                //по 1-му полю
                if (radioButton1.Checked)
                {
                    int first = Int32.Parse(textBox1.Text);
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (first == lst[i].P1)
                        {
                            listBox1.Items.Add(lst[i].toStr());
                        }
                    }
                }
                //по второму
                else if (radioButton2.Checked)
                {
                    double second = double.Parse(textBox2.Text.Replace(".", ","));
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (Math.Abs(second - lst[i].P2) <= 0.001)
                        {
                            listBox1.Items.Add(lst[i].toStr());
                        }
                    }
                }
                else
                {
                    //по обеим полям
                    int first = Int32.Parse(textBox1.Text);
                    double second = double.Parse(textBox2.Text.Replace(".", ","));
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (first == lst[i].P1 && Math.Abs(second - lst[i].P2) <= 0.001)
                        {
                            listBox1.Items.Add(lst[i].toStr());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //закрыть
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}