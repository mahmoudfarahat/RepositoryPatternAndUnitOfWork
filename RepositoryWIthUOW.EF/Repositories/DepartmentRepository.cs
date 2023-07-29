using RepositoryWIthUOW.Core.Interfaces;
using RepositoryWIthUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWIthUOW.EF.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
          
        }

        public IEnumerable<Department> Special()
        {
            throw new NotImplementedException();
        }
    }
}
