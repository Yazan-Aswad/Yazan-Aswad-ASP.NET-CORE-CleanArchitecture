using SchoolProject.Data.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolProject.Data.Entities
{

    public partial class Department : GeneralLocalizableEntity
    {
        public Department()
        {
            //HashSet for avoiding NullReferenceExceptions when no Records are Fetched
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
            Instructors = new HashSet<Instructor>();

        }
        [Key]
        //زيادة الترقيم 1 عند اضافة ريكورد جديد
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int DID { get; set; }
        //replace it in fluentapi [StringLength(500)]
        //public string DName { get; set; }
        public string? DNameAr { get; set; }
        [StringLength(200)]
        public string? DNameEn { get; set; }

        //InsManager is the foreign key from instructor class
        public int? InsManager { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Student> Students { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }
        [InverseProperty("department")]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [ForeignKey("InsManager")]
        [InverseProperty("departmentManager")]
        public virtual Instructor? Instructor { get; set; }
    }
}
