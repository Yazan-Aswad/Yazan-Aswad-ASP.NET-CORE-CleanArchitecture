using AutoMapper;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile : Profile
    {

        public StudentProfile()
        {
            //CreateMap<TSource, TDistination>

            GetStudentListMapping();
            GetStudentByIDMapping();
            AddStudentCommandMapping();
            EditStudentCommandMapping();
        }
    }
}
