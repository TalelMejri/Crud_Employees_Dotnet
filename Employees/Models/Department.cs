using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Department Id")]
        public int DepartmentId { get; set; }

        [Required]
        [Column(TypeName="Varchar(150)")]
        [Display(Name ="Department Name")]

        public string DepartmentName{ get; set; }

        [Column(TypeName ="Varchar(5)")]
        [Display(Name ="Department Abbreviation")]
        public string DepartmentAbbr{ get; set; }

    }
}
