using Dapr.Client;
using NLog.Extensions.Logging;
using Zeebe.Client;

namespace dapr.redis.worker {
    public class ZeebeDaprClient : IZeebeDaprClient {
        private ZeebeClient zeebeClient;
        private DaprClient daprClient;
        public DaprClient DaprClient {get{return daprClient;}}
        public ZeebeClient ZeebeClient {get{return zeebeClient;}}

        public ZeebeDaprClient(){ 
            CreateClient("localhost:26500");
        }

        public void CreateClient(string gatewayAddress){ 
             zeebeClient = Zeebe.Client.ZeebeClient.Builder()
                .UseLoggerFactory(new NLogLoggerFactory())
                .UseGatewayAddress(gatewayAddress)
                .UsePlainText()
                .Build() as ZeebeClient;
            daprClient = new DaprClientBuilder().Build();
        }
    }

    public interface IZeebeDaprClient
    {
        DaprClient DaprClient {get;}
        ZeebeClient ZeebeClient {get;}
        void CreateClient(string gatewayAddress);
    }
}