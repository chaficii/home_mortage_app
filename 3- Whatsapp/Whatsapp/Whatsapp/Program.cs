using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Whatsapp
{
	class Program
	{
		static void Main(string[] args)
		{

			TwilioClient.Init("ACd4ae0701cd168add755e577369c2428b", "0eaa45bff21ab6d12e5aeeab5d390a26");

		


			var message = MessageResource.Create(
			   //from: new PhoneNumber("whatsapp:+15403181924"),
			   from: new PhoneNumber("whatsapp:+14155238886"),
			   body: "Hello World!",
			   to: new PhoneNumber("whatsapp:+96170465436"),

		   mediaUrl: new List<Uri> { new Uri("https://www.s1homes.com/property_images/ResidenceUddingston/2018/2018070707055959/image1-640x480.jpg") }
		   );


			
			Console.WriteLine("Message SID: " + message.ErrorMessage);
			//Console.ReadLine();

		}
	}
}
