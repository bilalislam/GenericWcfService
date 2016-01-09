using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using WcfServiceCommon;

namespace Test1Common
{
	[ServiceContract]
	public interface IThatOneService
	{
		[OperationContract, FaultContract(typeof(WcfServiceFault))]
		string GetName(string seed);

		[OperationContract, FaultContract(typeof(WcfServiceFault))]
		Address GetAddress(int id);
	}

	[DataContract]
	public class Address
	{
		[DataMember]
		public string Line1 { get; set; }

		[DataMember]
		public string Line2 { get; set; }

		[DataMember]
		public string City { get; set; }

		[DataMember]
		public string State { get; set; }

		[DataMember]
		public string Zip { get; set; }
	}
}
