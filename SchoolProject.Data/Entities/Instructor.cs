using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Instructor : GeneralLocalizableEntity
    {

        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int InsId { get; set; }
        public string? ENameAr { get; set; }
        public string? ENameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        //InsId is the same as SupervisorId
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public string? Image { get; set; }
        public int? DID { get; set; }

        [ForeignKey(nameof(DID))]
        //Instructors is the name from department class public virtual ICollection<Instructor> Instructors { get; set; }
        [InverseProperty("Instructors")]
        public Department? department { get; set; }

        [InverseProperty("Instructor")]
        public Department? departmentManager { get; set; }
        //one علاقة مع نفسه وهي طرف ال 
        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty("Instructors")]
        public Instructor Supervisor { get; set; }
        //many علاقة مع نفسه وهي طرف ال 
        [InverseProperty("Supervisor")]

        public virtual ICollection<Instructor> Instructors { get; set; }
        [InverseProperty("instructor")]

        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }





    }

}
