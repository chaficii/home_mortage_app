using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace persistentProject
{

	public sealed class ReplyWhatsapp : CodeActivity
	{
		// Define an activity input argument of type string
		public InArgument<string> Text { get; set; }
		public InArgument<string> PhoneNb { get; set; }


		// If your activity returns a value, derive from CodeActivity<TResult>
		// and return the value from the Execute method.
		protected override void Execute(CodeActivityContext context)
		{
			// Obtain the runtime value of the Text input argument
			string text = context.GetValue(this.Text);
			string phoneNb = context.GetValue(this.PhoneNb);

			TwilioClient.Init("ACd4ae0701cd168add755e577369c2428b", "0eaa45bff21ab6d12e5aeeab5d390a26");
			
			var message = MessageResource.Create(
			   //from: new PhoneNumber("whatsapp:+15403181924"),
			   from: new PhoneNumber("whatsapp:+14155238886"),
			   body: "Hi " + phoneNb + "! Thanks for placing an order with us. We have found you an appartment with " + text + "% rate!",
			   to: new PhoneNumber("whatsapp:+" + phoneNb),

			   mediaUrl: new List<Uri> { new Uri("https://www.s1homes.com/property_images/ResidenceUddingston/2018/2018070707055959/image1-640x480.jpg") }
		   );
			Console.WriteLine("Message SID: " + text);

		}
	}
}
