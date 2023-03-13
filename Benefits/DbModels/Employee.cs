using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benefits.DbModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Salary from DB, but constant for this exercise
        //assume 2k per paycheck -- 26 paychecks
        [NotMapped]
        public double Salary => 52000;
        public List<Dependent>? Dependents { get; set; }

    }
}