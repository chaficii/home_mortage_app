using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vendor2_Panel.ServiceReference1;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace Vendor2_Panel
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			fillData();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			AskVendor2Client c = new AskVendor2Client();
			AskVendor2 a = new AskVendor2();
			a.customerId = textBox1.Text;
			a.rate2 = Int32.Parse(textBox2.Text);

			string stateResponse = c.AskVendor2(a);

			string connectionString = "Data Source=sql126.main-hosting.eu; Initial Catalog=u256565172_agl; User ID=u256565172_root; Password=9pz9WU7Du3Ob;";
			MySqlCommand cmd = new MySqlCommand();
			MySqlConnection cn = new MySqlConnection();
			cn.ConnectionString = connectionString;
			cn.Open();

			cmd.Connection = cn;

			cmd.CommandText = "UPDATE applications SET state = " + stateResponse + " WHERE phoneNumber = " + textBox1.Text;

			cmd.ExecuteNonQuery();
			cmd.Clone();

			richTextBox1.Text = "Success " + stateResponse;

			textBox1.Text = "";
			textBox2.Text = "";

			fillData();
		}

		private void fillData()
		{
			string connectionString = "Data Source=sql126.main-hosting.eu; Initial Catalog=u256565172_agl; User ID=u256565172_root; Password=9pz9WU7Du3Ob;";
			string query = "SELECT phoneNumber, housePrice, downPercentage, years, salary FROM applications WHERE state = 3";
			using (MySqlConnection conn = new MySqlConnection(connectionString))
			{
				using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
				{
					DataSet ds = new DataSet();
					adapter.Fill(ds);
					dataGridView1.DataSource = ds.Tables[0];
				}
			}
		}


		private void dataGridView1_SelectionChanged(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dataGridView1.SelectedRows)
			{
				textBox1.Text = row.Cells[0].Value.ToString();
			}
		}






		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// Click on the link below to continue learning how to build a desktop app using WinForms!
			System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

		}

		private void button1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Thanks!");
		}

	}
}
