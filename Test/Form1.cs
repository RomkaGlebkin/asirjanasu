using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Test
{
    public partial class Form1 : Form
    {
        List<Question> Spisok = new List<Question>();
        int current = 0;
        int max;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
            string[] testlist = Directory.GetFiles("..\\tests", "*.dat");
            foreach (string test in testlist)
            {
                comboBox1.Items.Add(test.Substring(9));
            }
            comboBox1.SelectedIndex = 0;


        }



        private void Calculation(int answer)
        {
            if (Spisok[current].right_ans == answer)
            {
                score++;
                MessageBox.Show("Правильный ответ!");
                //вывести сообщение что правильно ответил
            }
            else
            {
                MessageBox.Show("Ответ неверный.");
            }
            current++;
            if (current == max)
            {
                MessageBox.Show("Тест пройдет ваш результат " + score + " из " + max);
                button1.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                comboBox1.Visible = true;
                label2.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                label1.Text = "тест";
                //Вывести сообщение что все конец и счет
            }
            else
            {
                label1.Text = Spisok[current].que;
                button2.Text = Spisok[current].ans1;
                button3.Text = Spisok[current].ans2;
                button4.Text = Spisok[current].ans3;
                button5.Text = Spisok[current].ans4;
            }
        
    }
        private void Save(string name)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("..\\tests\\" + name, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Spisok);
            }
        }

        private void Loadd(string name)
        {
            
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("..\\tests\\" + name, FileMode.OpenOrCreate))
            {
                Spisok = (List<Question>)formatter.Deserialize(fs);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loadd(comboBox1.SelectedItem.ToString());
            if (Spisok.Count == 0)
            {
                MessageBox.Show("Вопросов нет!");
                return;
            }
            else
            {
                
                max = Spisok.Count;
                button6.Hide();
                current = 0;
                score = 0;
                label1.Text = Spisok[current].que;
                button2.Text = Spisok[current].ans1;
                button3.Text = Spisok[current].ans2;
                button4.Text = Spisok[current].ans3;
                button5.Text = Spisok[current].ans4;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button7.Visible = false;
                comboBox1.Visible = false;
                label2.Visible = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                Calculation(1);
            }


        private void button3_Click(object sender, EventArgs e)
        {
            Calculation(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Calculation(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Calculation(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Test.Form2();
            fr2.Show();
            Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Test.Form4(comboBox1.SelectedItem.ToString());
            fr4.Show();
            Hide();
        }
    }
}
