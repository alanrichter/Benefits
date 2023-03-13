using Benefits.DbContexts;
using Benefits.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Benefits.Repositories
{
    public class BenefitsRepository: IBenefitsRepository 
    {
        public BenefitsRepository(bool seed = false)
        {
            if (seed)
            {
                using (var context = new BenefitsContext())
                {
                    var Employees = new List<Employee> {
                        new Employee {
                            FirstName = "Test",
                            LastName = "One",
                            Dependents = null
                        },
                        new Employee {
                            FirstName = "Test",
                            LastName = "Two",
                            Dependents = new List<Dependent> {
                                new Dependent { FirstName = "Dep", LastName = "One" },
                                new Dependent { FirstName = "Dep", LastName = "Two" }
                            }
                        },
                        new Employee {
                            FirstName = "ADiscount",
                            LastName = "Test",
                            Dependents = null
                        },
                        new Employee {
                            FirstName = "Discount",
                            LastName = "Dependent",
                            Dependents = new List<Dependent> {
                                new Dependent { FirstName = "ADepOne", LastName = "Dependent" },
                                new Dependent { FirstName = "DepTwo", LastName = "Dependent" }
                            }
                        },
                        new Employee {
                            FirstName = "Discount",
                            LastName = "AllAround",
                            Dependents = new List<Dependent> {
                                new Dependent { FirstName = "ADepOne", LastName = "AllAround" },
                                new Dependent { FirstName = "ADepTwo", LastName = "AllAround" }
                            }
                        }
                    };
                    context.Employees.AddRange(Employees);
                    context.SaveChanges();
                }
            }
        }

        public Task<List<Employee>> GetEmployees()
        {
            using (var context = new BenefitsContext())
            {
                var list = context.Employees
                    .Include(e => e.Dependents)
                    .ToListAsync();
                return list;
            }
        }
        public Task<Employee> GetEmployeeById(int id)
        {
            using (var context = new BenefitsContext())
            {
                var employee = context.Employees
                    .Where(e => e.Id == id)
                    .Include(e => e.Dependents)
                    .FirstOrDefaultAsync();
                return employee;
            }
        }
    }
}