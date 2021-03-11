using System;
using System.Collections.Generic;
using System.Linq;

namespace TVSubscriptionAPI.Services
{
    public class TVSubscriptionService : ITVSubscriptionService
    {
        private IList<Subscription> subscriptions;

        /// <summary>
        /// Create a list in memory of some stock data.
        /// </summary>
        public TVSubscriptionService()
        {
            subscriptions = new List<Subscription>();

            var subscription1 = new Subscription()
            {
                Id = 1,
                Name = "Subscription One",
                Price = 100
            };

            var subscription2 = new Subscription()
            {
                Id = 2,
                Name = "Subscription Two",
                Price = 200
            };

            var subscription3 = new Subscription()
            {
                Id = 3,
                Name = "Subscription Three",
                Price = 300
            };

            subscriptions.Add(subscription1);
            subscriptions.Add(subscription2);
            subscriptions.Add(subscription3);                        
        }

        /// <summary>
        /// Service to add a subscription to the list of subscriptions.
        /// </summary>
        public bool AddSubscription(Subscription subscription)
        {
            if(subscription != null)
            {
                //if the json body is not null, proceed to auto increment in case the value of the typed id, already exists in the list
                //until we meet the first unique integer for the id.
                while(subscriptions.Any(x => x.Id == subscription.Id))
                {
                    subscription.Id++;                    
                }
                if(subscriptions.Any(x => x.Id != subscription.Id))
                {
                    subscriptions.Add(subscription);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Service method that gets a list of all subscriptions.
        /// </summary>
        public IEnumerable<Subscription> GetAllSubscriptions()
        {
            return subscriptions;
        }

        /// <summary>
        /// Service method that deletes a specific subscription based on the id values of subsctions by the provided id.
        /// </summary>
        public void DeleteSubscription(int id)
        {
            if(id > 0 && id <= subscriptions.Count)
            {
                var item = subscriptions.Where(x => x.Id == id).First();
                subscriptions.Remove(item);
            }
            else
            {
                throw new InvalidOperationException("Id was invalid");
            }
        }

        /// <summary>
        /// Service method to get a specific subscription based on the id values of subsctions by the provided id.
        /// </summary>
        public IEnumerable<Subscription> GetSubscription(int id)
        {
            if(subscriptions.Count >= id)
            {
                return subscriptions.Where(x => x.Id == id);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Subscription with the specified id not found");
            }            
        }
    }
}