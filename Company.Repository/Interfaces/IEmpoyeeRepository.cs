
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Entities;

namespace Company.Repository.Interfaces
{
    public interface IEmpoyeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeeByName(string name);
        IEnumerable<Employee>GetEmployeesByAddress(string address);
    }
}
