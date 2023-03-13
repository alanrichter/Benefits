namespace Benefits.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public string FullName => FirstName + " " + LastName;

        public IEnumerable<DependentsViewModel>? Dependents { get; set; }
        public int NumberOfDependents => Dependents == null ? 0 : Dependents.Count();
        public double AnnualBenefitCost { get; set; }

    }
}
