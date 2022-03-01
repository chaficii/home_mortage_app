using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WF4_GetUserState
{
	public class Data
	{
		public List<bool> inLawsuit = new List<bool>();
		public List<bool> hadBankrupcy = new List<bool>();
		public List<bool> hadForeclosure = new List<bool>();
		public List<bool> hasCreditHistory = new List<bool>();

		public Data()
		{
			inLawsuit.Add(false);
			inLawsuit.Add(true);
			inLawsuit.Add(false);
			inLawsuit.Add(false);
			inLawsuit.Add(false);
			inLawsuit.Add(true);
			inLawsuit.Add(false);
			inLawsuit.Add(false);
			inLawsuit.Add(true);
			inLawsuit.Add(false);
			inLawsuit.Add(true);

			hadBankrupcy.Add(false);
			hadBankrupcy.Add(false);
			hadBankrupcy.Add(false);
			hadBankrupcy.Add(false);
			hadBankrupcy.Add(true);
			hadBankrupcy.Add(false);
			hadBankrupcy.Add(false);
			hadBankrupcy.Add(false);
			hadBankrupcy.Add(true);
			hadBankrupcy.Add(true);
			hadBankrupcy.Add(true);

			hadForeclosure.Add(false);
			hadForeclosure.Add(false);
			hadForeclosure.Add(true);
			hadForeclosure.Add(false);
			hadForeclosure.Add(false);
			hadForeclosure.Add(false);
			hadForeclosure.Add(false);
			hadForeclosure.Add(false);
			hadForeclosure.Add(false);
			hadForeclosure.Add(true);
			hadForeclosure.Add(true);

			hasCreditHistory.Add(false);
			hasCreditHistory.Add(true);
			hasCreditHistory.Add(false);
			hasCreditHistory.Add(false);
			hasCreditHistory.Add(false);
			hasCreditHistory.Add(true);
			hasCreditHistory.Add(false);
			hasCreditHistory.Add(true);
			hasCreditHistory.Add(false);
			hasCreditHistory.Add(false);
			hasCreditHistory.Add(true);

		}


	}
}