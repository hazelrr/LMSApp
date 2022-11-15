using LMS_App.Interface;
using LMS_App.Models;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace LMS_App.Repository
{
    public class SqlDataRepository : ISqlDataRepository
    {
        //private readonly DbContext db;
        //private readonly DbSet<Course> courseDb;
        //private readonly DbSet<Technology> technologyDb;
        //private readonly DbSet<User> userDb;

        //public SqlDataRepository(LMS_DbContext lmsDbContext)
        //{
        //    db = lmsDbContext;
        //    courseDb = db.Set<Course>();
        //    technologyDb = db.Set<Technology>();
        //    userDb = db.Set<User>();
        //}


        private readonly IMongoCollection<User> userDb;
        private readonly IMongoCollection<Course> courseDb;
        private readonly IMongoCollection<Technology> technologyDb;
        private readonly LMS_AppConfig _settings;

        public SqlDataRepository(IOptions<LMS_AppConfig> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.LMS_DbConnectionString);
            var database = client.GetDatabase(_settings.DataBaseName);
            userDb = database.GetCollection<User>(_settings.UserCollectionName);
            courseDb = database.GetCollection<Course>(_settings.CourseCollectionName);
            technologyDb = database.GetCollection<Technology>(_settings.TechnologyCollectionName);
        }



        public async Task<User> AddUser(User userInfo)
        {
            userInfo.CreatedOn = DateTime.Now;
            userInfo.UpdatedOn = DateTime.Now;
            //var user = userDb.Add(userInfo).Entity;
            //sql- userDb.Add(userInfo).State = EntityState.Added;
            //sql- var user = userDb.AddAsync(userInfo);
            await userDb.InsertOneAsync(userInfo);
            //sql- await db.SaveChangesAsync();
            return userInfo;           
        }

        public async Task<List<User>> GetAllUsers()
        {
            //sql-return userDb.ToListAsync();
            return await userDb.Find(x => true).ToListAsync();
        }

        public async Task<User> GetUserByEmailAddress(string emailId)
        {
            //sql- return userDb.Where(x => x.EmailAddress == emailId).FirstOrDefault();
            return userDb.Find<User>(x => x.EmailAddress == emailId).FirstOrDefault();
        }

        public async Task<User> GetUserByUserId(string userId)
        {
            //sql-return userDb.Where(x => x.UserId == userId).FirstOrDefault();
            return userDb.Find<User>(x => x.UserId == userId.ToString()).FirstOrDefault();
        }

        public async Task<User> ModifyUser(User userInfo)
        {
            //sql-userDb.Update(userInfo).State = EntityState.Modified;
            //sql-await db.SaveChangesAsync();
            await userDb.ReplaceOneAsync(c => c.UserId == userInfo.UserId, userInfo);
            return userInfo;           
        }

        public async Task<Course> AddCourse(Course courseInfo)
        {
            //sql- var addedcourse = courseDb.AddAsync(courseInfo);
            //sql-await db.SaveChangesAsync();
            await courseDb.InsertOneAsync(courseInfo);
            return courseInfo;
        }

        public async Task<Course> DeleteCourse(Course courseInfo)
        {
            //sql- var deleted =  courseDb.Remove(courseInfo);
            //sql- await db.SaveChangesAsync();
            var deleted = await courseDb.DeleteOneAsync(x=>x.CourseId == courseInfo.CourseId);
            return courseInfo;
        }

        public Task<List<Course>> ViewAllCourses()
        {
            //sql- return courseDb.ToListAsync();
            return courseDb.Find(x => true).ToListAsync();
        }


        public async Task<List<Course>> ViewAllCoursesByTechnology(string techid)
        {
            //sql- return await courseDb.Where(x => x.TechId == techid).ToListAsync();
            return await courseDb.Find(x => x.TechId == techid).ToListAsync();
        }
        public async Task<List<Technology>> ViewAllCoursesByTechnologyName(string techname)
        {
            //sql- var tech =  await technologyDb.FirstOrDefaultAsync(x => x.TechName == techname);
            var tech = await technologyDb.Find(x => x.TechName == techname).ToListAsync();
            return tech;
        }

        public async Task<List<Course>> ViewAllCoursesByCourseDuration(string techid,int durationfromrange,int durationtorange)
        {
            //sql-return await courseDb.Where(x => x.CourseDuration>=durationfromrange && x.CourseDuration <= durationtorange && x.TechId== techid).ToListAsync();
            return await courseDb.Find(x => x.CourseDuration >= durationfromrange && x.CourseDuration <= durationtorange && x.TechId == techid).ToListAsync();

        }


        public async Task<List<Course>> ViewAllCoursesByUserid(string userId)
        {
            return await courseDb.Find(x => x.UserId == userId).ToListAsync();
            //sql- return await courseDb.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<List<Course>> ViewAllCoursesByCourseName(string coursename)
        {
            return await courseDb.Find(x => x.CourseName == coursename).ToListAsync();
            //sql- return await courseDb.Where(x => x.CourseId == courseid).ToListAsync();
        }

    }
}
