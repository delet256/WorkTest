using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkTest.Models
{
    [Table("Departments")]
    public class Department
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public decimal Salary { get; set; }
    }
}
