using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;


namespace Application.Common.Interfaces
{
    public interface IChatDbContext
    {
        DbSet<Conversation> Conversations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

}
