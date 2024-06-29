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
    public partial class Form7 : Form
    {
        public static string file_name;
        public static int Num_log;
        public Form7()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            file_name = textBox1.Text.Trim();
            string logs = textBox2.Text.Trim();
            Num_log = int.Parse(logs);
            Form1 form1 = new Form1();
            form1.SetForm7info(file_name, Num_log);
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
