using MySql.Data.MySqlClient;
using State_Panel.ServiceReference1;
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

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace State_Panel
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			fillData();
		}

		private void fillData()
		{
			string connectionString = "Data Source=sql126.main-hosting.eu; Initial Catalog=u256565172_agl; User ID=u256565172_root; Password=9pz9WU7Du3Ob;";
			string query = "SELECT phoneNumber, housePrice, downPercentage, years, salary FROM applications WHERE state = 1";
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
				string nb = row.Cells[0].Value.ToString();
				retreiveData(nb);
				textBox1.Text = nb;
			}
		}

		void retreiveData(string phoneNumber)
		{
			string connectionString = "Data Source=sql126.main-hosting.eu; Initial Catalog=u256565172_agl; User ID=u256565172_root; Password=9pz9WU7Du3Ob;";
			string query = "SELECT * FROM personalData WHERE phoneNumber = " + phoneNumber;
			MySqlConnection con = new MySqlConnection(connectionString);
			con.Open();
			MySqlCommand cmd = new MySqlCommand(query, con);
			MySqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				textBox2.Text = ($"{reader.GetString("inLawsuit")}" == "1") ? "true" : "false";
				textBox3.Text = ($"{reader.GetString("hadBankrupcy")}" == "1") ? "true" : "false";
				textBox4.Text = ($"{reader.GetString("hasCreditHistory")}" == "1") ? "true" : "false";
				textBox5.Text = ($"{reader.GetString("hadForeclosure")}" == "1") ? "true" : "false";
			}

			//using (MySqlConnection conn = new MySqlConnection(connectionString))
			//{
			//	using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
			//	{
			//		DataSet ds = new DataSet();
			//		adapter.Fill(ds);
			//		dataGridView1.DataSource = ds.Tables[0];
			//	}
			//}
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

		private void button1_Click_1(object sender, EventArgs e)
		{
			GetUserProfileClient c = new GetUserProfileClient();
			GetUserProfile g = new GetUserProfile();
			g.customerId = textBox1.Text;
			g.inLawsuit = Boolean.Parse(textBox2.Text);
			g.hadBankrupcy = Boolean.Parse(textBox3.Text);
			g.hasCreditHistory = Boolean.Parse(textBox4.Text);
			g.hadForeclosure = Boolean.Parse(textBox5.Text);


			string stateResponse = c.GetUserProfile(g);

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
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";

			fillData();
		}
	}
}
