using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Net.Http;
using System.Threading.Tasks;

namespace WorkflowService2
{

	public sealed class CodeActivity1 : CodeActivity
	{
		// Define an activity input argument of type string
		public InArgument<int> rate1 { get; set; }
		public InArgument<int> rate2 { get; set; }
		public InArgument<int> rate3 { get; set; }

		public OutArgument<int> finalRate { get; set; }
		// If your activity returns a value, derive from CodeActivity<TResult>
		// and return the value from the Execute method.
		protected override async void Execute(CodeActivityContext context)
		{
			int r1 = context.GetValue(this.rate1);
			int r2 = context.GetValue(this.rate2);
			int r3 = context.GetValue(this.rate3);

			if (r1 != 0)
			{
				context.SetValue(finalRate, r1);
			}
			else
			{
				if (r2 != 0)
				{
					context.SetValue(finalRate, r2);
				}
				else
				{
					context.SetValue(finalRate, r3);
				}
			}
			

		}
	}
}
