namespace TestNinja.Mocking.Employee
{
    public class EmployeeStorage : IEmployeeStorage
    {
        private readonly EmployeeContext _db;
        
        public EmployeeStorage()
        {
            _db = new EmployeeContext();
        }
        
        public void RemoveEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}