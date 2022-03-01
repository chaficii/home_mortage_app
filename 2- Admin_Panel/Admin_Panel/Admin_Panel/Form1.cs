using Admin_Panel.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace Admin_Panel
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
			string query = "SELECT phoneNumber, housePrice, downPercentage, years, salary FROM applications WHERE state = 0 AND phoneNumber IS NOT NULL AND housePrice IS NOT NULL AND downPercentage IS NOT NULL AND salary IS NOT NULL AND years IS NOT NULL";
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
				textBox2.Text = row.Cells[1].Value.ToString();
				textBox3.Text = row.Cells[2].Value.ToString();
				textBox4.Text = row.Cells[3].Value.ToString();
				textBox5.Text = row.Cells[4].Value.ToString();

			}
		}

		

		private void button1_Click_1(object sender, EventArgs e)
		{
			GetApplicationClient c = new GetApplicationClient();
			GetApplication g = new GetApplication();
			g.customerId = textBox1.Text;
			g.housePrice = Int32.Parse(textBox2.Text);
			g.downPercentage = Int32.Parse(textBox3.Text);
			g.salary = Int32.Parse(textBox4.Text);
			g.years = Int32.Parse(textBox5.Text);

		
			string stateResponse = c.GetApplication(g);
			

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













		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

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

		private void label1_Click(object sender, EventArgs e)
		{

		}
		private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
		{

		}

	}
}
