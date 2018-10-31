using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Pizzeon_server.Models;

namespace PizzeonAzureFunctions.Functions
{
    public static class StoreCreate
    {
        [FunctionName("StoreCreate")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Admin, "post", Route = "store/{type}")]HttpRequestMessage req, TraceWriter log, string type)
        {
            log.Info("Creating a new store item");

	        switch (type) {
		        case "hat":
			        dynamic newHat = await req.Content.ReadAsAsync<NewHat>();
			        if (newHat == null) {
				        return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a valid json object in the body");
			        }

			        Hat hat = new Hat();
			        hat.Name = newHat.Name;
			        hat.Id = newHat.Id;
			        hat.Description = newHat.Description;
			        hat.Price = newHat.Price;
			        await MongoDbRepository.CreateHat(hat);
					return req.CreateResponse(HttpStatusCode.OK);
		        case "color":
			        dynamic newColor = await req.Content.ReadAsAsync<NewColor>();
			        if (newColor == null) {
				        return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a valid json object in the body");
			        }

					Color color = new Color();
			        color.Name = newColor.Name;
			        color.Id = newColor.Id;
			        color.Price = newColor.Price;
			        await MongoDbRepository.CreateColor(color);

					return req.CreateResponse(HttpStatusCode.OK);
		        case "avatar":
			        dynamic newAvatar = await req.Content.ReadAsAsync<NewAvatar>();
			        if (newAvatar == null) {
				        return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a valid json object in the body");
			        }

					Avatar avatar = new Avatar();
			        avatar.Name = newAvatar.Name;
			        avatar.Id = newAvatar.Id;
			        avatar.Price = newAvatar.Price;
			        await MongoDbRepository.CreateAvatar(avatar);

					return req.CreateResponse(HttpStatusCode.OK);
		        default:
			        return req.CreateResponse(HttpStatusCode.NotFound);
	        }
		}
    }
}