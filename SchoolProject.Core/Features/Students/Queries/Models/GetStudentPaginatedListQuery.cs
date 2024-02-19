using MediatR;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Enums;


namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        //public string[]? OrderBy { get; set; }
        //we use enum class as property to make the property dropdownlist with enumclasss valus
        public StudentOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
