using System.Data.Entity;

namespace TestNinja.Mocking.Employee
{
    public class EmployeeController
    {
        private readonly IEmployeeStorage _employeeStore;

        public EmployeeController(IEmployeeStorage employeeStore)
        {
            _employeeStore = employeeStore;
        }

        public ActionResult DeleteEmployee(int id)
        {
            _employeeStore.RemoveEmployee(id);

            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }
    
    public class EmployeeContext 
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}