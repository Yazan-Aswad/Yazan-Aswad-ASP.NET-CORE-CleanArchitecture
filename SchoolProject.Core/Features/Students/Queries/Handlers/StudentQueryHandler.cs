using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
        IRequestHandler<GetStudentsListQuery, Response<List<GetStudentsListResponse>>>,
        IRequestHandler<GetStudentByIDQuery, Response<GetSingleStudentResponse>>,
                IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>



    {

        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion
        /*#region Constructor
           public StudentQueryHandler(IStudentService studentService, IMapper mapper)
           {
               _studentService = studentService;
               _mapper = mapper;
           }
           #endregion*/
        #region Constructors
        public StudentQueryHandler(IStudentService studentService,
                                   IMapper mapper,
                                   IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handle Functions

        #endregion
        public async Task<Response<List<GetStudentsListResponse>>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {

            //using the service that will handle the request
            var studentList = await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentsListResponse>>(studentList);
            // return Success(studentListMapper);
            //add data to meta property
            var result = Success(studentListMapper);
            result.Meta = new { _Count = studentListMapper.Count() };
            return result;



        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {

            var student = await _studentService.GetStudentByIDWithIncludeAsync(request.Id);
            // if (student == null) return NotFound<GetSingleStudentResponse>("Object not found");
            //add localizer
            if (student == null) return NotFound<GetSingleStudentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var result = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(result);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            /* Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.NameAr, e.Address, e.Department.DNameAr);*/
            //add localize
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Localize(e.NameAr, e.NameEn), e.Address, e.Department.Localize(e.Department.DNameAr, e.Department.DNameEn));
            //_studentService.GetStudentsQuerable() to get the list paginated without the component search
            //  var queryable = _studentService.GetStudentsQuerable();

            // var FilterQuery = _studentService.FilterStudentPaginatedQuerable(request.Search); عدلناه مشان الاوردرنغ
            var FilterQuery = _studentService.FilterStudentPaginatedQuerable(request.OrderBy, request.Search);

            var PaginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            //add meta to paginated list
            PaginatedList.Meta = new { _Count = PaginatedList.Data.Count() };
            return PaginatedList;
        }
    }


}
