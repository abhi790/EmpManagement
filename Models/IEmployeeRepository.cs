namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployee(int id);
        void EditEmployee(Employee employee);
        void DeleteEmployee(int id);
        void AddEmployee(Employee employee);
    }
}
