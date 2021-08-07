using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityEF_DTO;

namespace ActivityEF_DAL
{
    public class Faculty_DAL
    {
		ConnectX connect;

		public Faculty_DAL()
		{

			connect = new ConnectX();
		}
		public List<Faculty_DTO> GetAllFaculties()
		{
			List<Faculty_DTO> lstFaculty = new List<Faculty_DTO>();
			try
			{
				var listOfFacultyFromDb = connect.Faculties.ToList();
				foreach (var item in listOfFacultyFromDb)
				{
					lstFaculty.Add(
					new Faculty_DTO()
					{
						PSNO = item.PSNO,
						EmailId = item.EmailId,
						FacultyName = item.FacultyName

					});
				}
				return lstFaculty;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public List<CourseFacultyMap_DTO> GetFacultyFromCId(string Cid)
		{
			List<CourseFacultyMap_DTO> lstFaculty = new List<CourseFacultyMap_DTO>();
			try
			{
				var lstFromDb = connect.FacultyCourseMappings.Where(x => x.CourseId == Cid);
				foreach (var item in lstFromDb)
				{
					lstFaculty.Add(
						new CourseFacultyMap_DTO
						{
							PSNO = item.PSNO
						});
				}
				return lstFaculty;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}



		public List<CourseFacultyMap_DTO> GetCoursesByFacultyName(string name)
		{
			List<CourseFacultyMap_DTO> courseList = new List<CourseFacultyMap_DTO>();
			try
			{
				var courseListFromDb = connect.FacultyCourseMappings.Join(connect.Faculties, x => x.PSNO, y => y.PSNO, (x, y) => new { fcMap = x, fac = y }).Where(x => x.fac.FacultyName == name).Select(x => new { x.fcMap.CourseId });
				foreach (var item in courseListFromDb)
				{
					courseList.Add(
						new CourseFacultyMap_DTO
						{
							CourseId = item.CourseId
						});
				}
				return courseList;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
	}
}
