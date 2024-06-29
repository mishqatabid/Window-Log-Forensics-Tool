using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forensilog
{
    public partial class Form5 : Form
    {
        public static string name_investigator;
        public static string Case_Name;
        public static string Note;
        public static string Case_No;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            name_investigator = textBox1.Text.Trim();
            Case_Name = textBox2.Text.Trim();
            Case_No = textBox3.Text.Trim();
            Note = textBox4.Text.Trim();

            Form1 form1 = new Form1();
            form1.SetData(name_investigator, Case_Name, Case_No, Note);  // Pass data to Form1

            this.Hide();
        }
    }
}
