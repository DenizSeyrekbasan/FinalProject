using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employee)
        {
            _employeeDal = employee;
        }

        public List<Employee> GetAll()
        {
            return _employeeDal.GetAll();
        }

        public List<Employee> GetAllByCategoryId(int id)
        {
            return _employeeDal.GetAll(p=>p.EmployeeId == id);
        }
    }
}
