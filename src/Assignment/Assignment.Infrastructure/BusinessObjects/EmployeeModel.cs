namespace Assignment.Infrastructure.BusinessObjects
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Postion { get; set; }
        public decimal SalaryAmount { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
