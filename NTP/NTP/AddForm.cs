using System;
using System.ComponentModel;
using System.Windows.Forms;
using Model;

namespace NTP
{
    public partial class AddForm : Form
    {
        public BindingList<Fitness> lst;

        public AddForm(BindingList<Fitness> lst)
        {
            InitializeComponent();
            this.lst = lst;
        }

        //добавить
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int first;
                double second;
                bool result = Int32.TryParse(textBox1.Text, out first);
                if (!result || first <= 0)
                {
                    throw new Exception("Вы ввели некорректное значение для первого поля");
                }
                else
                {
                    result = double.TryParse(textBox2.Text.Replace(".", ","), out second);
                    if (!result || second < 0)
                    {
                        throw new Exception("Вы ввели некорректное значение для второго поля");
                    }
                    else
                    {
                        if (radioButton1.Checked)
                        {
                            lst.Add(new Run(first, second));
                        }
                        else if (radioButton2.Checked)
                        {
                            lst.Add(new Swim(first - 1, second));
                        }
                        else
                        {
                            lst.Add(new Press(first, second));
                        }
                        Close();
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

        //бег
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label1.Text = "Интенсивность (1-10):";
                label2.Text = "Расстояние:";
            }
        }

        //плавание
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label1.Text = "Стиль плавания (1-4):";
                label2.Text = "Расстояние:";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                label1.Text = "Кол-во повторов:";
                label2.Text = "Вес штанги:";
            }
        }
    }
}