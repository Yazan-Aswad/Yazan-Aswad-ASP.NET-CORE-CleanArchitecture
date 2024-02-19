using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        //هون بهمني بس الايدي تبع ال    طالب 
        //ماعندي فورم رح اتعامل معو متل الاضافة والتعديل
        public int Id { get; set; }
        public DeleteStudentCommand(int id)
        {
            Id=id;
        }
    }
}
