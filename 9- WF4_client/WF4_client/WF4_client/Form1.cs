using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF4_client.ServiceReference1;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace WF4_client
{
	public partial class Form1 : Form
	{
		//public EvaluateMortageClient emc;
		
		string customerCode;
		int housePrice = 0, downPayment = 0, years = 0, salary = 0;
		bool hasCreditHistory = false, hadBankrupcy = false, inLawsuit = false, hadForeclosure = false;
		HttpClient client;
		
		public Form1()
		{
			InitializeComponent();
			
			//emc = new EvaluateMortageClient();
			client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:60967/");
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}


		private void Form1_Load(object sender, EventArgs e)
		{

		}
		private void label1_Click(object sender, EventArgs e)
		{

		}
	


		private void button1_Click(object sender, EventArgs e)
		{
			printCurrentProfile();
		}

		/*private void fetchHoldingRequests()
		{
			ServiceReference2.Service12Client a = new ServiceReference2.Service12Client();
			
		}*/

		private void button2_Click(object sender, EventArgs e)
		{
			printCurrentProfile();
			screeningRequest();
		}

		private void screeningRequest()
		{
			//int x = await emc.EvaluateMortageAsync(customerCode, housePrice, downPayment, years, salary);
			//int rep = emc.EvaluateMortage(customerCode, housePrice, downPayment, years, salary);
			
			//int rep = emc2.EvaluateMortage("10", 3200000, 43, 5, 1800);
			try
			{
				EvaluateMortageClient emc2 = new EvaluateMortageClient();
				//emc2.Open();
				string msg;
				int rep = emc2.EvaluateMortage(customerCode, housePrice, downPayment, years, salary, out msg);
				//emc2.Close();
				richTextBox1.Text = rep.ToString() + " " + msg;
			}
			catch (Exception e)
			{
				richTextBox1.Text = e.ToString();
			}
		}

		private void printCurrentProfile()
		{
			assignAllParams();
			string profile = "";
			profile += "CustomerCode\t:\t" + customerCode + "\n";
			profile += "--------------------------------------------------------------------\n";
			profile += "Had Bankrupcy\t:\t" + hadBankrupcy + "\n";
			profile += "Had Foreclosure\t:\t" + hadForeclosure + "\n";
			profile += "Has Credit History\t:\t" + hasCreditHistory + "\n";
			profile += "In Lawsuit\t:\t" + inLawsuit + "\n";
			profile += "--------------------------------------------------------------------\n";
			profile += "House Price\t:\t$" + housePrice + "\n";
			profile += "Down Payment\t:\t" + downPayment + "%\n";
			profile += "Years\t\t:\t" + years + "\n";
			profile += "Salary\t\t:\t$" + salary;

			richTextBox1.Text = profile;
		}
		private void assignAllParams()
		{
			assignExistingParams();
			assignMissingParams();
		}
		private void assignExistingParams()
		{
			customerCode = textBox1.Text;
			housePrice = Int32.Parse(textBox3.Text);
			downPayment = Int32.Parse(textBox2.Text);
			years = Int32.Parse(textBox4.Text);
			salary = Int32.Parse(textBox5.Text);
		}
		private bool getProfileOption(string option, string id)
		{
			HttpResponseMessage response = client.GetAsync("api/" + option + "/" + id).Result;
			bool val = false;
			if (response.IsSuccessStatusCode)
			{
				val = bool.Parse(response.Content.ReadAsStringAsync().Result);
			}
			return val;
		}
		private void assignMissingParams()
		{
			inLawsuit = getProfileOption("InLawsuit", customerCode.ToString());
			hadBankrupcy = getProfileOption("HadBankrupcy", customerCode.ToString());
			hadForeclosure = getProfileOption("HadForeclosure", customerCode.ToString());
			hasCreditHistory = getProfileOption("HasCreditHistory", customerCode.ToString());
		}
		

	}
}
