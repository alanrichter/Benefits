using Benefits.DbModels;
using Benefits.Models;

namespace Benefits.Helpers
{
     public static class BenefitCostHelpers
    {
        private static double EmployeeBaseCost(string firstName, string lastName)
        {
            var BaseCost = 1000;
            if (NameStartsWithA(firstName) || NameStartsWithA(lastName))
            {
                return BaseCost * .9;
            }
            return BaseCost;
        }

        private static double EmployeeTotalCost(Employee employee)
        {
            var employeeCost = EmployeeBaseCost(employee.FirstName, employee.LastName);

            for (int i = 0; i < employee.Dependents.Count; i++)
            {
                employeeCost += DependentCost(employee.Dependents[i]);
            }

            return employeeCost;
        }

        private static double DependentCost(Dependent dependent)
        {
            var BaseCost = 500;
            if(NameStartsWithA(dependent.FirstName) || NameStartsWithA(dependent.LastName))
            {
                return BaseCost * .9;
            }
            return BaseCost;
        }

        private static bool NameStartsWithA(string name)
        {
            return name.ToUpper().StartsWith('A');
        }


        public static EmployeeViewModel CalculateCosts(Employee employee)
        {
            //get cost
            double cost = BenefitCostHelpers.EmployeeTotalCost(employee);
            //map employee to VM and return.
            EmployeeViewModel evm = new()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Salary = employee.Salary,
                AnnualBenefitCost = cost,
                Dependents = employee.Dependents.Count > 0 ?
                employee.Dependents.Select(d =>
                    new DependentsViewModel { Id = d.Id, FirstName = d.FirstName, LastName = d.LastName })
                    : null
            };
            return evm;
        }
    }
}