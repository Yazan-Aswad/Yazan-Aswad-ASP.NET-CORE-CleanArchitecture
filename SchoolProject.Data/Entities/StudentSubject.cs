using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text;

    public class StudentSubject
    {
    /* [Key]
     public int StudSubID { get; set; }*/

    //we use composite key and add the next to the applicationdbcontext because we have composite key
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmetSubject>()
                    .HasKey(x => new { x.SubID, x.DID });

        modelBuilder.Entity<Ins_Subject>()
                   .HasKey(x => new { x.SubId, x.InsId });
        modelBuilder.Entity<StudentSubject>()
                 .HasKey(x => new { x.SubID, x.StudID });*/

        [Key]
        public int StudID { get; set; }
        [Key]
        public int SubID { get; set; }
         public decimal? grade { get; set; }


    [ForeignKey("StudID")]
    [InverseProperty("StudentSubject")]
    public virtual Student? Student { get; set; }

    [ForeignKey("SubID")]
    [InverseProperty("StudentsSubjects")]
    public virtual Subject? Subject { get; set; }

}
