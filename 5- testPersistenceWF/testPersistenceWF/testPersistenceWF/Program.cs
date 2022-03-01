using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testPersistenceWF.ServiceReference1;
using testPersistenceWF.ServiceReference2;
using testPersistenceWF.ServiceReference3;

namespace testPersistenceWF
{
	class Program
	{
		static void Main(string[] args)
		{

			while (true)
			{
				string option = Console.ReadLine();
				if (option == "1")
				{
					GenerateRandomClient n = new GenerateRandomClient();
					GenerateRandom g = new GenerateRandom();
					g.name = Console.ReadLine();
					string nb = n.GenerateRandom(g);
					Console.WriteLine(nb);
				}
				else
				{
					CheckNumberClient n = new CheckNumberClient();
					CheckNumber c = new CheckNumber();
					c.name = Console.ReadLine();
					string nb = n.CheckNumber(c);
					Console.WriteLine(nb);

				}
			}





















			while (true)
			{
				string option = Console.ReadLine();
				if (option == "1")
				{
					GetAppClient n = new GetAppClient();
					string name = Console.ReadLine();
					string custName = n.getApp(name);
					Console.WriteLine("Ok " + custName);
				}
				else
				{
					checkApp a = new checkApp();
					a.custName = Console.ReadLine();
					a.prototype = Console.ReadLine();
					CheckAppClient n = new CheckAppClient();
					string proto = n.checkApp(a);
					Console.WriteLine(proto);
					
				}
			}
			//string custName = n.


			// Send initial message to start the workflow service
			Console.WriteLine("Sending start message");
			StartOrderClient startProxy = new StartOrderClient();
			string orderId = startProxy.StartOrder("Chafic");
			Console.WriteLine(orderId);
			// The workflow service is now waiting for the second message to be sent
			Console.WriteLine("Workflow service is idle...");
			Console.WriteLine("Press [ENTER] to send an add item message to reactivate the workflow service...");
			Console.ReadLine();
			
			// Send the second message
			Console.WriteLine("Sending add item message");
			AddItemClient addProxy = new AddItemClient();
			AddItem item = new AddItem();
			item.pItemName = "Zone HD";
			item.pOrderId = orderId;

			string orderResult = addProxy.AddItem(item);
			Console.WriteLine("Service returned: " + orderResult);

			Console.ReadLine();
		}
	}
}
