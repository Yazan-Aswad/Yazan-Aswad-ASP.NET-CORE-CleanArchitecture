using SchoolProject.Data.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolProject.Data.Entities
{

    public class Subject : GeneralLocalizableEntity
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmetsSubjects = new HashSet<DepartmetSubject>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        public int SubID { get; set; }
        [StringLength(500)]
        // public string SubjectName { get; set; }
        public string? SubjectNameAr { get; set; }
        public string? SubjectNameEn { get; set; }
        public int Period { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }
    }

}
