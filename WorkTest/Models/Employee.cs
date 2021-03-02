using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkTest.Models
{
    [Table("Employees")]
    public class Employee
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        
        public decimal Salary { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }
    }
}
