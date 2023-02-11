using System;
using System.Collections.Generic;

namespace StudentCRUDMVC_Feb9.Models
{
    public partial class StudentDetail
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public int? StudentAge { get; set; }
        public string? StudentAddress { get; set; }
        public int? CourseId { get; set; }
    }
}
