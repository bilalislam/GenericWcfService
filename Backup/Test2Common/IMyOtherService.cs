using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using WcfServiceCommon;

namespace Test2Common
{
	[ServiceContract]
	public interface IMyOtherService
	{
		[OperationContract, FaultContract(typeof(WcfServiceFault))]
		string GetName(string seed);

		[OperationContract, FaultContract(typeof(WcfServiceFault))]
		Person GetPerson(int id);
	}

	[DataContract]
	public class Person
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string Title { get; set; }
	}
}
