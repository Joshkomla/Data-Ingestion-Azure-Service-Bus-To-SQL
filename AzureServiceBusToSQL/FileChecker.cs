using System.Collections.Specialized;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Xenhey.BPM.Core.Net6.Implementation;
using Xenhey.BPM.Core.Net6;

namespace AzureServiceBusToSQL
{
    public class FileChecker
    {
        private NameValueCollection nvc = new NameValueCollection();

        [FunctionName("FileChecker")]
        public void Run([TimerTrigger("%TimerInterval%")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string ApiKeyName = "x-api-key";
            //Ge file and update database information.
            nvc.Add(ApiKeyName, "3FB620B0E0FD4E8F93C9E4D839D00E1E");
            string requestBody = "{\"ProcessStarted\" : \"Yes\" }";
            var uploadFile = orchrestatorService.Run(requestBody);
            log.LogInformation(uploadFile);
        }

        private IOrchestrationService orchrestatorService
        {
            get
            {
                return new ManagedOrchestratorService(nvc);
            }
        }
    }
}