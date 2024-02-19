using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Core.Features.Students.Queries.Models
{

    //IRequest<List<Student>> means the request will return list of Students

    //public class GetStudentsListQuery: IRequest<List<Student>>


    //GetStudentsListResponse is the View Model Of Student Class
    public class GetStudentsListQuery : IRequest<Response <List<GetStudentsListResponse>>>

    {


    }
}
