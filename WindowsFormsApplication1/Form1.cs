using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string res = "";
        int[,] Mat = new int[100, 100];
        string[,] b = new string[100, 100];

        private void Form1_Load(object sender, EventArgs e)
        {
            Random R = new Random();
            dataGridView1.RowCount = 4;
            dataGridView1.ColumnCount = 4;

            for (int i = 0; i < 4; i++)
            {
                dataGridView1.Columns[i].HeaderText = Convert.ToString(i + 1);
            }

            for (int j = 0; j < 4; j++)
            {
                dataGridView1.Rows[j].HeaderCell.Value = Convert.ToString(j + 1);
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j == 0)
                    {
                        Mat[j, i] = 7;
                    }
                    else
                    {
                        Mat[j, i] = R.Next(0, 8);
                    }
                    prov(Mat[j, i]);

                    b[j, i] = res;
                    dataGridView1.Rows[j].Cells[i].Value = b[j, i];
                }
            }
        }

        private string prov(int c)
        {
            res = "";
            string bit = Convert.ToString(c, 2);
            while (bit.Length < 3)
                bit = bit.Insert(0, "0");
            if (c == 0)
                res += "Полный запрет ";
            if (c == 7)
                res += "Полный доступ";
            else
            {
                if (bit[0] == '1')
                    res += "Передача прав ";
                if (bit[1] == '1')
                    res += "Запись ";
                if (bit[2] == '1')
                    res += "Чтение ";
            }
            return res;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            button5.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int f = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Неверное значение пользователя");
                textBox1.Text = "1";
            }
            finally
            {
                int f = Convert.ToInt32(textBox1.Text);
                if ((f <= 4) && (f > 0))
                {
                    textBox1.Enabled = false;
                    button5.Visible = false;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox3.Visible = true;
                }
                else
                {
                    MessageBox.Show("Неверное значение пользователя");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int f = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Неверное значение обьекта");
                textBox2.Text = "1";
            }
            finally
            {
                int i = Convert.ToInt32(textBox2.Text) - 1;
                int j = Convert.ToInt32(textBox1.Text) - 1;
                string num = Convert.ToString(Mat[j, i], 2);
                string format = num.PadLeft(3, '0');
                char[] chars = format.ToCharArray();
                if (chars[2] == '1')
                    MessageBox.Show("Чтение успешно");
                else
                    MessageBox.Show("Чтение запрещено");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int f = Convert.ToInt32(textBox3.Text);
            }
            catch
            {
                MessageBox.Show("Неверное значение пользователя");
                textBox3.Text = "1";
            }
            finally
            {
                int i = Convert.ToInt32(textBox3.Text) - 1;
                int j = Convert.ToInt32(textBox1.Text) - 1;
                string num = Convert.ToString(Mat[j, i], 2);
                string format = num.PadLeft(3, '0');
                char[] chars = format.ToCharArray();
                if (chars[1] == '1')
                    MessageBox.Show("Запись успешна");
                else
                    MessageBox.Show("Запись запрещена");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int f = Convert.ToInt32(textBox4.Text);
                int d = Convert.ToInt32(textBox5.Text);
            }
            catch
            {
                MessageBox.Show("Неверное значение");
                textBox4.Text = "1";
                textBox5.Text = "1";
            }
            finally
            {
            bool a = false;
            int i = Convert.ToInt32(textBox5.Text) - 1;
            int j = Convert.ToInt32(textBox1.Text) - 1;
            string num = Convert.ToString(Mat[j, i], 2);
            string format = num.PadLeft(3, '0');
            char[] chars = format.ToCharArray();
            if (chars[0] == '1')
            {
                int q = Convert.ToInt32(textBox4.Text) - 1;
                int w = Convert.ToInt32(textBox5.Text) - 1;
                string number = Convert.ToString(Mat[q, w], 2);
                string formatt = number.PadLeft(3, '0');
                char[] charss = formatt.ToCharArray();
                    if (checkBox3.Checked == true && checkBox1.Checked == true)
                    {
                        if (chars[0] == '1' && chars[2] == '1')
                        {
                            charss[0] = '1';
                            charss[2] = '1';
                            formatt = new string(charss);
                            formatt = Convert.ToString(Convert.ToInt32(formatt, 2), 10);
                            Mat[q, w] = Convert.ToInt32(formatt);
                            prov(Mat[q, w]);

                            b[q, w] = res;
                            dataGridView1.Rows[q].Cells[w].Value = b[q, w];

                        }
                        else
                        {
                            a = true;
                            MessageBox.Show("Действие невозможно");
                        }
                    }
                    
                    if (checkBox3.Checked == true && checkBox2.Checked == true && a == false)
                    {
                        if (chars[0] == '1' && chars[1] == '1')
                        {
                            charss[0] = '1';
                            charss[1] = '1';
                            formatt = new string(charss);
                            formatt = Convert.ToString(Convert.ToInt32(formatt, 2), 10);
                            Mat[q, w] = Convert.ToInt32(formatt);
                            prov(Mat[q, w]);

                            b[q, w] = res;
                            dataGridView1.Rows[q].Cells[w].Value = b[q, w];
                        }
                        else
                        {
                            a = true;
                            MessageBox.Show("Действие невозможно");
                        }

                    }
                    if (checkBox2.Checked == true && checkBox1.Checked == true && a == false)
                    {
                        if (chars[1] == '1' && chars[2] == '1')
                        {
                            charss[1] = '1';
                            charss[2] = '1';
                            formatt = new string(charss);
                            formatt = Convert.ToString(Convert.ToInt32(formatt, 2), 10);
                            Mat[q, w] = Convert.ToInt32(formatt);
                            prov(Mat[q, w]);

                            b[q, w] = res;
                            dataGridView1.Rows[q].Cells[w].Value = b[q, w];
                        }
                        else
                        {
                            a = true;
                            MessageBox.Show("Действие невозможно");
                        }
                    }
                    if (checkBox3.Checked == true && a == false)
                {
                        if (chars[0] == '1')
                        {
                            charss[0] = '1';
                            formatt = new string(charss);
                            formatt = Convert.ToString(Convert.ToInt32(formatt, 2), 10);
                            Mat[q, w] = Convert.ToInt32(formatt);
                            prov(Mat[q, w]);

                            b[q, w] = res;
                            dataGridView1.Rows[q].Cells[w].Value = b[q, w];
                        }
                }
                if (checkBox2.Checked == true && a == false)
                {
                    if (chars[1] == '1')
                    {
                        charss[1] = '1';
                        formatt = new string(charss);
                        formatt = Convert.ToString(Convert.ToInt32(formatt, 2), 10);
                        Mat[q, w] = Convert.ToInt32(formatt);
                        prov(Mat[q, w]);

                        b[q, w] = res;
                        dataGridView1.Rows[q].Cells[w].Value = b[q, w];
                    }
                    else MessageBox.Show("Действие Запись невозможно");
                }

                if (checkBox1.Checked == true && a == false)
                {
                    if (chars[2] == '1')
                    {
                        charss[2] = '1';
                        formatt = new string(charss);
                        formatt = Convert.ToString(Convert.ToInt32(formatt, 2), 10);
                        Mat[q, w] = Convert.ToInt32(formatt);
                        prov(Mat[q, w]);

                        b[q, w] = res;
                        dataGridView1.Rows[q].Cells[w].Value = b[q, w];
                    }
                    else MessageBox.Show("Действие Чтение невозможно");
                }
                
            }
            else MessageBox.Show("Нет прав");
        }
    }
    }
}
