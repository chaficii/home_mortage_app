using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkflowCalculator_client.ServiceReference1;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace WorkflowCalculator_client
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
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
		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}


		private void button1_Click_1(object sender, EventArgs e)
		{
			//ServiceReference1.CalculateClient
			CalculateClient client = new CalculateClient();

			// Use the 'client' variable to call operations on the service.
			Calculate c = new Calculate();
			c.parameter1 = Int32.Parse(textBox1.Text);
			c.parameter2 = Int32.Parse(textBox2.Text);
			c.operationName = textBox3.Text;

			string str = client.Calculate(c);
			richTextBox1.Text = str;
			// Always close the client.
			client.Close();
		}
	}
}
