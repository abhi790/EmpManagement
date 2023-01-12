using EmployeeManagement.Models;
namespace EmployeeManagement.Models
{
    
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public SQLEmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public void AddEmployee(Employee employee)
        {
            try{
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch(Exception ){
                throw;
            }
            
        }

        public void DeleteEmployee(int id)
        {
            try{
                Employee emp = GetEmployee(id);
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
            catch(Exception ){
                throw;
            }
        }

        public Employee GetEmployee(int id)
        {
            try{
                Employee emp = _context.Employees.SingleOrDefault(emp => emp.Id == id);
                return  emp;
                
            }
            catch(Exception ){
                throw;
            }

        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            try{

                return _context.Employees.ToList();
            }
            catch(Exception ){
                throw;
            }
        }

        public void EditEmployee(Employee employee)
        {
            try{
                Employee currentEmp = GetEmployee(employee.Id);
                if(currentEmp != null){
                    currentEmp.Name = employee.Name;
                    currentEmp.Email = employee.Email;
                    currentEmp.Department = employee.Department;
                    _context.SaveChanges();
                }
                
            }
            catch(Exception ){
                throw;
            }
        }
    }
}
