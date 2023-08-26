using System.ComponentModel.DataAnnotations;

public class Student
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

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Enrollment Date")]
    public DateTime EnrollmentDate { get; set; }

    [Display(Name = "Full Name")]
    public string FullName { get { return FirstName + " " + LastName; } }


    public virtual ICollection<Enrollment> Enrollments { get; set; }

}