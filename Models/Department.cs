using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Department
{
    [Key]
    public int DepartmentID { get; set; }

    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; }

    [DataType(DataType.Currency)]
    public decimal Budget { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }

    public int? InstructorID { get; set; }
    public virtual Instructor Instructor { get; set; }

    public virtual ICollection<Course> Courses { get; set; }
}
