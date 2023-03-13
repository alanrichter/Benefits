using Benefits.DbModels;

namespace Benefits.Repositories
{
    public interface IBenefitsRepository
    {
        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployeeById(int id);

        //void CreateEmployee(Employee employee);
        //void UpdateEmployee(Employee employee);
    }
}
