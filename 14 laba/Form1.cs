using _14_laba._2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14_laba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "1" && textBox2.Text == "1")
            {
                MessageBox.Show("Авторизация успешна!");

                Form2 form2 = new Form2();
                form2.Show();
                this.Hide(); // Скрываем Form1 при открытии Form2

            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль. Попробуйте снова.");
            }
        }
    }
}
