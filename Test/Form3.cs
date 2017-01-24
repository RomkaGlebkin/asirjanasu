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
    public partial class Form3 : Form
    {
        List<Question> Spisok = new List<Question>();
        int ans = 1;
        public Form3()
        {
            InitializeComponent();
            Loadd();
        }

        void SetData(Form3 Form,Question tmp)
            {
                tmp.que = Form.textBox1.Text;
                tmp.ans1 = Form.textBox2.Text;
                tmp.ans2 = Form.textBox3.Text;
                tmp.ans3 = Form.textBox4.Text;
                tmp.ans4 = Form.textBox5.Text;
            }
        void GetData(Form3 Form, Question tmp)
            {
                Form.textBox1.Text = tmp.que;
                Form.textBox2.Text = tmp.ans1;
                Form.textBox3.Text = tmp.ans2;
                Form.textBox4.Text = tmp.ans3;
                Form.textBox5.Text = tmp.ans4;
                if (tmp.right_ans == 1)
                    Form.radioButton1.Checked = true;
                if (tmp.right_ans == 2)
                    Form.radioButton2.Checked = true;
                if (tmp.right_ans == 3)
                    Form.radioButton3.Checked = true;
                if (tmp.right_ans == 4)
                    Form.radioButton4.Checked = true;
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
            PrintList();
        }
        void PrintList()
        {
            listBox1.Items.Clear();
            foreach (var tmp in Spisok)
            {
                listBox1.Items.Add(tmp.que);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ans = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ans = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ans = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ans = 4;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if (i < 0)
                return;
            GetData(this, Spisok[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Question tmp = new Question();
            SetData(this, tmp);
            tmp.right_ans = ans;
            Spisok.Add(tmp);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            MessageBox.Show("Вопрос добавлен!");
            PrintList();
            Save();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;

            if (i < 0)
                return;
            Spisok.RemoveAt(i);
            listBox1.Items.RemoveAt(i);
            listBox1.SelectedIndex = i - 1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            MessageBox.Show("Вопрос удален!");
            Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Test.Form1();
            fr1.Show();
            Close();
        }
    }
}
