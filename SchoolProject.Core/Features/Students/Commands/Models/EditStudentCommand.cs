using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Students.Commands.Models
{

    //response is string not object
    //response is edit is done or not
    public class EditStudentCommand : IRequest<Response<string>>
    {
        //we add id property which means accept the id number to check if exist
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int DepartmementId { get; set; }
    }
}
