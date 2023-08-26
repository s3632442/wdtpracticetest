using System.ComponentModel.DataAnnotations;

public class Instructor
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Last Name")]
    [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
    public string LastName { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "First Name")]
    [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
    public string FirstName { get; set; }

    public DateTime HireDate { get; set; }


    [Display(Name = "Full Name")]
    public string FullName => $"{FirstName} {LastName}";

    public virtual ICollection<CourseAssignment> CourseAssignments { get; set; }
    public virtual OfficeAssignment OfficeAssignment { get; set; }

}