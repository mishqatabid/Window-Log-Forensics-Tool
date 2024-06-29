using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forensilog
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String Log_file = textBox1.Text.Trim();
            String message = textBox2.Text.Trim();
            try
            {
                if (EventLog.Exists(Log_file))
                {
                    using (EventLog eventLog = new EventLog(Log_file))
                    {
                        eventLog.Source = Log_file;
                        eventLog.WriteEntry(message, EventLogEntryType.Information);
                        MessageBox.Show("Log entry written successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else if (string.IsNullOrEmpty(Log_file) || string.IsNullOrEmpty(message))
                {
                    MessageBox.Show("filename or messag is not entered", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No such file exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}");
            }
        }
    }
}
