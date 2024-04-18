using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace _14_laba._2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

            tabControl.SelectedTab = tabPage2;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPage1;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }
  
        

    
        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем текст из каждого TextBox
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            string text3 = textBox3.Text;
            string text4 = textBox4.Text;
            string text5 = textBox5.Text;



            // Создаем новую строку с данными из TextBox
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView1, text1, text2, text3, text4, text5);

            // Добавляем новую строку в DataGridView
            dataGridView1.Rows.Add(row);

            // Очищаем содержимое каждого TextBox
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";



            {
                dataGridView2.Rows.Add(row.Cells[2].Value, row.Cells[3].Value);
                // Добавить данные из DataGridView1 в ListBox1.

              
            }
        }
                
        

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Получить значения из первого и второго столбцов для выбранной ячейки.
            string value1 = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            string value2 = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();

            // Добавить значения в ListBox1 и ListBox2 соответственно.
            listBox1.Items.Add(value1);
            listBox2.Items.Add(value2);
        }
        
            

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Инициализировать переменную для хранения суммы.
            int sum = 0;

            // Пройтись по элементам ListBox2.
            foreach (object item in listBox2.Items)
            {
                // Проверить, является ли элемент числом.
                if (int.TryParse(item.ToString(), out int number))
                {
                    // Добавить число к сумме.
                    sum += number;
                }
            }

            // Вывести сумму в TextBox7.
            textBox7.Text = sum.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Получить индекс выбранной строки.
            int rowIndex = dataGridView1.SelectedRows[0].Index;

            // Удалить выбранную строку.
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Получить числа из TextBox13 и TextBox7.
            int number1 = int.Parse(textBox13.Text);
            int number2 = int.Parse(textBox7.Text);

            // Проверить, меньше ли число в TextBox13 числа в TextBox7.
            if (number1 < number2)
            {
                // Вывести сообщение об ошибке.
                MessageBox.Show("Число в TextBox13 должно быть больше или равно числу в TextBox7.");
            }
            else
            {
                // Вычислить разность.
                int difference = number1 - number2;

                // Вывести разность в TextBox14.
                textBox14.Text = difference.ToString();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Очистить ListBox1 и ListBox2.
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox7.Clear();
            textBox13.Clear();
            textBox14.Clear();
        }
    }
}
