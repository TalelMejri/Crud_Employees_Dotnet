using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Models
{
    [Table("Employee",Schema ="dbo")]
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name="Employee Id")]
        public int EmployeeID { get; set; }

        [Required]
        [Column(TypeName ="Varchar(5)")]
        [MaxLength(5)]
        [Display(Name ="Employee Number")]
        public string  EmployeeNumber { get; set; }

        [Required]
        [Column(TypeName ="Varchar(150)")]
        [MaxLength(5)]
        [Display(Name ="Employee Name")]
        public string EmployeeName{ get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        [Display(Name ="Date of birth")]
        public DateTime DOB { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hiring Date")]
        [DisplayFormat(DataFormatString ="{0:dd-MMM-yyyy}")]
        public DateTime HiringBirth { get; set; }

        [Required]
        [Column(TypeName ="decimal(12,2)")]
        [Display(Name ="Gross Salary")]
        public decimal GrossSalary { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        [Display(Name = "Net Salary")]
        public decimal NetSalary { get; set; }

        [ForeignKey("Department")]
        [Required]
        public int DepartmentId { get; set; }

        [Display(Name =("Department"))]
        [NotMapped]
        public string DepartmentName { get; set; }

        public virtual Department Department{ get; set; }

    }
}
