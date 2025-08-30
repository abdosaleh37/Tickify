using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickify.Core.Interfaces.Repositories;
using Tickify.Infrastructure.Data;

namespace Tickify.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IApplicatonUserRepository ApplicationUsers { get; private set; }
        public ITicketRepository Tickets { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IPaymentRepository Payments { get; private set; }
        public IEventCategoryRepository EventCategories { get; private set; }
        public IEventRepository Events { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            ApplicationUsers = new ApplicationUserRepository();
            Tickets = new TicketRepository();
            Categories = new CategoryRepository();
            Payments = new PaymentRepository();
            EventCategories = new EventCategoryRepository();
            Events = new EventRepository();
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
