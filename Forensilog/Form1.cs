using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
    using System.Windows.Forms;

namespace Forensilog
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Label labelForensilog;
        private System.Windows.Forms.Label labelForensilog2;
        private System.Windows.Forms.Label labelForensilog3;
        private System.Windows.Forms.Label labelForensilog4;
        private System.Windows.Forms.Label labelForensilog5;
        private System.Windows.Forms.Label labelForensilog6;
        //file name use in investigation tab
        public String File;
        //random log file page
        public static string Name_file;
        public static int num_log;
        private static readonly Random random = new Random();

        //investigator detail
        public static string Investigator_name, case_name, case_no, note;

        public List<string> Tag = new List<string>();
        public List<string> Message_wit_tag = new List<string>();
        List<string> Notable_item = new List<string>();
        //file path use in context menu
        public string path_of_file;
        public Form1()
        {
            InitializeComponent();
            CustomButton();
            InitializeCustomComponents();

            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;


        }
        public void SetForm7info(string file_name, int Num_log)
        {
            Name_file = file_name;
            num_log = Num_log;
        }
        public void SetData(string nameInvestigator, string caseName, string caseNo, string note1)
        {
            Investigator_name = nameInvestigator;
            case_name = caseName;
            case_no = caseNo;
            note = note1;
        }
        private void label3_Click(object sender, EventArgs e) { }

        private void panel3_Paint(object sender, PaintEventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void button2_Click(object sender, EventArgs e) { }

        private void OnMouseEnterButton1(object sender, EventArgs e)
        {

        }

        private void OnMouseLeaveButton1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e) { }

        private void panel6_Paint(object sender, PaintEventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void button8_Click(object sender, EventArgs e)
        {
            ShowPanel(panel6);
        }

        private void CustomButton()
        {
            panel6.Visible = false;
        }

        private void hideMenu()
        {
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }
        }

        private void ShowPanel(Panel obj)
        {
            if (obj.Visible == false)
            {
                hideMenu();
                obj.Visible = true;
            }
            else
            {
                obj.Visible = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            hideMenu();
        }

        private void button10_Click(object sender, EventArgs e) 
        {
            OpenGitHubLink();
        }
        private void OpenGitHubLink()
        {
            // The URL to open
            string url = "https://github.com/mun1bxD/Window-Log-Forensics-Tool";
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open link: {ex.Message}");
            }
        }

        private void InitializeCustomComponents()
        {
            // Create and set up the Label
            labelForensilog = new System.Windows.Forms.Label
            {
                Text = "Forensilog",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 64, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Gainsboro,
                Dock = DockStyle.None,
                Anchor = AnchorStyles.None
            };
            labelForensilog2 = new System.Windows.Forms.Label
            {
                Text = "Forensilog",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 64, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Gainsboro,
                Dock = DockStyle.None,
                Anchor = AnchorStyles.None
            };
            labelForensilog3 = new System.Windows.Forms.Label
            {
                Text = "Forensilog",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 64, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Gainsboro,
                Dock = DockStyle.None,
                Anchor = AnchorStyles.None
            };
            labelForensilog4 = new System.Windows.Forms.Label
            {
                Text = "Forensilog",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 64, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Gainsboro,
                Dock = DockStyle.None,
                Anchor = AnchorStyles.None
            };
            labelForensilog5 = new System.Windows.Forms.Label
            {
                Text = "Forensilog",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 64, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Gainsboro,
                Dock = DockStyle.None,
                Anchor = AnchorStyles.None
            };
            labelForensilog6 = new System.Windows.Forms.Label
            {
                Text = "Forensilog",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 64, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Gainsboro,
                Dock = DockStyle.None,
                Anchor = AnchorStyles.None
            };
            panel4.Controls.Add(labelForensilog);
            panel8.Controls.Add(labelForensilog2);
            panel13.Controls.Add(labelForensilog3);
            panel30.Controls.Add(labelForensilog5);
            panel32.Controls.Add(labelForensilog6);

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView6.Visible = false;
            dataGridView5.Visible = false;

            panel4.Resize += (s, e) => PositionLabelInCenter(panel4, labelForensilog);
            panel8.Resize += (s, e) => PositionLabelInCenter(panel8, labelForensilog2);
            panel4.Resize += (s, e) => PositionLabelInCenter(panel13, labelForensilog3);     
            panel4.Resize += (s, e) => PositionLabelInCenter(panel11, labelForensilog5);
            panel8.Resize += (s, e) => PositionLabelInCenter(panel28, labelForensilog6);

        }
        private void PositionLabelInCenter(Panel panel, System.Windows.Forms.Label label)
        {
            if (panel != null && label != null)
            {
                label.Size = new Size(200, 50);
                int x = (panel.Width - label.Width) / 2;
                int y = (panel.Height - label.Height) / 2;
                label.Location = new Point(x, y);
            }
        }

        private void PositionLabelInCenterOfPanel()
        {
            if (panel4 != null && labelForensilog != null)
            {
                labelForensilog.Size = new Size(200, 50);
                int x = (panel4.Width - labelForensilog.Width) / 2;
                int y = (panel4.Height - labelForensilog.Height) / 2;
                labelForensilog.Location = new Point(x, y);
            }
        }

        private void Panel4_Resize(object sender, EventArgs e)
        {
            PositionLabelInCenterOfPanel();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            PositionLabelInCenterOfPanel();
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Forensilog_label6();
            try
            {
                EventLog[] log = EventLog.GetEventLogs();
                //  if (dataGridView1.ColumnCount == 0)
                //{
                //  dataGridView1.Columns.Add("All Available Logs File", "All Available Logs File");
                //  }
                int row = 1;
                foreach (EventLog entry in log)
                {
                    dataGridView1.Rows.Add(row,entry.LogDisplayName);
                    row++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void PositionLabelInCenterOfPanel5(System.Windows.Forms.Label label)
        {
            if (panel5 != null && label != null)
            {
                label.Size = new Size(200, 50); 
                int x = (panel5.Width - label.Width) / 2;
                int y = (panel5.Height - label.Height) / 2;
                label.Location = new Point(x, y);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button45_Click(object sender, EventArgs e)
        {
            Form5 obj = new Form5();
            obj.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
        private void Forensilog_label1()
        {
            var Forensilog1 = new System.Windows.Forms.Label
            {
                Text = "Forensilog",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 48, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Gainsboro,
                Anchor = AnchorStyles.None
            };
            panel10.Controls.Add(Forensilog1);
            PositionLabelInCenterOfPanel5(Forensilog1);

               dataGridView2.Visible = true;
               dataGridView2.BringToFront();
        }
        private void Forensilog_label2()
        {
            var Forensilog2 = new System.Windows.Forms.Label
            {
                Text = "Forensilog",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 48, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Gainsboro,
                Anchor = AnchorStyles.None
            };
            panel22.Controls.Add(Forensilog2);
            PositionLabelInCenterOfPanel5(Forensilog2);

                 dataGridView6.Visible = true;
                 dataGridView6.BringToFront();
        }
        private void Forensilog_label3()
        {
            var Forensilog4 = new System.Windows.Forms.Label
            {
                Text = "Forensilog",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 48, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Gainsboro,
                Anchor = AnchorStyles.None
            };
            panel31.Controls.Add(Forensilog4);
            PositionLabelInCenterOfPanel5(Forensilog4);
            
            dataGridView3.Visible = true;
            dataGridView3.BringToFront();
        }
        private void Forensilog_label5()
        {
            var Forensilog5 = new System.Windows.Forms.Label
            {
                Text = "Forensilog",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 48, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Gainsboro,
                Anchor = AnchorStyles.None
            };
            panel33.Controls.Add(Forensilog5);
            PositionLabelInCenterOfPanel5(Forensilog5);

            dataGridView5.Visible = true;
            dataGridView5.BringToFront();
        }
        private void Forensilog_label6()
        {
            var Forensilog6 = new System.Windows.Forms.Label
            {
                Text = "Forensilog",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 48, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Gainsboro,
                Anchor = AnchorStyles.None
            };

            panel5.Controls.Add(Forensilog6);
            PositionLabelInCenterOfPanel5(Forensilog6);

            dataGridView1.Visible = true;
            dataGridView1.BringToFront();
        }

        private void panel33_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button44_Click(object sender, EventArgs e)
        {
            Forensilog_label5();
            File = Interaction.InputBox("Enter File name to Investigate", "File Name", "");
            
            Load_refresh();
        }
        public void Load_refresh()
        {
            if (string.IsNullOrEmpty(File))
            {
                MessageBox.Show("File Name not enter", "No FIle Name!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!EventLog.Exists(File))
            {
                MessageBox.Show($"No such Log File Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EventLog eventLog = new EventLog(File);

            // Clear the5DataGridView first
       //     dataGridView5.Rows.Clear();
       //     dataGridView5.Columns.Clear();

       //     dataGridView5.Columns.Add("EntryType", "Entry Type");
       //     dataGridView5.Columns.Add("TimeGenerated", "Time Generated");
       //     dataGridView5.Columns.Add("Message", "Message");

            try
            {
                for (int i = eventLog.Entries.Count - 1; i >= 0; i--)
                {
                    EventLogEntry entry = eventLog.Entries[i];
                    dataGridView5.Rows.Add(entry.EntryType, entry.EventID, entry.TimeGenerated, entry.Source, entry.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private void button43_Click(object sender, EventArgs e)
        {
            //Form4 o = new Form4();
            //o.Show();
            DialogResult DR = MessageBox.Show("Are you sure to Unload", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                dataGridView5.Rows.Clear();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forensilog_label1();

            //  int rowIndex = dataGridView1.Rows.Add();
            //    dataGridView2.Rows[1].Cells["EventID"].Value = "22222222";
            //    dataGridView2.Rows[1].Cells["EventType"].Value = "information";
            //    dataGridView2.Rows[1].Cells["Source"].Value = "hello world333333333333333333333333333333333333333333";
            //    dataGridView2.Rows[1].Cells["TimeGenerated"].Value = "23-22-2022";
            //     dataGridView2.Rows[1].Cells["Message"].Value = "hello mun333333333333333333333333333333333333333ib";
            MessageBox.Show("This may take a second to load the file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            EventLog Log = new EventLog("Application");
         //   dataGridView2.Rows.Clear();
         //   dataGridView2.Columns.Clear();
         //   dataGridView2.Columns.Add("EntryType", "Entry Type");
         //   dataGridView2.Columns.Add("TimeGenerated", "Time Generated");
         //   dataGridView2.Columns.Add("Source", "Source");
          //  dataGridView2.Columns.Add("Message", "Message");

            try
            {
                // Iterate through the entries in the Application log
                foreach (EventLogEntry entry in Log.Entries)
                {
                    dataGridView2.Rows.Add(entry.EntryType, entry.EventID, entry.TimeGenerated, entry.Source, entry.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Forensilog_label2();
            MessageBox.Show("This may take a second to load the file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            EventLog eventLog = new EventLog("System");


           // dataGridView1.Rows.Clear();
          //  dataGridView1.Columns.Clear();


           // dataGridView1.Columns.Add("EntryType", "Entry Type");
           // dataGridView1.Columns.Add("TimeGenerated", "Time Generated");
           // dataGridView1.Columns.Add("Source", "Source");
           // dataGridView1.Columns.Add("Message", "Message");
          //  dataGridView1.Columns.Add("EventID", "Event ID");
          //  dataGridView1.Columns.Add("TaskCategory", "Task Category");

            try
            {

                for (int i = eventLog.Entries.Count - 1; i >= 0; i--)
                {
                    EventLogEntry entry = eventLog.Entries[i];
                    dataGridView6.Rows.Add(entry.EntryType,entry.EventID, entry.TimeGenerated, entry.Source, entry.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button46_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            try
            {
                string file1 = Interaction.InputBox("Enter File to Delete", "Enter file Name", "");
                if (!string.IsNullOrEmpty(file1))
                {
                    if (EventLog.Exists(file1))
                    {
                        EventLog.Delete(file1);
                        MessageBox.Show($"{file1} deleted Successfully", "Delete Log File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"No such file Exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Enter File name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 obj = new Form6();
            obj.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Form7 obj7 = new Form7();
            obj7.ShowDialog();

            // MessageBox.Show(num_log);
            Generate_Random_log();

        }
        private void Generate_Random_log()
        {
            try
            {
                for (int i = 0; i < num_log; i++)
                {
                    int eventID = random.Next(1000, 9999);
                    string message = RandomMessage();

                    writemessagetolog(message, eventID);
                }
                MessageBox.Show($"{num_log} logs are written to ${Name_file}", "Log info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string RandomMessage()
        {
            string[] Messages = new string[]
            {
                 "System started successfully",
                "Disk space low on Drive C:",
                "User login detected",
                "Network connection established",
                "Service restarted",
                "Unauthorized access attempt blocked"
            };
            int randomMessage = random.Next(Messages.Length);

            return Messages[randomMessage];
        }
        private void writemessagetolog(string message, int eventID)
        {
            try
            {
                using (EventLog eventLog = new EventLog(Name_file))
                {
                    eventLog.Source = Name_file;
                    eventLog.WriteEntry(message, EventLogEntryType.Information, eventID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to write to event log: {ex.Message}");
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {

            string message = Interaction.InputBox("Enter Mesage to add", "ADD message", "");
            if (!string.IsNullOrEmpty(message))
            {
                using (EventLog eventLog = new EventLog("System"))
                {
                    eventLog.Source = "System";
                    eventLog.WriteEntry(message, EventLogEntryType.Information);

                }
            }
            else
            {
                MessageBox.Show("Enter Data to add", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button25_Click(object sender, EventArgs e)
        {
            string logName = "System";
            EventLog eventLog = new EventLog(logName);
            try
            {
                if (EventLog.Exists(logName))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to clear the event log?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        eventLog.Clear();
                        MessageBox.Show("Event log cleared.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       // dataGridView2.Columns.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Event log not cleared.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Event log does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string message = Interaction.InputBox("Enter Mesage to add", "ADD message", "");
                if (!string.IsNullOrEmpty(message))
                {
                    using (EventLog eventLog = new EventLog("Application"))
                    {
                        eventLog.Source = "System";
                        eventLog.WriteEntry(message, EventLogEntryType.Information);
                        MessageBox.Show("Message Entered Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Enter Data to add", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string logName = "Application";
            EventLog eventLog = new EventLog(logName);
            try
            {
                if (EventLog.Exists(logName))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to clear the event log?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        eventLog.Clear();
                        MessageBox.Show("Event log cleared.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView2.Columns.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Event log not cleared.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Event log does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ShowPanel(panel9);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            ShowPanel(panel15);
        }

        private void button20_Click(object sender, EventArgs e)
        {
         //   MessageBox.Show(Investigator_name+case_name);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.Title = "Save";
                saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.DefaultExt = "txt";

                string path = saveFileDialog1.FileName;
                int Total_Notable_item = Notable_item.Count;
                int Total_tag = Tag.Count;
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(Investigator_name);
                    writer.WriteLine("Report Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    writer.WriteLine("\nTotal Notable item:" + Total_Notable_item);
                    writer.WriteLine("\nTotal Tag item:" + Total_tag);
                    writer.WriteLine("\nNotable items:");

                    for (int i = 0; i < Notable_item.Count; i++)
                    {
                        writer.WriteLine(i + Notable_item[i]);


                    }
                    writer.WriteLine("Tag item with message:");

                    for (int i = 0; i < Tag.Count; i++)
                    {

                        writer.WriteLine(i + $"{Tag[i]}: {Message_wit_tag[i]}");
                        writer.WriteLine("\n");
                    }
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {

            string caseName = case_name;
            string caseNumber = case_no;
            string examiner = Investigator_name;
            string addedNote = note;

            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;

            string filePath = "C:\\Windows\\System32\\winevt\\Logs\\" + File;

            string newLogCreated = "Log 2024/04/13 11:31:21";
            int totalLogFile = Count_log();
            string imageLink = @"C:\Users\hp\Downloads\image.png";

            string htmlContent = $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Log File Forensic Report</title>
    <style>
        body {{
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(to right, #ece9e6, #ffffff);
            color: #333;
            margin: 0;
            padding: 0;
        }}
        header {{
            background-color: #313030; /* Changed color */
            color: white;
            padding: 20px 0;
            text-align: center;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }}
        .container {{
            width: 80%;
            margin: 30px auto;
            background: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
        }}
        .section {{
            margin-bottom: 30px;
        }}
        .section-title {{
            font-size: 22px;
            font-weight: bold;
            color: #308686; /* Changed color */
            border-bottom: 3px solid #308686; /* Changed color */
            padding-bottom: 10px;
        }}
        ul {{
            list-style-type: none;
            padding: 0;
        }}
        ul li {{
            padding: 10px 0;
            border-bottom: 1px solid #ddd;
        }}
        .highlight {{
            background-color: #e0f7fa;
            border-left: 5px solid #308686; /* Changed color */
            padding: 15px;
            margin: 10px 0;
            border-radius: 4px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }}
        .image-container {{
            text-align: center;
            margin-top: 20px;
        }}
        .image-container img {{
            max-width: 100%;
            height: auto;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }}
    </style>
</head>
<body>
    <header>
        <h1>Log File Forensic Report</h1>
    </header>
    <div class='container'>
        <div class='section'>
            <div class='section-title'>Report Information</div>
            <p>HTML Report Generated on {DateTime.Now}</p>
        </div>

        <div class='section'>
            <div class='section-title'>Investigator Information</div>
            <p>Case: {Investigator_name}</p>
            <p>Case Number: {caseNumber}</p>
            <p>Examiner: {examiner}</p>
            <p>Added Note: {addedNote}</p>
        </div>

        <div class='section'>
            <div class='section-title'>Log Information</div>
            <p>File name: {filePath}</p>
            <p>Timezone: {localTimeZone.Id}</p>
        </div>

        <div class='section'>
            <div class='section-title'>Report Navigation</div>
            <p>Tag Item: {Tag.Count}</p>
            <p>Notable item: {Notable_item.Count}</p>
        </div>

        <div class='section'>
            <div class='section-title'>New Log Created</div>
            <p>New Log Created: {newLogCreated}</p>
            <p>New Log Files after baseline: {totalLogFile}</p>
        </div>

        <div class='section'>
            <div class='section-title'>Tag Item</div>";
            for (int i = 0; i < Tag.Count; i++)
            {
                htmlContent += $"<div class='highlight'>{Tag[i]} : {Message_wit_tag[i]}</div>";
            }
            htmlContent += @"
        </div>

        <div class='section'>
            <div class='section-title'>Notable Item</div>";
            foreach (string item in Notable_item)
            {
                htmlContent += $"<div class='highlight'>{item}</div>";
            }
            htmlContent += @"
        </div>

        <div class='section image-container'>
            <div class='section-title'>End</div>
            <img src='" + imageLink + @"' alt='Image' />
        </div>
    </div>
</body>
</html>";


            // Save the HTML content to a temporary file
            string tempFilePath = Path.Combine(Path.GetTempPath(), "LogFileForensicReport.html");
            System.IO.File.WriteAllText(tempFilePath, htmlContent);

            // Open the HTML file in the default web browser (Chrome)
            Process.Start(new ProcessStartInfo
            {
                FileName = tempFilePath,
                UseShellExecute = true
            });

        }
        public int Count_log()
        {
            string connection1 = "Data Source=DESKTOP-LLF4HB6\\SQLEXPRESS;Initial Catalog=PLAYER;Integrated Security=True;";
            int rowCount = 0;
            string tableName = "Unique_Entries";
            string query = $"SELECT COUNT(*) FROM {tableName}";

            // Create and open the connection
            using (SqlConnection connection = new SqlConnection(connection1))
            {

                try
                {
                    connection.Open();

                    // Create the command
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and get the row count
                        rowCount = (int)command.ExecuteScalar();

                        // Output the row count
                        Console.WriteLine($"The number of rows in the table '{tableName}' is: {rowCount}");
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return rowCount;
        }

        private void addToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedCells.Count > 0)
            {
                int row_index = dataGridView5.SelectedCells[0].RowIndex;
                if ((dataGridView5.SelectedCells[0].ColumnIndex == 0) || (dataGridView5.SelectedCells[0].ColumnIndex == 1) || (dataGridView5.SelectedCells[0].ColumnIndex == 2) || (dataGridView5.SelectedCells[0].ColumnIndex == 3) || (dataGridView5.SelectedCells[0].ColumnIndex == 4))
                {
                    String Message = dataGridView5.Rows[row_index].Cells[4].Value.ToString(); // Replace 1 with the index of your desired column
                    Notable_item.Add(Message);
                    dataGridView5.Rows[row_index].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
            else
            {
                MessageBox.Show("Select an item to be notable", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_refresh();
        }

        private void copyFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {

            path_of_file = "C:\\Windows\\System32\\winevt\\Logs\\" + File;
            Clipboard.SetText(path_of_file);

            MessageBox.Show("File path copied to clipboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void copyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView5.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    Clipboard.SetDataObject(dataGridView5.GetClipboardContent());

                    MessageBox.Show("Copied to clipboard.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    MessageBox.Show("The Clipboard could not be accessed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void removeNotableItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView5.SelectedCells.Count > 0)
            {
                int row_index = dataGridView5.SelectedCells[0].RowIndex;
                if ((dataGridView5.SelectedCells[0].ColumnIndex == 0) || (dataGridView5.SelectedCells[0].ColumnIndex == 1) || (dataGridView5.SelectedCells[0].ColumnIndex == 2) || (dataGridView5.SelectedCells[0].ColumnIndex == 3) || (dataGridView5.SelectedCells[0].ColumnIndex == 4))
                {
                    String Message = dataGridView5.Rows[row_index].Cells[4].Value.ToString(); // Replace 1 with the index of your desired column
                    if (Notable_item.Contains(Message))
                    {
                        Notable_item.Remove(Message);
                        dataGridView5.Rows[row_index].DefaultCellStyle.BackColor = Color.Empty;

                    }
                    else
                    {
                        MessageBox.Show("Item does not exist in the notable list.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            else
            {
                MessageBox.Show("Select an item to remove from notable", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void removeTagToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView5.SelectedCells.Count > 0)
            {
                int row_index = dataGridView5.SelectedCells[0].RowIndex;
                if ((dataGridView5.SelectedCells[0].ColumnIndex == 0) || (dataGridView5.SelectedCells[0].ColumnIndex == 1) || (dataGridView5.SelectedCells[0].ColumnIndex == 2) || (dataGridView5.SelectedCells[0].ColumnIndex == 3) || (dataGridView5.SelectedCells[0].ColumnIndex == 4))
                {
                    String Message = dataGridView5.Rows[row_index].Cells[4].Value.ToString(); // Replace 1 with the index of your desired column
                    String source = dataGridView5.Rows[row_index].Cells[3].Value.ToString();
                    String Time = dataGridView5.Rows[row_index].Cells[2].Value.ToString(); // Replace 1 with the index of your desired column
                    String Eventid = dataGridView5.Rows[row_index].Cells[1].Value.ToString();
                    String Message_type = dataGridView5.Rows[row_index].Cells[0].Value.ToString();
                    string Final_Message = Message_type + " : " + Eventid + " :" + Time + " :" + source + " :" + Message;
                    for (int i = 0; i < Message_wit_tag.Count; i++)
                    {
                        if (Message_wit_tag[i] == Final_Message)
                        {
                            Tag.RemoveAt(i);
                        }
                    }
                    dataGridView5.Rows[row_index].DefaultCellStyle.BackColor = Color.Empty;


                }
            }
            else
            {
                MessageBox.Show("Select an item to be notable", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addNewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView5.Rows.Add();
            // dataGridView5.Rows.Remove(dataGridView5.SelectedRows());
            dataGridView5.CurrentCell = dataGridView5.Rows[index].Cells[0];
        }

        private void removeItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView5.SelectedRows)
            {
                dataGridView5.Rows.Remove(Row);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView5.SelectedCells.Count > 0)
            {
                var selectedCell = this.dataGridView5.SelectedCells[0];
                Clipboard.SetText(selectedCell.Value.ToString());
                selectedCell.Value = string.Empty;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView5.SelectedCells.Count > 0)
            {
                var Cell = this.dataGridView5.SelectedCells[0];
                if (Clipboard.ContainsText())
                {
                    Cell.Value = Clipboard.GetText();
                }
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {

            string userInput = Interaction.InputBox("Enter Log File Name", "Log file name!", "");

            try
            {
                if (!string.IsNullOrEmpty(userInput))
                {
                    string connectionString = "Data Source=DESKTOP-LLF4HB6\\SQLEXPRESS;Initial Catalog=PLAYER;Integrated Security=True;";
                    string tableName = userInput;

                    // Check if the table already exists
                    string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName";
                    int tableCount;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(checkTableQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TableName", tableName);
                            tableCount = (int)command.ExecuteScalar();
                        }

                        if (tableCount > 0)
                        {
                            MessageBox.Show($"Table '{tableName}' already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!EventLog.Exists(userInput))
                        {
                            MessageBox.Show($"No such Log File Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Create the table
                        string createTableQuery = $"CREATE TABLE {tableName} (TaskID INT, Message NVARCHAR(MAX), Hash VARCHAR(255))";
                       
                        using (SqlCommand command = new SqlCommand(createTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show($"Table '{tableName}' created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Insert data from the event log into the table
                        EventLog eventLog = new EventLog(userInput);
                        foreach (EventLogEntry entry in eventLog.Entries)
                        {
                            Calculate_Hash obj = new Calculate_Hash();
                            string hash = obj.Hashing(entry.Message);

                            string insertQuery = $"INSERT INTO {tableName} (TaskID, Message, Hash) VALUES (@TaskID, @Message, @Hash)";
                        
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                //          insertCommand.Parameters.AddWithValue("@TaskID", entry.InstanceId);
                                insertCommand.Parameters.AddWithValue(@"EventType",entry.EventID);
                                insertCommand.Parameters.AddWithValue("@Message", entry.Message);
                                insertCommand.Parameters.AddWithValue("@Hash", hash);
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No File is Selected");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button38_Click(object sender, EventArgs e)
        {
            string userInput = Interaction.InputBox("Enter Log File Name", "Log file name!", "");

            try
            {
                if (string.IsNullOrEmpty(userInput))
                {
                    MessageBox.Show("No file name entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show($"Do you want to update log file '{userInput}'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string connectionString = "Data Source=DESKTOP-LLF4HB6\\SQLEXPRESS;Initial Catalog=PLAYER;Integrated Security=True;";
                    string tableName = userInput;

                    // Check if the table already exists
                    string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName";
                    int tableCount;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(checkTableQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TableName", tableName);
                            tableCount = (int)command.ExecuteScalar();
                        }

                        if (tableCount == 1)
                        {

                            string clearDataQuery = $"TRUNCATE TABLE {tableName}";
                            using (SqlCommand command = new SqlCommand(clearDataQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }

                            // Insert data from the event log into the table
                            EventLog eventLog = new EventLog(userInput);
                            foreach (EventLogEntry entry in eventLog.Entries)
                            {
                                Calculate_Hash obj = new Calculate_Hash();
                                string hash = obj.Hashing(entry.Message);

                                string insertQuery = $"INSERT INTO {tableName} (TaskID, Message, Hash) VALUES (@TaskID, @Message, @Hash)";
                                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@TaskID", entry.EntryType);
                                    insertCommand.Parameters.AddWithValue("@Message", entry.Message);
                                    insertCommand.Parameters.AddWithValue("@Hash", hash);
                                    insertCommand.ExecuteNonQuery();
                                }
                            }
                            MessageBox.Show($"Data in table '{tableName}' updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"No such table exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button37_Click(object sender, EventArgs e)
        {
            Forensilog_label3();
            
            string connection1 = "Data Source=DESKTOP-LLF4HB6\\SQLEXPRESS;Initial Catalog=PLAYER;Integrated Security=True;";


            try
            {
                MessageBox.Show("This may take a second to load the file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Forensilog_label3();
                string userinput = Interaction.InputBox("Enter Log File Name", "Log file name!", "");
                if (string.IsNullOrEmpty(userinput))
                {
                    MessageBox.Show("No file name entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string query = $"SELECT * FROM {userinput}";
                using (SqlConnection connection = new SqlConnection(connection1))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView3.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("Enter Log File name", "Security Check", "");
            string tableName = "Temp";
            try
            {
                string connection1 = "Data Source=DESKTOP-LLF4HB6\\SQLEXPRESS;Initial Catalog=PLAYER;Integrated Security=True;";

                if (string.IsNullOrEmpty(name) && EventLog.SourceExists(name))
                {
                    MessageBox.Show("Enter Log file name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                using (SqlConnection con = new SqlConnection(connection1))
                {
                    con.Open();
                    if (!TableExists(con, tableName))
                    {
                        string createTableQuery = $"CREATE TABLE {tableName} (TaskID INT, Message NVARCHAR(MAX), Hash VARCHAR(255))";
                        using (SqlCommand command = new SqlCommand(createTableQuery, con))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string clearTableQuery = $"TRUNCATE TABLE {tableName}";
                        using (SqlCommand command = new SqlCommand(clearTableQuery, con))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    string insertQuery = $"INSERT INTO {tableName} (TaskID, Message, Hash) VALUES (@TaskID, @Message, @Hash)";
                    EventLog eventLog = new EventLog(name);
                    foreach (EventLogEntry entry in eventLog.Entries)
                    {
                        Calculate_Hash obj = new Calculate_Hash();
                        string hash = obj.Hashing(entry.Message);


                        using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@TaskID", entry.EntryType);
                            cmd.Parameters.AddWithValue("@Message", entry.Message);
                            cmd.Parameters.AddWithValue("@Hash", hash);
                            cmd.ExecuteNonQuery();
                        }
                    }

                }
                CreateDifferentTable(name);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void CreateDifferentTable(string name)
        {
            string table_Original = name;
            string table_temp = "Temp";
            string Unique_table = "Unique_Entries";
            string connection1 = "Data Source=DESKTOP-LLF4HB6\\SQLEXPRESS;Initial Catalog=PLAYER;Integrated Security=True;";

            try
            {
                using (SqlConnection con = new SqlConnection(connection1))
                {
                    con.Open();
                    if (!TableExists(con, Unique_table))
                    {
                        string query1 = $"CREATE TABLE {Unique_table} (TaskID INT, Message NVARCHAR(MAX), Hash VARCHAR(255))";
                        using (SqlCommand cmd = new SqlCommand(query1, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query2 = $"TRUNCATE TABLE {Unique_table}";
                        using (SqlCommand cmd = new SqlCommand(query2, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    string diffQuery = $@"
                    INSERT INTO {Unique_table} (TaskID, Message, Hash)
                    SELECT TaskID, Message, Hash FROM {table_temp}
                     EXCEPT
                    SELECT TaskID, Message, Hash FROM {table_Original}";
                    using (SqlCommand cmd = new SqlCommand(diffQuery, con))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    //  string checkQuery = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName";
                    string checkQuery = "SELECT COUNT(*) FROM " + Unique_table;

                    // Execute the query
                    using (SqlCommand command = new SqlCommand(checkQuery, con))
                    {
                        //  command.Parameters.AddWithValue("@TableName", Unique_table);
                        int columnCount = (int)command.ExecuteScalar();


                        if (columnCount > 1)
                        {
                            MessageBox.Show("Changes have been detected in the system logs. Consider taking security measures or generating a report to review the changes.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("No changes have been detected in the system logs.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool TableExists(SqlConnection connection, string tableName)
        {
            string checkTableQuery = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName";
            using (SqlCommand command = new SqlCommand(checkTableQuery, connection))
            {
                command.Parameters.AddWithValue("@TableName", tableName);
                int tableCount = (int)command.ExecuteScalar();
                return tableCount > 0;
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void dataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button36_Click(object sender, EventArgs e)
        {
         //   Form4 obj4=new Form4();
         //   obj4.Show();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            OpenGitHubLink();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            OpenGitHubLink();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            OpenGitHubLink();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            OpenGitHubLink();   
        }

        private void button36_Click_1(object sender, EventArgs e)
        {
            Form4 obj4=new Form4();
            obj4.Show();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            ShowPanel(panel24);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            
            ShowPanel(panel27);
        }

        private void notToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string Tag_info = Interaction.InputBox("Enter File name to Investigate", "File Name", "");

            if (dataGridView5.SelectedCells.Count > 0 && !string.IsNullOrEmpty(Tag_info))
            {
                int row_index = dataGridView5.SelectedCells[0].RowIndex;
                if ((dataGridView5.SelectedCells[0].ColumnIndex == 0) || (dataGridView5.SelectedCells[0].ColumnIndex == 1) || (dataGridView5.SelectedCells[0].ColumnIndex == 2) || (dataGridView5.SelectedCells[0].ColumnIndex == 3) || (dataGridView5.SelectedCells[0].ColumnIndex == 4))
                {
                    String Message = dataGridView5.Rows[row_index].Cells[4].Value.ToString(); // Replace 1 with the index of your desired column
                    String source = dataGridView5.Rows[row_index].Cells[3].Value.ToString();
                    String Time = dataGridView5.Rows[row_index].Cells[2].Value.ToString(); // Replace 1 with the index of your desired column
                    String Eventid = dataGridView5.Rows[row_index].Cells[1].Value.ToString();
                    String Message_type = dataGridView5.Rows[row_index].Cells[0].Value.ToString();
                    string Final_Message = Message_type + " : " + Eventid + " :" + Time+" :"+source+" :"+Message;

                    Message_wit_tag.Add(Final_Message);
                    Tag.Add(Tag_info);
                    dataGridView5.Rows[row_index].DefaultCellStyle.BackColor = Color.Yellow;

                }
            }
            else
            {
                MessageBox.Show("Item or tag value is not Entered", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
