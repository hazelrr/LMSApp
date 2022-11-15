using LMS_App.Interface;
using LMS_App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseInfo icourseserviceInfo;

        public CourseController(ICourseInfo _icourseServiceInfo)
        {
            icourseserviceInfo = _icourseServiceInfo;
        }

        [HttpGet]
        [Route("ViewAllCourses")]
        public async Task<IActionResult> ViewAllCourses()
        {
            try
            {

                var courses = await icourseserviceInfo.ViewAllCourses();
                return new OkObjectResult(courses);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        // GET api/<CourseController>/5
        [HttpGet]
        [Route("GetAllCoursesByUserId/{UserId}")]
        public async Task<IActionResult> ViewAllCoursesByUserId(string UserId)
        {
            try
            {

                var courses = await icourseserviceInfo.ViewAllCoursesByUserId(UserId);
                return new OkObjectResult(courses);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // GET api/<CourseController>/5
        [HttpGet]
        [Route("GetAllCoursesByTechnology/{TechId}")]
        public async Task<IActionResult> GetAllCoursesByTechnology(string TechId)
        {
            try
            {

                var courses = await icourseserviceInfo.ViewAllCoursesByTechnology(TechId);
                return new OkObjectResult(courses);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // GET api/<CourseController>/5
        [HttpGet]
        [Route("GetAllCoursesByCourseDuration/{TechName}/{CourseFromRange}/{CourseToRange}")]
        public async Task<IActionResult> GetAllCoursesByCourseDuration(string? TechName, int CourseFromRange, int CourseToRange)
        {
            try
            {

                var courses = await icourseserviceInfo.ViewAllCoursesByCourseDuration(TechName, CourseFromRange, CourseToRange);
                return new OkObjectResult(courses);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // POST api/<CourseController>
        [HttpPost]
        [Route("AddCourse")]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            try
            {
                var courseDetails = await icourseserviceInfo.AddCourse(course);
                return new OkObjectResult(courseDetails);
                
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // POST api/<CourseController>
        [HttpDelete]
        [Route("DeleteCourse")]
        public async Task<IActionResult> DeleteCourse([FromBody] Course course)
        {
            try
            {
                var courseDetails = await icourseserviceInfo.DeleteCourse(course);
                return new OkObjectResult(courseDetails);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }       


    }
}
