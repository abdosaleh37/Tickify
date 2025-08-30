using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickify.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicatonUserRepository ApplicationUsers { get; }
        ITicketRepository Tickets { get; }
        ICategoryRepository Categories { get; }
        IPaymentRepository Payments { get; }
        IEventCategoryRepository EventCategories { get; }
        IEventRepository Events { get; }

        Task<int> Complete();
    }
}
