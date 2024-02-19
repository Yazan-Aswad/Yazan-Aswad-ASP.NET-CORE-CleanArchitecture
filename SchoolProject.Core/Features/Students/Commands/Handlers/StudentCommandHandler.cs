using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                       IRequestHandler<AddStudentCommand, Response<string>>,
                                       IRequestHandler<EditStudentCommand, Response<string>>,
                                         IRequestHandler<DeleteStudentCommand, Response<string>>

    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;


        #endregion

        #region Constructors
        /*    public StudentCommandHandler(IStudentService studentService,
                                         IMapper mapper)
            {
                _studentService = studentService;
                _mapper = mapper;
            }*/
        #endregion

        public StudentCommandHandler(IStudentService studentService,
                                IMapper mapper,
                                IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = localizer;
        }



        #region Handle Functions

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //mapping Between request and student
            var studentmapper = _mapper.Map<Student>(request);
            //add
            var result = await _studentService.AddAsync(studentmapper);
            //check condition
            //if (result == "Exist") return new Response<string>("Name Is Exist");
            //return response
            //else
            if (result == "Success") return Created("Added Succefully");

            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var student = await _studentService.GetByIdAsync(request.Id);
            //return NotFound
            if (student == null) return NotFound<string>("Name not Exist");
            //mapping Between request and student
            //var studentmapper = _mapper.Map<Student>(request); is not good becuse it transfer the hole object to viwe model but _mapper.Map(request, student) transfer the specified properties

            var studentmapper = _mapper.Map(request, student);
            //Call service that make Edit
            var result = await _studentService.EditAsync(studentmapper);
            //return response
            if (result == "Success") return Success($"Edit Succeded for Student with ID    {studentmapper.StudID}");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //Check if the Id is Exist Or not
            var student = await _studentService.GetByIdAsync(request.Id);
            //return NotFound
            if (student == null) return NotFound<string>("Student Is Not Found");
            //Call service that make Delete
            var result = await _studentService.DeleteAsync(student);
            if (result == "Success") return Deleted<string>("Student Is Deleted");
            else return BadRequest<string>();
        }


        #endregion

    }
}
