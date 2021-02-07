/*
using System.Threading.Tasks;
using dapr.gql.basket.Repositories;
using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace dapr.gql.basket.Topics
{
    [ApiController]
    public class ProductResevationTopic : ControllerBase {

        [Inject] BasketRepository _repository {get;set;}
        [Inject] DaprClient _client {get;set;}

        /// <summary>
        /// A product reservation topic subscription. This assures that the item 
        /// can be added safely to the basket as its reserved by the inventory service.
        /// In order to tell Dapr that a message was processed successfully, return 
        /// a 200 OK response. If Dapr receives any other return status code than 200,
        /// or if your app crashes, Dapr will attempt to redeliver the message following
        ///  At-Least-Once semantics.
        /// </summary>
        [Topic("productreserved","productreserved")]
        [HttpPost]
        public async Task<IActionResult> Reserved([FromBody] string correlationId)
        {
            var productId = await _client.GetStateEntryAsync<int>("inventory","correlationId",ConsistencyMode.Strong);
           // await Task.Run(()=>_repository.Add());
            return this.Ok();
        }
    }
}
*/