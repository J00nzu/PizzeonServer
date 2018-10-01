using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeon_server.Models;
using Pizzeon_server.Processors;
namespace Pizzeon_server.Controllers
{
    [Route("api/store")]
	[ApiController]
    public class StoreController : ControllerBase
    {
        private StoreProcessor _processor;
        public StoreController (StoreProcessor storeProcessor) {
            _processor = storeProcessor;
        }

        [HttpPost("hat")]
        public ActionResult CreateHat([FromBody] NewHat hat) {
            _processor.CreateHat(hat);
            return Ok();
        }

        [HttpPost("color")]
        public ActionResult CreateColor([FromBody] NewColor color) {
            _processor.CreateColor(color);
            return Ok();
        }

        [HttpPost("avatar")]
        public ActionResult CreateAvatar([FromBody] NewAvatar avatar) {
            _processor.CreateAvatar(avatar);
            return Ok();
		}

		[HttpPost("hat/buy")]
		public ActionResult BuyHat([FromBody] StoreTransaction transaction) {
			_processor.BuyHat(transaction.playerId, transaction.itemId);
			return Ok();
		}

		[HttpPost("color/buy")]
		public ActionResult BuyColor([FromBody] StoreTransaction transaction) {
			_processor.BuyColor(transaction.playerId, transaction.itemId);
			return Ok();
		}

		[HttpPost("avatar/buy")]
		public ActionResult BuyAvatar([FromBody] StoreTransaction transaction) {
			_processor.BuyAvatar(transaction.playerId, transaction.itemId);
			return Ok();
		}

		[HttpGet("hat")]
        public IEnumerable<Hat> GetAllHats() {
			return _processor.GetAllHats().Result;
        }

        [HttpGet("color")]
        public IEnumerable<Color> GetAllColors() {
			return _processor.GetAllColors().Result;
		}

        [HttpGet("avatar")]
        public IEnumerable<Avatar> GetAllAvatars() {
			return _processor.GetAllAvatars().Result;
		}
    }
}