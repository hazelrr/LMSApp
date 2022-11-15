using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LMS_App.Models
{
    [BsonIgnoreExtraElements]
    public partial class Course
    {
        [BsonId]       
        [BsonRepresentation(BsonType.ObjectId)]

        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string TechId { get; set; }
        public string UserId { get; set; }
        public int? CourseDuration { get; set; }
        public string CourseDesc { get; set; }
        public string CourseLink { get; set; }
        public virtual User User { get; set; }
    }
}
