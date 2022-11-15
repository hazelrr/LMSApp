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
    public partial class Technology
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TechId { get; set; }
        public string TechName { get; set; }
        public string CourseId { get; set; }
    }
}
