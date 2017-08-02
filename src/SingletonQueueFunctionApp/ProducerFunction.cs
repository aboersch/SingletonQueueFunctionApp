using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Threading.Tasks;
using System.Linq;

namespace FunctionApp1
{
    public static class Function
    {
        [FunctionName("CreateQueueItems")]
        [Singleton]
        public static async Task CreateQueueItems(
            [TimerTrigger("0 */15 * * * *", RunOnStartup = true)]TimerInfo myTimer,
            [Queue("singleton-test")]IAsyncCollector<string> queue,
            TraceWriter log)
        {
            
            await Task.WhenAll(System.Linq.Enumerable.Range(1, 10).Select(n => queue.AddAsync(n.ToString())));
        }
    }
}
