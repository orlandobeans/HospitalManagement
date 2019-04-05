using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework_CodeFirst.Core;
using EntityFramework_CodeFirst.Infrastructure.Repository;

namespace Service.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void DeleteDepartment(long id)
        {
            _departmentRepository.Delete(id);
        }

        public Department GetDepartment(long id)
        {
           return _departmentRepository.GetById(id);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _departmentRepository.GetAll;
        }

        public void InsertDepartment(Department department)
        {
            _departmentRepository.Insert(department);
        }

        public void UpdateDepartment(Department department)
        {
            _departmentRepository.Update(department);
        }
    }
}
