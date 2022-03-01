using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.IO;
using System.Diagnostics;

namespace WorkflowService2
{

	public sealed class CodeActivity2 : CodeActivity
	{
		public InArgument<string> Text { get; set; }
		public OutArgument<string> result { get; set; }

		protected override void Execute(CodeActivityContext context)
		{
			string text = context.GetValue(this.Text);

			File.AppendAllText(@"D:\WorkflowLog.txt", "Customer Code is:" + text + Environment.NewLine);
			Debug.WriteLine("===============================================================" + "\n"+
				"===============================================================" + "\n"+
				text + "\n" +
				"==============================================================="+ "\n" +
				"===============================================================");
			context.SetValue(result, "Id is:" + text);
			
		}
	}
}
