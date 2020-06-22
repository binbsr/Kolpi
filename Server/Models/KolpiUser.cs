using Kolpi.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace Kolpi.Server.Models
{
    public class KolpiUser : IdentityUser
    {
        // One-to-One to Reputation, Foreign Key and navigation property
        public int ReputationId { get; set; }
        public Reputation Reputation { get; set; }
    }
}
