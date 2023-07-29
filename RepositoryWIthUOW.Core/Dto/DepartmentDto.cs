using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWIthUOW.Core.Dto
{
    public class DepartmentDto
    {
        public string Name { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }
}
