using SchoolProject.Data.Entities;
using SchoolProject.Infrastacture.InfrastructureBases;
using SchoolProject.Infrastacture.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastacture.Abstracts
{
    //the class which has the implementation of the methods
    public interface IStudentRepository: IGenericRepositoryAsync<Student>
    {
       Task<List<Student>> GetStudentsListAsync();
    }
}
