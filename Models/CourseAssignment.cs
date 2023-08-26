using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CourseAssignment
{

    [ForeignKey("Course")]
    [Key, Column(Order = 0)]
    public int CourseID { get; set; }

    [ForeignKey("Instructor")]
    [Key, Column(Order = 1)]
    public int InstructorID { get; set; }

    public virtual Course Course { get; set; }

    public virtual Instructor Instructor { get; set; }


}