using RepositoryWIthUOW.Core;
using RepositoryWIthUOW.Core.Interfaces;
using RepositoryWIthUOW.Core.Models;
using RepositoryWIthUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWIthUOW.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IDepartmentRepository  Departments {get; private set;}
          public IBaseRepository<Employee> Employees { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Departments= new DepartmentRepository(_context);

            Employees = new BaseRepository<Employee>(_context);

        }

      
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
