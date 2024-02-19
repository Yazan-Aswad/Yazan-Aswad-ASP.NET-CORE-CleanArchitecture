using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Core.Features.Students.Queries.Results
{
    //GetStudentsListResponse is the View Model Of Student Class

    public class GetStudentsListResponse
    {
      
        public int StudID { get; set; }
   
        public string Name { get; set; }
        
        public string Address { get; set; }
       
       
        public string? DepartmentName { get; set; }
    }
}
