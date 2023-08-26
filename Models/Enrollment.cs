using System.ComponentModel.DataAnnotations;

public enum Grade
    {
        A, B, C, D, E, F
    }

public class Enrollment
{
    
    [Key]
    public int EnrollmentID { get; set; }

    public int CourseID { get; set; }

    public int StudentID { get; set; }

    [EnumDataType(typeof(Grade))]
    public Grade? Grade { get; set; }

    public virtual Course Course { get; set; }

    public virtual Student Student { get; set; }


}