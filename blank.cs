using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class blank : Form
    {
        public bool IsSaved = false;
        private string docName = "";
        public blank()
        {
            InitializeComponent();
            sbTime.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());
            sbTime.ToolTipText = Convert.ToString(System.DateTime.Today.ToLongDateString());
            //sbTime.ToolTipText = "22222";
        }

        private void blank_Load(object sender, EventArgs e)
        { }
            private string BufferText = "";
            public string DocName { get => docName; set => docName = value; }

            public void Cut() //Вырезание текста
            {
                this.BufferText = richTextBox1.SelectedText;
                richTextBox1.SelectedText = "";
            }
            public void Copy() //Копирование текста
            {
                this.BufferText = richTextBox1.SelectedText;
            }
            public void Paste()//Вставка
            {
                richTextBox1.SelectedText = this.BufferText;
            }
            public void SelectAll()//Выделение всего текста
            {
                richTextBox1.SelectAll();
            }
            public void Delete()//Удаление
            {
                richTextBox1.SelectedText = "";
                this.BufferText = "";
            }
            public void richTextBox1_TextChanged(object sender, EventArgs e)
            {
                sbAmount.Text = "Amount of Symbols: " + richTextBox1.Text.Length.ToString();
            }
        private void cutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cut();
        }

        private void copyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }
        public void Open(string OpenFileName)
        {
            if(OpenFileName=="")
            {
                return;
            }
            else
            {
                StreamReader sr = new StreamReader(OpenFileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                DocName = OpenFileName;
            }
        }
        public void Save(string SaveFileName)
        {
            if(SaveFileName=="")
            {
                return;
            }
            else
            {
                StreamWriter sw = new StreamWriter(SaveFileName);
                sw.WriteLine(richTextBox1.Text);
                sw.Close();
                DocName = SaveFileName;
            }
        }

        private void blank_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsSaved == true)
            {
                if (MessageBox.Show("Сохранить изменения в " + this.DocName + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Save(this.DocName);
                }
            }
            if (IsSaved == false)
            {
                if (MessageBox.Show("Сохранить изменения в " + this.DocName + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    this.Save(this.DocName);
                }
            }
        }

        private void sbTime_Click(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            sbTime.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());
            sbAmount.ToolTipText = Convert.ToString(System.DateTime.Today.ToLongDateString());
        }
    }
}
