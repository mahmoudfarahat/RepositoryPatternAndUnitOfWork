﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWIthUOW.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int EmployeeCode { get; set; }

        public string Email { get; set; }

        public Department Department { get; set; }

    }
}
