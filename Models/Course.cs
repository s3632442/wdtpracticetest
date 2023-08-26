using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Course
{
    [Key]
    public int CourseID { get; set; }

    [StringLength(50, MinimumLength = 3)]
    [Display(Name = "Course Title")]
    public string Title { get; set; }

    [Range(0, 5)]
    public int Credits { get; set; }

    [ForeignKey("Department")]
    public int DepartmentID { get; set; }


    public virtual Department Department { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; }

    public virtual ICollection<CourseAssignment> CourseAssignments { get; set; }

}