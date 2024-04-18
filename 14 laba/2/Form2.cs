using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


                listBox1.Items.Add(row.Cells[2].Value.ToString());


              
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

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
