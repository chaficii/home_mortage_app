using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;

namespace ProjetAGL
{

	class Program
	{
		static void Main(string[] args)
		{
			Activity workflow1 = new Workflow1()
			{
				customerId = "2",
				housePrice = 120000,
				downPercentage = 25,
				years = 5,
				salary = 2400
			};

			IDictionary<string, object> output = WorkflowInvoker.Invoke(workflow1);
			int amount = (int)output["rate"];
			Console.WriteLine("Workflow returned {0}% for my order rate", amount);
			Console.ReadLine();
		}
	}
}
