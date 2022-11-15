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
    public partial class User    {
        
            public User()
            {
                Courses = new HashSet<Course>();
            }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UserRole { get; set; }
        public string UserCourseId { get; set; }
        public string UserTechId { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
