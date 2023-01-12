﻿namespace EmployeeManagement.Models
{
    
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>() { 
                new Employee() { Id=1, Name="Abhi",Email="abhi@ex.com",Department="SWE"},
                new Employee() { Id=2, Name="Sonu",Email="sonu@ex.com",Department="Engineer"},
                new Employee() { Id=3, Name="Sonal",Email="sonal@ex.com",Department="Doctor"},
                new Employee() { Id=4, Name="Khushi",Email="khushi@ex.com",Department="Scientist"}};
        }
        public void AddEmployee(Employee employee)
        {

            try
            {
                employee.Id = (_employeeList.Max(emp => emp.Id)) + 1;

            }
            catch (Exception)
            {
                employee.Id = 1;
            }
            _employeeList.Add(employee);
        }

        public void DeleteEmployee(int id)
        {
            try
            {
             Employee employee = GetEmployee(id);
            _employeeList.Remove(employee);

            }
            catch (Exception)
            {
                Console.WriteLine("Error Occured");
            }
            
        }

        public void EditEmployee(Employee employee)
        {
            Employee updtEmp = _employeeList.FirstOrDefault(emp => emp.Id == employee.Id);
            updtEmp.Id = employee.Id;
            updtEmp.Name = employee.Name;
            updtEmp.Email = employee.Email;
            updtEmp.Department = employee.Department;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList.ToList();
        }

        public Employee GetEmployee(int id)
        {
            Employee emp = _employeeList.SingleOrDefault(emp => emp.Id == id);
            return emp;
        }
    }
}
