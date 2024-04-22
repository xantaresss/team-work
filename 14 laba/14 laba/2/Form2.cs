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
using System.Data.SqlClient;
using System.Reflection.Emit;




namespace _14_laba._2
{
    public partial class Form2 : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private bool newRawAdding = false;

        public Form2()
        {


            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Delete] FROM Users", sqlConnection);

                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "Users");

                dataGridView1.DataSource = dataSet.Tables["Users"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView1[5, i] = linkCell;

                }

            }

            catch (Exception ex)
            {
                //Появление ошибки
                MessageBox.Show(ex.Message, "ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ReloadData()
        {
            try
            {
                
                dataSet.Tables["Users"].Clear();

                sqlDataAdapter.Fill(dataSet, "Users");

                dataGridView1.DataSource = dataSet.Tables["Users"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView1[5, i] = linkCell;

                }

            }

            catch (Exception ex)
            {
                //Появление ошибки
                MessageBox.Show(ex.Message, "ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\С#\14 laba\14 laba\14 laba\Database1.mdf"";Integrated Security=True");

            sqlConnection.Open();

            LoadData();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            //пепреводит на другой лист
            tabControl.SelectedTab = tabPage2;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPage1;
            // Очистить DataGridView2.
            dataGridView2.Rows.Clear();

            // Скопировать данные из DataGridView1 в DataGridView2.
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView2.Rows.Add(row.Cells[2].Value, row.Cells[3].Value);
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            try
            {
                if (e.ColumnIndex == 5)
                {
                    //происываем код для управления 6 колонкой(т.е как кнопкой)
                    string task = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                    if (task == "Delete")
                    {
                        //добавляем иконку удалить
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                      == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;

                            dataGridView1.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Users"].Rows[rowIndex].Delete();

                            sqlDataAdapter.Update(dataSet, "Users");
                        }
                    }


                    else if (task == "Insert")
                    { 
                        //если воодим значения кнопка Deelete меняется на insert и выполняет следующие действия
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Users"].NewRow();


                        row["number"] = dataGridView1.Rows[rowIndex].Cells["number"].Value;
                        row["name"] = dataGridView1.Rows[rowIndex].Cells["name"].Value;
                        row["price"] = dataGridView1.Rows[rowIndex].Cells["price"].Value;
                        row["remains"] = dataGridView1.Rows[rowIndex].Cells["remains"].Value;

                        if (MessageBox.Show("Добавить строку?", "Добавить", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                 == DialogResult.Yes)

                        {
                            
                            dataSet.Tables["Users"].Rows.Add(row);

                            dataSet.Tables["Users"].Rows.RemoveAt(dataSet.Tables["Users"].Rows.Count - 1);

                            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);

                            dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";

                            sqlDataAdapter.Update(dataSet, "Users");

                            newRawAdding = false;
                        }
                        ReloadData();

                    }
                    else if (task == "Update")
                    {
                        //если воодим значение в имеющую строку
                        int r = e.RowIndex;

                        dataSet.Tables["Users"].Rows[r] ["number"] = dataGridView1.Rows[r].Cells["number"].Value;
                        dataSet.Tables["Users"].Rows[r]["name"] = dataGridView1.Rows[r].Cells["name"].Value;
                        dataSet.Tables["Users"].Rows[r]["price"] = dataGridView1.Rows[r].Cells["price"].Value;
                        dataSet.Tables["Users"].Rows[r]["remains"] = dataGridView1.Rows[r].Cells["remains"].Value;

                        if (MessageBox.Show("Изменить?", "Изменить", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                 == DialogResult.Yes)
                        {
                            sqlDataAdapter.Update(dataSet, "Users");

                            dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";
                        }


                    }
                        ReloadData();
                    }
                
            }
            catch
            {
              
            }
            
        }
        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRawAdding == false)
                {
                    newRawAdding = true;

                    int lastRow = dataGridView1.Rows.Count - 2;

                    DataGridViewRow row = dataGridView1.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();


                    dataGridView1[5, lastRow] = linkCell;

                    row.Cells["Delete"].Value = "Insert";



                }
            }
            catch
            {
              
            }
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
            



            // Создаем новую строку с данными из TextBox
            
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView1, text1, text2, text3, text4);



            // Очищаем содержимое каждого TextBox
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
           
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

       

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ReloadData();

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRawAdding == false)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();


                    dataGridView1[5, rowIndex] = linkCell;

                   editingRow.Cells["Delete"].Value = "Update";
                }
            }



            catch
            {

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
      

               
                    
    