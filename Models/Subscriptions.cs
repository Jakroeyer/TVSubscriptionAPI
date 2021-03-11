using System.ComponentModel.DataAnnotations;

namespace TVSubscriptionAPI.Services
{
    public class Subscription
    {
        [Required]
        public int Id {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public int Price {get; set;}
    }
}