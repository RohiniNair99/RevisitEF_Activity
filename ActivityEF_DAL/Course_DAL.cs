using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityEF_DTO;

namespace ActivityEF_DAL
{
    public class Course_DAL
    {
		ConnectX connect;

		public Course_DAL()
		{
			connect = new ConnectX();
		}
		public List<Course_DTO> GetAllCourses()
		{
			List<Course_DTO> lstOfCourse = new List<Course_DTO>();
			try
			{
				var listOfCourseFromDb = connect.Courses.ToList();
				foreach (var item in listOfCourseFromDb)
				{
					lstOfCourse.Add(
					new Course_DTO()
					{
						CourseId = item.CourseId,
						CourseTitle = item.CourseTitle,
						CourseDuration = Convert.ToInt32(item.CourseDuration),
						CourseMode = item.CourseMode
					});
				}
				return lstOfCourse;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
	}
}
