using AutoMapper;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Helper;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Department;
using Company.Service.Interfaces.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto employeeDto)
        {
            //    Employee employee = new Employee
            //    {
            //        Age = employeeDto.Age,
            //        DepartmentId = employeeDto.DepartmentId,
            //        Email = employeeDto.Email,
            //        HiringDate = employeeDto.HiringDate,
            //        ImageUrl = employeeDto.ImageUrl,
            //        Name = employeeDto.Name,
            //        PhoneNumber = employeeDto.PhoneNumber,
            //        Salary = employeeDto.Salary,

            //    };

            employeeDto.ImageUrl = DocumentSettings.UploadFile(employeeDto.Image, "Images");
        Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmpoyeeRepository.Add(employee);
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {

            Employee employee = _mapper.Map<Employee>(employeeDto);

            _unitOfWork.EmpoyeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {

            var employees = _unitOfWork.EmpoyeeRepository.GetAll();

            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id is null)

                return null;
            var employee = _unitOfWork.EmpoyeeRepository.GetById(id.Value);
            if (employee is null)
                return null;

        EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

       

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
         var employees=   _unitOfWork.EmpoyeeRepository.GetEmployeeByName(name);
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return mappedEmployees;
        }
           
   
        public void Update(EmployeeDto employee)
        {

            //_unitOfWork.EmpoyeeRepository.Update(employee);
            //_unitOfWork.Complete();
        }

        IEnumerable<EmployeeDto> IEmployeeService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

