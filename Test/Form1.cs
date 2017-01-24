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
            Loadd();
            max = Spisok.Count;
            

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
        private void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("question.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Spisok);
            }
        }

        private void Loadd()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("question.dat", FileMode.OpenOrCreate))
            {
                Spisok = (List<Question>)formatter.Deserialize(fs);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Spisok.Count == 0)
            {
                MessageBox.Show("Вопросов нет!");
                return;
            }
            else
            {
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
            Form4 fr4 = new Test.Form4();
            fr4.Show();
            Hide();
        }
    }
}
