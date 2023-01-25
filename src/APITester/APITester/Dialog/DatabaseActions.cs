using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace APITester.Dialog
{
    public partial class DatabaseActions : Form
    {
        public DatabaseActions()
        {
            InitializeComponent();
        }

        public string SelectedEnvironment { get; set; }

        private void tsbtnRunSQLCommand_Click(object sender, EventArgs e)
        {
            string command = fctxtbSQLCommand.Text;
            RunDatabaseScript(command);
            MessageBox.Show("SQL Command execution completed.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RunDatabaseScript(string commandTest)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[SelectedEnvironment].ConnectionString))
            {
                connection.Open();
                if (commandTest.Contains("\nGO"))
                {
                    StringBuilder commandText = new StringBuilder();
                    MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(commandTest));
                    StreamReader reader = new StreamReader(stream);
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.ToUpper() != "GO")
                            commandText.AppendLine(line);
                        else
                        {
                            using (SqlCommand command = connection.CreateCommand())
                            {
                                try
                                {
                                    command.CommandText = commandText.ToString();
                                    command.CommandType = CommandType.Text;
                                    command.ExecuteNonQuery();
                                }
                                catch (Exception excp)
                                {
                                    MessageBox.Show($"SQL Command execution failed.\n{excp.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            commandText = new StringBuilder();
                        }
                    }
                    if (commandText.Length > 0)
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            try
                            {
                                command.CommandText = commandText.ToString();
                                command.CommandType = CommandType.Text;
                                command.ExecuteNonQuery();
                            }
                            catch (Exception excp)
                            {
                                MessageBox.Show($"SQL Command execution failed.\n{excp.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        commandText = new StringBuilder();
                    }
                }
                else
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        try
                        {
                            command.CommandText = commandTest;
                            command.CommandType = CommandType.Text;
                            command.ExecuteNonQuery();
                        }
                        catch (Exception excp)
                        {
                            MessageBox.Show($"SQL Command execution failed.\n{excp.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
            }
        }
    }
}
