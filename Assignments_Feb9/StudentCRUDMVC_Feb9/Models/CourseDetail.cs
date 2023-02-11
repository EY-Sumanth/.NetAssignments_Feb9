using System;
using System.Collections.Generic;

namespace StudentCRUDMVC_Feb9.Models
{
    public partial class CourseDetail
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int? CourseFee { get; set; }
        public string? CourseResult { get; set; }
    }
}
