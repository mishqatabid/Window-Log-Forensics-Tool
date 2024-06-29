using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forensilog
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string File_name = textBox1.Text;
                string Password = textBox2.Text;
                if (string.IsNullOrEmpty(File_name) || string.IsNullOrEmpty(Password))
                {
                    MessageBox.Show("No filename or Password entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (Password.Equals("admin"))
                {
                    string connectionString = "Data Source=DESKTOP-LLF4HB6\\SQLEXPRESS;Initial Catalog=PLAYER;Integrated Security=True;";

                    string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName";
                    int tableCount;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(checkTableQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TableName", File_name);
                            tableCount = (int)command.ExecuteScalar();
                        }

                        if (tableCount == 1)
                        {
                            string sql = $"DROP TABLE dbo.{File_name};";
                            using (SqlCommand dropCommand = new SqlCommand(sql, connection))
                            {
                                dropCommand.ExecuteNonQuery();
                            }
                            MessageBox.Show("File Deleted Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("No Such File Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(File_name) && !Password.Equals("admin"))
                {
                    MessageBox.Show("No file name entered or Password entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Occurred:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string password = Interaction.InputBox("By clicking this button, you may permanently remove all baseline data, and it cannot be recovered. Are you sure you want to proceed?\n\nPassword:", "Warning!", "");
            try
            {
                if (password.Equals("admin"))
                {
                    string connectionString = "Data Source=DESKTOP-LLF4HB6\\SQLEXPRESS;Initial Catalog=PLAYER;Integrated Security=True;";

                    string database = "PLAYER";
                    string sql = $@"
                    USE [{database}];
                    DECLARE @sql NVARCHAR(MAX) = '';
                    SELECT @sql = @sql + 'DROP TABLE ' + QUOTENAME(t.name) + ';'
                    FROM sys.tables AS t;
                    EXEC sp_executesql @sql;
                    ";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@DatabaseName", database);
                            command.ExecuteNonQuery();
                        }


                        MessageBox.Show("File Deleted Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show($"Incorrect Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Occurred:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
