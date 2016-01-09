using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test1Common;
using System.ServiceModel;
using WcfServiceCommon;

namespace Test1Service
{
	public class ThatOneService : WcfServiceBase, IThatOneService
	{
		#region IThatOneService Members

		public string GetName(string seed)
		{
			return "Mr. " + seed.ToUpper();
		}

		public Address GetAddress(int id)
		{
			return new Address 
			{ 
				Line1 = "100 Main Street", 
				Line2 = "P.O. Box 100", 
				City = "MallTown", 
				State = "TX", 
				Zip = "12345" 
			};
		}

		#endregion
	}
}
