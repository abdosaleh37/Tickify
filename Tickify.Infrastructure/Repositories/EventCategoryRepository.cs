using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickify.Core.Entities;
using Tickify.Core.Interfaces.Repositories;
using Tickify.Infrastructure.Data;

namespace Tickify.Infrastructure.Repositories
{
    public class EventCategoryRepository : BaseRepository<EventCategory>, IEventCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public EventCategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
