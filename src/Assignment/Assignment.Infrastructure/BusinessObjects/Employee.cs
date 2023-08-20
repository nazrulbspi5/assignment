namespace Assignment.Infrastructure.BusinessObjects
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ManagerId { get; set; }
        public string? Postion { get; set; }
        public decimal SalaryAmount { get; set; }
        public DateTime JoiningDate { get; set; }
        public bool IsBonusAdded { get; set; }
    }
}
