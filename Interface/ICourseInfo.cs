using LMS_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_App.Interface
{
    public interface ICourseInfo
    {
        public Task<List<Course>> ViewAllCourses();
        public Task<List<Course>> ViewAllCoursesByUserId(string UserId);
        public Task<List<Course>> ViewAllCoursesByTechnology(string TechId);
        public Task<List<Course>> ViewAllCoursesByCourseDuration(string TechId, int CourseFromRange, int CourseToRange);
        public Task<Course> AddCourse(Course course);
        public Task<Course> DeleteCourse(Course course);
    }
}
