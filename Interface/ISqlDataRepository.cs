using LMS_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_App.Interface
{
    public interface ISqlDataRepository
    {
        public Task<User> AddUser(User user);
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUserByEmailAddress(string emailId);
        public Task<User> GetUserByUserId(string userId);
        public Task<User> ModifyUser(User user);
        public Task<Course> AddCourse(Course courseInfo);
        public Task<Course> DeleteCourse(Course courseInfo);
        public Task<List<Course>> ViewAllCourses();
        public Task<List<Course>> ViewAllCoursesByTechnology(string techid);
        public Task<List<Technology>> ViewAllCoursesByTechnologyName(string techname);
        public Task<List<Course>> ViewAllCoursesByCourseDuration(string techid, int durationfromrange, int durationtorange);
        public Task<List<Course>> ViewAllCoursesByUserid(string userid);
        public Task<List<Course>> ViewAllCoursesByCourseName(string coursename);



    }
}
