using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;

namespace ProjetAGL
{

	public sealed class AskVendor3 : CodeActivity
	{
		public OutArgument<int> Result { get; set; }

		public InArgument<string> customerCode { get; set; }
		public InArgument<string> housePrice { get; set; }
		public InArgument<string> downPayment { get; set; }
		public InArgument<string> years { get; set; }
		public InArgument<string> salary { get; set; }

		protected override void Execute(CodeActivityContext context)
		{
			string cc = context.GetValue(this.customerCode);
			string hp = context.GetValue(this.housePrice);
			string dp = context.GetValue(this.downPayment);
			string y = context.GetValue(this.years);
			string s = context.GetValue(this.salary);


			WebClient proxy = new WebClient();
			byte[] data = proxy.DownloadData("http://localhost:50708/Service1.svc/GetRate/" + cc + "/" + hp + "/" + dp + "/" + y + "/" + s);


			Stream stream = new MemoryStream(data);
			DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(string));
			string result = obj.ReadObject(stream).ToString();

			//string result = "32";
			string res = result.ToString();

			int resInt = Int32.Parse(res);
			context.SetValue(Result, resInt);

		}
	}
}
