using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.IO;
using Facebook;
using System.Dynamic;

namespace WorkflowService1
{

	public sealed class CodeActivity1 : CodeActivity
	{
		// Define an activity input argument of type string
		public InArgument<string> Text { get; set; }
		public OutArgument<string> result { get; set; }

		// If your activity returns a value, derive from CodeActivity<TResult>
		// and return the value from the Execute method.
		protected override void Execute(CodeActivityContext context)
		{
			string text = context.GetValue(this.Text);

			File.AppendAllText(@"D:\WorkflowLog.txt", "Result is:" + text);
			context.SetValue(result, "Result is:" + text);

			

		}
	}
}
