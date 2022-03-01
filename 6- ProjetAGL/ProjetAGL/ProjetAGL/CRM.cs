using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace ProjetAGL
{

	public sealed class CRM : CodeActivity
	{
		public InArgument<int> rate1 { get; set; }
		public InArgument<int> rate2 { get; set; }
		public InArgument<int> rate3 { get; set; }

		public OutArgument<int> finalRate { get; set; }
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
