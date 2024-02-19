using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Department.Queries.Results
{
    public class GetDepartmentByIDResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        //StudentResponse هي يعني انو انت شايل ليست من ال 
        //public List<StudentResponse>? StudentList { get; set; }
        public PaginatedResult<StudentResponse>? StudentList { get; set; }

        public List<SubjectResponse>? SubjectList { get; set; }
        public List<InstructorResponse>? InstructorList { get; set; }
        //StudentList InstructorList SubjectList is DTO Classes
    }
    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentResponse(int id, string name)
        {
            Id=id;
            Name=name;
        }
    }
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class InstructorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
