using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class ConsumerFunction
    {
        [FunctionName("RunQueue")]
        [Singleton]
        public static void Run([QueueTrigger("singleton-test")]string myQueueItem, TraceWriter log)
        {
            log.Info(myQueueItem);
            Task.Delay(1000).Wait();
            log.Info(myQueueItem);
        }
    }
}
