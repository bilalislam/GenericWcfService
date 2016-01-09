using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WcfServiceCommon
{
    public class WcfServiceClient<TClient> : ClientBase<TClient>, IDisposable where TClient : class
    {
        public static WcfServiceClient<TClient> Create(string key)
        {
            Type clientType = typeof(TClient);
            var configItem = Config.GetServiceConfig(clientType);
            if (null != configItem)
            {
                NetTcpBinding tcpBinding = TcpBindingUtility.CreateNetTcpBinding();
                EndpointAddress endpointAddress = TcpBindingUtility.CreateEndpointAddress(
                    configItem.Item.ServiceAddressPort + "/" + configItem.Item.EndpointName);

                WcfServiceClient<TClient> client = new WcfServiceClient<TClient>(tcpBinding, endpointAddress);
                return client;
            }
            throw new Exception(clientType.AssemblyQualifiedName);
        }

        internal WcfServiceClient() { }

        internal WcfServiceClient(string endpointConfigurationName) : base(endpointConfigurationName) { }

        internal WcfServiceClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress) { }

        internal WcfServiceClient(InstanceContext callbackInstance) : base(callbackInstance) { }

        public TClient Instance
        {
            get { return base.Channel; }
        }

        public void Dispose()
        {
            AbortClose();
        }

        public void AbortClose()
        {
            //avoid the CommunicationObjectFaultedException 
            if (this.State != CommunicationState.Closed) this.Abort();
            //safe to close the client
            this.Close();
        }

    }
}
