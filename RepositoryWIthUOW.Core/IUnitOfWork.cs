using RepositoryWIthUOW.Core.Interfaces;
using RepositoryWIthUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWIthUOW.Core
{
    public interface IUnitOfWork :IDisposable
    {
        IBaseRepository<Employee> Employees { get; }
 
        IDepartmentRepository  Departments { get; }

        int Complete();

    }
}
