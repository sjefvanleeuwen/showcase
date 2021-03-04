using System.Threading.Tasks;
using System.Threading;

namespace dapr.redis.worker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*
            var client = await Zeebe.Client.ZeebeClient.Builder()
                .UseLoggerFactory(new NLogLoggerFactory())
                .UseGatewayAddress(ZeebeUrl)
                .UsePlainText()
                .Build();
            */

            var client = new ZeebeDaprClient();

            var deployResponse = await client.ZeebeClient.NewDeployCommand()
                .AddResourceFile("./resources/order-process.bpmn")
                .Send();

            // create workflow instance
            var workflowKey = deployResponse.Workflows[0].WorkflowKey;

            var workflowInstance = await client.ZeebeClient
                .NewCreateWorkflowInstanceCommand()
                .WorkflowKey(workflowKey)
                .Variables("{\"someValue\":42}")
                .Send();

            // for now complete all steps, without pub/sub redis
            var svc2 = new RedisPubSubWorker(client,"inventory-service");
            var svc1 = new RedisPubSubWorker(client,"payment-service");
            var svc3 = new RedisPubSubWorker(client,"shipment-service");
            using (var signal = new EventWaitHandle(false, EventResetMode.AutoReset))
            {
                signal.WaitOne();
            }
           
        }
    }
}
