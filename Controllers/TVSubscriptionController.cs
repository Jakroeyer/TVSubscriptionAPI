using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TVSubscriptionAPI.Services;

namespace TVSubscriptionAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/TVSubscription/Subscription")]
    public class TVSubscriptionController : ControllerBase
    {
        private ITVSubscriptionService _tvsubscriptionService;

        public TVSubscriptionController(ITVSubscriptionService tvsubscriptionService)
        {
            _tvsubscriptionService = tvsubscriptionService;
        }

        /// <summary>
        /// Adds a new subscription to the list.
        /// </summary>         
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> AddSubscription(Subscription subscription)
        {
            if(_tvsubscriptionService == null)
            {
                return NotFound();
            } 
            
            var result = _tvsubscriptionService.AddSubscription(subscription);
            return result;
        }

        /// <summary>
        /// Gets a list of all subscriptions.
        /// </summary>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Subscription>> GetSubscriptions()
        {
            if(_tvsubscriptionService == null)
            {
                return NotFound();
            }

            var result = _tvsubscriptionService.GetAllSubscriptions().ToList();
            return result;
        }

        /// <summary>
        /// Gets a list item of a subscription based on the given id.
        /// </summary>
        [HttpGet("Get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Subscription>> GetSubscription(int id)
        {
            if(_tvsubscriptionService == null)
            {
                return NotFound();
            }

            var result = _tvsubscriptionService.GetSubscription(id).ToList();
            return result;
        }

        /// <summary>
        /// Deletes a specific subscription.
        /// </summary>
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteSubscription(int id)
        {
            if(_tvsubscriptionService == null)
            {
                throw new Exception("Subscription not found");
            }

            _tvsubscriptionService.DeleteSubscription(id);

            return NoContent();
        }

    }
}