using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReadWord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                richTextBox1.Text = "";
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    richTextBox1.Text += ReadWord.ReadWordLib.readWordTable(textBox1.Text, (int)numericUpDown1.Value, (int)numericUpDown2.Value) + "\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        List<objXY> modelOne()
        {
            List<objXY> tmp = new List<objXY>();

            objXY obj00 = new objXY(0, 0);
            tmp.Add(obj00);

            //1-5行，5行，2列
            for (int i = 1; i <= 5; i++)
            {
                //列
                for (int j = 1; j <= 2; j++)
                {
                    objXY objij = new objXY(i, j);
                    tmp.Add(objij);
                }
            }

            //第6行，2行，6列
            for (int m = 6; m <= 7; m++)
            {
                //列
                for (int n = 1; n <= 6; n++)
                {
                    objXY objmn = new objXY(m, n);
                    tmp.Add(objmn);
                }
            }



            return tmp;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    var toGet = modelOne();
                    var tmpGetdic = ReadWord.ReadWordLib.readWordTable(textBox1.Text, toGet);
                    foreach (var item in tmpGetdic)
                    {
                        richTextBox1.Text += item.Key.rowIndex + "," + item.Key.colIndex + ":" + item.Value + "\r\n";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
