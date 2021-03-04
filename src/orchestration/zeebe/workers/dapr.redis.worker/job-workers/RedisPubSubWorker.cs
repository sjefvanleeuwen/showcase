using System;
using System.Threading;
using Zeebe.Client;
using Zeebe.Client.Api.Responses;
using Zeebe.Client.Api.Worker;

namespace dapr.redis.worker {
    public class RedisPubSubWorker {

        private string WorkerName = Environment.MachineName;
        public string Topic{get;set;}

        public RedisPubSubWorker(){}

        public RedisPubSubWorker(ZeebeDaprClient zeebeDaprClient, string topic)
        {
            Topic = topic;
            using (var signal = new EventWaitHandle(false, EventResetMode.AutoReset))
            {
                zeebeDaprClient.ZeebeClient.NewWorker()
                      .JobType(Topic)
                      .Handler(HandleJob)
                      .MaxJobsActive(5)
                      .Name(WorkerName)
                      .PollInterval(TimeSpan.FromSeconds(1))
                      .Timeout(TimeSpan.FromSeconds(10))
                      .Open();
                // blocks main thread, so that worker can run
               // signal.WaitOne();
            }

        }

        private static async void HandleJob(IJobClient jobClient, IJob job)
        {
            // no actual send topic to redis and no ack on receive 
            // from mico service
            await jobClient.NewCompleteJobCommand(job.Key).Send();
        }
    }
}