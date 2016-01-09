using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test2Common;
using System.ServiceModel;
using WcfServiceCommon;

namespace Test2Service
{
	public class MyOtherService : WcfServiceBase, IMyOtherService
	{
		#region IMyOtherService Members

		public string GetName(string seed)
		{
			base.Authorize();
			return "This is my name: " + seed.ToUpper();
		}

		public Person GetPerson(int id)
		{
			base.Authorize();
			return new Person { Name = "Donald Trumpet", Title = "King of the Hill" };
		}

		#endregion
	}
}
