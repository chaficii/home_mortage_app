using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ProjetAGL
{

	public sealed class GetUserState : CodeActivity
	{
		// Define an activity input argument of type string

		public InArgument<string> customerCode { get; set; }
		public OutArgument<bool> hasCH { get; set; }
		public OutArgument<bool> hadB { get; set; }
		public OutArgument<bool> inL { get; set; }
		public OutArgument<bool> hadFC { get; set; }
		
		public int customerCC { get; set; }
		HttpClient client;
		bool hasCreditHistory = false, hadBankrupcy = false, inLawsuit = false, hadForeclosure = false;


		public void initialise()
		{
			client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:60967/");
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
			initialise();
			inLawsuit = getProfileOption("InLawsuit", customerCode.ToString());
			hadBankrupcy = getProfileOption("HadBankrupcy", customerCode.ToString());
			hadForeclosure = getProfileOption("HadForeclosure", customerCode.ToString());
			hasCreditHistory = getProfileOption("HasCreditHistory", customerCode.ToString());
		}

		protected override void Execute(CodeActivityContext context)
		{
			assignMissingParams();

			//customerCC = context.GetValue(this.customerCode);

			context.SetValue(hasCH, hasCreditHistory);
			context.SetValue(hadFC, hadForeclosure);
			context.SetValue(hadB, hadBankrupcy);
			context.SetValue(hadFC, hadForeclosure);
		}
	}
}
