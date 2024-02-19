using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using System.Reflection;

namespace SchoolProject.Infrastacture.Repository
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext()
        {
                
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options ) 
        {

        }
        
        public DbSet<Department> departments { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<DepartmetSubject> departmetSubjects { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<StudentSubject> studentSubject { get; set; }


        #region FluentApi
        //we move all that to Configuration folder in infrastacture
        #endregion
        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<DepartmetSubject>()
                         .HasKey(x => new { x.SubID, x.DID });

             modelBuilder.Entity<Ins_Subject>()
                        .HasKey(x => new { x.SubId, x.InsId });

             modelBuilder.Entity<StudentSubject>()
                      .HasKey(x => new { x.SubID, x.StudID });

             modelBuilder.Entity<Instructor>()
                   .HasOne(x =>x.Supervisor)
                   .WithMany(x => x.Instructors)
                   .HasForeignKey(x => x.SupervisorId)
                   .OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<Department>(entity =>
             {
                 entity.HasKey(x=>x.DID);
                 entity.Property(x=> x.DNameAr).HasMaxLength(500);
                 entity.HasMany(x=> x.Students)
                       .WithOne(x => x.Department)
                       .HasForeignKey(x => x.DID)
                       .OnDelete(DeleteBehavior.Restrict);

                 entity.HasOne(x => x.Instructor)
                   .WithOne(x => x.departmentManager)
                   .HasForeignKey<Department>(x => x.InsManager)
                   .OnDelete(DeleteBehavior.Restrict);


             }); 

             modelBuilder.Entity<DepartmetSubject>(entity =>
             {


                 entity.HasOne(ds => ds.Department)
                   .WithMany(d => d.DepartmentSubjects)
                   .HasForeignKey(ds => ds.DID);

                  entity.HasOne(ds => ds.Subject)
                   .WithMany(d => d.DepartmetsSubjects)
                   .HasForeignKey(ds => ds.SubID);


             });
             modelBuilder.Entity<Ins_Subject>(entity =>
             {
                 entity.HasOne(ds => ds.instructor)
                   .WithMany(d => d.Ins_Subjects)
                   .HasForeignKey(ds => ds.InsId);

                 entity.HasOne(ds => ds.Subject)
                  .WithMany(d => d.Ins_Subjects)
                  .HasForeignKey(ds => ds.SubId);


             });   
             modelBuilder.Entity<StudentSubject>(entity =>
             {
                 entity.HasOne(ds => ds.Student)
                   .WithMany(d => d.StudentSubject)
                   .HasForeignKey(ds => ds.StudID);

                 entity.HasOne(ds => ds.Subject)
                  .WithMany(d => d.StudentsSubjects)
                  .HasForeignKey(ds => ds.SubID);


             });

             base.OnModelCreating(modelBuilder);
         }*/



        #region this code when using Configuration Folder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        #endregion

    }

}

