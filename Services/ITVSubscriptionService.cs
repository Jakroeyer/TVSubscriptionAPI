using System.Collections.Generic;

namespace TVSubscriptionAPI.Services
{
    public interface ITVSubscriptionService
    {
        bool AddSubscription(Subscription subscription);

        IEnumerable<Subscription> GetAllSubscriptions();

        void DeleteSubscription(int id);

        IEnumerable<Subscription> GetSubscription(int id);
    }
}