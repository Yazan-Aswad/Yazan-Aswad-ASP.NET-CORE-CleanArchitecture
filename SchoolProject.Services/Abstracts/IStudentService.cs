using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsListAsync();
        //GetStudentByIDWithIncludeAsync(int id) ==> we use it if want to get the department associated with th student, we need it with queries
        public Task<Student> GetStudentByIDWithIncludeAsync(int id);
        //GetByIdAsync ==> we use to get just student without the department name, we need it with commands like add and delete 
        public Task<Student> GetByIdAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<bool> IsNameExist(string nameAr);
        public Task<bool> IsNameExistExcludeSelf(string name, int id);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        //for paginated
        public IQueryable<Student> GetStudentsQuerable();
        public IQueryable<Student> GetStudentsByDepartmentIDQuerable(int DID);
        //public IQueryable<Student> FilterStudentPaginatedQuerable(string search); عدلناه مشان الاوردرتغ
        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search);
    }
}
