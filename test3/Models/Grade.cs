//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grade
    {
        public int GradeID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> CourseID { get; set; }
        public Nullable<decimal> Score { get; set; }
        public Nullable<System.DateTime> ExamDate { get; set; }
        public Nullable<int> SemesterID { get; set; }
        public Nullable<decimal> ScoreScale10 { get; set; }
        public Nullable<decimal> ScoreScale4 { get; set; }
        public string LetterGrade { get; set; }
    
        public virtual Cours Cours { get; set; }
        public virtual Student Student { get; set; }
        public virtual Semester Semester { get; set; }
    }
}
