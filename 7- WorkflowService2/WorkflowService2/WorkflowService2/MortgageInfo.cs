using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activities;
using System.Web;

namespace WorkflowService2
{
	public class MortgageInfo
	{
		public string customerCode { get; set; }
		public int housePrice { get; set; }
		public int downPayment { get; set; }
		public int years { get; set; }
		public int salary { get; set; }
		public CorrelationHandle customerCorrelationHandle { get; set; }
	}
}