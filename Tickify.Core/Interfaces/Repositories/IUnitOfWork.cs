using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickify.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Complete();
    }
}
