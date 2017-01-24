using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string line;
            int i = 0;
            System.IO.StreamReader file = new System.IO.StreamReader("questions.txt");
            while ((line = file.ReadLine()) != null)
            {
                Question new_que = new Question();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == '@')
                        i++;
                    else
                    {

                        if (i == 0)
                            new_que.que += line[j];
                        if (i == 1)
                            new_que.ans1 += line[j];
                        if (i == 2)
                            new_que.ans2 += line[j];
                        if (i == 3)
                            new_que.ans3 += line[j];
                        if (i == 4)
                            new_que.ans4 += line[j];
                        if (i == 5)
                            new_que.right_ans = (int)line[j]-48;
                    }

                }
                i = 0;
                Spisok.Add(new_que);

            }
            max = Spisok.Count;
            

        }

        public class Question
        {
            public string que;
            public string ans1;
            public string ans2;
            public string ans3;
            public string ans4;
            public int right_ans;

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

        private void button1_Click(object sender, EventArgs e)
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
    }
}
