using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastacture.Abstracts;
using SchoolProject.Infrastacture.InfrastructureBases;
using SchoolProject.Infrastacture.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastacture.Repositories
{
    //نسمي الكلاس هنا بنفس اسم الانترفيس
    //public class StudentRepository :  IStudentRepository
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository

    {
        //private readonly ApplicationDBContext _dBContext;
        private readonly DbSet<Student> _students;
       
        //public StudentRepository(ApplicationDBContext dBContext)
        public StudentRepository(ApplicationDBContext dBContext):base(dBContext) 

        {
            //this._dBContext = dBContext;
            _students= dBContext.Set <Student> ();

    }
        public async Task<List<Student>> GetStudentsListAsync()
        {
            //return await _dBContext.students.ToListAsync();

            // return await _dBContext.students.Include(x => x.Department).ToListAsync();

            return await _students.Include(x => x.Department).ToListAsync();
        }
    }
}
