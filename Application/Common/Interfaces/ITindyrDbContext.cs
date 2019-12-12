using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface ITindyrDbContext 
    {
        DbSet<User> Users { get; set; }
        DbSet<UserProfile> UserProfiles { get; set; }
        DbSet<Match> Matches { get; set; } 
        DbSet<Animal> Animals { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
