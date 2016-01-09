using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WcfServiceCommon;
using Test1Common;
using Test2Common;

namespace WcfSvcTest
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var client1 = WcfServiceClient<IThatOneService>.Create("test1"))
			{
				var name = client1.Instance.GetName("seed");
				Console.WriteLine(name);
				
				int addressId = 8;
				var address = client1.Instance.GetAddress(addressId);
				Console.WriteLine("{0}", address.City);
			}

			using (var client2 = WcfServiceClient<IMyOtherService>.Create("test2"))
			{
				try
				{
					Console.WriteLine(client2.Instance.GetName("newseed"));
					var per = client2.Instance.GetPerson(7);
					Console.WriteLine("{0}, {1}", per.Name, per.Title);
				}
				catch (FaultException<WcfServiceFault> fault)
				{
					Console.WriteLine(fault.ToString());
				}
				catch (Exception e) //handles exceptions not in wcf communication
				{
					Console.WriteLine(e.ToString());
				}
			}

			Console.ReadLine();
		}
	}
}
