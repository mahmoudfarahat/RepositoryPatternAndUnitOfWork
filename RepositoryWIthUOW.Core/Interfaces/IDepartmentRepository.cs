using RepositoryWIthUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWIthUOW.Core.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        IEnumerable<Department> Special();

    }
}
