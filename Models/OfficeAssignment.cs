using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OfficeAssignment
{
    [Key, ForeignKey("Instructor")]
    public int InstructorID { get; set; }

    [StringLength(50)]
    public string Location { get; set; }

    public virtual Instructor Instructor { get; set; }

}