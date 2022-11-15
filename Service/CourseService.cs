using LMS_App.Interface;
using LMS_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_App.Service
{
    public class CourseService : ICourseInfo
    {
        private readonly ISqlDataRepository sqldataRepository;
        //dependency injection
        public CourseService(ISqlDataRepository _sqldataRepository)
        {
            sqldataRepository = _sqldataRepository;
        }

        public async Task<List<Course>> ViewAllCourses()
        {
            try
            {
                return await sqldataRepository.ViewAllCourses();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<List<Course>> ViewAllCoursesByUserId(string userId)
        {
            try
            {
                return await sqldataRepository.ViewAllCoursesByUserid(userId);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<List<Course>> ViewAllCoursesByTechnology(string techid)
        {
            try
            {
                return await sqldataRepository.ViewAllCoursesByTechnology(techid);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public async Task<List<Course>> ViewAllCoursesByCourseDuration(string techname, int coursefromrange, int coursetorange)
        {
            try
            {
                List<Course> courses = new List<Course>();
                var techid = await sqldataRepository.ViewAllCoursesByTechnologyName(techname);
                foreach(var i in techid)
                {
                     courses = await sqldataRepository.ViewAllCoursesByCourseDuration(i.TechId, coursefromrange, coursetorange);
                }
                return courses;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<Course> AddCourse(Course course)
        {
            try
            {
                var exists = await sqldataRepository.ViewAllCoursesByCourseName(course.CourseName);
                if (exists.Count== 0)
                {
                    var courses = await sqldataRepository.AddCourse(course);
                    return courses;
                }
                else
                {
                    throw new Exception("Course already exists. Please add a new one!!");
                }
               
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<Course> DeleteCourse(Course course)
        {
            try
            {
                var exists = sqldataRepository.ViewAllCoursesByCourseName(course.CourseName);
                if (exists.Result.Count != 0)
                {
                    var courses = await sqldataRepository.DeleteCourse(course);

                    return courses;
                }
                else
                {
                    throw new Exception("Course does not exist...");
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }
}
